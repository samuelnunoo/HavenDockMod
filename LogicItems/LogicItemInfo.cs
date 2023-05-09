using UnityEngine;

namespace Modding.TaskCreator
{
    
    /*
     *
     * Module Use Case:
     *  This module is responsible for providing Data relevant to the attached LogicItem which will
     *  be used for a variety of operations including validation.
     */
    public class LogicItemInfo: MonoBehaviour
    {
        [SerializeField] public LogicItemEnum logicItemType;
        [SerializeField] public string logicItemResourceID;
        [SerializeField] public string logicItemTitle;
    }
}