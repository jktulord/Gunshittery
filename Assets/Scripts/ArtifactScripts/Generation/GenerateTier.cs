using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts.ArtifactScripts.Generation
{
    public static class GenerateTier
    {
        public static ArtifactStats Artifact1()
        {
            ArtifactStats artifact = new ArtifactStats("An Artifact", "NoDescription");
            Dictionary<EffectKind, float> PriceList = EffectPriceList.Basic();
            float budget = 10;

            artifact.ProEffects = Generate.Effects(budget, 1);
           
            Debug.Log("Item Budget: " + budget);
            Debug.Log("Deffect Generation Budget: " + budget * 0.75f);
            artifact.Deffects1 = Generate.Effects(-budget * 0.75f, Random.Range(1, 3)/*, new List<EffectKind>(artifact.ProEffects.Keys)*/);
            artifact.Deffects2 = Generate.Effects(-budget * 0.75f, Random.Range(1, 3)/*, new List<EffectKind>(artifact.Deffects1.Keys)*/);
            return artifact;
        }

        private static float CalculateDeffectBudget(ArtifactStats artifact, Dictionary<EffectKind, float> PriceList)
        {
            float budget = 0;
            foreach (EffectKind effectKind in artifact.ProEffects.Keys)
            {
                budget += artifact.ProEffects[effectKind] * PriceList[effectKind];
            }
            return budget;
        }

    }
}
