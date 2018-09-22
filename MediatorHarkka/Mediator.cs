using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorHarkka
{
    class Mediator
    {
        private static Mediator instance = new Mediator();
        public static Mediator Instance => instance;

        private Mediator() { }

        public event EventHandler<JobChangedEventArgs> JobChanged;

        public void OnJobChanged(object sender, Job job)
        {
            var JobChangeDelegate = JobChanged as EventHandler<JobChangedEventArgs>;

            if (JobChangeDelegate != null)
            {
                JobChangedEventArgs T = new JobChangedEventArgs(job);
                JobChangeDelegate.Invoke(sender, T);
            }
        }
    }
}
