namespace MyShop.Web.API.Models
{
    public class Audit
    {
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset Updated { get; set; }
        public Guid CreatedBY { get; set; }
        public Guid UpdatedBy { get; set; }
    }
}
