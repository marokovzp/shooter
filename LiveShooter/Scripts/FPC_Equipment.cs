using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FPC_Equipment : MonoBehaviour {

    public GameObject weapon;
    public GameObject arm;
    //[HideInInspector]
    public List<GameObject> weaponList;
    public List<GameObject> ammunitionList;

    private void Start()
    {
        weaponList = new List<GameObject>();
        weaponList.Add(weapon);

        ammunitionList = new List<GameObject>();
    }
}
