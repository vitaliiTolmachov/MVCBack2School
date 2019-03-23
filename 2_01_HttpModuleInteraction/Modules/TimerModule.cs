using System;
using System.Diagnostics;
using System.Web;

namespace _2_01_HttpModuleInteraction.Modules
{
    public class RequestTimerEventArgs : EventArgs
    {
        public float Duration { get; set; }
    }

    public class TimerModule : IHttpModule
    {
        private Stopwatch _timer;
        public event EventHandler<RequestTimerEventArgs> RequestTimed;

        public void Init(HttpApplication appCtx)
        {
            appCtx.BeginRequest += HandleBeginRequest;
            appCtx.EndRequest += HandleEndRequest;
        }

        private void HandleEndRequest(object sender, EventArgs e)
        {
            var duration = (float)_timer.ElapsedTicks / Stopwatch.Frequency;

            HttpContext.Current.Response.Write(
                $"<div style='color:red;'>TimerModule:</br>" +
                $"Время обработки запроса: {duration:F5} секунд" +
                $"</div>");

            RequestTimed?.Invoke(this, new RequestTimerEventArgs { Duration = duration });
        }

        private void HandleBeginRequest(object sender, EventArgs e)
        {
            _timer = Stopwatch.StartNew();
        }

        public void Dispose()
        {
            _timer = null;
        }
    }
}