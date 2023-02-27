using System.Reflection;
using System.Text;

namespace TypesToSqlTables.Library;

public class TypeTables
{
    private List<string> scriptsCreateTable = new List<string>();

    public List<string> ScriptsCreateTable
    {
        get { return scriptsCreateTable; }
        set { scriptsCreateTable = value; }
    }

    private List<string> scriptsAddForeignKey = new List<string>();

    public List<string> ScriptsAddForeignKey
    {
        get { return scriptsAddForeignKey; }
        set { scriptsAddForeignKey = value; }
    }

    private List<Table> tables = new List<Table>();

    public List<Table> Tables
    {
        get { return tables; }
        set { tables = value; }
    }

    public TypeTables(Assembly assembly, string schemaName)
    {
        Type[] types = assembly.GetExportedTypes();

        foreach (Type type in types)
        {
            Table table = new Table(type, schemaName);
            tables.Add(table);
        }

        BuildScriptCreateTables();
        BuildScriptAddForeignKeyScripts();
    }

    private void BuildScriptCreateTables()
    {
        foreach (Table table in Tables)
        {
            scriptsCreateTable.Add(table.BuildSqlScriptCreateTable());
        }
    }

    private void BuildScriptAddForeignKeyScripts()
    {
        foreach (Table table in Tables)
        {
            scriptsAddForeignKey.Add(BuildSqlScriptAddForeignKey(table));
        }
    }

    private string BuildSqlScriptAddForeignKey(Table table)
    {
        StringBuilder stringBuilder = new StringBuilder();

        foreach (KeyValuePair<String, Type> field in table.FieldsNameType)
        {
            foreach (Table t2 in tables)
            {
                if (field.Value.Name.ToLower() == t2.TableName)
                {
                    stringBuilder.AppendLine($"ALTER TABLE {table.SchemaName}.{table.TableName} ADD CONSTRAINT fk_{field.Key} FOREIGN KEY ({field.Key}) REFERENCES {t2.SchemaName}.{t2.TableName} (pk_{t2.TableName}_id) NOT VALID;");
                    stringBuilder.Append($"ALTER TABLE {table.SchemaName}.{table.TableName} VALIDATE CONSTRAINT fk_{field.Key};");
                }
            }
        }

        return stringBuilder.ToString();
    }

    public string CombineScripts()
    {
        StringBuilder stringBuilder = new StringBuilder();

        foreach (string script in scriptsCreateTable)
        {
            stringBuilder.AppendLine($"\n{script}");
        }

        foreach (string script in scriptsAddForeignKey)
        {
            stringBuilder.AppendLine($"\n{script}");
        }

        return stringBuilder.ToString();
    }
}