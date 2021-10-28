using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorGroupControl : MonoBehaviour
{
    public List<DoorScript> Doors;

    public void Start()
    {
        //Open();
    }

    public void Open()
    {
        foreach (DoorScript door in Doors)
        {
            door.Open();
        }
    }

    public void Close()
    {
        foreach (DoorScript door in Doors)
        {
            door.Close();
        }
    }
}
