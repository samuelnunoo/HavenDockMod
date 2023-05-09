using UnityEngine;

namespace Modding.TaskCreator
{
    public class LogicResultantsAssetProvider: MonoBehaviour
    {
        private static readonly string _taskCreatorFolderPath = "Modding/TaskCreator/";
        private static readonly string logicResultants = _taskCreatorFolderPath + "LogicResultants/";
        
        public static GameObject CreateIfLogicItemResultant() {
            return CreateLogicItemResultant("IfLogicItemResultant");
        }

        public static GameObject CreateDoneLogicItemResultant()
        {
            return CreateLogicItemResultant("DoneLogicItemResultant");
        }
        
        public static GameObject CreateStatementLogicItemResultant()
        {
            return CreateLogicItemResultant("StatementLogicItemResultant");
        }

        public static GameObject CreateThenLogicItemResultant()
        {
            return CreateLogicItemResultant("ThenLogicItemResultant");
        }

        public static GameObject CreateActionLogicItemResultant()
        {
            return CreateLogicItemResultant("ActionLogicItemResultant");
        }

        public static GameObject CreateCustomLogicItemResultant()
        {
            return CreateLogicItemResultant("CustomLogicItemResultant");
        }

        public static GameObject CreateElseLogicItemResultant()
        {
            return CreateLogicItemResultant("ElseLogicItemResultant");
        }

        private static GameObject CreateGameObject(string gameObjectName)
        {
            return Instantiate(Resources.Load(_taskCreatorFolderPath + gameObjectName) as GameObject);
        }

        private static GameObject CreateLogicItemResultant(string logicItemResultant)
        {
            return Instantiate(Resources.Load(logicResultants + logicItemResultant) as GameObject);
        }
    }
}