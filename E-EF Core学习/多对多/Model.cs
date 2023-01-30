namespace P.Models;
public class Teacher
{
    public int Id { get; set; }
    public string Name { get; set; }

    // 一个老师可以上多门课
    public ICollection<CourseTeacher> Courses { get; set; }
}
public class Course
{
    public int Id { get; set; }
    public string Name { get; set; }

    // 一门课可以由多名老师教
    public ICollection<CourseTeacher> Teachers { get; set; }
}
// 多对多要增加一个实体, 并且在OnModelCreating编辑
public class CourseTeacher
{
    public int TeacherId { get; set; }
    public Teacher Teacher { get; set; }
    public int CourseId { get; set; }
    public Course Course { get; set; }
}