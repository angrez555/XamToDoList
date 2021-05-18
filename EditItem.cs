using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace XamToDoList
{
    [Activity(Label = "Edit an Item")]
    public class EditItem : Activity
    {


        //this binds to layout
        TextView txtTitle;
        TextView txtDetails;
        Button btnEdit;
        Button btnDelete;

        //this comes in from the Main Activity
        int ListId;
        String EditTitle;
        String EditDetails;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here

            SetContentView(Resource.Layout.EditItem);
            //binding to the Layout
            txtTitle = FindViewById<TextView>(Resource.Id.txtEditTitle);
            txtDetails = FindViewById<TextView>(Resource.Id.txtEditDescription);

            btnEdit = FindViewById<Button>(Resource.Id.btnEdit);
            btnDelete = FindViewById<Button>(Resource.Id.btnDelete);
            btnDelete.Click += onBtnDelete_Click;
            btnEdit.Click += onBtnEdit_Click;


            //getting data from the MainActivity
            ListId = Intent.GetIntExtra("ListID", 0);
            EditTitle = Intent.GetStringExtra("Title");
            EditDetails = Intent.GetStringExtra("Details");


        }

        private void onBtnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                DatabaseManager.EditItem(txtTitle.Text, txtDetails.Text, ListId); //save changes to DB
                Toast.MakeText(this, "Note was Edited", ToastLength.Long).Show();
                this.Finish();
                StartActivity(typeof(MainActivity));



            }
            catch (Exception ex)
            {
                Toast.MakeText(this, "It Borked! " + ex.Message, ToastLength.Long).Show();
                Console.WriteLine("Error Occurred:" + ex.Message);
            }
        }

        private void onBtnDelete_Click(object sender, EventArgs e)
        {

            try
            {
                DatabaseManager.DeleteItem(ListId);
                Toast.MakeText(this, "Note was Deleted", ToastLength.Long).Show();
                this.Finish();
                StartActivity(typeof(MainActivity));

            }
            catch (Exception ex)
            {

                Toast.MakeText(this, "It Borked! " + ex.Message, ToastLength.Long).Show();
                Console.WriteLine("Error Occurred:" + ex.Message);
            }



        }
    }
}