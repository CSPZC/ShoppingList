namespace ShoppingList
{
	public class PurchaseAdapter : ArrayAdapter
	{
		private Activity activity;

		public PurchaseAdapter(Activity activity, Context context, int viewRecourseId, List<Purchase> objects) : base(context, viewRecourseId, objects)
		{ 
			this.activity = activity;
		}

        public override Android.Views.View GetView(int position, Android.Views.View convertView,
        Android.Views.ViewGroup parent)
        {
            var view = (convertView ?? activity.LayoutInflater.Inflate(Resource.Layout.list_item,
            parent, false)) as LinearLayout;
            ImageView picView = (ImageView)view.FindViewById<ImageView>(Resource.Id.pic);
            TextView nameView = (TextView)view.FindViewById<TextView>(Resource.Id.name);
            TextView priceView = (TextView)view.FindViewById<TextView>(Resource.Id.price);
            var item = (Purchase)this.GetItem(position);
            picView.SetImageResource(item.picResource);
            nameView.Text = item.name;
            priceView.Text = item.price.ToString("#0.00") + " руб.";
            return view;
        }
    }
}