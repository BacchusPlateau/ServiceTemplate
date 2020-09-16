using BusinessLogicCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServiceTemplateDotNet
{
    public class StartMeUp
    {

        private CancellationTokenSource cancelSource = null;
        private CancellationToken cancelToken;
        private Task task = null;

        public void SomeTask()
        {
            //instantiate process here
            var fun = new BusinessCore();
            while(true)
            {
                if(cancelToken.IsCancellationRequested)
                {
                    break;
                }

                fun.DoSomeWork("heyletsgo");
            }
        }


        public int Start()
        {
            cancelSource = new CancellationTokenSource();
            cancelToken = cancelSource.Token;

            task = new Task(SomeTask, cancelToken, TaskCreationOptions.LongRunning);
            task.Start();

            return 0;
        }

        public void Stop()
        {

            if (cancelSource != null)
            {
                cancelSource.Cancel();
            }

            Task.WaitAll(new Task[] { task }, 1000);

        }

    }
}
