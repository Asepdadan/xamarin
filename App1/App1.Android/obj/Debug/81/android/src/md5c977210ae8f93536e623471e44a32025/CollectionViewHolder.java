package md5c977210ae8f93536e623471e44a32025;


public class CollectionViewHolder
	extends android.support.v7.widget.RecyclerView.ViewHolder
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("AiForms.Renderers.Droid.CollectionViewHolder, CollectionView.Droid", CollectionViewHolder.class, __md_methods);
	}


	public CollectionViewHolder (android.view.View p0)
	{
		super (p0);
		if (getClass () == CollectionViewHolder.class)
			mono.android.TypeManager.Activate ("AiForms.Renderers.Droid.CollectionViewHolder, CollectionView.Droid", "Android.Views.View, Mono.Android", this, new java.lang.Object[] { p0 });
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
