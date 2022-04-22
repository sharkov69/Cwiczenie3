using Microsoft.AspNetCore.Mvc;
//using System.Text.Json;
using Cwiczenie3.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Cwiczenie3.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentsController : ControllerBase
    {
        private CSV db = new CSV();
        public StudentsController()
        {
            db.Load();
        }
        //private readonly StudentContext _context;
        //public StudentsController(StudentContext context)
        //{
        //    _context = context;
        //}
        ~StudentsController()
        {
            db.Save();
        }
        [HttpGet()]
        //public async Task<ActionResult<IEnumerable<Student>>> GetStudent()
        //    {
        //    return await _context.Students.ToListAsync();
        //    }
        public IEnumerable<Student> GetStudents()
        {

            //for (int i = 0; i < 5; i++)
            //{
            //    Student student = new Student
            //    {
            //        Imie = "a" + i,
            //        Nazwisko = "b" + i,
            //        NumerIndeksu = "c" + i,
            //        DataUrodzenia = "d" + i,
            //        Studia = "e" + i,
            //        Tryb = "f" + i,
            //        Email = "g" + i,
            //        ImieOjca = "h" + i,
            //        ImieMatki = "i" + i
            //    };
            //    db.Add(student);
            //}
            //db.Save();
            return db.Get();
        }
        [HttpGet("{numerIndeksu}")]
        public ActionResult<Student> GetStudent(string numerIndeksu)
        {
            foreach (Student student in db.Get())
            {
                if (student.NumerIndeksu == numerIndeksu)
                {
                    return student;
                }
            }
            return NotFound();
        }
        [HttpPut("{numerIndeksu}")]
        public ActionResult PutStudent(string numerIndeksu, Student s)
        {
            if (numerIndeksu != s.NumerIndeksu)
            {
                return BadRequest();
            }

            try
            {
                //do zrobienia
            }
            catch (Exception)
            {
                if (!StudentExists(numerIndeksu))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
        [HttpPost]
        public ActionResult<Student> PostStudent(Student s)
        {
            db.Add(s);
            db.Save();
            return CreatedAtAction(nameof(GetStudent), new { numerIndeksu = s.NumerIndeksu }, s);
        }
        [HttpDelete("{numerIndeksu}")]
        public ActionResult DeleteStudent(string numerIndeksu)
        {
            foreach (Student student in db.Get())
            {
                if (student.NumerIndeksu == numerIndeksu)
                {
                    db.Delete(numerIndeksu);
                    db.Save();
                    return NoContent();
                }
            }
            return NotFound();
        }
        private bool StudentExists(string numerIndeksu)
        {
            foreach (Student student in db.Get())
            {
                if (student.NumerIndeksu == numerIndeksu)
                {
                    return true;
                }
            }
            return false;
        }
        //public async Task<ActionResult<Student>> GetStudent(string numerIndeksu)
        //{
        //    var student = await _context.Students.FindAsync(numerIndeksu);

        //    if (student == null)
        //    {
        //        return NotFound();
        //    }
        //    return student;
        //}
    }
}
//ConvertFrom-Json(Invoke-WebRequest -Method GET -Uri 'http://localhost:5273/students').Content | ft
//ConvertFrom-Json(Invoke-WebRequest -Method GET -Uri 'http://localhost:5273/Students/c3').Content | ft
//Invoke-WebRequest -Method POST -Uri 'http://localhost:5273/Students' -Body (Select-Object @{n='imie';e={'Jan'}},@{n='nazwisko';e={'Kowalski'}},@{n='numerIndeksu';e={'c69'}},@{n='dataUrodzenia';e={'01011970'}},@{n='studia';e={'test'}},@{n='tryb';e={'albo'}},@{n='email';e={'nie@pl.com'}},@{n='imieOjca';e={'£ukasz'}},@{n='imieMatki';e={'Anna'}} -InputObject '' | ConvertTo-Json) -ContentType 'application/json'

