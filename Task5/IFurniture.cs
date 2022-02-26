using System;

namespace Task5
{
    public interface IFurniture : IComparable<IFurniture>
    {
        Material Material { get; set; }

        int GetPriceCoefficient();

        int CompareTo(IFurniture other);
    }
}