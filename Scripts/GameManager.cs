namespace SystemPadoru
{

    using UnityEngine;
    using Model;
    using System.Collections.Generic;
    using System.Linq;

    public class GameManager : MonoBehaviour
    {
        public Color colorChose; //Color (en codigo RGBA) elegido por el usuario.
        public List<GameObject> listPrefabObjects; //Lista de prefabs. Piensalo como el catalogo existente de elementos, como gorros, ropa, cabello, etc.
        public GameObject buttonToInstantiate; //GameObject del boton qué permite seleccionar que parte del elemento se cambiará el color.
        public GameObject areaToInstantiate; //Gameobject donde se depositaran la lista de botones que cambian los colores.
        public Element gameObjectSelected; //Elemento seleccionado por el usuario. El cuál se modificará. Solo es la información del objeto, más no su gameObject.
        public GameObject objectToColor; //Elemento seleccionado por el usuario. 
        public Transform pointToInstantiate; //Posición en el cuál se instanciará el objetpo seleccionado por el usuario.
        public GameObject ObjetoCompleto;
        public List<GameObject> listObjectInScene;

        private void Start()
        {
            listObjectInScene = new List<GameObject>();
        }

        //Método que selecciona el elemento a modificar.
        public void SelectObject(Element gameObjectSelected)
        {

            this.gameObjectSelected = gameObjectSelected;
        }

        public void SelectItemToColor(GameObject objectToColor2)
        {
            Debug.Log(objectToColor2);
            this.objectToColor = objectToColor2;
        }

        public void InstantiateColorsButtons()
        {
            RemoveColorButtons();
            Transform temporal = null;
            for (int i = 0; i < gameObjectSelected.numberComponents; i++)
            {
                temporal = Instantiate(buttonToInstantiate.transform, transform.position, transform.rotation);
                temporal.parent = areaToInstantiate.transform;
                temporal.localScale = new Vector3(20, 20, 20);
                temporal.position = new Vector3(temporal.position.x, temporal.position.y, 15);
                if (temporal.GetComponent<ChangeColorController>())
                {
                    temporal.GetComponent<ChangeColorController>().SetttingController(ObjetoCompleto.gameObject, i);
                }
            }
            objectToColor = temporal.gameObject;

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

            if (IsCreatedObjectBefore(gameObjectSelected.idElement))
            {
                return;
            }

            Transform gameSelected = Instantiate(listPrefabObjects[gameObjectSelected.idElement].transform, pointToInstantiate.position, pointToInstantiate.rotation);
            listObjectInScene.Add(gameSelected.gameObject);

            if (gameSelected.gameObject.GetComponent<ElementController>())
            {
                ObjetoCompleto = gameSelected.gameObject;
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

        private bool IsCreatedObjectBefore(int index)
        {
            bool isCreated = false;

            if (listObjectInScene.FirstOrDefault(x => x.GetComponent<ElementController>().elementToChose.idElement == index))
            {
                isCreated = true;
            }

            return isCreated;
        }

    }

}