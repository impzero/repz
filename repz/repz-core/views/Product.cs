namespace repz_core.views
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public Product(int iD, string name)
        {
            ID = iD;
            Name = name;
        }
    }
}
