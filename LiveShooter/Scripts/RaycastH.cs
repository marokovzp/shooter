using UnityEngine;
using System.Collections;

public class RaycastH : MonoBehaviour
{

    public GameObject Enemy;

    private RaycastHit RayH;
   
	void Start () {
	
	}
	
	
	void Update () {
	
        if (Physics.Raycast(transform.position, transform.forward, out RayH, 30.0f))
        {
            if (RayH.transform.tag == "Enemy")
                Destroy(Enemy);
        }

	}
}
