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
    [Register ("RssArticlesViewController")]
    partial class RssArticlesViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIActivityIndicatorView loader { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView RssArticlesTableView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (loader != null) {
                loader.Dispose ();
                loader = null;
            }

            if (RssArticlesTableView != null) {
                RssArticlesTableView.Dispose ();
                RssArticlesTableView = null;
            }
        }
    }
}