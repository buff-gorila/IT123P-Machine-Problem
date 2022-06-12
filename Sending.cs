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
using System.Net;
using System.IO;

namespace IT123P_Machine_Problem
{
    [Activity(Label = "Sending")]
    public class Sending : Activity
    {
        string login_name, res="";
        EditText messageToSend;
        Button sendButton, returnButton;
        HttpWebResponse response;
        HttpWebRequest request;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.sending);
            // Create your application here
            login_name = Intent.GetStringExtra("Name");

            messageToSend = FindViewById<EditText>(Resource.Id.editText1);
            sendButton = FindViewById<Button>(Resource.Id.button1);
            returnButton = FindViewById<Button>(Resource.Id.button2);

            sendButton.Click += (o, i) =>
             {
                 //sendButton_Click(sender, EventArgs, );
             };
            returnButton.Click += (o, i) =>
            {
                Finish();
            };
        }

        void sendButton_Click(object sender, EventArgs e, string name)
        {
            string message = messageToSend.Text;
            //string name = ;
            if (message == "")
            {
                Toast.MakeText(this, "Please enter a message", ToastLength.Long).Show();
            }
            else
            {
                request = (HttpWebRequest)WebRequest.Create("http://192.168.0.17/SupportApp/REST/add_message.php?message=" + message + " &username=" + login_name);
                request.Timeout = 2000;
                response = (HttpWebResponse)request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                res = reader.ReadToEnd();
                Toast.MakeText(this, res, ToastLength.Long).Show();
                //Finish();
            }
        }
}