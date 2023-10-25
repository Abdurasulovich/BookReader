using Bookreader.DataAccess.Handler;
using Dapper;
using Npgsql;

namespace Bookreader.DataAccess.Repositories;

public class BaseRepository
{
    protected readonly NpgsqlConnection _connection;

    public BaseRepository()
    {
        SqlMapper.AddTypeHandler(new DateonlyTypeHandler());
        Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
        this._connection = new NpgsqlConnection("Host=localhost; Port=5432; Database=Bookreader; User Id = postgres; Password=java2001;");
    }
}