package md5c977210ae8f93536e623471e44a32025;


public class HCollectionViewAdapter
	extends md5c977210ae8f93536e623471e44a32025.CollectionViewAdapter
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_getItemCount:()I:GetGetItemCountHandler\n" +
			"";
		mono.android.Runtime.register ("AiForms.Renderers.Droid.HCollectionViewAdapter, CollectionView.Droid", HCollectionViewAdapter.class, __md_methods);
	}


	public HCollectionViewAdapter ()
	{
		super ();
		if (getClass () == HCollectionViewAdapter.class)
			mono.android.TypeManager.Activate ("AiForms.Renderers.Droid.HCollectionViewAdapter, CollectionView.Droid", "", this, new java.lang.Object[] {  });
	}


	public int getItemCount ()
	{
		return n_getItemCount ();
	}

	private native int n_getItemCount ();

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
