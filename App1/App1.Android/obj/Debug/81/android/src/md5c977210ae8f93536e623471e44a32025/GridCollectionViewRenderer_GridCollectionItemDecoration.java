package md5c977210ae8f93536e623471e44a32025;


public class GridCollectionViewRenderer_GridCollectionItemDecoration
	extends android.support.v7.widget.RecyclerView.ItemDecoration
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_getItemOffsets:(Landroid/graphics/Rect;Landroid/view/View;Landroid/support/v7/widget/RecyclerView;Landroid/support/v7/widget/RecyclerView$State;)V:GetGetItemOffsets_Landroid_graphics_Rect_Landroid_view_View_Landroid_support_v7_widget_RecyclerView_Landroid_support_v7_widget_RecyclerView_State_Handler\n" +
			"";
		mono.android.Runtime.register ("AiForms.Renderers.Droid.GridCollectionViewRenderer+GridCollectionItemDecoration, CollectionView.Droid", GridCollectionViewRenderer_GridCollectionItemDecoration.class, __md_methods);
	}


	public GridCollectionViewRenderer_GridCollectionItemDecoration ()
	{
		super ();
		if (getClass () == GridCollectionViewRenderer_GridCollectionItemDecoration.class)
			mono.android.TypeManager.Activate ("AiForms.Renderers.Droid.GridCollectionViewRenderer+GridCollectionItemDecoration, CollectionView.Droid", "", this, new java.lang.Object[] {  });
	}

	public GridCollectionViewRenderer_GridCollectionItemDecoration (md5c977210ae8f93536e623471e44a32025.GridCollectionViewRenderer p0)
	{
		super ();
		if (getClass () == GridCollectionViewRenderer_GridCollectionItemDecoration.class)
			mono.android.TypeManager.Activate ("AiForms.Renderers.Droid.GridCollectionViewRenderer+GridCollectionItemDecoration, CollectionView.Droid", "AiForms.Renderers.Droid.GridCollectionViewRenderer, CollectionView.Droid", this, new java.lang.Object[] { p0 });
	}


	public void getItemOffsets (android.graphics.Rect p0, android.view.View p1, android.support.v7.widget.RecyclerView p2, android.support.v7.widget.RecyclerView.State p3)
	{
		n_getItemOffsets (p0, p1, p2, p3);
	}

	private native void n_getItemOffsets (android.graphics.Rect p0, android.view.View p1, android.support.v7.widget.RecyclerView p2, android.support.v7.widget.RecyclerView.State p3);

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
