namespace ProjectSharp.Api.Brokers.DateTime;

public interface IDateTimeBroker
{
    DateTimeOffset TimeNow();
}