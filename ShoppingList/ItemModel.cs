namespace ListSectionHeader
{
    public class ItemModel : Java.Lang.Object
    {
        public bool isSectionHeader { get; set; } // Назначается ли заголовок
        public string itemTime { get; set; } // Время
        public string itemSysDia { get; set; } // Давление
        public string itemPulse { get; set; } // Пульс
        public DateTime date { get; set; } // Дата
        public ItemModel(string itemTime, string itemSysDia, string itemPulse, DateTime date)
        {
            this.itemTime = itemTime;
            this.itemSysDia = itemSysDia;
            this.itemPulse = itemPulse;
            this.date = date;
            isSectionHeader = false;
        }
        public void setToSectionHeader()
        {
            this.isSectionHeader = true;
        }
    }
    public class ListAdapter : ArrayAdapter
    {
        private Activity activity;
        public ListAdapter(Activity activity, Context context, List<ItemModel> items)
        : base(context, 0, items)
        {
            this.activity = activity;
        }
        public override Android.Views.View GetView(int position, Android.Views.View
        convertView, Android.Views.ViewGroup parent)
        {
            View v = convertView;
            var item = (ItemModel)this.GetItem(position);
            if (item.isSectionHeader)
            {
                v = activity.LayoutInflater.Inflate(Resource.Layout.section_header, null);
                v.Clickable = false;
                TextView title = v.FindViewById<TextView>(Resource.Id.section_title);
                title.Text = item.date.ToString("dddd, dd.MM.yyyy");
            }
            else
            {
                v = activity.LayoutInflater.Inflate(Resource.Layout.row_item, null);
                TextView txt_time = v.FindViewById<TextView>(Resource.Id.txt_time);
                TextView txt_item_sysdia =
                v.FindViewById<TextView>(Resource.Id.txt_item_sysdia);
                TextView txt_item_puls = v.FindViewById<TextView>(Resource.Id.txt_item_puls);
                txt_time.Text = item.itemTime;
                txt_item_sysdia.Text = item.itemSysDia;
                txt_item_puls.Text = item.itemPulse;
            }
            return v;
        }
    }
}