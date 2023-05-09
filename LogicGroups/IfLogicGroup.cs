using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Modding.TaskCreator
{
    /*
     * Module Use Case:
     *  This module is responsible for executing the proper
     *  placement algorithm for IfLogicGroups.
     */
    public class IfLogicGroup : MonoBehaviour,ILogicGroup
    {

        [SerializeField] public LogicGroupEnum logicGroup;
        
        public void PlaceLogicGroup(GameObject logicItem)
        {
            UIPlacementController.PlaceIfLogicGroup(gameObject,logicItem);
        }
    
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
    
}
