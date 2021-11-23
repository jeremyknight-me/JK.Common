using System;

namespace JK.Common.Geospatial;

public class CoordinateFactory
{
    public CoordinateBase Make(in CoordinateType coordinateType)
        => coordinateType switch
        {
            CoordinateType.Latitude => new Latitude(),
            CoordinateType.Longitude => new Longitude(),
            _ => throw new ArgumentOutOfRangeException(nameof(coordinateType)),
        };
}
