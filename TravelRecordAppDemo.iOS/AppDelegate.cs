using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;
using System.IO;

namespace TravelRecordAppDemo.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            //notifies the ios project that it will be initialized through xamarin forms

            Xamarin.FormsMaps.Init(); //initializes ios project to use xamarin forms with maps

            string dbName = "travel_db.sqlite";

            string folderPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "..", "Library");
            /*get the path of the library folder by navigating outside of the personal folder to 
             its parent folder in which Library is stored*/

            string fullPath = Path.Combine(folderPath, dbName);
            /*Path.Combine function creates a path string e.g \somepath\travel_db.sqlite by combining the string
            parameters passed to it*/

            //LoadApplication(new App());
            LoadApplication(new App(fullPath));
            /*pass full path to the second app constructor see app.xaml.cs*/

            //LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
    }
}
