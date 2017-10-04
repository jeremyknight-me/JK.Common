namespace DL.Common.OpenXml.Spreadsheet
{
    public class DataColumn
    {
        protected internal DataColumn(int index, string name)
        {
            this.Index = index;
            this.Name = name;
        }

        public int Index { get; private set; }
        public string Name { get; private set; }
    }
}
