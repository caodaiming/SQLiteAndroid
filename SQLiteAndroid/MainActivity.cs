using Android.App;
using Android.Widget;
using Android.OS;
using SQLiteAndroid.Models;
using System;

namespace SQLiteAndroid
{
    [Activity(Label = "SQLiteAndroid", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            FindViewById<Button>(Resource.Id.btnSave).Click += MainActivity_Click;
            FindViewById<Button>(Resource.Id.btnRead).Click += MainActivity_Click1;
            LoadDataToListView();
        }

        private void MainActivity_Click1(object sender, EventArgs e)
        {
            LoadDataToListView();
        }

        private void MainActivity_Click(object sender, EventArgs e)
        {
            ProfileService profileService = new ProfileService();
            profileService.AddProfile(GetProfile());
            LoadDataToListView();
        }

        private Profile GetProfile()
        {
            return new Profile
            {
                UserName = FindViewById<EditText>(Resource.Id.editUserName).Text,
                Address = FindViewById<EditText>(Resource.Id.editAddress).Text,
                Age = Convert.ToInt16(FindViewById<EditText>(Resource.Id.editAge).Text)
            };
        }

        private void LoadDataToListView()
        {
            ProfileService profileService = new ProfileService();
            var profiles = profileService.GetAll();

            var listView = FindViewById<ListView>(Resource.Id.myListView);

            var profileAdapter = new ProfileAdapter(this,profiles);
            listView.Adapter = profileAdapter;

            profileAdapter.btnDelete.Click += BtnDelete_Click;
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            ProfileService profileService = new ProfileService();
            var tag = (sender as Button).Tag;

            profileService.Delete(tag.ToString());
        }
    }
}

