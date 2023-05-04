namespace BlogApp.Identity;

public class IdentityServiceRegistration
{
    public static IServiceCollection ConfigureIdentityServices(this IServiceCollection services,
                                                                  IConfiguration configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));
        services.AddDbContext<BlogAppIdentityDbContext>(options =>
        options.UseNpgsql(
            configuration.GetConnectionString("BlogIdentityConnectionString"),
        options => options.MigrationsAssembly(typeof(BlogAppIdentityDbContext).Assembly.FullName)));

        services.AddIdentity<BlogUser, IdentityRole>()
        .AddEntityFrameworkStores<BlogAppIdentityDbContext>()
        .AddDefaultTokenProviders();

        services.AddTransient<IAuthService, AuthService>();
        services.Configure<DataProtectionTokenProviderOptions>(opt =>
                        opt.TokenLifespan = TimeSpan.FromHours(2));

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero,
                ValidIssuer = configuration["JwtSettings:Issuer"],
                ValidAudience = configuration["JwtSettings:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"]))
            };
        });
        return services;
    }
}
