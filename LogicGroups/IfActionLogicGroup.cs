using UnityEngine;

namespace Modding.TaskCreator
{
    
    /*
     * Module Use Case:
     *  This module is responsible for executing the
     *  proper Placement algorithm for IfActionLogicGroups.
     */
    public class IfActionLogicGroup: MonoBehaviour,ILogicGroup
    {
        
        [SerializeField] public LogicGroupEnum logicGroup;
        public void PlaceLogicGroup(GameObject logicItem)
        {
            UIPlacementController.PlaceIfActionLogicGroup(gameObject,logicItem);
        }
    }
}