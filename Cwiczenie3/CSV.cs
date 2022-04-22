using System.Globalization;
using CsvHelper;
using Cwiczenie3.Models;
namespace Cwiczenie3
{
    public class CSV
    {
        public List<Student> students;
        public CSV()
        {
            students = new List<Student>();
        }
        public void Load()
        {
            using var streamReader = File.OpenText("db.csv");
            using var csvReader = new CsvReader(streamReader, CultureInfo.CurrentCulture);
            students = csvReader.GetRecords<Student>().ToList();
        }
        public void Save()
        {
            using var writer = new StreamWriter("db.csv");
            using var csvWriter = new CsvWriter(writer, CultureInfo.CurrentCulture);

            csvWriter.WriteHeader<Student>();
            csvWriter.NextRecord(); // adds new line after header
            csvWriter.WriteRecords(students);
        }
        public void Add(Student s)
        {
            students.Add(s);
        }
        public List<Student> Get()
        {
            return students;
        }
        public void Delete(string numerIndeksu)
        {
            foreach (Student student in students)
            {
                if (student.NumerIndeksu == numerIndeksu)
                {
                    students.Remove(student);
                    break;
                }
            }
        }
    }
}
