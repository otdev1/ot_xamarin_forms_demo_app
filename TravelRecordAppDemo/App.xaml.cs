using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelRecordAppDemo
{
    public partial class App : Application
    {
        public static string DatabaseLocation = string.Empty;
        public App()
        {
            InitializeComponent();

            //MainPage = new MainPage();

            MainPage = new NavigationPage(new MainPage()); 
            /*a navigation page is necessary in order to manage navigation to and from all pages in the app
             in order for this page to work a root must be set for it in this case mainpage
            the navigation page function will also add a back button to the user interface
            see mainpage.xaml*/
        }

        /*second constructor, this constructor function is called in LoadApplication function
         * in MainActivity.cs(Android) and AppDelegate.cs(iOS)*/
        public App(string databaseLocation)
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());

            DatabaseLocation = databaseLocation;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
