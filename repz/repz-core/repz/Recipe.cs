
namespace repz_core.repz
{
    public class Recipe
    {
        private int _id;
        private string _title;
        private string _description;
        private bool _approved;

        public int ID { get => _id; set => _id = value; }
        public string Title { get => _title; set => _title = value; }
        public string Description { get => _description; set => _description = value; }
        public bool Approved { get => _approved; set => _approved = value; }

        public Recipe(int id, string title, string description, bool approved)
        {
            _id = id;
            _title = title;
            _description = description;
            _approved = approved;
        }
    }
}
