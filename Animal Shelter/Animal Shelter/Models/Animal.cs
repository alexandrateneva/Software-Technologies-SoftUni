namespace Animal_Shelter.Models
{
    using Animal_Shelter.Helpers;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class Animal
    {
        public int AnimalId { get; set; }
        [Required(ErrorMessage = "Category is required.")]
        [DisplayName("Category")]
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }
        public string Breed { get; set; }
        [Required(ErrorMessage = "Gender is required.")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "Age is required.")]
        public string Age { get; set; }
        [Required(ErrorMessage = "Weight is required.")]
        public double Weight { get; set; }
        [Required(ErrorMessage = "Height is required.")]
        public double Height { get; set; }
        [Display(Name = "Additional Information")]
        public string AdditionalInformation { get; set; }
        [Required(ErrorMessage = "Photo is required.")]
        [Display(Name = "Photo")]
        [ImageUrlAtribute]
        public string ImageUrl { get; set; }

        public virtual Category Category { get; set; }
    }
}