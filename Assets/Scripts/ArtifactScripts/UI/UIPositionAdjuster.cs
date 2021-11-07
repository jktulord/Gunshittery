using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPositionAdjuster : MonoBehaviour
{ 
    public Transform Canvas;
    private Camera cam;
    private CinemachineVirtualCamera Cinemachine;

    public Transform Owner;
    public Vector3 Offset; 

    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        if (cam != null)
            Debug.Log("No cam found");
        Canvas = GameObject.FindGameObjectWithTag("MainCanvas").transform.Find("ObjectUI");
        Cinemachine = GameObject.FindGameObjectWithTag("Cinemachine").GetComponent<CinemachineVirtualCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Cinemachine.m_Lens.OrthographicSize <= 15)
        {
            transform.GetChild(0).gameObject.SetActive(true);
            transform.position = cam.WorldToScreenPoint(Owner.position + Offset);
        }
        else
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }
            

    }
}
