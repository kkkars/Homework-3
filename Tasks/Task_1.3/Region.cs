using System;
using System.Collections.Generic;
using System.Text;

namespace Task_1._3
{
    class Region : IRegion
    {
        private string brand;
        private string country;

        public Region(string brand, string country)
        {
            this.brand = brand;
            this.country = country;
        }

        public string Brand => brand;
        public string Country => country;

        public override int GetHashCode()
        {
            return (brand.GetHashCode() ^ country.GetHashCode());
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            Region regionObj = obj as Region;
            if (regionObj as Region == null)
                return false;

            return regionObj.Brand == this.Brand && regionObj.Country == this.Country;
        }

    }
}
