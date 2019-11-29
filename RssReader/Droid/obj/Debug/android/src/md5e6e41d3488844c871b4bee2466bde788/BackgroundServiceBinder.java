package md5e6e41d3488844c871b4bee2466bde788;


public class BackgroundServiceBinder
	extends android.os.Binder
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("RssReader.Droid.Services.BackgroundServiceBinder, RssReader.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", BackgroundServiceBinder.class, __md_methods);
	}


	public BackgroundServiceBinder ()
	{
		super ();
		if (getClass () == BackgroundServiceBinder.class)
			mono.android.TypeManager.Activate ("RssReader.Droid.Services.BackgroundServiceBinder, RssReader.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

	public BackgroundServiceBinder (md5e6e41d3488844c871b4bee2466bde788.BackgroundService p0)
	{
		super ();
		if (getClass () == BackgroundServiceBinder.class)
			mono.android.TypeManager.Activate ("RssReader.Droid.Services.BackgroundServiceBinder, RssReader.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "RssReader.Droid.Services.BackgroundService, RssReader.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", this, new java.lang.Object[] { p0 });
	}

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
