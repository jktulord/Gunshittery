using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazer : MonoBehaviour
{

    private LineRenderer lineRenderer;
    public Transform LazerHit;
    public Quaternion DirectionModifier;
    public bool IsActive = true;
    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.enabled = true;
        lineRenderer.useWorldSpace = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (IsActive)
        {
            lineRenderer.enabled = true;
            int layer = 1 << LayerMask.NameToLayer("Enviroment");
            RaycastHit2D hit = Physics2D.Raycast(transform.position, DirectionModifier * transform.up, 100f);
            //Debug.DrawLine(transform.position, hit.point);
            //LazerHit.position = hit.point;
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, hit.point);
        }
        else
        {
            lineRenderer.enabled = false; 
        }

    }
}
