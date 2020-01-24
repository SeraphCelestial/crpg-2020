using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRPG
{
    public class Weapon : Item
    {
        public int MaximumDamage;
        public int MinimumDamage;

        public Weapon(int id, string name, string namePlural, int minimumDamage, int maximumDamage) : base(id, name, namePlural)
        {
            MaximumDamage = maximumDamage;
            MinimumDamage = minimumDamage;
        }

    }
}
