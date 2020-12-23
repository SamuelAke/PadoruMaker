
namespace SystemPadoru
{
    using UnityEngine;
    using Model;

    public class ItemController : MonoBehaviour
    {

        public Element elementToChose;

        public void SelectElement()
        {
            GameObject gameManager = GameObject.FindGameObjectWithTag("GameManager");
            if (gameManager.GetComponent<GameManager>())
            {
                gameManager.GetComponent<GameManager>().SelectObject(elementToChose);
                gameManager.GetComponent<GameManager>().InstantiatePrefabObject();
            }
        }
    }
}
