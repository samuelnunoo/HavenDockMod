using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class testScript : MonoBehaviour
{
    public GameObject gameObject;
    public Button button;
    public RectTransform layout;
    void Start()
    {
        button.onClick.AddListener(increaseSize);
    }

    void increaseSize()
    {
        Debug.Log("RUNNING");
        Vector3 localScale = gameObject.transform.localScale;
        localScale.y += 1.5F;
        transform.localScale = localScale;
        LayoutRebuilder.ForceRebuildLayoutImmediate(layout);
        
    }
}
