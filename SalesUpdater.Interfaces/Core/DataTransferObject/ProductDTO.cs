namespace SalesUpdater.Interfaces.Core.DataTransferObject
{
    public class ProductDTO : DataTransferObject
    {
        public string Name { get; set; }

        public ProductDTO(string name)
        {
            Name = name;
        }
    }
}
