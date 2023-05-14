namespace MyShop.Web.API.Models
{
    public class Audit
    {
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public Guid CreatedBY { get; set; }
        public Guid UpdatedBy { get; set; }
    }
}
