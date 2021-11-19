//普通實作
Student student = new Student();
Console.WriteLine(student.Id);  // 777

//明確實作會被繼承，且不會被自身實作影響，但可以透過明確實作修改值
IStudent student1 = new Student();
Console.WriteLine(student1.Id); // 1

//明確實作會被繼承，且不會被自身實作影響，但可以透過明確實作修改值
IStudent2 student2 = new Student();
Console.WriteLine(student2.Id); // 2

//!!! 沒有明確實作實  優先取用自身實作實作  
IStudent3 student3 = new Student();
Console.WriteLine(student3.Id);  // 777

// FOR DI 參考 :
DoIStudent2(student); //2
DoIStudent2(student2); //2

void DoIStudent2(IStudent2 student)
{
    Console.WriteLine($"{student.Id}"); 
}

/// <summary>
///  學生  繼承123
/// </summary>
public class Student : IStudent, IStudent2 , IStudent3
{
    //明確實作 i 1
    int IStudent.Id { get { return 1; } set { } }

    //明確實作 i 2
    int IStudent2.Id { get { return 2; } set { } }

    //不明確實作 i 3

    //不明確實作時為自身屬性
    public int Id { get { return 777; } set { } }

    //普通實作
    public string? Name { get; set; }

    //普通實作
    public DateTime Created { get; set; }

}

