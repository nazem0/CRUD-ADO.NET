using Microsoft.Data.SqlClient;
using System.Data;
using System.Security.Cryptography;

namespace CRUD
{
    public class StudentOperations
    {
        static SqlConnection Conn = SQL.Conn;
        static SqlCommand Sql = SQL.Sql;

        public static bool Insert()
        {
            Console.WriteLine("Enter Student Data ID, First Name, Last Name --Hardcoded for now");
            int StudentID = int.Parse(Console.ReadLine());
            string StudentFname = Console.ReadLine();
            string StudentLname = Console.ReadLine();

            Conn.Open();
            Sql.CommandType = CommandType.Text;
            Sql.CommandText = $"INSERT INTO Student (St_Id,St_Fname,St_Lname) VALUES ({StudentID} , '{StudentFname}' , '{StudentLname}')";
            try
            {
                Sql.ExecuteNonQuery();
            }
            catch
            {
                Conn.Close();
                Console.WriteLine(Conn.State);
                Console.WriteLine("Insertion Failed");
                return false;
            }
            Conn.Close();
            Console.WriteLine(Conn.State);
            return true;
        }
        public static void Show()
        {
            
            Conn.Open();
            Sql.CommandType = CommandType.Text;
            Sql.CommandText = $"SELECT * FROM Student";
            SqlDataReader reader = Sql.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    //Temporarily Using Student Enum :v
                    Console.WriteLine($"ID => {reader[(int)Student.St_Id]}, " +
                        $"Student Name => {reader[(int)Student.St_Fname]} {reader[(int)Student.St_Lname]}");
                }
            }
            else
            {
                Console.WriteLine("No rows found.");
            }
            Conn.Close();
            Console.WriteLine(Conn.State);

        }
        public static void Show(int _ID)
        {
            Conn.Open();
            Sql.CommandType = CommandType.Text;
            Sql.CommandText = $"SELECT * FROM Student WHERE St_Id = {_ID}";
            SqlDataReader reader = Sql.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Console.WriteLine($"ID => {reader[(int)Student.St_Id]}, " +
                        $"Student Name => {reader[(int)Student.St_Fname]} {reader[(int)Student.St_Lname]}");

                }
            }
            else
            {
                Console.WriteLine("No rows found.");
            }
            Conn.Close();
            Console.WriteLine(Conn.State);

        }
        public static bool Update(int _ID)
        {
            Console.WriteLine("Enter Student Data ID, First Name, Last Name --Hardcoded for now");
            int StudentID = int.Parse(Console.ReadLine());
            string StudentFname = Console.ReadLine();
            string StudentLname = Console.ReadLine();

            Conn.Open();
            Sql.CommandType = CommandType.Text;
            Sql.CommandText = $"UPDATE Student SET St_Id = {StudentID}, St_Fname = '{StudentFname}', St_Lname = '{StudentLname}' WHERE St_Id = {_ID}";
            try
            {
                Sql.ExecuteNonQuery();
            }
            catch
            {
                Conn.Close();
                Console.WriteLine(Conn.State);
                Console.WriteLine("Update Failed");
                return false;
            }
            Conn.Close();
            Console.WriteLine(Conn.State);
            return true;
        }

        public static void Delete(int _ID)
        {
            Conn.Open();
            Sql.CommandType = CommandType.Text;
            Sql.CommandText = $"DELETE FROM Student WHERE St_Id = {_ID}";
            Sql.ExecuteNonQuery();
            Conn.Close();
            Console.WriteLine(Conn.State);
        }

    }
}
