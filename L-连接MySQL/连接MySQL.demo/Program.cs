// See https://aka.ms/new-console-template for more information
using System.Data;
using MySqlConnector;
using 连接MySQL.demo;

Console.WriteLine("Hello, World!");

using var connection = new MySqlConnection
    ("Server=192.168.137.205;User ID=holvon;Password=qwe123456;Database=sql_invoicing");
connection.Open();

using var command = new MySqlCommand
    //("CALL `GET_RISK_FACTOR`();", connection);
    ("SELECT * FROM clients;", connection);

MySqlDataReader? reader = command.ExecuteReader();
while (reader.Read())
    //Console.WriteLine(reader.GetString(0));
    ReadSingleRow((IDataRecord)reader);
//TableToConsole.PrintTable(reader.GetSchemaTable());
reader.Close();

MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter();
mySqlDataAdapter.SelectCommand = command;

DataTable t = new();
mySqlDataAdapter.Fill(t);
TableToConsole.PrintTable(t);

static void ReadSingleRow(IDataRecord record)
{
    List<string> list = new();
    for (int j = 0; j < record.FieldCount; j++)
    {
        list.Add(record[j].ToString() + ",");
    }
    foreach (string s in list)
    { Console.Write(s); }
    Console.WriteLine("");
    //Console.WriteLine(String.Format("{0}, {1}", record[0], record[1]));
}