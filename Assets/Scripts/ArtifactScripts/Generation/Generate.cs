
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.ArtifactScripts.Generation
{
    public class Generate
    {
        public static Dictionary<EffectKind, float> Effects(float budget, int Basic, int Advanced, int Perk, int Type)
        {
            Dictionary<EffectKind, float> Effects = new Dictionary<EffectKind, float>();
            int type = Random.Range(0,5);
            EffectKind kind;
            float EffectValue;
            float CurrentBudget = budget;

            for (int i = 0; i < Basic - 1; i++)
            {
                (kind, EffectValue) = BasicEffect(CurrentBudget, new List<EffectKind>(Effects.Keys));
                Effects.Add(kind, EffectValue);
            }
            (kind, EffectValue) = BasicEffect(CurrentBudget, new List<EffectKind>(Effects.Keys));
            Effects.Add(kind, EffectValue);
            /*
            switch (type)
            {
                case 0: // 1 effect
                    (kind, EffectValue) = BasicEffect(budget, new List<EffectKind>(Effects.Keys));
                    Effects.Add(kind, EffectValue);
                    break;
                case 1: // 2 effect 0.5:0.5
                    (kind, EffectValue) = BasicEffect(budget * 0.5f, new List<EffectKind>(Effects.Keys));
                    Effects.Add(kind, EffectValue);
                    (kind, EffectValue) = BasicEffect(budget * 0.5f, new List<EffectKind>(Effects.Keys));
                    Effects.Add(kind, EffectValue);
                    break;
                case 2: // 2 effect 0.7:0.3
                    (kind, EffectValue) = BasicEffect(budget * 0.7f, new List<EffectKind>(Effects.Keys));
                    Effects.Add(kind, EffectValue);
                    (kind, EffectValue) = BasicEffect(budget * 0.3f, new List<EffectKind>(Effects.Keys));
                    Effects.Add(kind, EffectValue);
                    break;
                case 3: // 3 effect 0.5:0.25:0.25
                    (kind, EffectValue) = BasicEffect(budget * 0.5f, new List<EffectKind>(Effects.Keys));
                    Effects.Add(kind, EffectValue);
                    (kind, EffectValue) = BasicEffect(budget * 0.25f, new List<EffectKind>(Effects.Keys));
                    Effects.Add(kind, EffectValue);
                    (kind, EffectValue) = BasicEffect(budget * 0.25f, new List<EffectKind>(Effects.Keys));
                    Effects.Add(kind, EffectValue);
                    break;
                case 4: // 3 effect 0.33:0.33:0.33
                    (kind, EffectValue) = BasicEffect(budget * 0.33f, new List<EffectKind>(Effects.Keys));
                    Effects.Add(kind, EffectValue);
                    (kind, EffectValue) = BasicEffect(budget * 0.33f, new List<EffectKind>(Effects.Keys));
                    Effects.Add(kind, EffectValue);
                    (kind, EffectValue) = BasicEffect(budget * 0.33f, new List<EffectKind>(Effects.Keys));
                    Effects.Add(kind, EffectValue);
                    break;
            
            }
            */
            //Debug.Log(kind + ": " + value);


            return Effects;
        }

        public static (EffectKind, float) BasicEffect(float budget, List<EffectKind> Effects)
        {
            Dictionary<EffectKind, float> PriceList = EffectPriceList.Basic();
            int i = Random.Range(0, PriceList.Count);
            EffectKind kind = PriceList.ElementAt(i).Key;
            if (Effects.Contains(kind))
                return BasicEffect(budget, Effects);

            float value = budget / PriceList[kind];
            return (kind, value);
        }

        public static (EffectKind, float) AdvancedEffect(float budget, List<EffectKind> Effects)
        {
            Dictionary<EffectKind, float> PriceList = EffectPriceList.Basic();
            int i = Random.Range(0, PriceList.Count);
            EffectKind kind = PriceList.ElementAt(i).Key;
            if (Effects.Contains(kind))
                return BasicEffect(budget, Effects);

            float value = budget / PriceList[kind];
            return (kind, value);
        }


    }
}

