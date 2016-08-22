using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;

namespace ProcessModel
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int minWorker, minIOC, maxWorker, maxIOC, defaultMaxWorker, defaultMinWorker, defaultMaxIOC, defaultMinIOC;


            // Get the Default settings.
            defaultMinWorker = Global.DefaultMinWorker;
            defaultMinIOC = Global.DefaultMinIOC;
            defaultMaxIOC = Global.DefaultMaxIOC;
            defaultMaxWorker = Global.DefaultMaxWorker;

            Response.Write("<table border=\"2\">");
            Response.Write("<tr><th></th><th>MinIOThreads</th><th>MaxIOThreads</th><th>MinWorkerThreads</th><th>MaxWorkerThreads</th></tr>");
            Response.Write(string.Format("<tr><th>Default</th><th>{0}</th><th>{1}</th><th>{2}</th><th>{3}</th></tr>", defaultMinIOC, defaultMaxIOC, defaultMinWorker, defaultMaxWorker));

            // Get the Current settings.
            ThreadPool.GetMinThreads(out minWorker, out minIOC);
            ThreadPool.GetMaxThreads(out maxWorker, out maxIOC);

            Response.Write(string.Format("<tr><th>Modified</th><th>{0}</th><th>{1}</th><th>{2}</th><th>{3}</th></tr>", minIOC, maxIOC, minWorker, maxIOC));
            Response.Write("</table>");

        }
    }
}