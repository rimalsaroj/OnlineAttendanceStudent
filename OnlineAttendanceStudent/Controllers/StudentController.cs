using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineAttendanceStudent.Data;
using OnlineAttendanceStudent.Models;
using OnlineAttendanceStudent.Models.Domain;

namespace OnlineAttendanceStudent.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentDbContext studentDbContext;

        public StudentController(StudentDbContext studentDbContext)
        {
            this.studentDbContext = studentDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var students = await studentDbContext.Students.ToListAsync();
                return View(students); 
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddStudents addStudentRequest)
        {
            var student = new Student()
            {
                Id = Guid.NewGuid(),
                Name = addStudentRequest.Name,
                Email = addStudentRequest.Email,
                Department = addStudentRequest.Department
            };
           await studentDbContext.Students.AddAsync(student);
           await studentDbContext.SaveChangesAsync();
            return RedirectToAction("Add");

        }

            [HttpGet]
            public async Task<IActionResult> View(Guid id)
            {
                var student = await studentDbContext.Students.FirstOrDefaultAsync(x => x.Id == id);
                if (student != null)
                {
                    var viewModel = new UpdateViewModel()
                    {
                        Id = student.Id,
                        Name = student.Name,
                        Email = student.Email,
                        Department= student.Department
                        
                    };
                return await Task.Run(() => View("View", viewModel));

            };

                return RedirectToAction("Index");
            }
        [HttpPost]
        public async Task<IActionResult> View(UpdateViewModel model)
        {
            var student = await studentDbContext.Students.FindAsync(model.Id);
            if (student != null)
            {
                student.Name = model.Name;
                student.Email = model.Email;
                student.Department = model.Department;
                

                await studentDbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(UpdateViewModel model)
        {
            var job = await studentDbContext.Students.FindAsync(model.Id);
            if (job != null)
            {
                studentDbContext.Students.Remove(job);
                await studentDbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

    }
    }
