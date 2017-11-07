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
    public class ProfileAdapter<T> : BaseAdapter<T>
    {
        private Activity context;
        private List<T> dataSource;
        private int LayoutSource;
        private Action<View, T> action;
        public ProfileAdapter(Activity activity, List<T> dataSource, int layoutSource, Action<View, T> action)
        {
            context = activity;
            this.LayoutSource = layoutSource;
            this.action = action;
            this.dataSource = dataSource;
        }
        public override T this[int position] => dataSource[position];

        public override int Count => dataSource.Count;

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var t = dataSource[position];

            View v = convertView;

            if (null == v)
            {
                v = context.LayoutInflater.Inflate(LayoutSource, null);
            }

            //convertView.FindViewById<TextView>(Resource.Id.txtAddress).Text = profile.Address;
            //convertView.FindViewById<TextView>(Resource.Id.txtAge).Text = profile.Age.ToString();
            //convertView.FindViewById<TextView>(Resource.Id.txtName).Text = profile.UserName.ToString();

            //btnDelete = convertView.FindViewById<Button>(Resource.Id.btnDelete);
            //btnDelete.Tag = profile.UserName;
            //btnDelete.Click += ProfileAdapter_Click;

            if (action != null)
            {
                action.Invoke(v, t);
            }

            return v;
        }

        private void ProfileAdapter_Click(object sender, EventArgs e)
        {
            var btnDelete = sender as Button;
        }
    }
}