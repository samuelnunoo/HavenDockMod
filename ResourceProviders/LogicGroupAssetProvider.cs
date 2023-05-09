using UnityEditor;
using UnityEngine;

namespace Modding.TaskCreator
{ 
    
    /*
     *
     * Module Use Case:
     *  This module is responsible for providing Logic Group Assets for the rest of the modules to use 
     */
    public class LogicGroupAssetProvider : MonoBehaviour
    {
        private static readonly string _taskCreatorFolderPath = "Modding/TaskCreator/";
        public static GameObject CreateActionLogicGroup()
        {
            return Instantiate(Resources.Load(_taskCreatorFolderPath + "LogicGroups/ActionLogicGroup") as GameObject);
        }

        public static GameObject CreateElseLogicGroup()
        {
            return Instantiate(Resources.Load(_taskCreatorFolderPath + "LogicGroups/ElseLogicGroup") as GameObject);
        }
        public static GameObject CreateGeneralLogicGroup()
        {
            return Instantiate(Resources.Load(_taskCreatorFolderPath + "LogicGroups/GeneralLogicGroup") as GameObject);

        }

        public static GameObject CreateIfActionLogicGroup()
        {
            return Instantiate(Resources.Load(_taskCreatorFolderPath + "LogicGroups/IfActionLogicGroup") as GameObject);
        }
        public static GameObject CreateIfLogicGroup()
        {
            return Instantiate(Resources.Load(_taskCreatorFolderPath + "LogicGroups/IfLogicGroup") as GameObject);
        }

        public static GameObject CreateThenLogicGroup()
        {
            return Instantiate(Resources.Load(_taskCreatorFolderPath + "LogicGroups/ThenLogicGroup") as GameObject);
        }
        public static GameObject CreateLogicGroup()
        {
            return Instantiate(Resources.Load(_taskCreatorFolderPath + "LogicGroup") as GameObject);
        }
    }
}