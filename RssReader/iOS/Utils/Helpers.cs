using System;
using UIKit;
namespace RssReader.iOS.Utils
{
    public static class Helpers
    {
        public static UIAlertController CreatePopup( string title, string message)
        {
            var alert = UIAlertController.Create(title,
                        message,
                        UIAlertControllerStyle.Alert);

            alert.AddAction(UIAlertAction.Create("Ok",
              UIAlertActionStyle.Default,
              (a) => { }));

            return alert;
        }
    }
}
