using CRUD;

public class Program
{
    public static void ShowOptions()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("1- Show All Students");
        Console.WriteLine("2- Get Student By ID");
        Console.WriteLine("3- Update Student");
        Console.WriteLine("4- Delete Student");
        Console.WriteLine("5- Clear Screen");
        Console.WriteLine("6- Exit");
        Console.ForegroundColor = ConsoleColor.White;
        int Option=99;
        try
        {
            Option=int.Parse(Console.ReadLine());
        }
        catch {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Incorrect Option");
            Console.ForegroundColor = ConsoleColor.White;
        }
        
        switch (Option)
        {
            case 1:
                {
                    StudentOperations.Show();
                    ShowOptions();
                    break;
                }
            case 2:
                {
                    Console.WriteLine("Enter Student ID");
                    int Std_Id = int.Parse(Console.ReadLine());
                    StudentOperations.Show(Std_Id);
                    ShowOptions();
                    break;
                }
            case 3:
                {
                    Console.WriteLine("Enter Student ID");
                    int Std_Id = int.Parse(Console.ReadLine());
                    StudentOperations.Update(Std_Id);
                    ShowOptions();
                    break;
                }
            case 4:
                {
                    Console.WriteLine("Enter Student ID");
                    int Std_Id = int.Parse(Console.ReadLine());
                    StudentOperations.Delete(Std_Id);
                    ShowOptions();
                    break;
                }
            case 5:
                {
                    Console.Clear();
                    ShowOptions();
                    break;
                }
            case 99:
                {
                    ShowOptions();
                    break;
                }

        }
    }
    public static void Main()
    {
        ShowOptions();
    }
}