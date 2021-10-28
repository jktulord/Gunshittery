using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    private GameObject Door;

    // Start is called before the first frame update
    void Start()
    {
        Door = transform.Find("Door").gameObject;
        Open();
    }

    public void Open()
    {
        Door.SetActive(false);
    }
    public void Close()
    {
        Door.SetActive(true);
    }
    

  
}
