
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using RssReader.Droid.Adapters;
using RssReader.Droid.Helpers;
using RssReader.Models;
using RssReader.Services;

namespace RssReader.Droid.Activities
{
    [Activity(Label = "AddRssSourceActivity")]
    public class AddRssSourceActivity : AppCompatActivity
    {
        EditText EditTitle;
        EditText EditUrl;
        Button BtnOk;
        Button BtnCancel;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.AddRssSource);

            EditTitle = FindViewById<EditText>(Resource.Id.AddRssSource_TitleEditText);
            EditUrl = FindViewById<EditText>(Resource.Id.AddRssSource_UrlEditText);
            BtnOk = FindViewById<Button>(Resource.Id.AddRssSource_btnOk);
            BtnCancel = FindViewById<Button>(Resource.Id.AddRssSource_btnCancel);

            BtnOk.Click += (sender, e) => 
            {
                if (RssSourceService.Add(EditTitle.Text, EditUrl.Text, BddHelper.Instance))
                {
                    SetResult(Result.Ok);
                    //List<RssSource> data = BddHelper.Instance.GetAll());
                    //HomeEditViewAdapter.Notify(data);
                    Finish();
                }

                else
                {
                    var alert = new Android.Support.V7.App.AlertDialog.Builder(this);
                    alert
                        .SetTitle(GetString(Resource.String.add_error_title))
                    .SetMessage("Some fields are empty")
                        .SetPositiveButton("ok", (s1, e1) => { })
                        .Show();
                }
            };

            BtnCancel.Click += (sender, e) =>
            {
                Finish();
            };

        }
    }
}
