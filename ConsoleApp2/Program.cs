//蔡昀翰整理
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

//MSDN 說明 :
//如果沒有強力的理由，要避免明確實作介面成員。 
//瞭解明確實作需要有進階級的專業知識。 例如，許多開發人員並不知道明確實作的成員是可以公開呼叫的。
//如果成員只要透過介面來呼叫，請考慮明確實作介面成員。
//使用時機例如 :  序列化、系結資料

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

