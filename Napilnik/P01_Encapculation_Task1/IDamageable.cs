using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Napilnik.Napilnik.P01_Encapculation_Task1
{
    internal interface IDamageable
    { 
        public void AcceptDamage(int damageValue);
        public bool IsDead();
    }
}
