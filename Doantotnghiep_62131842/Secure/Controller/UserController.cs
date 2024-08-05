using Doantotnghiep_62131842.Entity;
using Doantotnghiep_62131842.Secure.Key;
using Doantotnghiep_62131842.Secure.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net.NetworkInformation;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using RouteAttribute = Microsoft.AspNetCore.Components.RouteAttribute;

namespace Doantotnghiep_62131842.Secure.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly MamnonProjectContext context_;
        private readonly AppSetting appSettings_;
        public UserController(MamnonProjectContext context, IOptionsMonitor<AppSetting> optionsMonitor)
        {
            context_ = context;
            appSettings_ = optionsMonitor.CurrentValue;
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Validate([FromBody] LoginModels model)
        {
            //kiểm tra có tài khoản trong dbAccount có trùng vs acc 
            //mà người dùng nhập hay không
            var account = context_.Users.SingleOrDefault(p => p.Mail == model.Email
            && p.Password == model.Password);
            if (account == null)
            {
                return Ok(new ApiResponse
                {
                    Success = false,
                    Message = "Invalid username/password"
                });
            }
            //cấp token
            var token = await GeneratedToken(account);
            return Ok(new ApiResponse
            {
                Success = true,
                Message = "Authenticate success",
                Data = token
            });
        }

        //GeneratedToken tạo ra 1 cặp token(access và refresh)
        private async Task<TokenModels> GeneratedToken(User account)
        {
            // Khởi tạo đối tượng JwtSecurityTokenHandler để tạo và xử lý JWT
            var jWtTokenHandler = new JwtSecurityTokenHandler();
            // Chuyển đổi chuỗi SecretKey từ cài đặt thành mảng byte
        
            // Chuyển đổi chuỗi SecretKey từ cài đặt thành mảng byte
            var secretkeyBytes = Encoding.UTF8.GetBytes(appSettings_.SecretKey);

            // Lấy giá trị cho MaPhuhuynh và MaGiaovien dựa trên điều kiện Magiaovien
            string? maPhuhuynh = account.Magiaovien == null ? account.ParentResumeId.ToString() : string.Empty;
            string? maGiaovien = account.Magiaovien == null ? string.Empty : account.Magiaovien.ToString();

            // Mô tả thông tin về token
            var tokenDescription = new SecurityTokenDescriptor
            {
                // Subject chứa danh sách các Claims (khẳng định) về người dùng
                Subject = new ClaimsIdentity(new[]
                {
            // Thêm claim "UserName" với giá trị là tên người dùng từ đối tượng Account
            new Claim("UserId", account.UserId),
            // Thêm claim Email
            new Claim(JwtRegisteredClaimNames.Email, account.Mail),
            // Jti được set bằng Guid để xác định token là duy nhất
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim("Role", account.RoleId),
            new Claim("ParentResumeId", maPhuhuynh),
            new Claim("MaGiaovien", maGiaovien),

            // Thêm claim Role
            new Claim(ClaimTypes.Role, account.RoleId),
        }),
                // Token sẽ hết hạn sau một khoảng thời gian 
                Expires = DateTime.UtcNow.AddMinutes(20),
                // Đặt thuật toán và khóa để ký và xác thực token
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretkeyBytes), SecurityAlgorithms.HmacSha256Signature)
            };

            // Tạo token dựa trên mô tả của tokenDescription
            var token = jWtTokenHandler.CreateToken(tokenDescription);
            // Viết var token thành một chuỗi token
            var accessToken = jWtTokenHandler.WriteToken(token);
            // Tạo refresh token
            var refreshToken = GenerateRefreshToken();
            // Tạo data token để thêm vào database
            var refreshTokenEntity = new RefreshToken
            {
                Id = Guid.NewGuid(),
                JwtId = token.Id,
                Token = refreshToken,
                IsUsed = false,
                IsRevoked = false,
                IssuedAt = DateTime.UtcNow,
                ExpireAt = DateTime.UtcNow.AddHours(1),
                NguoidungUsername = account.UserId,
            };

            await context_.AddAsync(refreshTokenEntity);
            await context_.SaveChangesAsync();

            return new TokenModels
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken,
            };
        }

        //hàm tạo refreshToken
        private string GenerateRefreshToken()
        {
            var random = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(random);
                return Convert.ToBase64String(random);
            }
        }

        [HttpPost("RenewToken")]
        public async Task<IActionResult> RenewToken(TokenModels tokenModels)
        {
            // Khởi tạo đối tượng JwtSecurityTokenHandler để tạo và xử lý JWT
            var jWtTokenHandler = new JwtSecurityTokenHandler();
            // Chuyển đổi chuỗi SecretKey từ cài đặt thành mảng byte
            var secretkeyBytes = Encoding.UTF8.GetBytes(appSettings_.SecretKey);
            var tokenValidateparam = new TokenValidationParameters
            {
                //tự cấp token
                ValidateIssuer = false,
                ValidateAudience = false,
                //ký vào token
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(secretkeyBytes),
                ClockSkew = TimeSpan.Zero,
                ValidateLifetime = false, //không kiểm tra token hết hạn
            };
            try
            {
                //check 1: AccessToken valid format
                var tokenInverification = jWtTokenHandler.ValidateToken(tokenModels.AccessToken,
                    tokenValidateparam, out var validatedToken);
                //check 2: check thuật toán
                if (validatedToken is JwtSecurityToken jwtSecurityToken)
                {
                    var result = jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256,
                        StringComparison.InvariantCultureIgnoreCase);
                    if (!result)
                    {
                        return Ok(new ApiResponse
                        {
                            Success = false,
                            Message = "Invalid Token"
                        });
                    }
                }
                //check 3: Check access token expire?
                var utcExpireDate = long.Parse(tokenInverification.Claims
                    .FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Exp).Value);

                var expireDate = ConvertUnitTimeToDateTime(utcExpireDate);
                if (expireDate > DateTime.UtcNow)
                {
                    return Ok(new ApiResponse
                    {
                        Success = false,
                        Message = "Accses token has not yet expired"
                    });
                }
                // check 4: check refreshtoken exits in DB
                var storedToken = context_.RefreshTokens
                    .FirstOrDefault(x => x.Token == tokenModels.RefreshToken);
                if (storedToken == null)
                {
                    return Ok(new ApiResponse
                    {
                        Success = false,
                        Message = "Refresh token does not exist"
                    });
                }
                // check 5 : check refreshToken is used/revoked?
                if (storedToken.IsUsed)
                {
                    return Ok(new ApiResponse
                    {
                        Success = false,
                        Message = "Refresh token has been used"
                    });
                }
                //check bị thu hồi chưa
                if (storedToken.IsRevoked)
                {
                    return Ok(new ApiResponse
                    {
                        Success = false,
                        Message = "Refresh token has been revoked"
                    });
                }
                // check 6: Access token id == Jwt in RefreshToken
                var jti = tokenInverification.Claims
                    .FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Jti).Value;
                if (storedToken.JwtId != jti)
                {
                    return Ok(new ApiResponse
                    {
                        Success = false,
                        Message = "Token doesn't not match"
                    });
                }
                //--------------------------------------
                //update Token is used
                storedToken.IsUsed = true;
                storedToken.IsRevoked = true;
                context_.Update(storedToken);
                await context_.SaveChangesAsync();
                //create new token
                var user = await context_.Users.SingleOrDefaultAsync(a => a.UserId == storedToken.NguoidungUsername);
                var token = await GeneratedToken(user);
                return Ok(new ApiResponse
                {
                    Success = true,
                    Message = "renew token success"

                });
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse
                {
                    Success = false,
                    Message = "Something went wrong"
                });
            }
        }

        private DateTime ConvertUnitTimeToDateTime(long utcExpireDate)
        {
            DateTime datetimeInterval = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            // Thêm số giây từ Unix timestamp
            return datetimeInterval.AddSeconds(utcExpireDate).ToUniversalTime();
        }
    }
}
