using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "New Player", menuName = "Player", order = 0)]
    public class Player : ScriptableObject
    {
        [Header("Store")]
        //The Store ICon
        public Sprite _storeIcon;

        public string _itemName;
        public string _itemDescription;
        public string _itemPrice;
        
        [Header("Playable")]
        public int _life;
     
        
        public Mesh _mesh;
        public List<Material> _Material;
    }
