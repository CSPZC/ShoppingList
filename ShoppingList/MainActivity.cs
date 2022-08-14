namespace ListSectionHeader
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            List<ItemModel> itemsList = new List<ItemModel>();
            ListView list = FindViewById<ListView>(Resource.Id.listview);
            itemsList = sortAndAddSections(getItems());
            ListAdapter adapter = new ListAdapter(this, this, itemsList);
            list.Adapter = adapter;
        }
        private List<ItemModel> sortAndAddSections(List<ItemModel> itemList)
        {
            List<ItemModel> tempList = new List<ItemModel>();
            var q = itemList.OrderByDescending(x => x.date).ToList();
            string header = string.Empty;
            for (int i = 0; i < q.Count; i++)
            {
                if (!header.Equals(q[i].date.ToString("dd.MM.yyyy")))
                {
                    ItemModel sectionCell = new ItemModel(null, null, null, q[i].date);
                    sectionCell.setToSectionHeader();
                    tempList.Add(sectionCell);
                    header = q[i].date.ToString("dd.MM.yyyy");
                }
                tempList.Add(q[i]);
            }
            return tempList;
        }
        private List<ItemModel> getItems()
        {
            List<ItemModel> items = new List<ItemModel>();
            items.Add(new ItemModel("10:30", "140/75", "80", DateTime.Parse("28.01.2020")));
            items.Add(new ItemModel("13:30", "130/75", "75", DateTime.Parse("28.01.2020")));
            items.Add(new ItemModel("16:30", "150/80", "70", DateTime.Parse("28.01.2020")));
            items.Add(new ItemModel("10:30", "120/90", "80", DateTime.Parse("29.01.2020")));
            items.Add(new ItemModel("20:30", "120/90", "50", DateTime.Parse("29.01.2020")));
            items.Add(new ItemModel("10:30", "120/10", "80", DateTime.Parse("31.01.2020")));
            items.Add(new ItemModel("12:30", "142/95", "95", DateTime.Parse("31.01.2020")));
            items.Add(new ItemModel("15:30", "120/95", "200", DateTime.Parse("31.01.2020")));
            return items;
        }
    }
}