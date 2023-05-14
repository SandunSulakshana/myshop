namespace MyShop.Web.API.Models
{
    public class Product : Audit
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal CostPrice { get; set; }
        public decimal UnitPrice { get; set; }
        public int OederAfter { get; set; }

    }
}
