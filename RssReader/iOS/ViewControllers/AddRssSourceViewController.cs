using Foundation;
using RssReader.iOS.Utils;
using RssReader.Models;
using RssReader.Services;
using System;
using UIKit;

namespace RssReader.iOS
{
    public partial class AddRssSourceViewController : UIViewController
    {
        public Action OnSuccess { get; set; }
        public AddRssSourceViewController(IntPtr handle) : base(handle)
        {

        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            btnCancel.TouchUpInside += (sender, e) =>
            {
                NavigationController.PopViewController(true);
            };

            btnOk.TouchUpInside += (sender, e) =>
              {
                  if (RssSourceService.Add(TitleTextField.Text, UrlTextField.Text, BddHelper.Instance))
                  {   
                      NavigationController.PopViewController(true);
                      OnSuccess?.Invoke();
                  }
                  else
                  {
                      var msg = NSBundle.MainBundle.GetLocalizedString("ErrorTitle", "not found");
                      this.PresentViewController(Utils.Helpers.CreatePopup(msg, "Some fields are empty !"), true, () => { });
                  }
              };
        }

    }
}