using CLOUD.Auth;
using Microsoft.EntityFrameworkCore;

namespace CLOUD.DataBase;

// DbContext => reprezentarea bazei de date
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {}

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<User>().HasIndex(u => u.Username).IsUnique();
    }
    public DbSet<User> Users { get; set; }
    public DbSet<Pacient> Pacienti { get; set; }
    public DbSet<Judet> Judete { get; set; }
    public DbSet<DateMedicale> DateMedicale { get; set; }
    public DbSet<MedicPacienti> MedicPacienti { get; set; }
    public DbSet<Medic> Medici { get; set; }
    public DbSet<ECG> Ecg { get; set; }
    public DbSet<Umiditate> Umiditate { get; set; }
    public DbSet<Temperatura> Temperatura { get; set; }
    public DbSet<Puls> Puls { get; set; }
    public DbSet<ValoriNormaleSenzori> ValoriNormaleSenzori { get; set; }
}
