using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskPanel : MonoBehaviour
{
    public GameObject taskPanel;
    public GameObject workerPanel;
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(showTaskPanel);
    }

    void showTaskPanel()
    {
        workerPanel.SetActive(false);
        taskPanel.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
