using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.ArtifactScripts
{
    public class ArtifactStats
    {
        public string Name;
        public string Description;

        public Dictionary<EffectKind, float> Effects;

        public ArtifactStats(string name, string description, Dictionary<EffectKind, float> effects)
        {
            Name = name;
            Description = description;

            Effects = effects;

        }

    }
}
