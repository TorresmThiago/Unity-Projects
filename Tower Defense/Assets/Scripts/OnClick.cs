using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class OnClick : MonoBehaviour
{
    public UnityEvent unityEvent;
    public string targetTag;

    void Awake()
    {
        if (unityEvent == null)
            unityEvent = new UnityEvent();

        Debug.Log(targetTag);

    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 cubeRay = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D cubeHit = Physics2D.Raycast(cubeRay, Vector2.zero);

            if (cubeHit)
            {
                Debug.Log("Click Detected");
                // whatever tag you are looking for on your game object
                if (cubeHit.collider.tag == targetTag)
                {
                    unityEvent.Invoke();
                }
            }
        }
    }

    // public void OnMouseDown()
    // {
    //     unityEvent.Invoke();
    // }
}
