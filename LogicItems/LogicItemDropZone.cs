using System;
using PlayFab.Internal;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Modding.TaskCreator
{
    public class LogicItemDropZone : MonoBehaviour, IDropHandler
    {
        [SerializeField]
        public LogicItemEnum acceptedDropType;

        public GameObject dropZoneGroup;
        

        public void OnDrop(PointerEventData eventData)
        {
            if (eventData.pointerDrag != null)
            {
                if (!HasExpectedType(eventData.pointerDrag))
                {
                   eventData.pointerDrag.GetComponent<LogicItemDragHandler>().ResetDragTarget();
                   return;
                }
                dropZoneGroup.GetComponent<ILogicGroup>().PlaceLogicGroup(eventData.pointerDrag);
            }
       
        }

        private bool HasExpectedType(GameObject dropItem)
        {
            return dropItem.GetComponent<LogicItemInfo>().logicItemType == acceptedDropType;
        }

        private void PlayRejectItemAnimation(LogicItemDragHandler logicItem)
        {
            //  shake left and right a bit and stop 
            // 
        
        }

        private void PlayAcceptItemAnimation()
        {
            // slightly increase in scale to appear like it is accepting it
            // also glow the outline of i
            // t
        }
    }

}

