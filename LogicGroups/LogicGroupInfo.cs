using UnityEngine;

namespace Modding.TaskCreator
{
    public class LogicGroupInfo: MonoBehaviour
    {
        [SerializeField] public bool isInLogicGroup = false;
        [SerializeField] public LogicGroupEnum logicGroupType;
    }
}