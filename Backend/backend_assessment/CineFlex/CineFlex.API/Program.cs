using CineFlex.Application;
using CineFlex.Domain;
using CineFlex.Persistence;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.ConfigureApplicationServices();
builder.Services.ConfigurePersistenceServices(builder.Configuration);
builder.Services.AddHttpContextAccessor();
AddSwaggerDoc(builder.Services);
builder.Services.AddControllers();

// builder.Services.AddIdentity<User, IdentityRole>(options =>
//     {
//         options.User.RequireUniqueEmail = true;
//         options.SignIn.RequireConfirmedAccount = false;
//     })
//     .AddEntityFrameworkStores<CineFlexDbContex>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(o =>
{
    o.AddPolicy("CorsPolicy",
        builder => builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());
});

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}


app.UseCors("CorsPolicy");
app.UseAuthentication();
app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CineFlex.Api v1"));
app.UseHttpsRedirection();

app.UseAuthorization();


app.MapControllers();

app.Run();

void AddSwaggerDoc(IServiceCollection services)
{
    services.AddSwaggerGen(c =>
    {


        c.SwaggerDoc("v1", new OpenApiInfo
        {
            Version = "v1",
            Title = "CineFlex Api",

        });

    });
}