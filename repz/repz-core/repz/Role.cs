namespace repz_core.repz
{
    public class Role
    {
        private int _id;
        private string _name;

        public int ID { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }

        public Role(int id, string name)
        {
            _name = name;
            _id = id;
        }
    }
}