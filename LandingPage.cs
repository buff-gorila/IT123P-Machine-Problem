using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IT123P_Machine_Problem
{
    [Activity(Label = "LandingPage")]
    public class LandingPage : Activity
    {
        string login_name;
        TextView txt1;
        Button sendbtn, receivebtn;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.landingpage);
            //testing for login basic form
            login_name = Intent.GetStringExtra("Name");
            txt1 = FindViewById<TextView>(Resource.Id.textView1);
            txt1.Text = login_name;

            //button logic
            sendbtn = FindViewById<Button>(Resource.Id.button1);
            receivebtn = FindViewById<Button>(Resource.Id.button2);

            sendbtn.Click += (o, i) =>
            {
                Intent send = new Intent(this, typeof(SendingPage));
                send.PutExtra("Name", login_name);
                StartActivity(send);
            };
            receivebtn.Click += (o, i) =>
            {
                Intent receive = new Intent(this,typeof(Receiving));
                receive.PutExtra("Name", login_name);
                StartActivity(receive);
            };
        }
    }
}