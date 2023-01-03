using Microsoft.EntityFrameworkCore;
using Policy_Management_System_API;
//using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using Policy_Management_System_API.Utilityfunctions;

// using GlobalExceptionHandling.Data;
// using GlobalExceptionHandling.Services;
// using GlobalExceptionHandling.Utility;
var builder = WebApplication.CreateBuilder(args);
// adding serilog
var _logger = new LoggerConfiguration()
  .ReadFrom.Configuration(builder.Configuration)
  .Enrich.FromLogContext()
  .CreateLogger();
builder.Logging.AddSerilog(_logger);
// Add services to the container.

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<Context>(options =>{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});


builder.Services.AddTransient<IPolicyService,PolicyService>();
builder.Services.AddTransient<IPolicyDataAccessLayer,PolicyDataAccessLayer>();
// builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
// {
//     options.RequireHttpsMetadata=false;
//     options.SaveToken=true;
//     options.TokenValidationParameters=new TokenValidationParameters()
//     {
//         ValidateIssuer=true,
//         ValidateAudience=true,
//         ValidAudience= builder.Configuration["Jwt:Audience"],
//         ValidIssuer=builder.Configuration["Jwt:Issuer"],
//         IssuerSigningKey=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
//     };
// }
// );
builder.Services.AddControllersWithViews().AddNewtonsoftJson(options =>
options.SerializerSettings.ReferenceLoopHandling=Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

builder.Services.AddCors((setup) =>

{

    setup.AddPolicy("default", (options) =>

    {

        options.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();

    });

});
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
builder.Services.AddControllers(options => {options.Filters.Add(typeof(CustomExceptionFilter));});
// builder.Services.AddControllers(options => {     options.Filters.Add(typeof(CustomExceptionFilter)); });
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
// app.UseMiddleware(typeof(GlobalErrorHandlingMiddleware));
app.UseCors("default");
app.UseHttpsRedirection();

app.UseAuthorization();


app.MapControllers();

app.Run();
