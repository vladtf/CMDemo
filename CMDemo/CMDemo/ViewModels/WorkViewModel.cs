using Caliburn.Micro;
using System;
using System.Threading.Tasks;

namespace CMDemo.ViewModels
{
    public class WorkViewModel : Screen
    {
        #region Private fiels
        private Double _progress = 20;
        #endregion
        #region Public fields

        #endregion

        public WorkViewModel()
        {
            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    Task.Delay(100).Wait();
                    //Progress += 0.1;
                }
            });
        }


        public void Increase()
        {
            //if (Progress < 100)
            //{
            //    Progress++;
            //}
        }

        public void Decrease()
        {
            //if (Progress > 1)
            //{
            //    Progress--;
            //}
        }

        public void MouseDown()
        {
            //Progress = 0;
        }
    }
}