using System.Collections.Generic;
using System.Linq;

namespace JK.Common.Tests
{
    public class SimpleObject
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public static IEnumerable<SimpleObject> GetMockDataSet(int number = 5)
        {
            var list = new List<SimpleObject>();

            for (int i = 0; i < number; i++)
            {
                int id = i + 1;
                var item = new SimpleObject { Id = id, Title = string.Concat("Title ", id) };
                list.Add(item);
            }

            return list;
        }

        public static IQueryable<SimpleObject> GetMockDataSetAsQueryable(int number = 5)
        {
            return GetMockDataSet(number).AsQueryable();
        }
    }
}
