using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace InstructionAttrExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            new Program();
        }

        Program()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Dog1");
            dt.Columns.Add("Dog2");
            dt.Columns.Add("Cat1");
            dt.Columns.Add("Cat2");
            dt.Columns.Add("Snek");
            for (int i = 0; i < 500000; i++)
            {
                var row = dt.NewRow();
                row["Dog1"] = "Amos";
                row["Dog2"] = "Holden";
                row["Cat1"] = "Chisjen";
                row["Cat2"] = "Naomi";
                row["Snek"] = "Dawes";
                dt.Rows.Add(row);
            }
            var sw = Stopwatch.StartNew();
            var props = typeof(Pets).GetProperties().ToDictionary(k => k.Name, v=>v);
            List<Pets> pets = new List<Pets>();
            foreach (DataRow row in dt.AsEnumerable())
            {
                Pets p = new Pets();
                foreach (DataColumn column in dt.Columns)
                {
                    string valueToSave = row[column.ColumnName].ToString();
                    var potentialProp = props[column.ColumnName].GetCustomAttribute(typeof(InstructionAttribute));
                    if (potentialProp != null)
                    {
                        var attr = (InstructionAttribute)potentialProp;
                        if(attr.INSTRUCTIONS.Contains(MODIFIERS.TRIM))
                            valueToSave = valueToSave.Trim();
                        if (attr.INSTRUCTIONS.Contains(MODIFIERS.TOUPPER))
                            valueToSave = valueToSave.ToUpper();
                        if (attr.INSTRUCTIONS.Contains(MODIFIERS.TOLOWER))
                            valueToSave = valueToSave.ToLower();
                    }
                    props[column.ColumnName].SetValue(p, valueToSave);
                }
                pets.Add(p);
            }
            Console.WriteLine($"Time Taken: {sw.ElapsedMilliseconds}ms");
            _ = 999;
        }
    }
}
//7428ms with it on
//3789,s with it off.