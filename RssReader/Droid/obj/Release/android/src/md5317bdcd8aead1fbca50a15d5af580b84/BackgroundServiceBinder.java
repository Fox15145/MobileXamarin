package md5317bdcd8aead1fbca50a15d5af580b84;


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
		mono.android.Runtime.register ("RssReader.Droid.Services.BackgroundServiceBinder, RssReader.Droid", BackgroundServiceBinder.class, __md_methods);
	}


	public BackgroundServiceBinder ()
	{
		super ();
		if (getClass () == BackgroundServiceBinder.class)
			mono.android.TypeManager.Activate ("RssReader.Droid.Services.BackgroundServiceBinder, RssReader.Droid", "", this, new java.lang.Object[] {  });
	}

	public BackgroundServiceBinder (md5317bdcd8aead1fbca50a15d5af580b84.BackgroundService p0)
	{
		super ();
		if (getClass () == BackgroundServiceBinder.class)
			mono.android.TypeManager.Activate ("RssReader.Droid.Services.BackgroundServiceBinder, RssReader.Droid", "RssReader.Droid.Services.BackgroundService, RssReader.Droid", this, new java.lang.Object[] { p0 });
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
