using NpgsqlTypes;
using System.Collections;
using System.Net;
using System.Net.NetworkInformation;

namespace TypesToSqlTables.Library;

public class Constants
{

    public readonly Dictionary<Type, string> typeMap = new Dictionary<Type, string>()
    {
        // References:
        // https://www.npgsql.org/doc/types/basic.html
        // https://www.npgsql.org/doc/types/nodatime.html
        //

        { typeof(bool), "boolean" },
        { typeof(short), "smallint" },
        { typeof(int), "integer" },
        { typeof(long), "bigint" },
        { typeof(float), "real" },
        { typeof(double), "double precision" },
        { typeof(decimal), "numeric" },
        { typeof(string), "text" },
        { typeof(Guid), "uuid" },
        { typeof(byte[]), "bytea" },
        { typeof(NodaTime.Instant), "timestamp with time zone" },
        { typeof(NodaTime.LocalDateTime), "timestamp without time zone" },
        { typeof(NodaTime.LocalDate), "date" },
        { typeof(NodaTime.LocalTime), "time without time zone" },
        { typeof(NodaTime.OffsetTime), "time with timezone" },
        { typeof(NodaTime.Period), "interval" },
        { typeof(NodaTime.Interval), "tstzrange" },
        { typeof(NpgsqlRange<NodaTime.LocalDateTime>), "tsrange" },
        { typeof(NodaTime.DateInterval), "daterange" },
        { typeof(IPAddress), "inet" },
        { typeof(PhysicalAddress), "macaddr" },
        { typeof(NpgsqlTsQuery), "tsquery" },
        { typeof(NpgsqlTsVector), "tsvector" },
        { typeof(BitArray), "bit varying" },
        { typeof(NpgsqlPoint), "point" },
        { typeof(NpgsqlLSeg), "lseg" },
        { typeof(NpgsqlPath), "path" },
        { typeof(NpgsqlPolygon), "polygon" },
        { typeof(NpgsqlLine), "line" },
        { typeof(NpgsqlCircle), "circle" },
        { typeof(NpgsqlBox), "box" },
        { typeof(IDictionary<string, string>), "hstore" },
    };
}