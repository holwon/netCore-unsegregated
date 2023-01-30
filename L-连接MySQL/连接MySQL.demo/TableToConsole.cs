using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 连接MySQL.demo
{
    public class TableToConsole
    {

        /// <summary>
        /// Print a DataTable on to the console
        /// </summary>
        /// <param name="table">the table to be printed</param>
        public static void PrintTable(DataTable table)
        {
            // print head
            PrintLine(12 * table.Columns.Count);
            foreach (DataColumn col in table.Columns)
            {
                Console.Write(string.Format("{0,12}", col.Caption));
            }
            Console.Write("\n");
            PrintLine(12 * table.Columns.Count);

            // print rows
            for (int i = 0; i < table.Rows.Count; i++)
            {
                for (int j = 0; j < table.Columns.Count; j++)
                {
                    Console.Write(string.Format("{0,12}", table.Rows[i][j].ToString()));
                }
                Console.Write("\n");
            }
            PrintLine(12 * table.Columns.Count, "-");
        }

        /// <summary>
        /// Print a line with specific char on to the console
        /// </summary>
        /// <param name="length">count of the char to be printed</param>
        /// <param name="lineChar">the char to be printed, default is "="</param>
        private static void PrintLine(int length, string lineChar = "=")
        {
            string line = string.Empty;
            for (int i = 0; i < length; i++)
            {
                line += lineChar;
            }
            Console.WriteLine(line);
        }
    }
}
