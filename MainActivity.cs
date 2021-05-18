using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System.Linq.Expressions;
using System.Collections.Generic;
using System;
using Android.Content;
using XamToDoList.Models;

namespace XamToDoList
{
    [Activity(Label = "The Awesome To Do List", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {

        ListView ListToDoList;

        List<tblToDo> myList = new List<tblToDo>();




        protected override void OnCreate(Bundle savedInstanceState)
        {

            base.OnCreate(savedInstanceState);


            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            myList.AddRange(DatabaseManager.ViewAll());

            ListToDoList = FindViewById<ListView>(Resource.Id.listView1);
            ListToDoList.Adapter = new DataAdapter(this, myList);
            ListToDoList.ItemClick += onListToDoList_Click;

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);



        }

        private void onListToDoList_Click(object sender, AdapterView.ItemClickEventArgs e)
        {
            var position = e.Position; //get the number of the list item you clicked on
            var ToDoItem = myList[position];  //get the data from the list at the position I clicked

            var edititem = new Intent(this, typeof(EditItem));
            edititem.PutExtra("Title", ToDoItem.Title);
            edititem.PutExtra("Details", ToDoItem.Details);
            edititem.PutExtra("ListID", ToDoItem.ListID);

            StartActivity(typeof(EditItem));



        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}