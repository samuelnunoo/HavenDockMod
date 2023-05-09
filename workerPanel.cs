using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class workerPanel : MonoBehaviour
{
    public GameObject workerPanelObject;
    public GameObject taskPanel;
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(showWorkerPanel);
    }

    void showWorkerPanel()
    {
        workerPanelObject.SetActive(true);
        taskPanel.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
