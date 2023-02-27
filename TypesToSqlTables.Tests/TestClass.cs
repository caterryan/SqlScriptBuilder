namespace TypesToSqlTables.Tests;

public class TestTypeToTable
{
    public bool TestBoolToBoolean { get; set; }
    public short TestShortToSmallint { get; set; }
    public int TestIntToInteger { get; set; }
    public long TestLongToBigint { get; set; }
    public float TestFloatToReal { get; set; }
    public double TestDoubleToDoublePrecision { get; set; }
    public decimal TestDecimalToNumeric { get; set; }
    public string TestStringToText { get; set; }
    public byte[] TestByteArrayToBytea { get; set; }
    public ComplexType TestComplexType { get; set; }
}

public class ComplexType
{
    public string TestComplexTypeData { get; set; }
}
