using System.ComponentModel.DataAnnotations;
namespace MyBookApp.Models
{
    public class Bookmodel
    {
        public int Id { get; set; }
        [StringLength(50, MinimumLength = 5)]

        [Required(ErrorMessage = "please enter the title of your book")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "please enter the Author Name")]
        public string Author { get; set; } = string.Empty;
        [StringLength(100)]
        [Required(ErrorMessage = "please enter the Description of your book")]
        public string Description { get; set; } = string.Empty;

        [Required  (ErrorMessage = "please enter the book Categories")]
        public string Category { get; set; }= string.Empty;

        [Required (ErrorMessage = "please enter the language of your book")]

        [Display(Name = "Book Language")]
        public int LanguageId{ get; set; }
        public string? language { get; set; } = string.Empty;
        [Required(ErrorMessage = "please enter the total page of your book")]
        public int TotalPages { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        [Display(Name ="please upload a cover photo of your book")]
        [Required]
        public IFormFile CoverPhoto { get; set; }

        public string? CoverImageUrl { get; set; } = string.Empty;

        [Display(Name = "please upload your your book gallery")]
        [Required]
        public IFormFileCollection Galleryfiles{ get; set; }

        public List<GalleryModel>Gallery { get; set; } = new List<GalleryModel>();


        [Display(Name = "please upload your book in pdf format")]
        [Required]

        public IFormFile Bookpdf { get; set; }

        public string? BookpdfUrl { get; set; } = string.Empty;
    }
}
