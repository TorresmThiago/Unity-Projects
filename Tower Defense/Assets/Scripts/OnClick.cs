using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class OnClick : MonoBehaviour
{
    public UnityEvent unityEvent;

    void Awake()
    {
        if (unityEvent == null)
            unityEvent = new UnityEvent();
    }

    public void OnMouseDown()
    {
        unityEvent.Invoke();
    }
}
