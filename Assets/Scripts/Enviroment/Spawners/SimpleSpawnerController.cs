using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleSpawnerController : MonoBehaviour
{
    public List<Spawner> Spawners;
    
    public ObjectPoolTrigger ObjectPoolTrigger;

    public void Activate()
    {
        foreach (Spawner current in Spawners)
        {
            List<GameObject> GameObjects = current.Spawn();
            if (ObjectPoolTrigger != null)
                ObjectPoolTrigger.ActiveGameObjects.AddRange(GameObjects);
        }   
    }
}
