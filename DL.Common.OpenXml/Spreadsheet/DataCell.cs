namespace DL.Common.OpenXml.Spreadsheet
{
    public class DataCell
    {
        public DataCell()
        {
            this.Value = null;
        }

        public DataCell(int index, string name)
            : this()
        {
            this.ColumnIndex = index;
        }

        public int ColumnIndex { get; set; }
        public object Value { get; set; }
    }
}
