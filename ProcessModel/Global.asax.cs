﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Threading;

namespace ProcessModel
{
    public class Global : HttpApplication
    {

        static int defaultMinWorker, defaultMinIOC, defaultMaxWorker, defaultMaxIOC;
        public static int DefaultMinWorker
        {
            get
            {
                return defaultMinWorker;
            }
            set
            {
                int mw, mi;
                ThreadPool.GetMinThreads(out mw, out mi);
                defaultMinWorker = mw;
                defaultMinWorker = value;
            }
        }

        public static int DefaultMinIOC
        {
            get
            {
                return defaultMinIOC;
            }
            set
            {
                int mw, mi;
                ThreadPool.GetMinThreads(out mw, out mi);
                defaultMinIOC = mi;
                defaultMinIOC = value;
            }
        }

        public static int DefaultMaxWorker
        {
            get
            {
                return defaultMaxWorker;
            }
            set
            {
                int mw, mi;
                ThreadPool.GetMaxThreads(out mw, out mi);
                defaultMaxWorker = mw;
                defaultMaxWorker = value;
            }
        }
        public static int DefaultMaxIOC
        {
            get
            {
                return defaultMaxIOC;
            }
            set
            {
                int mw, mi;
                ThreadPool.GetMaxThreads(out mw, out mi);
                defaultMaxIOC = mi;
                defaultMaxIOC = value;
            }
        }

        void Application_Start(object sender, EventArgs e)
        {

            // Code that runs on application startup
            int minWorker, minIOC;
            // Get the current settings.
            ThreadPool.GetMinThreads(out minWorker, out minIOC);

            defaultMinWorker = minWorker;
            defaultMinIOC = minIOC;


            //Modify the Minimum threads in the ThreadPool
            ThreadPool.SetMinThreads(200, 12);

            int maxWorker, maxIOC;
            // Get the current settings
            ThreadPool.GetMaxThreads(out maxWorker, out maxIOC);

            defaultMaxWorker = maxWorker;
            defaultMaxIOC = maxIOC;

            ThreadPool.SetMaxThreads(10000, 1500);

        }
    }
}