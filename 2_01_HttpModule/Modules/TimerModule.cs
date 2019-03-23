using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace _2_01_HttpModule.Modules
{
    public class TimerModule : IHttpModule
    {
        private Stopwatch timer;

        public void Init(HttpApplication appCtx)
        {
            appCtx.BeginRequest += HandleBeginRequest;
            appCtx.EndRequest += HandleEndRequest;
        }

        private void HandleEndRequest(object sender, EventArgs e)
        {
            HttpContext.Current.Response.Write(
                $"<div style='color:red;'>" +
                $"Время обработки запроса: {(float)timer.ElapsedTicks / Stopwatch.Frequency:F5} секунд" +
                $"</div>");
        }

        private void HandleBeginRequest(object sender, EventArgs e)
        {
            timer = Stopwatch.StartNew();
        }

        public void Dispose()
        {
            timer = null;
        }
    }
}