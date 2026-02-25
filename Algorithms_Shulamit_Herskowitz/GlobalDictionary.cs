using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms_Shulamit_Herskowitz
{
    internal class GlobalDictionary<K, V>
    {

        private class Element
        {
            public V LocalVal { get; set; }
            public int ChangesUpdate { get; set; }

            public Element(V localVal, int changesUpdate)
            {
                this.LocalVal = localVal;
                this.ChangesUpdate = changesUpdate;
            }
        }

        private Dictionary<K, Element> dict = new Dictionary<K, Element>();
        private V publicVal;
        private int updatesPVal = 0;

        public void Set(K key, V value)
        {
            if (dict.ContainsKey(key))
            {
                dict[key].LocalVal = value;
                dict[key].ChangesUpdate = updatesPVal;
            }
            else
            {
                dict[key] = new Element(value, updatesPVal);
            }
        }

        public V Get(K key)
        {
            if (!dict.ContainsKey(key))
                if (publicVal != null)
                    return publicVal;
                else
                    throw new KeyNotFoundException("Key doesn't exist in the dictionary.");

            if (dict[key].ChangesUpdate == updatesPVal)
                return dict[key].LocalVal;
            else
                return publicVal;
        }
        public void SetAll(V value)
        {
            publicVal = value;
            updatesPVal++;
        }
    }
}
