//using Microsoft.EntityFrameworkCore;
//using CsvHelper;
//using System.Globalization;

//namespace Cwiczenie3.Models
//{
//    public class StudentContext : DbContext
//    {
//        public List<Student> students;
//        public StudentContext(DbContextOptions<StudentContext> options)
//            : base(options) 
//        {
//            students = new List<Student>();
//        }
//        public DbSet<Student> Students { get; set; }
//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            base.OnModelCreating(modelBuilder);
//            using var streamReader = File.OpenText("db.csv");
//            using var csvReader = new CsvReader(streamReader, CultureInfo.CurrentCulture);
//            students = csvReader.GetRecords<Student>().ToList();


//            foreach (var student in students)
//            {
//                modelBuilder.Entity<Student>().HasData(student);
//            }

//        }
//    }
//}
