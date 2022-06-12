using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.IO;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IT123P_Machine_Problem
{
    [Activity(Label = "Register")]
    public class RegisterPage : Activity
    {
        EditText username, password;
        Button send, goback;
        HttpWebResponse response;
        HttpWebRequest request;
        string res = "", uname = "", pword = "";
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            //set layout
            SetContentView(Resource.Layout.registration);
            // Create your application here
            username = FindViewById<EditText>(Resource.Id.editText1);
            password = FindViewById<EditText>(Resource.Id.editText2);
            send = FindViewById<Button>(Resource.Id.button1);
            goback = FindViewById<Button>(Resource.Id.button2);

            goback.Click += GoBack;
        }

        public void AddMessage(object sender, EventArgs e)
        {
            string newpword = username.Text;
            string newuser = password.Text;
            //hashes new password
            Hashing h = new Hashing();
            string hashedpass = h.HashString(newpword);
            string toSend = "http://192.168.0.17/SupportApp/REST/register_account.php?username=" + newuser + "&password=" + hashedpass;

            var checkif = checkif_blank();
            if (checkif)
            {
                request = (HttpWebRequest)WebRequest.Create(toSend);
                response = (HttpWebResponse)request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                res = reader.ReadToEnd();
                Toast.MakeText(this, res, ToastLength.Long).Show();
                //Clear once the user submitted a message
                Clear();
            }
            else
            {
                Toast.MakeText(this, "Please fill all fields", ToastLength.Long).Show();
            }
        }

        public bool checkif_blank()
        {
            if (username.Text == "" ||
                password.Text == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void Clear()
        {
            username.Text = "";
            password.Text = "";
        }

        public void GoBack(object sender, EventArgs e)
        {
            Finish();
        }
    }
   
}