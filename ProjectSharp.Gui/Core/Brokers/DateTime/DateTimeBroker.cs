namespace ProjectSharp.Gui.Core.Brokers.DateTime;

public class DateTimeBroker : IDateTimeBroker
{
    public DateTimeOffset TimeNow()
    {
        return DateTimeOffset.Now;
    }
}