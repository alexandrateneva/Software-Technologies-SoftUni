namespace Animal_Shelter.Models
{
    using System.Collections.Generic;

    public partial class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public List<Animal> Animals { get; set; }
    }
}