package md5e6e41d3488844c871b4bee2466bde788;


public class BackgroundService
	extends android.app.Service
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onStartCommand:(Landroid/content/Intent;II)I:GetOnStartCommand_Landroid_content_Intent_IIHandler\n" +
			"n_onBind:(Landroid/content/Intent;)Landroid/os/IBinder;:GetOnBind_Landroid_content_Intent_Handler\n" +
			"n_onDestroy:()V:GetOnDestroyHandler\n" +
			"";
		mono.android.Runtime.register ("RssReader.Droid.Services.BackgroundService, RssReader.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", BackgroundService.class, __md_methods);
	}


	public BackgroundService ()
	{
		super ();
		if (getClass () == BackgroundService.class)
			mono.android.TypeManager.Activate ("RssReader.Droid.Services.BackgroundService, RssReader.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public int onStartCommand (android.content.Intent p0, int p1, int p2)
	{
		return n_onStartCommand (p0, p1, p2);
	}

	private native int n_onStartCommand (android.content.Intent p0, int p1, int p2);


	public android.os.IBinder onBind (android.content.Intent p0)
	{
		return n_onBind (p0);
	}

	private native android.os.IBinder n_onBind (android.content.Intent p0);


	public void onDestroy ()
	{
		n_onDestroy ();
	}

	private native void n_onDestroy ();

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
