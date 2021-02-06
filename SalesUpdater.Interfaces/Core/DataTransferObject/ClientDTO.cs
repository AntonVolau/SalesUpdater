namespace SalesUpdater.Interfaces.Core.DataTransferObject
{
    public class ClientDTO : DataTransferObject
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public ClientDTO(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }
    }
}
