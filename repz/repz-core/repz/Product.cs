namespace repz_core.repz
{
    public class Product
    {
        private int _id;
        private string _name;

        public int ID { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }

        public Product(int id, string name)
        {
            _id = id;
            _name = name;
        }
    }
}
