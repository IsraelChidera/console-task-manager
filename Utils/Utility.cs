using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Utils
{
    internal class Utility
    {
        public static void Headers()
        {
            Console.WriteLine("\n******************************************\nI.C.E Task Manager\n" +
                "A good day... What do you want to do?");
          

            while (true)
            {
                Console.WriteLine("\n1: To list all running tasks\n2: To kill a task\n3: To start a task" +
              "\n4: To create a custom thread\n0: To exit application");
                Console.Write("==>");
                string option = Console.ReadLine();
                Tasks task = new();

                switch (option)
                {
                    case "1":
                        Console.Clear();
                        task.ListAllTasks();
                        break;
                    case "2":
                        Console.Clear();
                        task.KillTasks();
                        break;
                    case "3":
                        Console.Clear();
                        task.StartTasks();
                        Console.WriteLine("You pressed 3");
                        break;
                    case "4":
                        Console.Clear();
                        Console.WriteLine("Creating custom threads");
                        break;
                    case "0":
                        Console.WriteLine("Goodbye! We will love to see you again");
                        Environment.Exit(0);
                        return;
                    default:
                        Console.WriteLine("Invalid input. Try again\n");
                        break;
                }
                              
                
            }

            
        }
    }
}
