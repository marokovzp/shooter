using UnityEngine;
using System.Collections.Generic;

public class AmmunitionController : MonoBehaviour {
    private List<GameObject> ammunitionList;
    public GameObject mainCamera;

    void Start () {
        ammunitionList = this.GetComponent<FPC_Equipment>().ammunitionList;
    }

    public void AddAmmunition(GameObject ammunition)
    {
        Debug.Log("ammunition addede");
        ammunitionList.Add(ammunition);

        ammunition.transform.parent = mainCamera.transform;
        ammunition.GetComponent<BoxCollider>().enabled = false;
        ammunition.SetActive(false);
    }
}
