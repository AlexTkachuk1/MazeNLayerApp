namespace NLayerApp.DAL_.Entities
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual Hero Hero { get; set; }
    }
}
