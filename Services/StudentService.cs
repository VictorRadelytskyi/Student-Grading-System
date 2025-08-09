using System.Reflection;

namespace StudentGradingSystem.Services;

public class StudentService
{
    private readonly StudentDbContext _context;
    public StudentService(StudentDbContext context)
    {
        _context = context;
    }

    private List<Student> students = new List<Student>
    {
        new Student { Name = "Alice", Grade = 85 },
        new Student { Name = "Bob", Grade = 90 },
        new Student { Name = "Charlie", Grade = 75 },
        new Student { Name = "David", Grade = 88 },
        new Student { Name = "Emma", Grade = 92 },
        new Student { Name = "Frank", Grade = 79 },
        new Student { Name = "Grace", Grade = 95 },
        new Student { Name = "Hannah", Grade = 67 },
        new Student { Name = "Ian", Grade = 82 },
        new Student { Name = "Jack", Grade = 74 },
        new Student { Name = "Kate", Grade = 89 },
        new Student { Name = "Leo", Grade = 91 },
        new Student { Name = "Mia", Grade = 77 },
        new Student { Name = "Noah", Grade = 85 },
        new Student { Name = "Olivia", Grade = 93 }
    };

    public List<Student> GetStudents() => students;
    public double GetAverageGrade() => Math.Round(students.Average(s => s.Grade), 2);
    public List<Student> GetTopStudents(int threshold) => students.Where(s => s.Grade > threshold).ToList();
    public bool AddStudent(string name, int grade)
    {
        if (string.IsNullOrWhiteSpace(name) || grade < 0 || grade > 100)
        {
            return false;
        }

        students.Add(new Student { Name = name, Grade = grade });
        return true;
    }
    public void RemoveStudent(string name)
    {
        var studentToRemove = students.FirstOrDefault(s => s.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        if (studentToRemove != null)
        {
            students.Remove(studentToRemove);
        }
    }

    public List<Student> GetStudentSortedByGrade(bool descending = false)
    {
        return descending ? students.OrderByDescending(s => s.Grade).ToList() : students.OrderBy(s => s.Grade).ToList();
    }

    public List<Student> GetStudentsSorted(string sortBy, bool descending = false)
    {
        return sortBy.ToLower() switch
        {
            "name" => descending ? students.OrderByDescending(s => s.Name).ToList() : students.OrderBy(s => s.Name).ToList(),
            "grade" => descending ? students.OrderByDescending(s => s.Grade).ToList() : students.OrderBy(s => s.Grade).ToList(),
            _ => students
        };
    }

    public List<Student> SearchStudents(string name)
    {
        return students.Where(s => s.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();
    }

    public void PrintStudentProperties()
    {
        Type studentType = typeof(Student);
        PropertyInfo[] properties = studentType.GetProperties();

        Console.WriteLine("Student Properties:");
        foreach (var prop in properties)
        {
            Console.WriteLine(prop.Name);
        }
    }
}
