using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{

    public GameObject Bullet_Hole;
    private RaycastHit RayH;
        


	void Start () {

	
	}
	
	


	void Update () {

        transform.Translate(0,0,1);


        if (Physics.Raycast(transform.position, transform.forward, out RayH, 100.00f))
        {
            if (RayH.transform.tag == "Enemy")
            {
                Instantiate(Bullet_Hole, RayH.point, Quaternion.identity);
            }

        }


        
        Destroy(gameObject, 0.5f);
	}
}
