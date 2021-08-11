using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crew.Mock.UITests.Pages.Base
{
    public abstract class CrewBasePage : BasePage
    {
        public T ChangeWiFiState<T>() where T : CrewBasePage
        {
            //TODO: Provide Backdoor methods on Native platforms

            if (OnAndroid)
            {
                //var process = new System.Diagnostics.Process();
                //var startInfo = new System.Diagnostics.ProcessStartInfo
                //{
                //    WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden,
                //    FileName = "cmd.exe",
                //    Arguments = "/C adb shell am start -a android.intent.action.MAIN -n com.android.settings/.wifi.WifiSettings adb shell input keyevent 19 & adb shell input keyevent 19 & adb shell input keyevent 23 & adb shell input keyevent 82 & adb shell input tap 500 1000"
                //};
                //process.StartInfo = startInfo;
                //process.Start();
                throw new NotImplementedException();
            }

            if (OniOS)
            {
                throw new NotImplementedException();
            }

            return (T)this;
        }
    }
}
