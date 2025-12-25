using System.ComponentModel.DataAnnotations;

namespace RewindWebsite.Models
{
    public class Product
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public decimal price { get; set; }
        public string imageUrl { get; set; }
        public string category { get; set; }
        public string SEOKeywords { get; set; }
        public string SEODescription { get; set; }
        public bool isFeatured { get; set; }
        public DateTime createdDate { get; set; }
    }
}
