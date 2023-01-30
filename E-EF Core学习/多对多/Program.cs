// See https://aka.ms/new-console-template for more information
using P.Models;

DataContext data = new();
Teacher t1 = new() { Name = "Teacher1" };
Teacher t2 = new() { Name = "Teacher2" };
Course c1 = new() { Name = "Course1" };
Course c2 = new() { Name = "Course2" };

var a = data.Set<Teacher>().ToList();
foreach (var t in a)
{
    System.Console.WriteLine(t.Id);
}
// data.Teachers.Add(t1);
// data.Courses.Add(c1);
// data.SaveChanges();
var teacher = data.Teachers.FirstOrDefault();
var course = data.Courses.FirstOrDefault();
// CourseTeacher ct = new()
// {
//     CourseId = course.Id,
//     // Course = c1,
//     TeacherId = teacher.Id
//     // Teacher = teacher
// };
// data.CourseTeachers.Add(ct);
data.SaveChanges();
System.Console.WriteLine("Hello!");