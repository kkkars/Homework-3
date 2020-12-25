using System;
using System.Collections.Generic;

namespace Task_2._1
{
    class ProductComparer : IEqualityComparer<Product>
    {
        public bool Equals(Product x, Product y)
        {
            if (Object.ReferenceEquals(x, y))
                return true;
            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
                return false;

            return x.Brand.ToLower() == y.Brand.ToLower() && x.Id.ToLower() == y.Id.ToLower() && x.Model.ToLower() == y.Model.ToLower() && x.Price == y.Price;
        }

        public int GetHashCode(Product obj)
        {
            if (Object.ReferenceEquals(obj, null)) return 0;

            return obj.Price.GetHashCode() ^ obj.Model.ToLower().GetHashCode() ^ obj.Brand.ToLower().GetHashCode() ^ obj.Id.ToLower().GetHashCode();
        }
    }
}
