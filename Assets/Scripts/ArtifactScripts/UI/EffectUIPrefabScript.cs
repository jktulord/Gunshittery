using Assets.Scripts.ArtifactScripts;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EffectUIPrefabScript : MonoBehaviour
{
    public string Name = "Stability";
    public float Value = 100;

    private TMP_Text ValueLine;
    private TMP_Text NameLine;

    public void Start()
    {
        
        Refresh();
    }
    // Start is called before the first frame update
    void Load()
    {
        ValueLine = transform.Find("Value").GetComponent<TMP_Text>();
        NameLine = transform.Find("Name").GetComponent<TMP_Text>();
    }

    public void Refresh()
    {
        if (ValueLine == null)
            Load();
        if (Value > 0)
            ValueLine.text = "+" + Value;
        else  
            ValueLine.text = "" + Value;
        NameLine.text = "" + Name;
    }
}
