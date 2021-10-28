using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomScript : MonoBehaviour
{
    private CinemachineVirtualCamera Cinemachine;
    public bool IfPersonalZoomUnlocked = false;
    public int ZoomLimit = 20;

    // Start is called before the first frame update
    void Start()
    {
        Cinemachine = GetComponent<CinemachineVirtualCamera>();
    }

    private void Update()
    {

        Vector2 MouseDelta = Input.mouseScrollDelta;
        if ((MouseDelta.y != 0) && (IfPersonalZoomUnlocked))
        {
            Cinemachine.m_Lens.OrthographicSize -= 500 * MouseDelta.y * Time.deltaTime;
            if (Cinemachine.m_Lens.OrthographicSize < 5)
                Cinemachine.m_Lens.OrthographicSize = 5;
            if (Cinemachine.m_Lens.OrthographicSize > 20)
                Cinemachine.m_Lens.OrthographicSize = 20;
        }
    }



    public void UnlockedPersonalZoom()
    {
        IfPersonalZoomUnlocked = true;
    }

    public void SetZoom(int i)
    {
        Cinemachine.m_Lens.OrthographicSize = i;
    }
}
