
namespace SystemPadoru
{
    using UnityEngine;

    public class ChangeColorController : MonoBehaviour
    {
        public GameObject objectToChange;
        public int indexToChange;

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

        public void SelectObject()
        {
            GameObject gameManager = GameObject.FindGameObjectWithTag("GameManager");

            gameManager.GetComponent<GameManager>().SelectItemToColor(gameObject);
        }

        private void OnMouseDown()
        {
            SelectObject();
        }

    }
}
