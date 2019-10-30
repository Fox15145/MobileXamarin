
using Android.App;
using Android.Views;
using Android.Widget;
using RssReader.Models;
using System.Collections.Generic;

namespace RssReader.Droid.Adapters
{
    public class HomeEditViewAdapter : BaseAdapter<RssReader.Models.RssSource>
    {
        private readonly Activity _Context;
        private List<RssSource> Items;

        public HomeEditViewAdapter(Activity context, List<RssSource> rssSources)
        {
            _Context = context;
            Items = rssSources;
        }

        public override RssSource this[int position] => Items[position];

        public override int Count => Items.Count;

        public override long GetItemId(int position) => Items[position].Id;

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var elt = Items[position];

            // pour le recyclage : "convertView ??" et le "false"
            var view = convertView ?? _Context.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem2, parent, false);

            var textview_Title = view.FindViewById<TextView>(Android.Resource.Id.Text1);
            var textview_Url = view.FindViewById<TextView>(Android.Resource.Id.Text2);

            textview_Title.Text = elt.Title;
            textview_Url.Text = elt.Url;

            return view;
        }    

        public void Notify(List<RssSource> rssSources)
        {
            Items = rssSources;
            this.NotifyDataSetChanged();
        }
    }
}
