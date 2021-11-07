using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.ArtifactScripts
{
    public enum EffectKind
    {
        // Basic
        Dmg, DmgMod,       
        BPSMod,
        Accuracy, Stability,
        Bullets, Ricochet,
        SizeMod, ForceMod,

        // Advanced
        Clip, ClipMod,
        ReloadMod,

        //Types
        Auto, Semi, Burst, Cylinder, SlydingShutter,

        //Perks
        Peashot, Shotgun,
        LazerSight, SuperSight,
        SelfShooter, Freezer,
        BulletThrower,
        Dicer,
        PoweredTrigger, PoweredReload,
        Nails,
        ClipRegen, IncreasingSize,

        ImmuneToSelfHurt,
    }

    public class Effect
    {
        public EffectKind Name { get; set; }
        public float Value { get; set; } 
    }


}
