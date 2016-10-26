

namespace Person.DataAccess
{
    using DomainModel;
    using System.Data.Entity;

    public partial class PersonModel : DbContext
    {
        public PersonModel()
            : base("name=PersonModel")
        {
        }

        public virtual DbSet<Anstalld> Anstalld { get; set; }
        public virtual DbSet<Kurs> Kurs { get; set; }
        public virtual DbSet<Kursanmalan> Kursanmalan { get; set; }
        public virtual DbSet<Kurstillfalle> Kurstillfalle { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Anstalld>()
                .Property(e => e.Fornamn)
                .IsFixedLength();

            modelBuilder.Entity<Anstalld>()
                .Property(e => e.Efternamn)
                .IsFixedLength();

            modelBuilder.Entity<Anstalld>()
                .Property(e => e.Personnummer)
                .IsFixedLength();

            modelBuilder.Entity<Anstalld>()
                .HasMany(e => e.Kursanmalan)
                .WithRequired(e => e.Anstalld)
                .HasForeignKey(e => e.Anstalld_FK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Kurs>()
                .Property(e => e.Namn)
                .IsFixedLength();

            modelBuilder.Entity<Kurs>()
                .HasMany(e => e.Kurstillfalle)
                .WithRequired(e => e.Kurs)
                .HasForeignKey(e => e.Kurs_FK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Kursanmalan>()
                .Property(e => e.SkapadAv)
                .IsFixedLength();
        }
    }
}
