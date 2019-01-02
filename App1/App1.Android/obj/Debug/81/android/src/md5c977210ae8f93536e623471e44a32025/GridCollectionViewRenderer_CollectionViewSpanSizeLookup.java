package md5c977210ae8f93536e623471e44a32025;


public class GridCollectionViewRenderer_CollectionViewSpanSizeLookup
	extends android.support.v7.widget.GridLayoutManager.SpanSizeLookup
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_getSpanSize:(I)I:GetGetSpanSize_IHandler\n" +
			"";
		mono.android.Runtime.register ("AiForms.Renderers.Droid.GridCollectionViewRenderer+CollectionViewSpanSizeLookup, CollectionView.Droid", GridCollectionViewRenderer_CollectionViewSpanSizeLookup.class, __md_methods);
	}


	public GridCollectionViewRenderer_CollectionViewSpanSizeLookup ()
	{
		super ();
		if (getClass () == GridCollectionViewRenderer_CollectionViewSpanSizeLookup.class)
			mono.android.TypeManager.Activate ("AiForms.Renderers.Droid.GridCollectionViewRenderer+CollectionViewSpanSizeLookup, CollectionView.Droid", "", this, new java.lang.Object[] {  });
	}

	public GridCollectionViewRenderer_CollectionViewSpanSizeLookup (md5c977210ae8f93536e623471e44a32025.GridCollectionViewRenderer p0)
	{
		super ();
		if (getClass () == GridCollectionViewRenderer_CollectionViewSpanSizeLookup.class)
			mono.android.TypeManager.Activate ("AiForms.Renderers.Droid.GridCollectionViewRenderer+CollectionViewSpanSizeLookup, CollectionView.Droid", "AiForms.Renderers.Droid.GridCollectionViewRenderer, CollectionView.Droid", this, new java.lang.Object[] { p0 });
	}


	public int getSpanSize (int p0)
	{
		return n_getSpanSize (p0);
	}

	private native int n_getSpanSize (int p0);

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
