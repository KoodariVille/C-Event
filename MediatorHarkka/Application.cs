using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorHarkka
{
    static class Application
    {
        private static ConsoleControl JobMenu;
        private static ConsoleControl JobDetails;
        private static ConsoleControl JobEmployees;

        private static void BindMenuData(List<Job> param)
        {
            foreach (Job job in param)
            {
                JobMenu.Items.Add($"{job.Id}, {job.Title}");
            }
        }

        private static void BindDetailsData(Job job)
        {
            if (job.Items == null)
            {
                job.Items = new List<string>();
            }
            else
            {
                job.Items.Clear();
            }
            job.Items.Add("Työn tiedot");
            job.Items.Add($"Id: {job.Id}");
            job.Items.Add($"Nimi: {job.Title}");
            job.Items.Add($"Alkaa: {job.StartDate.ToShortDateString()}");
            job.Items.Add($"Loppuu: {job.EndDate.ToShortDateString()}");
        }

        private static void BindEmployeesData(Job job)
        {
            if (job.Items == null)
            {
                job.Items = new List<string>();
            }
            else
            {
                job.Items.Clear();
            }

            foreach (Employee e in Data.employees){
                if (e.Id == job.Id)
                {
                    job.Items.Add(e.Name);
                }
            }
        }

        private static void Initialize()
        {
            
        }
    }
}
