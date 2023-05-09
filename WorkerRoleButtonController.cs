using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorkerRoleButtonController : MonoBehaviour
{

    public bool isExpanded;
    public Button expandedButton;
    public GameObject expandedPanel;
    public RectTransform layoutGroup;
    void Start()
    {
        expandedButton.onClick.AddListener(Toggle);
    }

    void Toggle()
    {
        isExpanded = !isExpanded;
        expandedPanel.SetActive(isExpanded);
        LayoutRebuilder.MarkLayoutForRebuild(layoutGroup);
    }

}
