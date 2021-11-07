using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Entities.Perks
{
    public enum GunType
    {
        Auto, Burst, Semi, Cylinder, SlidingShutter, EnergyGun
    }

    public enum PerkKind
    {
        // Shoot and Clip Kind
        //Auto, Burst, Semi, Cylinder, SlidingShutter,

        // Traits
        Peashot, Shotgun, 
        
        LazerSight,  SuperSight,
        
        SelfShooter, Freezer,
        BulletThrower,

        Dicer, 
        PoweredTrigger, PoweredReload,
        Nails, 
        ClipRegen, IncreasingSize
        //SelfHurtImmunity



    }
    
}
