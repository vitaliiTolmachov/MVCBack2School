using System;
using System.Collections.Generic;
using System.Web.WebPages;

namespace _001_MobileView
{
    internal class DisplayConfig
    {
        public static void RegisterDisplayModes()
        {
            DisplayModeProvider.Instance.Modes.Insert(1, new DefaultDisplayMode("iPad")
            {
                ContextCondition = (ctx => ctx.GetOverriddenUserAgent()
                                              .IndexOf("iPad", StringComparison.OrdinalIgnoreCase) > 0)
            });

            DisplayModeProvider.Instance.Modes.Insert(1, new DefaultDisplayMode("iPhone")
            {
                ContextCondition = (ctx => ctx.GetOverriddenUserAgent()
                                              .IndexOf("iPhone", StringComparison.OrdinalIgnoreCase) > 0)
            });

            DisplayModeProvider.Instance.Modes.Insert(1, new DefaultDisplayMode("Android")
            {
                ContextCondition = (ctx => ctx.GetOverriddenUserAgent()
                                              .IndexOf("Android", StringComparison.OrdinalIgnoreCase) > 0)
            });

        }
    }
}