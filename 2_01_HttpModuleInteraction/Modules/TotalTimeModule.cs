using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _2_01_HttpModuleInteraction.Modules
{
    public class TotalTimeModule : IHttpModule
    {
        private static float totalTime = 0;
        private static int requestCount = 0;

        void IHttpModule.Init(HttpApplication appContext)
        {
            IHttpModule module = appContext.Modules["Timer"];

            if (module is TimerModule timerModule)
            {
                timerModule.RequestTimed += HandleRequestTimed;
            }
            appContext.EndRequest += HandleEndRequest;
        }

        private void HandleRequestTimed(object sender, RequestTimerEventArgs e)
        {
            totalTime += e.Duration;
            requestCount++;
        }

        private void HandleEndRequest(object sender, EventArgs e)
        {
            string result = $"<div style='color:blue;'>TotalTimeModule:</br>Количество обращений: {requestCount} </div>" +
                            $"<div style='color:blue;'>Общее время обработки запросов: {totalTime:F5} секунд </div>";
            HttpContext.Current.Response.Write(result);
        }

        void IHttpModule.Dispose()
        {
            throw new NotImplementedException();
        }
    }
}