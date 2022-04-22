namespace repz_core.views
{
    public class RecipeTitle
    {

        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public RecipeTitle(int id, string title, string description)
        {
            ID = id;
            Title = title;
            Description = description;
        }
    }
}
