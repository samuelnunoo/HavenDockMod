using UnityEngine;

namespace Modding.TaskCreator
{
    /*
     *
     * Module Use Case:
     *  This module is responsible for executing the proper
     *  placement algorithm for ThenLogicGroups.
     */
    public class ThenLogicGroup: MonoBehaviour, ILogicGroup
    {
        
        [SerializeField] public LogicGroupEnum logicGroup;
        public void PlaceLogicGroup(GameObject logicItem)
        {
            UIPlacementController.PlaceThenLogicGroup(gameObject,logicItem);
        }
    }
}