using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.ArtifactScripts.UI
{
    public class EffectListUIPrefabScript : MonoBehaviour
    {
        private List<EffectUIPrefabScript> EffectsUI;
        public Dictionary<EffectKind, float> Effects;

        public GameObject EffectUIPrefab;

        public void Start()
        {
            /*
            ArtifactStats MockArtifact = new ArtifactStats("Mock", "", 
                effects: new Dictionary<EffectKind, float>() {  },
                effects: new Dictionary<EffectKind, float>() { { EffectKind.Accuracy, 10 } }
                );
            
            Effects = new Dictionary<EffectKind, float>();
            Effects.Add(EffectKind.Dmg, 10);
            Effects.Add(EffectKind.Force, 70);
            Effects.Add(EffectKind.Ricochet, 1);
            */
            EffectsUI = new List<EffectUIPrefabScript>();

            Refresh();

        }

        public void Refresh()
        {
            Clear();
            foreach (EffectKind effect in Effects.Keys)
            {
                Add(effect, Effects[effect]);
            }
        }
        
        public void Add(EffectKind effect, float value)
        {
            GameObject gameObject = Instantiate(EffectUIPrefab, transform.GetChild(0));
            EffectUIPrefabScript effectUIPrefabScript = gameObject.GetComponent<EffectUIPrefabScript>();
            effectUIPrefabScript.Name = ""+effect;
            effectUIPrefabScript.Value = value - value % 0.01f;
            effectUIPrefabScript.Refresh();
            EffectsUI.Add(effectUIPrefabScript);
        }

        public void Clear()
        {
            for (int i = 0; i < transform.GetChild(0).childCount; i++)
            {
                Destroy(transform.GetChild(0).GetChild(i).gameObject);
            }
        }



    }
}
