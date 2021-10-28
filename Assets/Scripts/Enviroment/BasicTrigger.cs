using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BasicTrigger : MonoBehaviour
{ 
    public UnityEvent OnEnterEvent;
    public UnityEvent OneTimeOnEnterEvent;

    private bool OneTimeOnEnterEventActivated = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("OnTriggerEnter");

            OnEnterEvent.Invoke();
            if (!OneTimeOnEnterEventActivated)
            {
                OneTimeOnEnterEvent.Invoke();
                OneTimeOnEnterEventActivated = true;
            }
        }
        
        
    }

}
