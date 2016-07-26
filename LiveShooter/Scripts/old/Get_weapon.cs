using UnityEngine;
using System.Collections;

public class Get_weapon : MonoBehaviour {

    public GameObject FPC;
    public GameObject Weapon_1;

	

	void Update () {
	
        if (Vector3.Distance(transform.position,FPC.transform.position)<=2)
        {
            if (Input.GetKeyDown (KeyCode.E))
            {
                if (Weapon_1 == FPC.GetComponent<Weapon>().Truncheon_1)
                {

                    FPC.GetComponent<Weapon>().Truncheon = true;
                    FPC.GetComponent<Weapon>().Truncheon_equip = true;
                    FPC.GetComponent<Weapon>().w = 0;

                }

                if (Weapon_1 == FPC.GetComponent<Weapon>().Pistol_11)
                {
                    FPC.GetComponent<Weapon>().Pistol_1 = true;
                    FPC.GetComponent<Weapon>().Pistol_holder++;
                    FPC.GetComponent<Weapon>().Pistol_11_equip = true;
                    FPC.GetComponent<Weapon>().w = 1;
                    
                }

                if (Weapon_1 == FPC.GetComponent<Weapon>().Pistol_21)
                {
                    FPC.GetComponent<Weapon>().Pistol_2 = true;
                    FPC.GetComponent<Weapon>().Pistol_holder++;
                    FPC.GetComponent<Weapon>().Pistol_21_equip = true;
                    FPC.GetComponent<Weapon>().w = 2;
                  
                }

                if (Weapon_1 == FPC.GetComponent<Weapon>().Machin_gun_11)
                {
                    FPC.GetComponent<Weapon>().Mashin_gun_1 = true;
                    FPC.GetComponent<Weapon>().Machin_gun_holder++;
                    FPC.GetComponent<Weapon>().Mashin_gun_11_equip = true;
                    FPC.GetComponent<Weapon>().w = 3;
                  
                }

                if (Weapon_1 == FPC.GetComponent<Weapon>().Machin_gun_21)
                {
                    FPC.GetComponent<Weapon>().Mashin_gun_2 = true;
                    FPC.GetComponent<Weapon>().Machin_gun_holder++;
                    FPC.GetComponent<Weapon>().Mashin_gun_21_equip = true;
                    FPC.GetComponent<Weapon>().w = 4;
                  
                }
                FPC.GetComponent<Weapon>().GetComponent<AudioSource>().Play();
                Destroy(gameObject);
            }

        }
	}
}
