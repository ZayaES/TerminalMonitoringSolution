using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TerminalMonitoringSolution.DataAccess;
using TerminalMonitoringSolution.Entities;
using TerminalMonitoringSolution.IRepositories;
using TerminalMonitoringSolution.IServices;
using TerminalMonitoringSolution.Repositories;
using TerminalMonitoringSolution.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
//Console.WriteLine(connectionString);
builder.Services.AddHttpContextAccessor();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.Configure<SmtpDetails>(builder.Configuration.GetSection("SmtpDetails"));


builder.Services.AddDbContext<IdentityUserDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(connectionString);
    options.EnableSensitiveDataLogging();
});

builder.Services.AddIdentity<AdminIdentity, UserIdentityRole>(options =>
{
    options.SignIn.RequireConfirmedAccount = true;
    options.Lockout.AllowedForNewUsers = true;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 5;

    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 7;

    options.User.RequireUniqueEmail = true;
})
    .AddEntityFrameworkStores<IdentityUserDbContext>()
    .AddDefaultTokenProviders()
    .AddSignInManager()
    .AddRoles<UserIdentityRole>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
            ValidAudience = builder.Configuration["JwtSettings:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:Secret"]))
        };
    });

builder.Services.AddAuthorizationBuilder()
    .AddPolicy("RequiresZaya", policy => policy.RequireClaim("Email", "heavenphrince@gmail.com"))
    .AddPolicy("RequiresAdmin", policy => policy.RequireRole("Admin"))
    .AddPolicy("RequiresSuperAdmin", policy => policy.RequireRole("SuperAdmin"));

builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<ITerminalService, TerminalInfoService>();
builder.Services.AddScoped<ITerminalInfoRepo, TerminalInfoRepo>();
builder.Services.AddScoped<ITransactionService, TransactionService>();
builder.Services.AddScoped<ITransactionRepo, TransactionRepo>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<ISerialNumberService, SerialNumberService>();
builder.Services.AddScoped<HttpClient>();
builder.Services.AddScoped<IIPAddressService, IPAddressService>();


builder.Services.AddCors(c => {
    {
        c.AddPolicy("Client Permission", policy =>
        {
            policy.AllowAnyOrigin();
            //policy.WithOrigins("http://localhost:3000");
            policy.AllowAnyMethod();
            policy.AllowAnyHeader();
            //policy.AllowCredentials();
        });
    };
});

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.InjectJavascript("C:\\Users\\OBello6\\source\\repos\\Mine\\TerminalMonitoringSolution\\TerminalMonitoringSolution\\wwwroot\\Scripts\\CustomHeader.js");
    });
}

app.UseCors("Client Permission");

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
