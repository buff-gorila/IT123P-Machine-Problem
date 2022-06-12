using Android.App;
using Android.OS;
using Android.Runtime;
using AndroidX.AppCompat.App;
using Android.Widget;
using Android.Content;
using System;
using System.IO;
using System.Xml;
using System.Net;
using System.Text.Json;
using Xamarin.Essentials;

namespace IT123P_Machine_Problem
{
    [Activity(Label = "ReportHandler")]
    public class ReportHandler : Activity
    {
        TextView textReport, text1, text2;
        Button btnSearch, btnUpdate, btnDelete, btnReturn;
        EditText editSearch, editUpdate;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.reportHandling);
            // Create your application here

            //set values here that show up on start
            textReport = FindViewById<TextView>(Resource.Id.textReports);
            text1 = FindViewById<TextView>(Resource.Id.textView1);
        }
    }
}