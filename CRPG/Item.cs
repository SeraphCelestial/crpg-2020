using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRPG
{
    public class Item
    {
        public int ID;
        public string Name;
        public string NamePlural;

        public Item(int iD, string name, string namePlural)
        {
            ID = iD;
            Name = name;
            NamePlural = namePlural;
        }

        public Item()
        {

        }
    }
}
