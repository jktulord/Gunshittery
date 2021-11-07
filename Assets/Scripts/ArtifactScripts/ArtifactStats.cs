using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.ArtifactScripts
{
    public enum ArtifactTier{
        Tier1, Tier2, Tier3
    }

    public class ArtifactStats
    {
        public string Name;
        public string Description;

        public ArtifactTier ArtifactTier;

        public Dictionary<EffectKind, float> ProEffects;
        public Dictionary<EffectKind, float> Deffects1;
        public Dictionary<EffectKind, float> Deffects2;

        public int chosenDeffect = 0;

        public ArtifactStats(string name, string description,
            Dictionary<EffectKind, float> proEffects = null,
            Dictionary<EffectKind, float> deffects1 = null,
            Dictionary<EffectKind, float> deffects2 = null)
        {
            Name = name;
            Description = description;

            ProEffects = proEffects;
            Deffects1 = deffects1;
            Deffects2 = deffects2;
        }

    }
}
