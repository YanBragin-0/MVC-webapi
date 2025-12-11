namespace MVC_webapi.Models.Entities
{
    public class Birds
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public short CageId { get; set; }
        public string? Image {  get; set; }
        public Birds()
        {
            
        }
        public Birds(string Name,string Description, string? image)
        {
            Id = Guid.NewGuid();
            this.Name = Name;
            this.Description = Description;
            Image = image;
        }

    }
}
