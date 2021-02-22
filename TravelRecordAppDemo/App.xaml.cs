using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelRecordAppDemo
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new MainPage();

            MainPage = new NavigationPage(new MainPage()); 
            /*a navigation page is necessary in order to manage navigation to and from all pages in the app
             in order for this page to work a root must be set for it in this case mainpage*/
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
