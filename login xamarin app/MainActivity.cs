using Android.App;
using Android.Widget;
using Android.OS;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
using Android.Content;

namespace login_xamarin_app
{
    [Activity(Label = "goup", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

             SetContentView (Resource.Layout.Main);
            
            EditText usernameTxt = FindViewById<EditText>(Resource.Id.UserNameTxt);
            EditText passwordTxt = FindViewById<EditText>(Resource.Id.PasswordTxt);
            Button loginBtn = FindViewById<Button>(Resource.Id.loginBtn);
            List<User> users = new List<User>();
            users.Add(new User { name = "hocine", password = "123456" });
            users.Add(new User { name = "karim", password = "aa112" });
            users.Add(new User { name = "alaa", password = "s125" });
            users.Add(new User { name = "amal", password = "tr1542" });
            loginBtn.Click += delegate 
            {
                try
                {

                
                string username = usernameTxt.Text;
                IEnumerable<User> userQuery = from User in users where User.name == username select User;
                if (userQuery.Count<User>()!=0)
                {
                  User user=  userQuery.ElementAt<User>(0);
                    if (passwordTxt.Text==user.password)
                    {
                        Toast.MakeText(this, "loged in", ToastLength.Short).Show();
                        Intent inte = new Intent(this, typeof(WelcomeActivity));
                        inte.PutStringArrayListExtra("userInfo", new List<string> { user.name, user.password });
                        StartActivity(inte);
                    }
                     else
                     {
                            Toast.MakeText(this, "incorrect password try again", ToastLength.Short).Show();
                     }
                }
                    else
                    {
                        Toast.MakeText(this, "user name does not exist", ToastLength.Short).Show();
                    }
                }
                catch 
                {

                    Toast.MakeText(this, "invalid informations", ToastLength.Short).Show();
                }

            };
        }

        
    }
}

