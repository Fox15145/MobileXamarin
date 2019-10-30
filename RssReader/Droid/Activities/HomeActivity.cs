
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using RssReader.Droid.Adapters;
using RssReader.Droid.Helpers;
using RssReader.Droid.Services;
using RssReader.Models;

namespace RssReader.Droid.Activities
{
    [Activity(Label = "HomeActivity", MainLauncher = true)]
    public class HomeActivity : AppCompatActivity
    {
        HomeEditViewAdapter RssSourceAdapter;
        public const int C_RSS_SOURCE_REQUEST_RESULT = 10;

        public const string C_TITLE_NAME = "GET_EDIT_TITLE";
        public const string C_URL_NAME = "GET_EDIT_TITLE";
        public const string C_ARTICLE_URL = "SHOW_ARTICLE";


        ListView Home_RssSourceListView;
        FloatingActionButton btnAdd;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Home);
            btnAdd = FindViewById<FloatingActionButton>(Resource.Id.Home_btnAdd);
            Home_RssSourceListView = FindViewById<ListView>(Resource.Id.Home_RssSourceListView);


            RefresDataListView();

            btnAdd.Click +=(sender, e) =>
            {
                var intent = new Intent(this, typeof(AddRssSourceActivity));
                this.StartActivityForResult(intent, C_RSS_SOURCE_REQUEST_RESULT);
            }; 

            Home_RssSourceListView.ItemClick += (sender, e) =>
            {
                var intent = new Intent(this, typeof(RssArticleListActivity));

                var SelectedPosition = e.Position;
                var selectedItem = RssSourceAdapter[SelectedPosition];

                intent.PutExtra(C_ARTICLE_URL, selectedItem.Id);
                this.StartActivity(intent);
            };
            //Ajout de la liste view en tant que composant où le context menu sera généré
            RegisterForContextMenu(Home_RssSourceListView);

            StartService(new Intent(this, typeof(BackgroundService)));
        }

        private const int C_DELETE_ITEM_ID = 0;
        public override void OnCreateContextMenu(IContextMenu menu, View v, IContextMenuContextMenuInfo menuInfo)
        {
            if (v is ListView)
            {
                menu.Add(0, C_DELETE_ITEM_ID, 0, "Delete");
            }
            base.OnCreateContextMenu(menu, v, menuInfo);

        }

        public override bool OnContextItemSelected(IMenuItem item)
        {
            if (item.ItemId == C_DELETE_ITEM_ID)
            {
                var index = ((AdapterView.AdapterContextMenuInfo)item.MenuInfo).Position;
                var SelectedRssSource = RssSourceAdapter[index];

                BddHelper.Instance.Delete(SelectedRssSource.Id);

                RefresDataListView();

                return true;
            }
            return base.OnContextItemSelected(item);
        }

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            if ((requestCode == C_RSS_SOURCE_REQUEST_RESULT) && (resultCode == Result.Ok))
            {
                RefresDataListView();
            }
        }

        protected void RefresDataListView()
        {
            List<RssSource> myList = BddHelper.Instance.GetAll().ToList();

            if (Home_RssSourceListView.Adapter == null)
            {
                RssSourceAdapter = new HomeEditViewAdapter(this, myList);
                Home_RssSourceListView.Adapter = RssSourceAdapter;
            }
            else
                RssSourceAdapter.Notify(myList);
        }
    }
}
