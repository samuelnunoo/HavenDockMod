using UnityEngine;

namespace Modding.TaskCreator
{
    /*
     *
     * Module Use Case:
     *  This module is responsible for executing the proper
     *  placement algorithm for General Logic Groups.
     */
    public class GeneralLogicGroup: MonoBehaviour, ILogicGroup
    {
        [SerializeField] public LogicGroupEnum logicGroup;
        [SerializeField] public bool isInLogicGroup;
        public void PlaceLogicGroup(GameObject logicItem)
        {
            UIPlacementController.PlaceGeneralLogicGroup(gameObject,logicItem);
        }
    }
}