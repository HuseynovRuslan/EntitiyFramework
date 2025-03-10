
using Microsoft.EntityFrameworkCore;


Console.WriteLine("Salam");

AcademyDbContext context = new AcademyDbContext();

Student student1 = new Student()
{
    FirstName = "Nazim",
    LastName = "Nazimli",
    Score=7.4f


};

//Student student2 = new Student()
//{
//    FirstName = "Fazil",
//    LastName = "Fazilli",
//    Score = 5.4f


//};

//1-student add etmek 

//context.Students.Add(student1);
//context.Students.Add(student2);

//context.SaveChanges();

// 2 id daxil edirsiz daxil edilen Id oaln elemnt silinsin
//Variant-1

//var element = context.Students.FirstOrDefault(x => x.Id == 1);
//context.Students.Remove(element);
//context.SaveChanges();


//Variant-2

//Student student2 = new Student()
//{
//    Id = 2,

//};
//context.Students.Remove(student2);

//3 - id daxil edib hemen elementi update etmek

//Variant-1

//var element = context.Students.FirstOrDefault(x => x.Id == 1);

//element.FirstName = "Ruslan";
//element.LastName = "Huseynov";
//context.SaveChanges();

////Variant-2
//Student student2 = new Student()
//{
//    Id=2,
//    FirstName = "Orxan",
//    LastName = "Ceferov",
//    Score = 5.4f


//};

//context.Students.Update(student2);

//context.SaveChanges();

//4.İd - ə görə axtarış üçün aşağıdakı kodu əlavə et:



//var student = context.Students.FirstOrDefault(x => x.Id == 1);

//Console.WriteLine(student);




//5 butun studentleri gormek


//Method Syntax
//var datas = await context.Students.ToListAsync();

//foreach (var data in datas)
//{


//    Console.WriteLine(data);
//}

//Query Syntax
var datas = (from data in context.Students
                  select data).ToList();


foreach (var data in datas)
{

    Console.WriteLine(data);
}



public class AcademyDbContext : DbContext
{

    public DbSet<Student>Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=DESKTOP-20QTB3S\\SQLEXPRESS;Initial Catalog=KutuphaneDB;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
    }

}

public class Student
{

    public int Id { get; set; }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public float Score { get; set; }
    public override string ToString()
    {
        return $"Id: {Id}, FirstName: {FirstName}, LastName: {LastName}, Score: {Score}";
    }


}