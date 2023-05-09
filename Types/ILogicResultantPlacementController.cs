using UnityEngine;

namespace Modding.TaskCreator
{
    public interface ILogicResultantPlacementController
    {
        public void PlaceIfLogicResultant(GameObject parentContainer, LogicItemInfo LogicItemInfo);

        public void PlaceThenLogicResultant(GameObject parentContainer, LogicItemInfo LogicItemInfo);

        public void PlaceIfActionLogicResultant(GameObject parentContainer, LogicItemInfo LogicItemInfo);

        public void PlaceActionLogicResultant(GameObject parentContainer, LogicItemInfo LogicItemInfo);

        public void PlaceElseActionLogicResultant(GameObject parentContainer, LogicItemInfo LogicItemInfo);

        public void PlaceGeneralLogicResultant(GameObject parentContainer, LogicItemInfo LogicItemInfo);
    }
}