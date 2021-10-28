using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjectPoolTrigger : MonoBehaviour
{
    private bool InActive = false;
    public List<GameObject> ActiveGameObjects;
    public UnityEvent EveryoneDeadEvent;

    private bool TriggerStarted = false; 
    
    // Start is called before the first frame update
    void Start()
    {
        ActiveGameObjects = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfDead();
    }

    public void CheckIfDead()
    {
        if (InActive == false)
            if (ActiveGameObjects.Count > 0)
                InActive = true;
            else
                return;

        for (int i = 0; i < ActiveGameObjects.Count; i++)
        {
            if (ActiveGameObjects[i] == null)
                ActiveGameObjects.RemoveAt(i);
        }
        if (ActiveGameObjects.Count == 0)
        {
            EveryoneDeadEvent.Invoke();
        }
    }
}
