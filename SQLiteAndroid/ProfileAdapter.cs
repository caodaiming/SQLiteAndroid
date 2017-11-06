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
using SQLiteAndroid.Models;

namespace SQLiteAndroid
{
    public class ProfileAdapter : BaseAdapter<Profile>
    {
        private Activity context;
        private List<Profile> profiles;
        public ProfileAdapter(Activity activity,List<Profile> profiles)
        {
            context = activity;
            this.profiles = profiles;
        }
        public override Profile this[int position] => profiles[position];

        public override int Count => profiles.Count;

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var profile = profiles[position];

            if (null == convertView)
            {
                convertView = context.LayoutInflater.Inflate(Resource.Layout.ListItem,null);
            }

            convertView.FindViewById<TextView>(Resource.Id.txtAddress).Text = profile.Address;
            convertView.FindViewById<TextView>(Resource.Id.txtAge).Text = profile.Age.ToString();
            convertView.FindViewById<TextView>(Resource.Id.txtName).Text = profile.UserName.ToString();

            var btnDelete = convertView.FindViewById<Button>(Resource.Id.btnDelete);
            btnDelete.Tag = profile.UserName;
            btnDelete.Click += ProfileAdapter_Click;

            return convertView;
        }

        private void ProfileAdapter_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;

            ProfileService profileService = new ProfileService();
            profileService.Delete(btn.Tag.ToString());
        }
    }
}