using Doantotnghiep_62131842.Entity;
using Doantotnghiep_62131842.Repository;
using Doantotnghiep_62131842.Secure.Key;
using Doantotnghiep_62131842.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";


builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:4200",
                                              "http://localhost:4200");
                          policy.AllowAnyHeader();
                          policy.AllowAnyMethod();

                      });
});
//lấy giá trị secretkey
var secretKey = builder.Configuration["AppSettings:SecretKey"];
//chuyển đổi từ string sang mảng byte
//SymmetricSecurityKey, được sử dụng trong JWT,
//yêu cầu secret key ở dạng mảng byte.
var secretKeyBytes = Encoding.UTF8.GetBytes(secretKey);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(opt =>
    {
        opt.TokenValidationParameters = new TokenValidationParameters
        {
            //tự cấp token
            ValidateIssuer = false,
            ValidateAudience = false,
            //ký vào token
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(secretKeyBytes),
            ClockSkew = TimeSpan.Zero,
        };
        opt.Events = new JwtBearerEvents
        {
            OnMessageReceived = context =>
            {
                context.Token = context.Request.Headers["Authorization"].FirstOrDefault()?.Replace("Bearer ", "");
                Console.WriteLine($"Đã Nhận token");
                return Task.CompletedTask;
            }
        };
        opt.Events = new JwtBearerEvents
        {
            OnMessageReceived = context =>
            {
                context.Token = context.Request.Headers["Authorization"].FirstOrDefault()?.Replace("Bearer ", "");
                Console.WriteLine($"Đã Nhận token");
                return Task.CompletedTask;
            }
        };
    });

builder.Services.AddAuthorization();

builder.Services.AddControllers();


var optionsBuilder = new DbContextOptionsBuilder<MamnonProjectContext>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MamnonProjectContext>();
//Services
builder.Services.AddScoped(typeof(IRepository<>), typeof(MyRepository<>));
builder.Services.AddScoped<IChudeService, ChudeService>();
builder.Services.AddScoped<IDanhmonantheongayService, DanhmonantheongayService>();
builder.Services.AddScoped<IDonnhaphocService, DonnhaphocService>();
builder.Services.AddScoped<IDsthucDonService, DsthucDonService>();
builder.Services.AddScoped<IGiaoVienService, GiaoVienService>();
builder.Services.AddScoped<IHoatDongsService, HoatDongsService>();
builder.Services.AddScoped<IHocVienService, HocVienService>();
builder.Services.AddScoped<IImagesTinhtrangsuckhoeService, ImagesTinhtrangsuckhoeService>();
builder.Services.AddScoped<ILoaigiaovienService, LoaigiaovienService>();
builder.Services.AddScoped<ILoailopService, LoailopService>();
builder.Services.AddScoped<ILopService, LopService>();
builder.Services.AddScoped<IPhieubengoanService, PhieubengoanService>();
builder.Services.AddScoped<IPhieudiemdanhService, PhieudiemdanhService>();
builder.Services.AddScoped<IPhuhuynhService, PhuhuynhService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IThoikhoabieuService, ThoikhoabieuService>();
builder.Services.AddScoped<ITiethocService, TiethocService>();
builder.Services.AddScoped<ITinhtrangsuckhoeService, TinhtrangsuckhoeService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ISuckhoedinhkiService, SuckhoedinhkiService>();
builder.Services.AddScoped<IYkienService, YkienService>();
builder.Services.AddScoped<Ichitietgiaovien_lopservice, chitietlop_giaovienservice>();
builder.Services.AddScoped<IHoatdongchinhService, HoatdongchinhService>();
builder.Services.AddScoped<IChiphichinhService, ChiphichinhService>();
builder.Services.AddScoped<IChiphiphuservice, ChiphiphuService>();
builder.Services.AddScoped<IBienlaiService, BienlaiService>();
builder.Services.AddScoped<IBFdatasetService, BFdatasetService>();
builder.Services.AddScoped<ILunchdatasetService, LunchdatasetService>();
builder.Services.AddScoped<IAFnoondatasetService, AFnoondatasetService>();
builder.Services.AddScoped<IDesertdatasetService, DesertdatasetService>();
builder.Services.Configure<AppSetting>(builder.Configuration.GetSection("AppSettings"));
optionsBuilder.EnableSensitiveDataLogging();
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo API", Version = "v1" });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();
app.UseCors(MyAllowSpecificOrigins);

app.MapControllers();

app.Run();
