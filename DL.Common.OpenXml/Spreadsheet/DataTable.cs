using System;
using System.Collections.Generic;
using System.Linq;

namespace DL.Common.OpenXml.Spreadsheet
{
    public class DataTable
    {
        public DataTable()
        {
            this.Columns = new List<DataColumn>();
            this.Rows = new List<DataRow>();
        }

        public string Name { get; set; }

        public IList<DataColumn> Columns { get; }

        public IList<DataRow> Rows { get; }

        public DataColumn NewColumn(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            if (this.Columns.Any(x => x.Name == name))
            {
                return null;
            }

            var count = this.Columns.Count;
            var column = new DataColumn(count, name);
            this.Columns.Add(column);
            return column;
        }

        public DataRow NewRow()
        {
            var row = new DataRow(this);
            this.Rows.Add(row);
            return row;
        }
    }
}
