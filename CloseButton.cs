using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseButton : MonoBehaviour
{

    public GameObject panel;
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(closePanel);

    }

    void closePanel()
    {
        
        panel.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
