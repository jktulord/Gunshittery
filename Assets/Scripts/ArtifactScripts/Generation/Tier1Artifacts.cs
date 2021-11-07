using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts.ArtifactScripts.Generation
{
    public static class Tier1Artifacts
    {
        public static List<ArtifactStats> List = new List<ArtifactStats>
        {
            new ArtifactStats("HeavierBullets", "+15% Damage, -25% Force.",
                new Dictionary<EffectKind, float> {
                    { EffectKind.DmgMod, 15 },
                    //{ EffectKind.ForceMod, -25 }
                }/*,
                new Dictionary<EffectKind, float> {
                    { EffectKind.ForceMod, -25 },
                    //{ EffectKind.ForceMod, -25 }
                },
                new Dictionary<EffectKind, float> {
                    { EffectKind.Accuracy, -5 },
                    //{ EffectKind.ForceMod, -25 }
                }*/    
                )
    };

        public static ArtifactStats GetByInt(int i)
        {
            return List[i];
        }
        public static ArtifactStats GetRandom()
        {
            return GetByInt(Random.Range(0, Tier1Artifacts.List.Count));
        }
    }
}
