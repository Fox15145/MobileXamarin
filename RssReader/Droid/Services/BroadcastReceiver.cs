
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

namespace RssReader.Droid.Services
{
    [BroadcastReceiver]
    [IntentFilter(new String[] { 
    "android.intenet.action.BOOT_COMPLETED",
    "android.intenet.action.REBOOT" 
    })]
    public class BootBroadcastReceiver : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
            // Appel pour un service extérieur
            context.StartService(new Intent("com.yourname.BackgroundService"));

            //Toast.MakeText(context, "Received intent!", ToastLength.Short).Show();
        }
    }
}
