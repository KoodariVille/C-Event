using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace MediatorHarkka
{
    static class Application
    {
        private static ConsoleControl JobMenu;
        private static ConsoleControl JobDetails;
        private static ConsoleControl JobEmployees;

        private static void BindMenuData(List<Job> param)
        {
            /*foreach (Job job in param)
            {
                JobMenu.Items.Add($"{job.Id}, {job.Title}");            
            }*/

            if (JobMenu.Items == null)
            {
                JobMenu.Items = new List<string>();
            }
            else
            {
                JobMenu.Items.Clear();
            }
            foreach (Job job in param)
            {
                string s = $"{job.Id} {job.Title}";
                JobMenu.Items.Add(s);
            }
        }

        private static void BindDetailsData(Job job)
        {
            if (JobDetails.Items == null)
            {
                JobDetails.Items = new List<string>();
            }
            else
            {
                JobDetails.Items.Clear();
            }
            JobDetails.Items.Add("Työn tiedot");
            JobDetails.Items.Add($"Id: {job.Id}");
            JobDetails.Items.Add($"Nimi: {job.Title}");
            JobDetails.Items.Add($"Alkaa: {job.StartDate.ToShortDateString()}");
            JobDetails.Items.Add($"Loppuu: {job.EndDate.ToShortDateString()}");
        }

        private static void BindEmployeesData(Job job)
        {
            if (JobEmployees.Items == null)
            {
                JobEmployees.Items = new List<string>();
            }
            else
            {
                JobEmployees.Items.Clear();
            }

            foreach (Employee e in Data.employees){
                if (e.Id == job.Id)
                {
                    JobEmployees.Items.Add(e.Name);
                }
            }
        }

        private static void Initialize()
        {
            JobMenu = new ConsoleControl(1,System.Console.WindowWidth - 1,2,Data.jobs.Count());
            JobDetails = new ConsoleControl((System.Console.WindowWidth / 2) + 1, (System.Console.WindowWidth / 2) - 1,2,5);
            JobEmployees = new ConsoleControl((System.Console.WindowWidth / 2) + 1, (System.Console.WindowWidth / 2) - 1, JobDetails.Height + 3 ,System.Console.WindowHeight - JobDetails.Height - 1);

            JobMenu.BackColor = ConsoleColor.Gray;
            JobDetails.BackColor = ConsoleColor.Gray;
            JobEmployees.BackColor = ConsoleColor.Gray;
            JobMenu.TextColor = ConsoleColor.DarkBlue;
            JobDetails.TextColor = ConsoleColor.DarkGreen;
            JobEmployees.TextColor = ConsoleColor.DarkRed;

            BindMenuData(Data.jobs);         
        }

        private static void Metodi(object sender, JobChangedEventArgs e)
        {
            BindDetailsData(e.Job);
            BindEmployeesData(e.Job);
        }

        private static void MenuSelectionChanged(int id)
        {
            foreach(Job j in Data.jobs)
            {
                if (id == j.Id)
                {
                    Mediator.Instance.OnJobChanged(JobMenu, j);
                    JobDetails.Draw();
                    JobEmployees.Draw();
                }
                
            }
        }

        public static void Run()
        {
            Initialize();
            JobMenu.Draw();
            int inp = 1;

            while (inp != 0)
            {
                System.Console.SetCursorPosition(0, 0);
                Write("Valitse työn id (nolla lopettaa): ");
                bool input = Int32.TryParse(ReadLine(), out inp);

                if(inp < 0 || inp > JobMenu.Items.Count())
                {
                    System.Console.SetCursorPosition(0, 0);
                    WriteLine("Virhe");
                    ReadLine();
                }
                else
                {
                    MenuSelectionChanged(inp);
                }
            }
        }
    }
}
