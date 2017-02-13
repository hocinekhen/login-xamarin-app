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

namespace login_xamarin_app
{
    [Activity(Label = "WelcomeActivity")]
    public class WelcomeActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.welcomeLayout);
            string username = Intent.GetStringArrayListExtra("userInfo")[0];
            string password = Intent.GetStringArrayListExtra("userInfo")[1];
            FindViewById<TextView>(Resource.Id.welcomeTxt).Text = "Welcome " + username + " !!\n" + "your password is " + password;
        }
    }
}