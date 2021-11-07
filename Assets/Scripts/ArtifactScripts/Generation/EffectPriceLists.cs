using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.ArtifactScripts.Generation
{
    public static class EffectPriceList
    {
        public static Dictionary<EffectKind, float> Basic()
        {
            Dictionary<EffectKind, float> Basic = new Dictionary<EffectKind, float>
            {
                { EffectKind.Dmg, 10 },
                { EffectKind.DmgMod, 1 },

                { EffectKind.BPSMod, 1 },
                
                { EffectKind.Accuracy, 5 },
                { EffectKind.Stability, 5 },

                { EffectKind.SizeMod, 0.5f },
                { EffectKind.ForceMod, 0.5f },

                { EffectKind.ClipMod, 0.5f },
                { EffectKind.ReloadMod, -1 },
            };
            return Basic;
        }

        public static Dictionary<EffectKind, float> Advanced()
        {
            Dictionary<EffectKind, float> Basic = new Dictionary<EffectKind, float>
            {
                { EffectKind.Bullets, 50 },
                { EffectKind.Ricochet, 35 },

                { EffectKind.Clip, 5 },
            };
            return Basic;
        }

        public static Dictionary<EffectKind, float> Perks()
        {
            Dictionary<EffectKind, float> Basic = new Dictionary<EffectKind, float>
            {
                { EffectKind.Peashot, -30 },
                { EffectKind.Shotgun, -30 },
                { EffectKind.LazerSight, 50 },
                { EffectKind.SuperSight, 150 },
                { EffectKind.SelfShooter, -70 },
                { EffectKind.Freezer, -50 },
                { EffectKind.BulletThrower, 50 },
                { EffectKind.Dicer, 70 },
                { EffectKind.PoweredTrigger, 80 },
                { EffectKind.PoweredReload, 80 },
                { EffectKind.Nails, 25 },
                { EffectKind.ClipRegen, 100 },
                { EffectKind.IncreasingSize, 25 },
                { EffectKind.ImmuneToSelfHurt, 25 },
            };
            return Basic;
        }
    }
}
