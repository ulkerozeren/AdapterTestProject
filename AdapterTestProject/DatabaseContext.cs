using AdapterTestProject.Models;
using Microsoft.EntityFrameworkCore;

namespace AdapterTestProject
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            //DB BAĞLANTISI VB DATABASE INSTANCE'INI İLGİLENDİREN İNCE AYARLAR
            //dbContextOptionsBuilder.UseSqlServer("Server=127.0.0.1;Database=ECommerce;User Id=sa;Password=123;");
            dbContextOptionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=School;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //DATABASE ŞEMASI UYGULANIRKEN KULLANILACAK KURAL SETLERİ

        }

        public DbSet<Student> Students { get; set; }

    }
}