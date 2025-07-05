using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace JK.Common.Tests;

public class SimpleObject
{
    [XmlElement(Order = 1)]
    public int Id { get; set; }

    [XmlElement(Order = 2)]
    public string Title { get; set; }

    public static IEnumerable<SimpleObject> GetMockDataSet(int number = 5)
    {
        List<SimpleObject> list = [];
        for (var i = 0; i < number; i++)
        {
            var id = i + 1;
            var item = new SimpleObject { Id = id, Title = string.Concat("Title ", id) };
            list.Add(item);
        }

        return list;
    }

    public static IQueryable<SimpleObject> GetMockDataSetAsQueryable(int number = 5)
        => GetMockDataSet(number).AsQueryable();
}
