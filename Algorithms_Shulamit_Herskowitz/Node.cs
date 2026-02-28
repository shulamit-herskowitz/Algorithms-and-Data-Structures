using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms_Shulamit_Herskowitz
{
    internal class Node<T>
    {
        public T Value { get; set; }
        public Node<T> Next { get; set; }
    }
}
