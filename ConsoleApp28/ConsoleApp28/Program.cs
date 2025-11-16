using System.Runtime.CompilerServices;
using System.Xml.Linq;

class Student // CLASS !!!
{
    private string lastName = "Stashko";
    private string name = "Nikita";
    private string patronymic = "Sehrijovich";
    private int dateOfBirth = 28092010;
    private string homeAddress = "Sadovaja 3";
    private long phoneNumber = 380123456789;
    private int[] credits;
    private int[] coursework;
    private int[] exams;

    public Student(int creditsCount = 3, int courseworkCount = 3, int examsCount = 3)
    {
        credits = new int[creditsCount];
        coursework = new int[courseworkCount];
        exams = new int[examsCount];
    }
    public void SetCredits(int[] credits)
    {
        this.credits = credits;
    }
    public int[] GetCredits()
    {
        return credits;
    }

    public void SetCoursework(int[] coursework)
    {
        this.coursework = coursework;
    }
    public int[] GetCoursework()
    {
        return coursework;
    }

    public void SetExams(int[] exams)
    {
        this.exams = exams;
    }
    public int[] GetExams()
    {
        return exams;
    }



    public string Name
    {
        get { return name; }
        set { name = value; }
    }


    public string LastName
    {
        get { return lastName; }
        set { lastName = value; }
    }

    public void SetPatronymic(string patronymic)
    {
        this.patronymic = patronymic;
    }
    public string GetPatronymic()
    {
        return patronymic;
    }

    public int DateOfBirth
    {
        get { return dateOfBirth; }
        set { dateOfBirth = value; }
    }

    public void SetHomeAddress(string homeAddress)
    {
        this.homeAddress = homeAddress;
    }
    public string GetHomeAddress()
    {
        return homeAddress;
    }

    public void SetPhoneNumber(long phoneNumber)
    {
        this.phoneNumber = phoneNumber;
    }
    public long GetPhoneNumber()
    {
        return phoneNumber;
    }
    public static void Print(in Student student)
    {

        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine(student.Name);
        Console.WriteLine(student.LastName);
        Console.WriteLine(student.GetPatronymic());
        Console.WriteLine(student.DateOfBirth);
        Console.WriteLine(student.GetHomeAddress());
        Console.WriteLine(student.GetPhoneNumber());

        Console.WriteLine("\nЗаліки:");
        foreach (int mark in student.GetCredits())
            Console.Write(mark + " ");

        Console.WriteLine("\nКурсові:");
        foreach (int mark in student.GetCoursework())
            Console.Write(mark + " ");

        Console.WriteLine("\nЕкзамени:");
        foreach (int mark in student.GetExams())
            Console.Write(mark + " ");



    }

}



class Group
{
    private List<Student> students;
    private string groupName;
    private string specialization;
    private int courseNumber;


    public Student this[int index]
    {
        get
        {
            if (index >= 0 && index < students.Count)
                return students[index];
            return null;
        }
    }


    public Group()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        groupName = "Невідома група";
        specialization = "Невідома спеціалізація";
        courseNumber = 1;
        students = new List<Student>();
    }


    public Group(List<Student> existingStudents)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        groupName = "Група на основі списку";
        specialization = "Не вказано";
        courseNumber = 1;
        students = new List<Student>(existingStudents);
    }


    public Group(Group other)
    {
        groupName = other.groupName;
        specialization = other.specialization;
        courseNumber = other.courseNumber;
        students = new List<Student>(other.students);
    }
    public int Count
    {
        get { return students.Count; }
    }
    public void SetName(string groupName)
    {
        this.groupName = groupName;
    }

    public string Specialization
    {
        get { return specialization; }
        set { specialization = value; }
    }

    public int CourseNumber
    {
        get { return courseNumber; }
        set { courseNumber = value; }
    }

    public void AddStudent(Student s)
    {
        students.Add(s);
    }


    public void TransferStudent(Group toGroup, Student student)
    {
        if (students.Contains(student))
        {
            students.Remove(student);
            toGroup.AddStudent(student);
        }
    }

    public void ShowAllStudents()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.WriteLine($"\nГрупа: {groupName}");
        Console.WriteLine($"Спеціалізація: {specialization}");
        Console.WriteLine($"Курс: {courseNumber}\n");

        Console.WriteLine("Студенти групи:");
        foreach (Student st in students)
        {
            Console.WriteLine($"{st.LastName} {st.Name}");
        }

        Console.WriteLine();
    }

}

class Program
{
    static void Main()
    {
        Student s1 = new Student();
        s1.Name = "Nikita";
        s1.LastName = "Stashko";

        Student s2 = new Student();
        s2.Name = "Ivan";
        s2.LastName = "Petrenko";


        Group g1 = new Group();
        g1.SetName("KP-12");
        g1.Specialization = "Комп'ютерні науки";
        g1.CourseNumber = 1;

        g1.AddStudent(s1);
        g1.AddStudent(s2);

        Console.WriteLine("Група 1:");
        g1.ShowAllStudents();


        Group g2 = new Group();
        g2.SetName("KP-13");
        g2.Specialization = "Інженерія ПЗ";
        g2.CourseNumber = 1;

        g1.TransferStudent(g2, s2);

        Console.WriteLine("Після переведення:\n");

        Console.WriteLine("Група 1:");
        g1.ShowAllStudents();

        Console.WriteLine("Група 2:");
        g2.ShowAllStudents();

        g1.AddStudent(s1);

        Console.WriteLine(g1[0].Name);        
        Console.WriteLine(g1.Count);          
    }
}