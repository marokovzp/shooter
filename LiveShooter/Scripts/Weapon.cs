using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Weapon : MonoBehaviour
{

    public GameObject FPC;
    public GameObject Main_camera;

    public bool Truncheon;
    public bool Pistol_1;
    public bool Pistol_2;
    public bool Mashin_gun_1;
    public bool Mashin_gun_2;

    public GameObject Truncheon_1;
    public GameObject Pistol_11;
    public GameObject Pistol_21;
    public GameObject Machin_gun_11;
    public GameObject Machin_gun_21;

    public int Pistol_holder;
    public int Machin_gun_holder;

    public int w = 0;

    public bool Truncheon_equip = false;
    public bool Pistol_11_equip = false;
    public bool Pistol_21_equip = false;
    public bool Mashin_gun_11_equip = false;
    public bool Mashin_gun_21_equip = false;

    void Start()
    {

        Truncheon = false;
        Pistol_1 = false;
        Pistol_2 = false;
        Mashin_gun_1 = false;
        Mashin_gun_2 = false;

        Pistol_holder = 0;
        Machin_gun_holder = 0;


    }


    void Update()
    {



        if (Input.GetKeyDown(KeyCode.Q))
        {
            w++;
            Main_camera.GetComponent<Camera>().fieldOfView = 60;
            FPC.GetComponent<MouseLook>().sensitivityX = 15;
            Machin_gun_21.GetComponent<Machin_gun_Shoot>().Sniper_trigger = false;

        }
    }
    void CahngeWeapon(){

        if (w == 5)
        {
            w = 0;
        }


        if (w == 1 && Pistol_11_equip == false)
        {
            w = 2;
        }

        if (w == 2 && Pistol_21_equip == false)
        {
            w = 3;
        }

        if (w == 3 && Mashin_gun_11_equip == false)
        {
            w = 4;
        }

        if (w == 4 && Mashin_gun_21_equip == false)
        {
            w = 0;
        }



        if (w == 0 && Truncheon_equip == true)
        {
            Truncheon = true;
            Pistol_1 = false;
            Pistol_2 = false;
            Mashin_gun_1 = false;
            Mashin_gun_2 = false;
        }

        if (w == 1 && Pistol_11_equip == true)
        {
            Truncheon = false;
            Pistol_1 = true;
            Pistol_2 = false;
            Mashin_gun_1 = false;
            Mashin_gun_2 = false;
        }

        if (w == 2 && Pistol_21_equip == true)
        {
            Truncheon = false;
            Pistol_2 = true;
            Pistol_1 = false;
            Mashin_gun_1 = false;
            Mashin_gun_2 = false;
        }

        if (w == 3 && Mashin_gun_11_equip == true)
        {
            Truncheon = false;
            Mashin_gun_1 = true;
            Pistol_1 = false;
            Pistol_2 = false;
            Mashin_gun_2 = false;
        }

        if (w == 4 && Mashin_gun_21_equip == true)
        {
            Truncheon = false;
            Mashin_gun_2 = true;
            Pistol_1 = false;
            Pistol_2 = false;
            Mashin_gun_1 = false;
        }


        if (Truncheon == true)
        {
            Pistol_1 = false;
            Pistol_2 = false;
            Mashin_gun_1 = false;
            Mashin_gun_2 = false;

            Truncheon_1.GetComponent<Truncheon_hit>().g3 = true;
            Truncheon_1.GetComponent<Truncheon_hit>().Truncheon.SetActive(true);

            Pistol_11.GetComponent<Pistol_shoot>().g1 = false;
            Pistol_21.GetComponent<Pistol_shoot>().g2 = false;
            Pistol_11.GetComponent<Pistol_shoot>().Pistol_1.SetActive(false);
            Pistol_21.GetComponent<Pistol_shoot>().Pistol_2.SetActive(false);

            Machin_gun_21.GetComponent<Machin_gun_Shoot>().g2 = false;
            Machin_gun_11.GetComponent<Machin_gun_Shoot>().g1 = false;
            Machin_gun_21.GetComponent<Machin_gun_Shoot>().Machin_gun_2.SetActive(false);
            Machin_gun_11.GetComponent<Machin_gun_Shoot>().Machin_gun_1.SetActive(false);

        }
        if (Pistol_1 == true)
        {
            Truncheon = false;
            Pistol_2 = false;
            Mashin_gun_1 = false;
            Mashin_gun_2 = false;

            Truncheon_1.GetComponent<Truncheon_hit>().g3 = false;
            Truncheon_1.GetComponent<Truncheon_hit>().Truncheon.SetActive(false);

            Pistol_11.GetComponent<Pistol_shoot>().g1 = true;
            Pistol_21.GetComponent<Pistol_shoot>().g2 = false;
            Pistol_11.GetComponent<Pistol_shoot>().Pistol_1.SetActive(true);
            Pistol_21.GetComponent<Pistol_shoot>().Pistol_2.SetActive(false);

            Machin_gun_21.GetComponent<Machin_gun_Shoot>().g2 = false;
            Machin_gun_11.GetComponent<Machin_gun_Shoot>().g1 = false;
            Machin_gun_21.GetComponent<Machin_gun_Shoot>().Machin_gun_2.SetActive(false);
            Machin_gun_11.GetComponent<Machin_gun_Shoot>().Machin_gun_1.SetActive(false);


        }

        if (Pistol_2 == true)
        {
            Truncheon = false;
            Pistol_1 = false;
            Mashin_gun_1 = false;
            Mashin_gun_2 = false;

            Truncheon_1.GetComponent<Truncheon_hit>().g3 = false;
            Truncheon_1.GetComponent<Truncheon_hit>().Truncheon.SetActive(false);

            Pistol_21.GetComponent<Pistol_shoot>().g2 = true;
            Pistol_11.GetComponent<Pistol_shoot>().g1 = false;
            Pistol_21.GetComponent<Pistol_shoot>().Pistol_2.SetActive(true);
            Pistol_11.GetComponent<Pistol_shoot>().Pistol_1.SetActive(false);

            Machin_gun_21.GetComponent<Machin_gun_Shoot>().g2 = false;
            Machin_gun_11.GetComponent<Machin_gun_Shoot>().g1 = false;
            Machin_gun_21.GetComponent<Machin_gun_Shoot>().Machin_gun_2.SetActive(false);
            Machin_gun_11.GetComponent<Machin_gun_Shoot>().Machin_gun_1.SetActive(false);


        }

        if (Mashin_gun_1 == true)
        {
            Truncheon = false;
            Pistol_1 = false;
            Pistol_2 = false;
            Mashin_gun_2 = false;

            Truncheon_1.GetComponent<Truncheon_hit>().g3 = false;
            Truncheon_1.GetComponent<Truncheon_hit>().Truncheon.SetActive(false);

            Machin_gun_11.GetComponent<Machin_gun_Shoot>().g1 = true;
            Machin_gun_21.GetComponent<Machin_gun_Shoot>().g2 = false;
            Machin_gun_11.GetComponent<Machin_gun_Shoot>().Machin_gun_1.SetActive(true);
            Machin_gun_21.GetComponent<Machin_gun_Shoot>().Machin_gun_2.SetActive(false);

            Pistol_21.GetComponent<Pistol_shoot>().g2 = false;
            Pistol_11.GetComponent<Pistol_shoot>().g1 = false;
            Pistol_21.GetComponent<Pistol_shoot>().Pistol_2.SetActive(false);
            Pistol_11.GetComponent<Pistol_shoot>().Pistol_1.SetActive(false);


        }

        if (Mashin_gun_2 == true)
        {
            Truncheon = false;
            Pistol_1 = false;
            Pistol_2 = false;
            Mashin_gun_1 = false;

            Truncheon_1.GetComponent<Truncheon_hit>().g3 = false;
            Truncheon_1.GetComponent<Truncheon_hit>().Truncheon.SetActive(false);

            Machin_gun_21.GetComponent<Machin_gun_Shoot>().g2 = true;
            Machin_gun_11.GetComponent<Machin_gun_Shoot>().g1 = false;
            Machin_gun_21.GetComponent<Machin_gun_Shoot>().Machin_gun_2.SetActive(true);
            Machin_gun_11.GetComponent<Machin_gun_Shoot>().Machin_gun_1.SetActive(false);

            Pistol_21.GetComponent<Pistol_shoot>().g2 = false;
            Pistol_11.GetComponent<Pistol_shoot>().g1 = false;
            Pistol_21.GetComponent<Pistol_shoot>().Pistol_2.SetActive(false);
            Pistol_11.GetComponent<Pistol_shoot>().Pistol_1.SetActive(false);


        }

        if (Pistol_holder == 0 && Machin_gun_holder != 0)
        {
            if (Mashin_gun_11_equip == true && Mashin_gun_21_equip == true || Mashin_gun_11_equip == false && Mashin_gun_21_equip == true || Mashin_gun_11_equip == true && Mashin_gun_21_equip == false)
            {
                w = 3;
 
       }

            if (Mashin_gun_11_equip == false && Mashin_gun_21_equip == false)
            { w = 0; }
        }

        if (Machin_gun_holder == 0 && Pistol_holder != 0)
        {
            if (Pistol_11_equip == true && Pistol_21_equip == true || Pistol_11_equip == false && Pistol_21_equip == true || Pistol_11_equip == true && Pistol_21_equip == false)
            {
                w = 1;
           }

            if (Pistol_11_equip == false && Pistol_21_equip == false)
            { w = 0; }
        }

        if (Machin_gun_holder == 0 && Pistol_holder == 0)
        {
            w = 0;
        }

    }
}
