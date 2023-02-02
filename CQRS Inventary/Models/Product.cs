using System.ComponentModel.DataAnnotations;

namespace CQRS_Inventary.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Display(Name = "Name")]
        [Required]
        [StringLength(255)]
        public string ProductName { get; set; }

        [Display(Name = "Expiration Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [Required]
        public DateTime ProductExpirationDate { get; set; }

        [Display(Name = "Type")]
        [Required]
        public string ProductType { get; set; }

        [Display(Name = "Net Price")]
        [Required]
        public double ProductNetPrice { get; set; }

        [Display(Name = "Weigth")]
        [Required]
        //The weight is measured in litres o Kilograms.
        public double ProductWeight { get; set; }

        [Display(Name = "Quantity")]
        [Required]
        [Range(1, 100)]
        public byte ProductQuantity { get; set; }
  
    }
}
