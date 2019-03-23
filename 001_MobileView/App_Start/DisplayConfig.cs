using System.Collections.Generic;
using System.Web.WebPages;
using _001_MobileView.App_Start;

namespace _001_MobileView
{
    internal class DisplayConfig
    {
        public static void RegisterDisplayModes(IList<IDisplayMode> displayModes)
        {
            displayModes.Clear();
            var modeDesktop = new DefaultDisplayMode("")
            {
                ContextCondition = c => c.Request.IsDesktop()
            };
            var smartPhone = new DefaultDisplayMode("smart")
            {
                ContextCondition = c => c.Request.IsSmartphone()
            };
            var modeTablet = new DefaultDisplayMode("tablet")
            {
                ContextCondition = c => c.Request.IsTablet()
            };

            //Order is priority 0 is Max
            displayModes.Clear();
            displayModes.Add(smartPhone);
            displayModes.Add(modeTablet);
            displayModes.Add(modeDesktop);
        }
    }
}