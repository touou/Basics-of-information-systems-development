using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using databasePrac.DataBase;

namespace databasePrac
{
    class Program
    {
        private static UserAccount<string> FillingForInsert()
        {
            var name = Console.ReadLine();
            var surname = Console.ReadLine();
            var car = Console.ReadLine();
            return new UserAccount<string>(name, surname, car);
        }

        
        static void DBWorker()
        {
            Console.WriteLine("Press following numbers for commands:\n1-Insert\n2-Update\n3-Delete\n4-...");
            
            var switcher = Convert.ToInt32(Console.ReadLine());
            var newUser = new UserAccount<object>();
            while (true)
            {
                switch (switcher)
                {
                    
                    case 1:// insert in db
                        
                        var user = FillingForInsert();
                        UserAccountMethod.Insert(user);
                        break;
                    case 2:// update in db

                        var fieldToSet = Console.ReadLine();
                        var valueToSet = Console.ReadLine();
                        var fieldWhereSet = Console.ReadLine();
                        var valueWhereSet = Console.ReadLine();
                        UserAccountMethod.Update(fieldToSet,valueToSet,fieldWhereSet,valueWhereSet);
                        break;
                    case 3://delete from db
                        
                        var fieldWhereDelete = Console.ReadLine();
                        var valueForDelete = Console.ReadLine();
                        UserAccountMethod.Delete(fieldWhereDelete,valueForDelete);
                        break;
                    case 4: //find by id
                        Console.Write("enter an users id: " );
                        var a=int.Parse(Console.ReadLine());
                        newUser=UserAccountMethod.FindById(a);
                        Console.WriteLine($"Name:{newUser.Name} Surname:{newUser.Surname} Car:{newUser.Car}");
                        break;
                    case 5: //find by car
                        Console.Write("enter a Car for find Users");
                        var nameOfCar = Console.ReadLine();
                        newUser = UserAccountMethod.FindByCar(nameOfCar);
                        Console.WriteLine($"Name:{newUser.Name} Surname:{newUser.Surname} Car:{newUser.Car}");
                        break;
                    default:
                        
                        throw new ArgumentException("This command doesn't exists");
                }

                switcher = int.Parse(Console.ReadLine());
                if (switcher < 1 || switcher > 10)
                {
                    break;
                }
            }
        }
        
        static void Main(string[] args)
        {
            DBWorker();
            
            DataBaseLauncher.CloseDB();
           
        }
    }
}