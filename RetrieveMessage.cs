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
    [Activity(Label = "Receive A Message of Support")]
    public class RetrieveMessage : Activity
    {
        // still missing user since its testing (adjust for login)
        string user;
        TextView txtMsg, txtID;
        Button btn1, btn2, btn3;
        HttpWebResponse response;
        HttpWebRequest request;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.retrievepage);
            // page for the minimum schminimum liminum receiving page
            btn1 = FindViewById<Button>(Resource.Id.button1);
            // button 2 is report (wip since its mvps)
            btn2 = FindViewById<Button>(Resource.Id.button2);
            btn3 = FindViewById<Button>(Resource.Id.button3);   
            txtMsg = FindViewById<TextView>(Resource.Id.textView1);
            // hidden textview to store ID (for reporting)
            txtID = FindViewById<TextView>(Resource.Id.textView2);
            txtID.Visibility = Android.Views.ViewStates.Invisible;

            btn1.Click += getMessage;
            btn2.Click += reportMessage; // dont do stuff on this since not linked to login
        }

        public void getMessage(object sender, EventArgs e)
        {
            // change ip to your pc's ipv4 address when testing on your end (type ipconfig in command prompt to find it)
            // also change directory to wherever you've stored the php files
            request = (HttpWebRequest)WebRequest.Create("http://192.168.1.2/SupportApp/REST/display_message.php");
            response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            var result = reader.ReadToEnd();
            //parse result to Json then get root element
            using JsonDocument doc = JsonDocument.Parse(result);
            JsonElement root = doc.RootElement;

            try // validation to check if messagetable has values
            {
                var data = root[0];
                string message = data.GetProperty("message").ToString();
                string id = data.GetProperty("messageID").ToString();

                // set values from php
                txtMsg.Text = message;
                txtID.Text = id;
                Toast.MakeText(this, "Someone wants to tell you this...", ToastLength.Long).Show();
            } 
            catch (IndexOutOfRangeException) // error to catch if messagetable is empty
            {
                Toast.MakeText(this, "There are no messages available at the moment...", ToastLength.Long).Show();
                return;
            }
           
        }

        public void reportMessage(object sender, EventArgs e)
        {
        // since mvps i wont implement it for now
        }

        // test login (change once proper login is here)
        public void returnToLogin(object sender, EventArgs e)
        {
            Intent i = new Intent(this, typeof(MainActivity));
            StartActivity(i);
        }
    }
}