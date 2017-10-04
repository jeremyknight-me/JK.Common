using System;
using System.Collections.Generic;
using System.Linq;

namespace DL.Common.OpenXml.Spreadsheet
{
    public class DataRow
    {
        private readonly List<DataCell> cells;
        private readonly DataTable table;

        protected internal DataRow(DataTable dataTable)
        {
            this.table = dataTable;
            this.cells = new List<DataCell>();
            foreach (var column in dataTable.Columns)
            {
                this.cells.Add(new DataCell(column.Index, column.Name));
            }
        }

        public object this[string columnName]
        {
            get
            {
                var column = this.table.Columns.SingleOrDefault(x => x.Name == columnName);
                if (column == null)
                {
                    throw new IndexOutOfRangeException();
                }
                
                return this.cells.Single(x => x.ColumnIndex == column.Index).Value;
            }
            set
            {
                var column = this.table.Columns.SingleOrDefault(x => x.Name == columnName);
                if (column == null)
                {
                    throw new IndexOutOfRangeException();
                }

                this.cells.Single(x => x.ColumnIndex == column.Index).Value = value;
            }
        }

        public object this[int index]
        {
            get
            {
                if (this.cells.All(x => x.ColumnIndex != index))
                {
                    throw new IndexOutOfRangeException();
                }

                return this.cells.Single(x => x.ColumnIndex == index).Value;
            }
            set
            {
                if (this.cells.All(x => x.ColumnIndex != index))
                {
                    throw new IndexOutOfRangeException();
                }

                this.cells.Single(x => x.ColumnIndex == index).Value = value;
            }
        }
    }
}
