using System.Diagnostics;
using TaskManager.Interfaces;
using TaskManager.Utils;

namespace TaskManager
{
    internal class Tasks : IListAllTasks
    {
        public int index = 0;
        private string _fileName;

        public void ListAllTasks()
        {
            var runningTasks = from tasks in Process.GetProcesses(".")
                               orderby tasks.Id
                               select tasks;
            Console.WriteLine("\tPrinting out each process");
            foreach (var task in runningTasks)
            {
                Console.WriteLine($"\tID: {task.Id} \tName: {task.ProcessName}");
            }
        }

        public void KillTasks()
        {

            try
            {
                ListAllTasks();
                Console.WriteLine("\nThese are list of all tasks running at the moment" +
                    "\nType name of the one you want to close");
                Console.Write("==> ");
                string taskName = Console.ReadLine();
                foreach (var task in Process.GetProcessesByName(taskName))
                {
                    task.Kill(true);
                    Console.WriteLine($"You have successfully stopped " +
                        $"{task.ProcessName}");
                }
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void StartTasks()
        {
            Process process = null;

            try
            {
                Console.WriteLine("You want to start a task?\nInput file name");
                Console.Write("==> ");
                _fileName = Console.ReadLine() ?? string.Empty;



                Console.WriteLine("\nwhat do you want to do with your file");
                Console.Write("==> ");
                string? todo = Console.ReadLine();
                
                ProcessStartInfo processStartInfo = new ProcessStartInfo(_fileName, todo);

                /*Console.WriteLine("\nwhat do you want to do with your file");
                Console.Write("==> ");
                string? todo = Console.ReadLine();*/

                /*foreach (var verb in processStartInfo.Verbs)
                {
                    Console.WriteLine($"{index++} - - {verb} ");
                }*/
                  
                processStartInfo.WindowStyle = ProcessWindowStyle.Maximized;
                processStartInfo.Verb = "Open";

                processStartInfo.UseShellExecute = true;
                process = Process.Start(processStartInfo);
            }
            catch(Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine(ex.Message);
                StartTasks();
                Console.WriteLine();
            }

            while (true)
            {
                Console.WriteLine("\nDo you want to kill this process\nType 1: Yes\nType 2: No");
                string options = Console.ReadLine();

                switch (options)
                {
                    case "1":
                        try
                        {
                            foreach (var task in Process.GetProcessesByName(_fileName))
                            {
                                task.Kill(true);
                                Console.WriteLine($"You have successfully stopped " +
                                    $"{task.ProcessName}");
                            }
                            Utility.Headers();
                        }
                        catch (InvalidOperationException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        catch (FormatException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("\nReturning to Menu...");
                        Utility.Headers();
                        break;
                    default:
                        Console.WriteLine("Invalid input...");
                        break;
                }
            }

            
            

        }

        public static void TasksOperations()
        {
            Utility.Headers();
        }

    }
}
