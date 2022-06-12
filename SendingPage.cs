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
        EditText editMessage;
        TextView User;
        Button btnSubmit,btnHome;
        HttpWebResponse response;
        HttpWebRequest request;
        String message = "", username = "", res = "", str = "", login_name = "";

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            //set layout
            SetContentView(Resource.Layout.sending);//The layout is not yet created
            //get name of who login through Intent
            login_name = Intent.GetStringExtra("Name");
            //instantiate widgets
            User= FindViewById<EditText>(Resource.Id.editText1);
            editMessage = FindViewById<EditText>(Resource.Id.editText2);
            btnSubmit = FindViewById<Button>(Resource.Id.button1);
            btnHome = FindViewById<Button>(Resource.Id.button2);
            btnHome.Click += this.Back_LandingPage;
            btnSubmit.Click += this.AddMessage;
        }
        
        public void Back_LandingPage(object sender, EventArgs e)//Back to Landing Page
        {
            Finish();
        }

        public void AddMessage(object sender, EventArgs e)
        {
            message = editMessage.Text;
            username = User.Text;
           
            
            var checkif = checkif_blank();
            if (checkif)
            {
                request = (HttpWebRequest)WebRequest.Create("http://192.168.0.17/SupportApp/REST/add_message.php?message=" + message + " &username=" + login_name);
                response = (HttpWebResponse)request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                res = reader.ReadToEnd();
                Toast.MakeText(this, res, ToastLength.Long).Show();
                //Clear once the user submitted a message
                Clear();
            }
            else
            {
                Toast.MakeText(this,"Please fill the message",ToastLength.Long).Show();
            }
        }
        
        public bool checkif_blank()
        {
            if(editMessage.Text == "" ||
                User.Text == "")
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
            User.Text = "";
        }


     

       
    }
}