using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelRecordAppDemo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapPage : ContentPage
    {
        public MapPage()
        {
            InitializeComponent();
        }

        private async void GetPermissions()
        {
            try
            {
                //var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.LocationWhenInUse); - generates deprecation warning

                var status = await CrossPermissions.Current.CheckPermissionStatusAsync<LocationWhenInUsePermission>(); //see available permissions section https://github.com/jamesmontemagno/PermissionsPlugin

                if (status != PermissionStatus.Granted)
                {
                    if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.LocationWhenInUse))
                    {
                        await DisplayAlert("Need your location", "We need to access your location", "Ok");
                    }

                    //var results = await CrossPermissions.Current.RequestPermissionsAsync(Permission.LocationWhenInUse); - generates deprecation warning

                    /*var results = await CrossPermissions.Current.RequestPermissionAsync<LocationWhenInUsePermission>();
                    if (results.ContainsKey(Permission.LocationWhenInUse))
                        status = results[Permission.LocationWhenInUse]; //results is a dictionary*/
                    status = await CrossPermissions.Current.RequestPermissionAsync<LocationWhenInUsePermission>();
                }

                if (status == PermissionStatus.Granted)
                {
                    locationsMap.IsShowingUser = true;
                }
                else
                {
                    await DisplayAlert("Location denied", "You didn't give us permission to access location, so we can't show you where you are", "Ok");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "Ok");
            }
        }
    }
}