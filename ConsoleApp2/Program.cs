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

//博士
Doctor doctor = new Doctor();
Console.WriteLine(doctor.Id);  //777000

// FOR DI 參考 :
DoIStudent2(student); // 2
DoIStudent2(student2); //2
DoIStudent2(doctor); // 200000

Console.WriteLine("------------GAME------------");

//GAME DEMO  錯誤示範  只是示範用法
//人類玩家
IBeginer playerHuman = new PlayerHuman();
Console.WriteLine(playerHuman.Skill); //拳頭
ISuperBeginer playerHuman2 = new PlayerHuman();
Console.WriteLine(playerHuman2.Skill); //樹枝
IMasterBeginer playerHuman3 = new PlayerHuman();
Console.WriteLine(playerHuman3.Skill); //光速炮

//皮卡玩家
IBeginer PlayerPika = new PlayerPika();
Console.WriteLine(PlayerPika.Skill); //衝撞
ISuperBeginer PlayerPika2 = new PlayerPika();
Console.WriteLine(PlayerPika2.Skill); //鋼鐵尾巴
IMasterBeginer PlayerPika3 = new PlayerPika();
Console.WriteLine(PlayerPika3.Skill); //十萬伏特

//使用 IStudent2 DI
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

//博士
public class Doctor : IStudent, IStudent2, IStudent3
{
    //明確實作 i 1
    int IStudent.Id { get { return 100000; } set { } }

    //明確實作 i 2
    int IStudent2.Id { get { return 200000; } set { } }

    //不明確實作 i 3

    //不明確實作時為自身屬性
    public int Id { get { return 7770000; } set { } }

    //普通實作
    public string? Name { get; set; }

    //普通實作
    public DateTime Created { get; set; }

}

//人類玩家
public class PlayerHuman : IBeginer, ISuperBeginer, IMasterBeginer
{
    string? IBeginer.Skill { get { return "拳頭"; } set { } }
    string? ISuperBeginer.Skill { get { return "樹枝"; } set { } }
    string? IMasterBeginer.Skill { get { return "光速炮"; } set { } }

    public int Id { get ; set; }
    public string? Name { get; set; }
}

//現代人類  享有所有以前初心者人類所獲得的 SKILL
public class ModernHuman : PlayerHuman
{

}

//皮卡丘玩家
public class PlayerPika : IBeginer, ISuperBeginer, IMasterBeginer
{
    string? IBeginer.Skill { get { return "衝撞"; } set { } }
    string? ISuperBeginer.Skill { get { return "鋼鐵尾巴"; } set { } }
    string? IMasterBeginer.Skill { get { return "十萬伏特"; } set { } }

    public int Id { get; set; }
    public string? Name { get; set; }
}


