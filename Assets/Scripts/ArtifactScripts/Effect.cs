using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.ArtifactScripts
{
    public enum EffectKind
    {
        BaseDamage, DamageModifier, 
        BaseForce, ForceModifier,
        BulletDelayModifier, 
        Accuracy,
        Bullets,
        BulletSizeModifier,
        Ricochet,

        ChangeToAuto, ChangeToSemi,
        ChangeToShootgun,
        ChangeToPeashoot,
        ChangeToNormal,
        
        ImmuneToSelfHurt,
    }

    public class Effect
    {
        public EffectKind Name { get; set; }
        public float Value { get; set; } 
    }


}
