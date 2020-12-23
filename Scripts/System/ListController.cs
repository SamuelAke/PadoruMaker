namespace SystemPadoru
{
    using System.Collections.Generic;
    using UnityEngine;

    public class ListController : MonoBehaviour
    {

        private List<Transform> listElements;

        public void SetListElements(List<Transform> listElements)
        {
            this.listElements = listElements;
        }



    }
}
