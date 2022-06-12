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
    [Activity(Label = "SendingPage")]
    public class SendingPage : Activity
    {
        EditText editMessage,editUsername;
        Button btnSubmit,btnBack;
        HttpWebResponse response;
        HttpWebRequest request;
        String message = "", username = "", res = "", str = "", login_name = "";

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            //set layout
            SetContentView(Resource.Layout.SendingPage_Layout);//The layout is not yet created
            //get name of who login through Intent
            login_name = Intent.GetStringExtra("Name");
            //instantiate widgets
            editUsername= FindViewById<EditText>(Resource.Id.editText1);
            editMessage = FindViewById<EditText>(Resource.Id.editText2);
            btnSubmit = FindViewById<Button>(Resource.Id.button1);
            btnHome = FindViewById<Button>(Resource.Id.button1);
            btnHome.Click += this.Back_LandingPage;
            btnSubmit.Click += this.AddMessage;
        }
        
        public void Back_LandingPage(object sender, EventArgs e)//Back to Landing Page
        {
            Intent i = new Intent(this, typeof(LandingPage));
            StartActivity(i);
        }

        public void AddMessage(object sender, EventArgs e)
        {
            message = editMessage.Text;
            username = editUsername.Text;
           
            
            var checkif = checkif_blank();
            if (checkif)
            {
                request = (HttpWebRequest)WebRequest.Create("http://192.168.0.110:8080/IT140P/REST/add_message.php?name=" + message + " &username=" + username);
                response = (HttpWebResponse)request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                res = reader.ReadToEnd();
                Toast.MakeText(this, res, ToastLength.Long).Show();
                //Clear once the user submitted a message
                Clear();
            }
            else
            {
                Toast.MakeText(this,"Please fill out all forms!",ToastLength.Long).Show();
            }
        }
        
        public bool checkif_blank()
        {
            if(editMessage.Text == "" ||
                editUsername.Text == "")
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
            editMessage.Text = "";
            editUsername.Text = "";
        }


     

       
    }
}