
using System;

using Android.App;
using Android.Content;
using Android.OS;

namespace RssReader.Droid.Services
{
    [Service(Label = "BackgroundService")]
    [IntentFilter(new String[] { "com.yourname.BackgroundService" })]
    public class BackgroundService : Service
    {
        IBinder binder;

        public override StartCommandResult OnStartCommand(Android.Content.Intent intent, StartCommandFlags flags, int startId)
        {
            // start your service logic here
            var notification = new Notification.Builder(this)
                .SetContentTitle("hello")
                .SetContentText("C'est good !!")
                .SetSmallIcon(Resource.Mipmap.Icon)
                //.SetActions(new Action(() => { })
                .Build();

            var notificationManager = this.GetSystemService(Context.NotificationService) as NotificationManager;
            notificationManager.Notify(0, notification);

            // Return the correct StartCommandResult for the type of service you are building
            return StartCommandResult.NotSticky;
        }

        public override IBinder OnBind(Intent intent)
        {
            binder = new BackgroundServiceBinder(this);
            return binder;
        }
        public override void OnDestroy()
        {
            var alarm = (AlarmManager)GetSystemService(Context.AlarmService);
            var startTime = Java.Lang.JavaSystem.CurrentTimeMillis() + (60 * 1000);

            alarm.Set(AlarmType.RtcWakeup,
                startTime,
                PendingIntent
                .GetService(this, 0, new Intent(this, typeof(BackgroundService)), PendingIntentFlags.UpdateCurrent));
            //base.OnDestroy();
        }
    }

    public class BackgroundServiceBinder : Binder
    {
        readonly BackgroundService service;

        public BackgroundServiceBinder(BackgroundService service)
        {
            this.service = service;
        }

        public BackgroundService GetBackgroundService()
        {
            return service;
        }
    }

       
}
