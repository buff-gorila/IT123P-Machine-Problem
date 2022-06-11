using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using System;
using System.Net;
using System.IO;
using Android.Content;

namespace IT123P_Machine_Problem
{
    [Activity(Label = "Machine Problem", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    { 
        EditText edit1, edit2;
        Button btn1;
        HttpWebResponse response;
        HttpWebRequest request;
        string res = "", uname = "", pword = "";

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            edit1 = FindViewById<EditText>(Resource.Id.editText1);
            edit2 = FindViewById<EditText>(Resource.Id.editText2);
            btn1 = FindViewById<Button>(Resource.Id.button1);

            btn1.Click += Login;

        }

        public void Login(object sender, EventArgs e)
        {
            pword = edit2.Text;
            uname = edit1.Text;
            //Change to your ip adress and ports.
            request = (HttpWebRequest)WebRequest.Create("http://192.168.0.110:8080/IT123P/REST/admin_login.php?uname=" + uname + " &pword=" + pword);
            request.Proxy = null;
            request.Timeout = 2000;
            response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            res = reader.ReadToEnd();
            Toast.MakeText(this, res, ToastLength.Long).Show();

            if (res.Contains("OK!"))
            {
                Intent i = new Intent(this, typeof(LandingPage));
                i.PutExtra("Name", uname);  //baka gamitin ung name sa kabilang Activity
                StartActivity(i);
            }
        }



        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}