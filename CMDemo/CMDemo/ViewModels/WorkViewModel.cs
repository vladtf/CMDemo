using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMDemo.ViewModels
{
    public class WorkViewModel : Screen
    {
        public WorkViewModel()
        {
            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    Task.Delay(100).Wait();
                    Progress += 0.1;
                }
            });
        }


        private Double _progress = 20;

        public Double Progress
        {
            get { return _progress; }
            set { Set(ref _progress, value); }
        }

        public void Increase()
        {
            if (Progress<100)
            {
                Progress++;
            }
        }

        public void Decrease()
        {
            if (Progress>1)
            {
                Progress--;
            }
        }

        public void MouseDown()
        {
            Progress = 0;
        }

    }
}
