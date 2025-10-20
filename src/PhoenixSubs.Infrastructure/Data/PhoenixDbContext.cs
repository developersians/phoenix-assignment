using Microsoft.EntityFrameworkCore;
using PhoenixSubs.Domain;

namespace PhoenixSubs.Infrastructure.Data;

public sealed class PhoenixDbContext(DbContextOptions<PhoenixDbContext> options)
    : DbContext(options)
{
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<PlanEntity> Plans { get; set; }
    public DbSet<SubscribedPlanEntity> SubscribedPlans { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<UserEntity>()
            .ToTable("Users");
        modelBuilder
            .Entity<UserEntity>()
            .HasKey(e => e.Id);
        modelBuilder
            .Entity<UserEntity>()
            .Property(e => e.Id)
            .ValueGeneratedNever();
        modelBuilder
            .Entity<UserEntity>()
            .Property(e => e.UserName)
            .IsRequired()
            .HasMaxLength(250);
        modelBuilder
            .Entity<UserEntity>()
            .HasMany(e => e.Plans)
            .WithOne(e => e.User)
            .HasForeignKey(e => e.UserId);

        modelBuilder
            .Entity<PlanEntity>()
            .ToTable("Plans");
        modelBuilder
            .Entity<PlanEntity>()
            .HasKey(e => e.Id);
        modelBuilder
            .Entity<PlanEntity>()
            .Property(e => e.Id)
            .ValueGeneratedNever();
        modelBuilder
            .Entity<PlanEntity>()
            .Property(e => e.Title)
            .HasMaxLength(250);
        modelBuilder
            .Entity<PlanEntity>()
            .Property(e => e.Duration)
            .IsRequired()
            .HasConversion<int>();
        modelBuilder
            .Entity<PlanEntity>()
            .Property(e => e.Group)
            .IsRequired()
            .HasConversion<int>();
        modelBuilder
            .Entity<PlanEntity>()
            .HasIndex(e => new { e.Duration, e.Group })
            .IsUnique();
        modelBuilder
            .Entity<PlanEntity>()
            .HasMany(e => e.Subscriptions)
            .WithOne(e => e.Plan)
            .HasForeignKey(e => e.PlanId);

        modelBuilder
            .Entity<SubscribedPlanEntity>()
            .ToTable("SubscribedPlans");
        modelBuilder
            .Entity<SubscribedPlanEntity>()
            .HasKey(e => e.Id);
        modelBuilder
            .Entity<SubscribedPlanEntity>()
            .Property(e => e.Id)
            .ValueGeneratedNever();
        modelBuilder
            .Entity<SubscribedPlanEntity>()
            .Property(e => e.RegisteredDate)
            .IsRequired();

        base.OnModelCreating(modelBuilder);
    }
}
