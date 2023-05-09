using UnityEngine;

namespace Modding.TaskCreator
{
    
    /*
     *
     * Module Use Case:
     *  This module is responsible for providing access to global
     *  resources such as Canvas.
     */
    public class GlobalResourceProvider: MonoBehaviour
    {
        public static GameObject GetCanvas()
        {
            return GameObject.FindGameObjectWithTag("UI Canvas");
        }
    }
}