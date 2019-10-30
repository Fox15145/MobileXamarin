// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace RssReader.iOS
{
    [Register ("HomeViewController")]
    partial class HomeViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView RssSourceTableView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (RssSourceTableView != null) {
                RssSourceTableView.Dispose ();
                RssSourceTableView = null;
            }
        }
    }
}