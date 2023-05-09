using System.Collections.Generic;
using ExitGames.Client.Photon.StructWrapping;
using PlayFab.EconomyModels;
using UnityEngine;
using UnityEngine.UI.Extensions;

namespace Modding.TaskCreator
{
    public class UIDragController: MonoBehaviour
    {

        public static GameObject CreateDragItem(GameObject gameObject)
        {
            var clone = Instantiate(gameObject);
            var originalRectTransform = gameObject.GetComponent<RectTransform>();
            var cloneRectTransform = clone.GetComponent<RectTransform>();
            cloneRectTransform.sizeDelta =
                new Vector2(originalRectTransform.sizeDelta.x, originalRectTransform.sizeDelta.y);
            Transform canvas = GlobalResourceProvider.GetCanvas().transform;
            cloneRectTransform.SetParent(canvas);
            cloneRectTransform.GetComponent<CanvasGroup>().blocksRaycasts = false;
            cloneRectTransform.localScale = new Vector3(1, 1, 1);
            return clone;
        }

        public static bool IsHoveringDropZone(List<GameObject> hoveredUIElements)
        {
            foreach (var uiElement in hoveredUIElements)
            {
                LogicItemDropZone result;
                uiElement.TryGetComponent<LogicItemDropZone>(out result);
                if (result != null) return true;
            }
            return false;
        }
    }
}