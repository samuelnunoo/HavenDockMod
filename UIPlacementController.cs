using System;
using Mono.Cecil;
using UnityEngine;

/*
 *
 * Module Use Case:
 *  This module is responsible for transforming a LogicGroup that has had a LogicItem placed
 *  onto one of its DropZones into a LogicResultant or a recursive LogicGroup.
 */
namespace Modding.TaskCreator
{
    public class UIPlacementController: MonoBehaviour
    {
        public static void PlaceIfLogicGroup(GameObject logicGroup, GameObject logicItem)
        {
            var index = logicGroup.transform.GetSiblingIndex();
            var parent = logicGroup.transform.parent;
            var logicItemData = logicItem.GetComponent<LogicItemInfo>();
            if (logicItemData.logicItemType != LogicItemEnum.Statement)
            {
                throw new Exception("IfLogicGroup accepts only a Statement.");
            }
            GameObject ifLogicResultant = LogicResultantBuilder.BuildIfResultant(logicItemData);
            GameObject thenLogicGroup = LogicGroupAssetProvider.CreateThenLogicGroup();
            
            Destroy(logicGroup);
            ifLogicResultant.transform.SetParent(parent);
            thenLogicGroup.transform.SetParent(parent);
            ifLogicResultant.transform.localScale = new Vector3(1, 1, 1);
            thenLogicGroup.transform.localScale = new Vector3(1, 1, 1);
            logicItem.GetComponent<LogicItemDragHandler>().ResetDragTarget();
        }
        public static void PlaceThenLogicGroup(GameObject logicGroup, GameObject logicItem)
        {
            var logicItemInfo = logicItem.GetComponent<LogicItemInfo>();
            var parent = logicGroup.transform.parent;
            var thenResultant = LogicResultantBuilder.BuildThenResultant(logicItemInfo);
            var ifActionLogicGroup = LogicGroupAssetProvider.CreateIfActionLogicGroup();
            
            Destroy(logicGroup);
            thenResultant.transform.SetParent(parent);
            ifActionLogicGroup.transform.SetParent(parent);
            thenResultant.transform.localScale = new Vector3(1, 1, 1);
            ifActionLogicGroup.transform.localScale = new Vector3(1, 1, 1);
            logicItem.GetComponent<LogicItemDragHandler>().ResetDragTarget();
        }
        public static void PlaceIfActionLogicGroup(GameObject logicGroup, GameObject logicItem)
        {
            var logicItemInfo = logicItem.GetComponent<LogicItemInfo>();
            var parent = logicGroup.transform.parent;
            var ifActionResultant = LogicResultantBuilder.BuildIfActionResultant(logicItemInfo);
            
            ifActionResultant.transform.SetParent(parent);
            ifActionResultant.transform.localScale = new Vector3(1, 1, 1);
            
            if (logicItemInfo.logicItemType is LogicItemEnum.Action or LogicItemEnum.Custom)
            {
                var actionGroup = LogicGroupAssetProvider.CreateIfActionLogicGroup();
                actionGroup.transform.SetParent(parent);
                actionGroup.transform.localScale = new Vector3(1, 1, 1);
            }

            if (logicItemInfo.logicItemType == LogicItemEnum.Done)
            {
                PlaceNestedGeneralLogicGroup(logicGroup);
            }
            logicItem.GetComponent<LogicItemDragHandler>().ResetDragTarget();
            Destroy(logicGroup);
        }
        public static void PlaceGeneralLogicGroup(GameObject logicGroup, GameObject logicItem)
        {
            var index = logicGroup.transform.GetSiblingIndex();
            var parent = logicGroup.transform.parent;
            var logicItemData = logicItem.GetComponent<LogicItemInfo>();
            var isInLogicGroup = logicGroup.GetComponent<LogicGroupInfo>().isInLogicGroup;
            GameObject newLogicGroup;

            if (logicItemData.logicItemType == LogicItemEnum.If)
            {
                var logicGroupPartial = WrapInIfLogicGroupContainer(LogicGroupAssetProvider.CreateIfLogicGroup());
                newLogicGroup = isInLogicGroup ? logicGroupPartial : WrapInLogicGroupContainer(logicGroupPartial);
            }
            else if (logicItemData.logicItemType is LogicItemEnum.Action or LogicItemEnum.Custom)
            {
                newLogicGroup = WrapInLogicContainer(LogicResultantBuilder.BuildActionResultant(logicItem.GetComponent<LogicItemInfo>()));
            }
            else
            {
                return;
            }

            
            newLogicGroup.transform.SetParent(parent);
            newLogicGroup.transform.localScale = new Vector3(1, 1, 1);
            newLogicGroup.transform.SetSiblingIndex(index);
            logicItem.GetComponent<LogicItemDragHandler>().ResetDragTarget();
            Destroy(logicGroup);
            if (!isInLogicGroup || logicItemData.logicItemType != LogicItemEnum.If) InsertGenericLayoutAtIndex(parent, index + 1,isInLogicGroup);
            
         
        }
        public static void PlaceElseLogicGroup(GameObject logicGroup, GameObject logicItem)
        {
            var logicItemInfo = logicItem.GetComponent<LogicItemInfo>();
            var parent = logicGroup.transform.parent;
            Destroy(logicGroup);

            if (logicItemInfo.logicItemType is LogicItemEnum.Action or LogicItemEnum.Custom)
            {
                var actionResultant = LogicResultantBuilder.BuildActionResultant(logicItemInfo);
                var actionGroup = LogicGroupAssetProvider.CreateActionLogicGroup();
                actionResultant.transform.SetParent(parent);
                actionGroup.transform.SetParent(parent);
                actionResultant.transform.localScale = new Vector3(1, 1, 1);
                actionGroup.transform.localScale = new Vector3(1, 1, 1);
            }
            else if (logicItemInfo.logicItemType == LogicItemEnum.If)
            {
                var ifGroup = LogicGroupAssetProvider.CreateIfLogicGroup();
                ifGroup.transform.SetParent(parent);
                ifGroup.transform.localScale = new Vector3(1, 1, 1);
            }
            else
            {
                throw new Exception("ElseLogicGroup can only accept Action/Custom/If");
            }
           logicItem.GetComponent<LogicItemDragHandler>().ResetDragTarget();
        }
        public static void PlaceActionLogicGroup(GameObject logicGroup, GameObject logicItem)
        {
            var parent = logicGroup.transform.parent;
            var logicItemInfo = logicItem.GetComponent<LogicItemInfo>();
            
            var actionResultant = LogicResultantBuilder.BuildActionResultant(logicItemInfo);
            actionResultant.transform.SetParent(parent);
            actionResultant.transform.localScale = new Vector3(1, 1, 1);
            
            if (logicItemInfo.logicItemType is LogicItemEnum.Action or LogicItemEnum.Custom)
            {
                var actionGroup = LogicGroupAssetProvider.CreateActionLogicGroup();
                actionGroup.transform.SetParent(parent);
                actionGroup.transform.localScale = new Vector3(1, 1, 1);
            }

            if (logicItemInfo.logicItemType == LogicItemEnum.Done)
            {
                PlaceNestedGeneralLogicGroup(logicGroup);
            }
            Destroy(logicGroup);
            logicItem.GetComponent<LogicItemDragHandler>().ResetDragTarget();
        }
        private static GameObject WrapInLogicGroupContainer(GameObject logicGroup)
        {
            var logicGroupWrapper = LogicGroupAssetProvider.CreateLogicGroup();
            var expandedLogicGroup = logicGroupWrapper.transform.GetChild(0);
            var ContentContainer = expandedLogicGroup.transform.GetChild(1).GetChild(0).GetChild(0);
            logicGroup.transform.SetParent(ContentContainer);
            return logicGroupWrapper;
        }
        private static GameObject WrapInIfLogicGroupContainer(GameObject logicGroup)
        {
            var ifLogicGroupContainer = LogicContainerProvider.CreateIfLogicContainer();
            logicGroup.transform.SetParent(ifLogicGroupContainer.transform);
            return ifLogicGroupContainer;
        }
        private static GameObject WrapInLogicContainer(GameObject logicGroup)
        {
            var logicContainer = LogicContainerProvider.CreateGeneralLogicContainer();
            logicGroup.transform.SetParent(logicContainer.transform);
            return logicContainer;
        }
        private static void InsertGenericLayoutAtIndex(Transform parent, int index,bool isInLogicGroup)
        {
           GameObject logicGroup = LogicGroupAssetProvider.CreateGeneralLogicGroup();
           logicGroup.transform.SetParent(parent);
           logicGroup.transform.SetSiblingIndex(index);
           logicGroup.transform.localScale = new Vector3(1, 1, 1);
           logicGroup.GetComponent<LogicGroupInfo>().isInLogicGroup = isInLogicGroup;
        }
        private static void PlaceNestedGeneralLogicGroup(GameObject logicGroup)
        {
            var rootLogicGroup = logicGroup.transform.GetComponentInParent<LogicContainer>().transform;
            var generalLogicGroup = LogicGroupAssetProvider.CreateGeneralLogicGroup();
            generalLogicGroup.transform.SetParent(rootLogicGroup);
            generalLogicGroup.transform.localScale = new Vector3(1, 1, 1);
            generalLogicGroup.GetComponent<LogicGroupInfo>().isInLogicGroup = true;
        }
    }
}