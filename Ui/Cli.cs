using EpamDashkevichLab12.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamDashkevichLab12.Ui
{
    public class Cli
    {
        Mdb db;
        public Cli()
        {
            db = new Mdb();
        }
        public void ShowDbAndMenu()
        {
            bool isExit = false;
            while (!isExit)
            {
                try
                {
                    Console.WriteLine("Database:");
                    Console.WriteLine(db.Read());
                    Console.WriteLine("\n   MENU");
                    Console.WriteLine("1. Add.");
                    Console.WriteLine("2. Change.");
                    Console.WriteLine("3. Delete.");
                    Console.WriteLine("0. Exit.");
                    Console.Write("Choose what to do: ");
                    int menuItem = int.Parse(Console.ReadLine());
                    Console.WriteLine();

                    switch (menuItem)
                    {
                        case 1:
                            Create();
                            break;
                        case 2:
                            Update();
                            break;
                        case 3:
                            Delete();
                            break;
                        case 0:
                            isExit = true;
                            break;
                        default:
                            Console.WriteLine("Incorrect input");
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
        private void Create()
        {
            try
            {
                Console.WriteLine("To add new row to database, input item's name and amount.");
                Console.WriteLine("Do not use the same names which are already exist in the db\n");

                Console.WriteLine("Input item name:");
                string name = Console.ReadLine();

                Console.WriteLine("Input amount:");
                int amount = Convert.ToInt32(Console.ReadLine());
                if (amount < 0)
                {
                    throw new ArgumentOutOfRangeException("Incorrect amount");
                }

                db.Create(name, amount);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void Update()
        {
            try
            {
                Console.WriteLine("This is only for changing the number of item pieces.");
                Console.WriteLine("To change item name too, delete unnesesary item and add another with new name\n");

                Console.WriteLine("Input id:");
                int id = Convert.ToInt32(Console.ReadLine());
                if (id <= 0)
                {
                    throw new ArgumentOutOfRangeException("Incorrect id");
                }

                Console.WriteLine("Input amount:");
                int amount = Convert.ToInt32(Console.ReadLine());
                if (amount < 0)
                {
                    throw new ArgumentOutOfRangeException("Incorrect amount");
                }

                db.Update(id, amount);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        private void Delete()
        {
            Console.WriteLine("Delete row by its id");
            try
            {
                Console.WriteLine("Input id:");
                int id = Convert.ToInt32(Console.ReadLine());
                if (id <= 0)
                {
                    throw new ArgumentOutOfRangeException("Incorrect id");
                }

                db.Delete(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
