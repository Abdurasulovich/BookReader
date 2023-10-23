using System.Data;
using Dapper;

namespace Bookreader.DataAccess.Handler;

public class DateonlyTypeHandler : SqlMapper.TypeHandler<DateOnly>
{
    public override DateOnly Parse(object value)
    {
        if (value is not null)
        {
            var dateTime = DateTime.Parse(value.ToString()!);
            return DateOnly.FromDateTime(dateTime);
        }
        else return new DateOnly();
    }

    public override void SetValue(IDbDataParameter parametr, DateOnly value)
    {
        parametr.Value = (object)("" + value.Year + "-" + value.Month + "-" + value.Day);
    }
}