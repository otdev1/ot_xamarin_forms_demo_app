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
    public partial class HistoryPage : ContentPage
    {
        public HistoryPage()
        {
            InitializeComponent();
        }

        /*since data may be added or removed by the user to the database, the table(s)
          should be read every time the user navigates to the History Page, this can be done using the
          OnAppearing function*/
        protected override void OnAppearing()
        {
            base.OnAppearing();

            //SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation);

            //conn.CreateTable<Post>();
            /*CreateTable function is called here because the history page is the first page the user will be navigated 
              to after logging in, in the case where the app is being used to first time it is important for the Post
              table to be created immediately since the user may navigate to the NewTravelPage to add/remove an experience
              alternatively the Post table won't be recreated if it already exists*/

            //var posts = conn.Table<Post>().ToList();
            /*Table function returns a table query object however this object is not easy to work with therefore the ToList function
              is used to convert it into a working list(of Post objects)*/

            //conn.Close();

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Post>();

                var posts = conn.Table<Post>().ToList();

                postListView.ItemsSource = posts;
                /*set the list of (posts) elements to the listview with the name postListView see HistoryPage.xaml*/
            }
            /*the using statement eliminates the need to close a database connection and can be used to call the 
              the Dispose method from an IDisposable interface automatically
              SQLiteConnection implements the IDisposable interface (right click SQLiteConnection -> go to definition)
              refer to section 6 - vid 55 */

            /*void Handle_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e) //listview is passed as object sender
            {
                var selectedPost = postListView.SelectedItem as Post; 
                /*as Post converts the selecteditem i.e row of listview into a table query object

                if (selectedPost != null)
                {
                    Navigation.PushAsync(new PostDetailPage(selectedPost));
                }
            }*/
        }

        private void Handle_ItemSelected(object sender, SelectedItemChangedEventArgs e) //listview is passed as object sender
        {
            var selectedPost = postListView.SelectedItem as Post;
                /*as Post converts/casts the selecteditem i.e row of listview into a table query object*/

                if (selectedPost != null)
                {
                    Navigation.PushAsync(new PostDetailPage(selectedPost));
                }
        }

    }
}