using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextLineScript : MonoBehaviour
{
    private bool IfMoving;
    private Vector3 DirectionVector;

    public void SetMovingVector(Vector3 vector3)
    {
        IfMoving = true;
        DirectionVector = vector3;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += DirectionVector * Time.deltaTime;
    }
}
