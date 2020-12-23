namespace SystemPadoru
{

    using UnityEngine;
    using Model;
    using System.Collections.Generic;

    public class GameManager : MonoBehaviour
    {
        public Color colorChose; //Color (en codigo RGBA) elegido por el usuario.
        public List<GameObject> listPrefabObjects; //Lista de prefabs. Piensalo como el catalogo existente de elementos, como gorros, ropa, cabello, etc.
        public GameObject buttonToInstantiate; //GameObject del boton qué permite seleccionar que parte del elemento se cambiará el color.
        public GameObject areaToInstantiate; //Gameobject donde se depositaran la lista de botones que cambian los colores.
        public Element gameObjectSelected; //Elemento seleccionado por el usuario. El cuál se modificará. Solo es la información del objeto, más no su gameObject.
        private GameObject objectToColor; //Elemento seleccionado por el usuario. 
        public Transform pointToInstantiate; //Posición en el cuál se instanciará el objetpo seleccionado por el usuario.


        //Método que selecciona el elemento a modificar.
        public void SelectObject(Element gameObjectSelected)
        {
            this.gameObjectSelected = gameObjectSelected;
        }

        public void SelectItemToColor(GameObject objectToColor)
        {
            this.objectToColor = objectToColor;
        }

        public void InstantiateColorsButtons()
        {
            RemoveColorButtons();
            for (int i = 0; i < gameObjectSelected.numberComponents; i++)
            {
                Transform temporal = Instantiate(buttonToInstantiate.transform, transform.position, transform.rotation);
                temporal.parent = areaToInstantiate.transform;
                if (temporal.GetComponent<ChangeColorController>())
                {
                    temporal.GetComponent<ChangeColorController>().SetttingController(objectToColor, i);
                }
            }

        }

        private void RemoveColorButtons()
        {
            int numberChilds = areaToInstantiate.transform.childCount;
            for (int i = 0; i < numberChilds; i++)
            {
                Destroy(areaToInstantiate.transform.GetChild(0));
            }
        }

        public void InstantiatePrefabObject()
        {
            Transform gameSelected = Instantiate(listPrefabObjects[gameObjectSelected.idElement].transform, pointToInstantiate.position, pointToInstantiate.rotation);

            if (gameSelected.gameObject.GetComponent<ElementController>())
            {
                objectToColor = gameSelected.gameObject.GetComponent<ElementController>().elements[0].gameObject;
                InstantiateColorsButtons();
            }

        }

        public void RemoveSelectItemToColor()
        {
            this.objectToColor = null;
        }

        public void ChangeColor()
        {
            if (objectToColor == null)
            {
                return;
            }

            if (objectToColor.GetComponent<ChangeColorController>())
            {
                objectToColor.GetComponent<ChangeColorController>().ChangeColor();
            }
        }

    }

}