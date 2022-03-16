namespace repz_core.views
{
    public class RecipeTitle
    {

        public int ID { get; set; }
        public string Title { get; set; }

        public RecipeTitle(int iD, string title)
        {
            ID = iD;
            Title = title;
        }
    }
}
