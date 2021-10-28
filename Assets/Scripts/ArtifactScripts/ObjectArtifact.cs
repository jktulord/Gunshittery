using Assets.Scripts.ArtifactScripts;
using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ObjectArtifact : MonoBehaviour
{
    public ArtifactStats artifact;
    public int Number = 0;
    public bool IfRandom;
    public Transform Canvas;
    private Camera cam;
    private CinemachineVirtualCamera Cinemachine;

    public GameObject TextlinePrefab;
    private TMP_Text NameLine;
    private TMP_Text DescriptionLine;
    
   
    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        if (cam != null)
            Debug.Log("No cam found");
        Canvas = GameObject.FindGameObjectWithTag("MainCanvas").transform.Find("ObjectUI");
        Cinemachine = GameObject.FindGameObjectWithTag("Cinemachine").GetComponent<CinemachineVirtualCamera>();


        if (IfRandom == true)
            artifact = GetArtifact.ByNum(Random.Range(0, 36));
        else
            artifact = GetArtifact.ByNum(Number);

        NameLine = Instantiate(TextlinePrefab, Canvas).GetComponent<TMP_Text>();
        NameLine.text = artifact.Name;

        DescriptionLine = Instantiate(TextlinePrefab, Canvas).GetComponent<TMP_Text>();
        DescriptionLine.text = artifact.Description;
        
        Debug.Log(transform.position);
        Debug.Log(cam.WorldToScreenPoint(transform.position + new Vector3(0, 0.5f)));
    }

    // Update is called once per frame
    void Update()
    {
        if (Cinemachine.m_Lens.OrthographicSize <= 15)
        {
            NameLine.gameObject.SetActive(true);
            DescriptionLine.gameObject.SetActive(true);
            NameLine.transform.position = cam.WorldToScreenPoint(transform.position + new Vector3(0, 1.5f));
            DescriptionLine.transform.position = cam.WorldToScreenPoint(transform.position + new Vector3(0, 1f));
        }
        else
        {
            NameLine.gameObject.SetActive(false);
            DescriptionLine.gameObject.SetActive(false);
        }
    }

    public void Disapear()
    {
        Destroy(NameLine.gameObject);
        Destroy(DescriptionLine.gameObject);
    }
}
