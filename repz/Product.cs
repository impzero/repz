using System;

public class Product
{
    private int _id;
    private string _name;

    public int ID { get => _id; set => _id = value; }
    public int Name { get => _name; set => _name = value; }

    public Product(int id, string name)
    {
        this._id = id;
        this._name = name;
    }
}
