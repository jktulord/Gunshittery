using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextSpawner : MonoBehaviour
{
    private Transform Canvas;
    private Camera cam;

    public GameObject TextLinePrefab;

    public List<TMP_Text> ActiveTextLines;

    public Color Color;

    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        if (cam != null)
            Debug.Log("No cam found");
        Canvas = GameObject.FindGameObjectWithTag("MainCanvas").transform.Find("ObjectUI");
        ActiveTextLines = new List<TMP_Text>();
    }

    public void ThrowAText(string text, Vector3 directionVector)
    {
        TMP_Text ThrownTextLine = Instantiate(TextLinePrefab, Canvas).GetComponent<TMP_Text>();
        //ThrownTextLine.color = Color;
        ThrownTextLine.text = text;
        Vector3 RanVect = new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f)) ;
        ThrownTextLine.transform.position = cam.WorldToScreenPoint(transform.position + RanVect);
        ActiveTextLines.Add(ThrownTextLine);
        ThrownTextLine.GetComponent<TextLineScript>().SetMovingVector(directionVector);
        Destroy(ThrownTextLine.gameObject, 0.250f);
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
