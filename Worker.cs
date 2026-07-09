using Microsoft.EntityFrameworkCore;
using WebNetCoreEntittyFramework.Entities;

namespace WebNetCoreEntittyFramework
{
    public class Worker : BackgroundService { 
    
        private readonly StudentDbContext _db;

        public Worker(StudentDbContext db)
        {
            _db = db;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            //Create
            /* await InsertStudent(new Student
             {
                 Name = "Sean Sta Ana",
                 Address = "29 r cotas st Calzada Tipas Taguig City",
                 Birthday = new DateTime(2004, 5 ,10)
             }); */

            //Retrieve
            /*var students = await GetStudent();
            foreach (var student in students)
            {
               Console.WriteLine($"{student.Name}, {student.Birthday?.ToString("MM/dd/yyyy")}");
            }
            */

            /* Console.WriteLine("GET BY ID....");
            var studentById = await GetStudentById(1);
            Console.WriteLine(studentById?.Name);
            Console.WriteLine("GET BY NAME.....");
            var studentByName = await GetStudentByName("Sean Sta Ana");
            Console.WriteLine(studentById?.Name); */

            //Update
            /* await UpdateStudentName
             * (2, "Jhonna Robles");*/       

            //Delete
            /* for (int i = 3; i <= 6; i++)
            {
                var student = await GetStudentById(i);

                if (student != null)
                {
                    _db.Students.Remove(student);
                }
            }
              await _db.SaveChangesAsync();
           */

        }





        #region--CRUD OPERATIONS--

        // Retrivals
        private async Task<List<Student>> GetStudent()
        {
            return await _db.Students.ToListAsync();
        }

        private async Task<Student> GetStudentById(int id)
        {
            return await _db.Students.FirstOrDefaultAsync(s => s.Id == id);
        }

        private async Task<Student> GetStudentByName(string name)
        {
            return await _db.Students.FirstOrDefaultAsync(s => s.Name == name);
        }


        private async Task<Student> GetStudentById(string name)
        {
            return await _db.Students
                .Where(s => s.Name == name)
                .FirstOrDefaultAsync();
        }
        
        // Update
        private async Task UpdateStudentName(int id, string name)
        {
            var student = await GetStudentById(id);

            if (student != null)
            {
                student.Name = name;
               await _db.SaveChangesAsync();
            }

        }
        

        // Remove
        private async Task DeleteStudent (int id)
        {
            _db.Students.Remove(await GetStudentById(id));
            await _db.SaveChangesAsync();
        }

        // Insert
        private async Task InsertStudent (Student student)
        {
            Console.WriteLine("INSERT STUDENT CALLED");
            _db.Students.Add(student);
            await _db.SaveChangesAsync();
        }

        #endregion

    }
}
