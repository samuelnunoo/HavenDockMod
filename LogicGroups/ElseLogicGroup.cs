using UnityEngine;

namespace Modding.TaskCreator
{
    /*
     * Module Use Case:
     *  This module is responsible for executing the proper
     *  Placement algorithm for Else Logic Groups
     */
    public class ElseLogicGroup: MonoBehaviour,ILogicGroup
    {
        [SerializeField] public LogicGroupEnum logicGroup;
        public void PlaceLogicGroup(GameObject logicItem)
        {
            UIPlacementController.PlaceElseLogicGroup(gameObject,logicItem);
        }
    }
}