using UnityEngine;

namespace Modding.TaskCreator
{
    /*
     *
     * Module Use Case:
     *  This module is responsible for executing the proper
     *  Placement algorithm for Action Logic Groups.
     */
    public class ActionLogicGroup: MonoBehaviour,ILogicGroup
    {
        [SerializeField] public LogicGroupEnum logicGroup;
        public void PlaceLogicGroup(GameObject logicItem)
        {
            UIPlacementController.PlaceActionLogicGroup(gameObject,logicItem);
        }
    }
}