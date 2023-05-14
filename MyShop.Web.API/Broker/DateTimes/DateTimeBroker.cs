namespace MyShop.Web.API.Broker.DateTimes
{
    public class DateTimeBroker : IDateTimeBroker
    {
        public DateTimeOffset GetCurrentDateTime() => DateTime.UtcNow;
    }
}
