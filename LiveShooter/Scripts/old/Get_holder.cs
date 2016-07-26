using UnityEngine;
using System.Collections;

public class Get_holder : MonoBehaviour
{

    public GameObject FPC;
    public GameObject Weapon_1;
	

	void Update () {
	
        if (Vector3.Distance(transform.position,FPC.transform.position)<=2)
        {
           {
               if (Weapon_1 == FPC.GetComponent<Weapon>().Pistol_11 || Weapon_1 == FPC.GetComponent<Weapon>().Pistol_21)
                {
                    FPC.GetComponent<Weapon>().Pistol_holder++;
                    
                }

               if (Weapon_1 == FPC.GetComponent<Weapon>().Machin_gun_11 || Weapon_1 == FPC.GetComponent<Weapon>().Machin_gun_21)
                {
                    FPC.GetComponent<Weapon>().Machin_gun_holder++;
                    
                }
               FPC.GetComponent<Weapon>().GetComponent<AudioSource>().Play();
                Destroy(gameObject);
            }
        }
	}
}
