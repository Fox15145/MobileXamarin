package md5f5f9d55b194f082bf0498ff347104a20;


public class AddRssSourceActivity
	extends android.support.v7.app.AppCompatActivity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("RssReader.Droid.Activities.AddRssSourceActivity, RssReader.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", AddRssSourceActivity.class, __md_methods);
	}


	public AddRssSourceActivity ()
	{
		super ();
		if (getClass () == AddRssSourceActivity.class)
			mono.android.TypeManager.Activate ("RssReader.Droid.Activities.AddRssSourceActivity, RssReader.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

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
