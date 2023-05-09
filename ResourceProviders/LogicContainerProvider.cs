using UnityEngine;

namespace Modding.TaskCreator
{
    public class LogicContainerProvider: MonoBehaviour
    {
        private static string containersDir = "Modding/TaskCreator/Containers/";
        
        public static GameObject CreateGeneralLogicContainer()
        {
            return GetResourceWithName("GeneralLogicContainer");
        }
        
        public static GameObject CreateIfLogicContainer()
        {
            return GetResourceWithName("IfLogicContainer");
        }
        private static GameObject GetResourceWithName(string resourceName)
        {
            return Instantiate(Resources.Load(containersDir + resourceName) as GameObject);
        }
    }
}