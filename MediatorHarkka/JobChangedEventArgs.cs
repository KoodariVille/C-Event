using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorHarkka
{
    class JobChangedEventArgs : EventArgs
    {
        public Job Job;

        public JobChangedEventArgs(Job job)
        {
            Job = job;
        }
    }
}
