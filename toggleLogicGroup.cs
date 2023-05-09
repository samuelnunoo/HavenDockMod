using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class toggleLogicGroup : MonoBehaviour
{
    // Start is called before the first frame updat
    public Button collapsedButton;
    public Button expandedButton;
    public GameObject expandedLogicGroup;
    public GameObject collasedLogicGroup;
    private bool isExpanded = false;
    
    void Start()
    {
        collapsedButton.onClick.AddListener(toggle);
        expandedButton.onClick.AddListener(toggle);
    }

    void toggle()
    {
        if (isExpanded)
        {
            expandedLogicGroup.SetActive(false);
            collasedLogicGroup.SetActive(true);
            isExpanded = false;
        }
        else
        {
            expandedLogicGroup.SetActive(true);
            collasedLogicGroup.SetActive(false);
            isExpanded = true;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
