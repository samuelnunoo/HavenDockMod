using UnityEngine;
using UnityEngine.EventSystems;

namespace Modding.TaskCreator
{
    
    /*
     *
     * Module Use Case:
     *  This module is responsible for performing drag operations on the Logic Items and
     *  handling the logic for which drag algorithms should run depending upon different state information
     *  such as information within the LogicItemInfo
     */
    public class LogicItemDragHandler: MonoBehaviour, IBeginDragHandler, IDragHandler,IEndDragHandler
    {
        [SerializeField] public bool hasBeenPlaced = false;
        [SerializeField] public LogicItemEnum logicItemType;
        [SerializeField] public GameObject parentContainer;
        private GameObject dragTarget;
        public void ResetDragTarget()
        {
            Destroy(dragTarget);
            dragTarget = null;
        }
        private bool ShouldDragForPlacement()
        {
            return !hasBeenPlaced;
        }
        private bool ShouldNotAllowDrag()
        {
            if (ShouldDragForPlacement()) return false;
            return logicItemType == LogicItemEnum.Then;
        }
        private bool ShouldDragContainer()
        {
            if (!hasBeenPlaced || ShouldNotAllowDrag()) return false;
            return logicItemType is LogicItemEnum.If or LogicItemEnum.Else;
        }
        private bool ShouldDragForMove()
        {
            if (ShouldNotAllowDrag() || ShouldDragForPlacement()) return false;
            return !ShouldDragContainer();
        }
        
        public void OnBeginDrag(PointerEventData eventData)
        {
            if (ShouldNotAllowDrag()) return;
            if (ShouldDragForPlacement())
            {
                dragTarget = UIDragController.CreateDragItem(gameObject);
                gameObject.GetComponent<CanvasGroup>().blocksRaycasts = false;
            }
            if (ShouldDragForMove())
            {
                dragTarget = gameObject;
            }
            if (ShouldDragContainer())
            {
                dragTarget = parentContainer;
            }
        }
        
        public void OnDrag(PointerEventData eventData)
        {
            dragTarget.transform.position = eventData.position;
        }
        
        public void OnEndDrag(PointerEventData eventData)
        {
            gameObject.GetComponent<CanvasGroup>().blocksRaycasts = true;
            if (!UIDragController.IsHoveringDropZone(eventData.hovered))
            {
                ResetDragTarget();
            }
            else
            {
                dragTarget.GetComponent<LogicItemDragHandler>().hasBeenPlaced = true;
            }
        }
    }
}