using RewindWebsite.Models;

namespace RewindWebsite.Services
{
    public interface iSeoServices
    {
        string GenerateProductSchema(Product product);
        string GenerateBreadcrumbSchema(string currentPage);
        string OptimizeMetaDescription(string description);
    }

    public class SeoService : iSeoServices
    {
        public string GenerateProductSchema(Product product)
        {
            return $@"{{
                ""@context"": ""https://schema.org"",
                ""@type"": ""Product"",
                ""name"": ""{product.name}"",
                ""description"": ""{product.SEODescription}"",
                ""image"": ""https://rewindsnacks.com{product.imageUrl}"",
                ""offers"": {{
                    ""@type"": ""Offer"",
                    ""price"": ""{product.price}"",
                    ""priceCurrency"": ""USD""
                }}
            }}";
        }

        public string GenerateBreadcrumbSchema(string currentPage)
        {
            return $@"{{
                ""@context"": ""https://schema.org"",
                ""@type"": ""BreadcrumbList"",
                ""itemListElement"": [
                    {{
                        ""@type"": ""ListItem"",
                        ""position"": 1,
                        ""name"": ""Home"",
                        ""item"": ""https://rewindsnacks.com""
                    }},
                    {{
                        ""@type"": ""ListItem"",
                        ""position"": 2,
                        ""name"": ""{currentPage}""
                    }}
                ]
            }}";
        }

        public string OptimizeMetaDescription(string description)
        {
            if (description.Length > 160)
            {
                return description.Substring(0, 157) + "...";
            }
            return description;
        }
    }
}