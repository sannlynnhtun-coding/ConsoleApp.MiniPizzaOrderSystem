class Pizza
{
    public string Name { get; }
    public double Price { get; }
    public List<Extra> Extras { get; } = new List<Extra>();

    public Pizza(string name, double price)
    {
        Name = name;
        Price = price;
    }
}
