using NUnit.Framework.Internal;
using System;
using System.IO;
using Xamarin.UITest;

namespace Crew.Mock.UITests
{
    static class AppManager
    {
        private const string ApkPath = "Crew.Mock/Crew.Mock.Android/bin/Debug/com.clearion.crew.mock.apk";
        private const string PackageName = "com.clearion.crew.mock";
        private const string AppPath = "/Users/vskliam/crew.mock/Crew.Mock/Crew.Mock.iOS/bin/iPhoneSimulator/Debug/device-builds/iphone 12-14.5/Crew.Mock.iOS.app";
        private const string IpaBundleId = "com.clearion.crew.mock";

        private static IApp _app;
        public static IApp App
        {
            get
            {
                if (_app == null)
                    throw new NullReferenceException("'AppManager.App' not set. Call 'AppManager.StartApp()' before trying to access it.");
                return _app;
            }
        }

        private static Platform? _platform;
        public static Platform Platform
        {
            get
            {
                if (_platform == null)
                    throw new NullReferenceException("'AppManager.Platform' not set.");
                return _platform.Value;
            }

            set
            {
                _platform = value;
            }
        }

        public static void StartApp()
        {
            //
            //  If there's more than one device or emulator connected, 
            //  Xamarin.UITest will halt test execution and display an error message as it's unable to resolve what the intended target is for the test.
            //  In this case, it's necessary to provide the serial ID of the device or emulator to run the test.
            //  For example, consider the following output from the "adb devices" command that lists all of the devices (or emulators) attached to the computer (along with their serial ID)
            //
            //  .DeviceSerial("192.168.56.101:5555")
            //  .DeviceSerial("03f80ddae07844d3")
            //


            if (Platform == Platform.Android)
            {
                //var path = Path.Combine(Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName, ApkPath);

                _app = ConfigureApp
                    .Android
                    //.EnableLocalScreenshots()
                    .InstalledApp(PackageName) // Used to run an already installed app
                    //.ApkFile(path) // Used to deploy and run a .apk file
                    .StartApp();
            }


            if (Environment.OSVersion.Platform == PlatformID.MacOSX || Environment.OSVersion.Platform == PlatformID.Unix)
            {
                if (Platform == Platform.iOS)
                {
                    _app = ConfigureApp
                        .iOS
                        .AppBundle(AppPath) // Used to run a .app file on an ios simulator:
                        .DeviceIdentifier("1D512309-B9EF-4543-A238-271C0121600E")
                        //.InstalledApp(IpaBundleId) // Used to run a .ipa file on a physical ios device:
                        .StartApp();
                }
            }
        }
    }
}
