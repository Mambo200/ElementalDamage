using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elements
{
    public struct Element : IEqualityComparer<Element>
    {
        public static Element RandomElements(int _elementNumber)
        {
            return new Element();
        }

        public bool Equals(Element x, Element y)
        {
            throw new NotImplementedException();
        }

        public int GetHashCode(Element obj)
        {
            throw new NotImplementedException();
        }
    }
}
