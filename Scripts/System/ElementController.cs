
namespace SystemPadoru
{

    using UnityEngine;
    using Model;

    public class ElementController : MonoBehaviour
    {

        public Transform[] elements;
        private Renderer render;

        public Element elementToChose;

        //Método para cambiar el color de un determinado elemento.
        public void ChangeColor(int indexElement)
        {
            GameObject gameManager = GameObject.FindGameObjectWithTag("GameManager");
            Color colorToChange;
            render = elements[indexElement].gameObject.GetComponent<Renderer>();

            if (gameManager.GetComponent<GameManager>())
            {
                colorToChange = gameManager.GetComponent<GameManager>().colorChose;

                render.material.color = colorToChange;
            }
        }

        private void OnMouseDown()
        {
            GameObject gameManager = GameObject.FindGameObjectWithTag("GameManager");

            if (gameManager.GetComponent<GameManager>())
            {
                gameManager.GetComponent<GameManager>().SelectObject(elementToChose);
                gameManager.GetComponent<GameManager>().SelectItemToColor(elements[0].gameObject);
                gameManager.GetComponent<GameManager>().InstantiateColorsButtons();
            }
        }

    }

}