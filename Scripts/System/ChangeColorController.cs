
namespace SystemPadoru
{
    using UnityEngine;

    public class ChangeColorController : MonoBehaviour
    {
        private GameObject objectToChange;
        private int indexToChange;

        public void SetttingController(GameObject objectToChange, int indexToChange)
        {
            this.objectToChange = objectToChange;
            this.indexToChange = indexToChange;
        }

        public void ChangeColor()
        {
            if (objectToChange.GetComponent<ElementController>())
            {
                objectToChange.GetComponent<ElementController>().ChangeColor(indexToChange);
            }
        }


    }
}
