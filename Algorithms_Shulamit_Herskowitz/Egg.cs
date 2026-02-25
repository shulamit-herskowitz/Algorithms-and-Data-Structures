using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms_Shulamit_Herskowitz
{
    internal class Egg
    {
        [Flags]
        public enum Content { Toy = 1, Sticker = 2, Both = 3 };
        public Content EggContent { get; set; }

        public Egg(Content content)
        {
            this.EggContent = content;
        }
    }
}
