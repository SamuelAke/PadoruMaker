namespace Model
{
    using System;
    using UnityEngine;
    using Model.Enumerators;

    [Serializable]
    public class Element
    {

        [SerializeField]
        public int idElement;
        public int numberComponents;
        public TypeElement type;
    }
}