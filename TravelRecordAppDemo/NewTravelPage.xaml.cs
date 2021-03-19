using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelRecordAppDemo.Model; //enables Post model defined in Model folder to be used
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelRecordAppDemo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewTravelPage : ContentPage
    {
        public NewTravelPage()
        {
            InitializeComponent();
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            Post post = new Post()
            {
                Experience = experienceEntry.Text //experienceEntry is the name of the entry element in NewTravelPage.xaml
            };

            /*SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation);
            /*SQLiteConnection function expects the location/path of the database as a parameter

            conn.CreateTable<Post>(); 
            /*CreateTable<type_of_table>() <> is generics notation, functions which are non generic are less secure

            int rows = conn.Insert(post); //Insert function expects an object as a parameter

            conn.Close();
            /*only one connection at a time can be made to the table so it must closed after use*/

            /*if (rows > 0) /*the insert function returns an integer which represents the number of rows in
                           a table
                DisplayAlert("Success", "Experience succesfully inserted", "Ok");
                /*DisplayAlert accepts 3 stings i.e "Title", "Message", "CancelButton" and displays it in a dialog box on device screen
            else
                DisplayAlert("Failure", "Experience failed to be inserted", "Ok");*/

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Post>();
                int rows = conn.Insert(post);

                if (rows > 0)
                    DisplayAlert("Success", "Experience succesfully inserted", "Ok");
                else
                    DisplayAlert("Failure", "Experience failed to be inserted", "Ok");
            }

            /*the using statement eliminates the need to close a database connection and can be used to call the 
              the Dispose method from an IDisposable interface automatically
              SQLiteConnection implements the IDisposable interface (right click SQLiteConnection -> go to definition)
              refer to section 6 - vid 55 */

        }
    }
}