namespace BlogApp.Identity.Configurations;

public class UserConfiguration
{
    public void Configure(EntityTypeBuilder<BlogUser> builder)
    {
        var hasher = new PasswordHasher<BlogUser>();
        builder.HasData(
            new BlogUser
            {
                Id = "4000b844-74ca-479b-badb-4f41850ae07e",
                Email = "Admin@HR.com",
                NormalizedEmail = "ADMIN@HR.COM",
                UserName = "Admin@HR.com",
                NormalizedUserName = "ADMIN@HR.COM",
                PasswordHash = hasher.HashPassword(null, "P@ssword1"),
                EmailConfirmed = false
            },

            new BlogUser
            {
                Id = "efa06a55-d0cc-4e01-abbf-870f21d91441",
                Email = "User@HR.com",
                NormalizedEmail = "USER@HR.COM",
                UserName = "User@HR.com",
                NormalizedUserName = "USER@HR.COM",
                PasswordHash = hasher.HashPassword(null, "P@ssword2"),
                EmailConfirmed = false
            }
        );
    }
}
