namespace MVC_webapi.Models.Entities
{
    public class Cages
    {
        public Guid Id { get; set; }
        public short? Size { get; set; }

        private List<Birds> _birds = new();
        public IReadOnlyCollection<Birds> Birds => _birds.AsReadOnly();
        public Cages()
        {
            
        }
        public Cages(short size = 10)
        {
            Size = size;
        }
        public IEnumerable<Birds> getAllInCage() => _birds;
        public void PutInCage(Birds bird) => _birds.Add(bird);
    }
}
