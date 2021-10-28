using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Prefab;
    public int Amount;

    public List<GameObject> Spawn()
    {   
        List<GameObject> ObjectList = new List<GameObject>();
        for (int i = 0; i < Amount; i++)
        {
            GameObject gameObject = Instantiate(Prefab, new Vector2(transform.position.x, transform.position.y), Quaternion.Euler(new Vector3())) ;
            gameObject.GetComponent<EnemyMoveAi>().target = GameObject.Find("PlayerSquare").transform;
            ObjectList.Add(gameObject);
        }
        return ObjectList;
    }
}
