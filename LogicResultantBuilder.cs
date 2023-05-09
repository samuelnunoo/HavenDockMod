using System;
using System.Collections.Generic;
using ExitGames.Client.Photon.StructWrapping;
using UnityEngine;

namespace Modding.TaskCreator
{
    /*
     * Module Use Case:
     *  This module is responsible for building logic resultants
     *  incorporating the given LogicItem.
     */
    public class LogicResultantBuilder: MonoBehaviour
    {
        public static GameObject BuildIfResultant(LogicItemInfo logicItemInfo)
        {
            if (logicItemInfo.logicItemType != LogicItemEnum.Statement)
            {
                throw new Exception("IfResultant only accepts a logicItemInfo of Statement");
            }
            var ifLogicItemResultant = LogicResultantsAssetProvider.CreateIfLogicItemResultant();
            var statementLogicItemResultant = LogicResultantsAssetProvider.CreateStatementLogicItemResultant();
            addLogicItemInfoToComponent(statementLogicItemResultant,logicItemInfo);
            return addResultantsToContainer(new List<GameObject> { ifLogicItemResultant, statementLogicItemResultant });
        }
        
        public static GameObject BuildThenResultant(LogicItemInfo logicItemInfo)
        {
            var thenLogicItemResultant = LogicResultantsAssetProvider.CreateThenLogicItemResultant();
            GameObject logicItemResultant;

            switch (logicItemInfo.logicItemType)
            {
                case LogicItemEnum.Action:
                    logicItemResultant = LogicResultantsAssetProvider.CreateActionLogicItemResultant();
                    break;
                case LogicItemEnum.Custom:
                    logicItemResultant = LogicResultantsAssetProvider.CreateCustomLogicItemResultant();
                    break;
                default:
                    throw new Exception("ThenResultant only accepts Action or Custom LogicItemInfo");
                    break;
            }
            addLogicItemInfoToComponent(logicItemResultant,logicItemInfo);
            return addResultantsToContainer(new List<GameObject>{ thenLogicItemResultant, logicItemResultant});
        }

        public static GameObject BuildIfActionResultant(LogicItemInfo logicItemInfo)
        {
            GameObject logicItemResultant;
            switch (logicItemInfo.logicItemType)
            {
                case LogicItemEnum.Action:
                    logicItemResultant = LogicResultantsAssetProvider.CreateActionLogicItemResultant();
                    addLogicItemInfoToComponent(logicItemResultant,logicItemInfo);
                    break;
                case LogicItemEnum.Done:
                    logicItemResultant = LogicResultantsAssetProvider.CreateDoneLogicItemResultant();
                    break;
                case LogicItemEnum.Else:
                    return buildElseLogicResultant(logicItemInfo);
                case LogicItemEnum.Custom:
                    logicItemResultant = LogicResultantsAssetProvider.CreateCustomLogicItemResultant();
                    break;
                default:
                    throw new Exception(
                        "BuildIfActionResultant only accepts LogicItemEnum of type Action,Custom, Done, or Else");
                    break;
            }
            return addResultantsToContainer(new List<GameObject> { logicItemResultant });
            
        }

        public static GameObject BuildActionResultant(LogicItemInfo logicItemInfo)
        {
            GameObject logicResultant;
            
            switch (logicItemInfo.logicItemType)
            {
                case LogicItemEnum.Action:
                    logicResultant = LogicResultantsAssetProvider.CreateActionLogicItemResultant();
                    break;
                case LogicItemEnum.Custom:
                    logicResultant = LogicResultantsAssetProvider.CreateCustomLogicItemResultant();
                    break;
                case LogicItemEnum.Done:
                    logicResultant = LogicResultantsAssetProvider.CreateDoneLogicItemResultant();
                    break;
                default:
                    throw new Exception("ActionResultant only accepts LogicItemInfo of Action/Custom/Done");
            }
            addLogicItemInfoToComponent(logicResultant,logicItemInfo);
            return addResultantsToContainer(new List<GameObject> { logicResultant });
        }
        private static void addLogicItemInfoToComponent(GameObject logicItemResultant, LogicItemInfo logicItemInfo)
        {
            var resultantInfo = logicItemResultant.GetComponent<LogicItemInfo>();
            resultantInfo.logicItemType = logicItemInfo.logicItemType;
            resultantInfo.logicItemResourceID = logicItemInfo.logicItemResourceID;
            resultantInfo.logicItemTitle = logicItemInfo.logicItemTitle;
        }
        private static GameObject addResultantsToContainer(List<GameObject> logicResultants)
        {
            var container = LogicContainerProvider.CreateGeneralLogicContainer();
            for (var i = 0; i < logicResultants.Count; i++)
            {
                var logicResultant = logicResultants[i];
                logicResultant.transform.SetParent(container.transform);
                logicResultant.transform.SetSiblingIndex(i);
            }
            return container;
        }
        private static GameObject buildElseLogicResultant(LogicItemInfo logicItemInfo)
        {
            var elseItem = LogicResultantsAssetProvider.CreateElseLogicItemResultant();
            var elseLogicGroup = LogicGroupAssetProvider.CreateElseLogicGroup();
            addLogicItemInfoToComponent(elseItem,logicItemInfo);
            return addResultantsToContainer(new List<GameObject> { elseItem, elseLogicGroup });
        }
    }
    
}