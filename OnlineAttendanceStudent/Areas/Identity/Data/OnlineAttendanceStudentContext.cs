using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineAttendanceStudent.Areas.Identity.Data;

namespace OnlineAttendanceStudent.Areas.Identity.Data;

public class OnlineAttendanceStudentContext : IdentityDbContext<OnlineAttendanceStudentUser>
{
    public OnlineAttendanceStudentContext(DbContextOptions<OnlineAttendanceStudentContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
        builder.ApplyConfiguration(new ApplicationUserEntityConfiguration());
    }
}
public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<OnlineAttendanceStudentUser>
{
    public void Configure(EntityTypeBuilder<OnlineAttendanceStudentUser> builder)
    {
        builder.Property(u => u.FirstName).HasMaxLength(128);
        builder.Property(u => u.LastName).HasMaxLength(128);
        
    }
}
