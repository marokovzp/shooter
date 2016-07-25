using UnityEngine;
using System.Collections;

public class Pistol_shoot : MonoBehaviour
{
    public GameObject FPC;

    public GameObject Pistol_1;
    public GameObject Pistol_2;
    public bool g1 = false;
    public bool g2 = false;

    public AnimationClip Anim_Pistol_shoot_1;
    public AnimationClip Anim_Pistol_recharge;
    private int Anim_shoot_speed = 2;
    private float Time_1;
    private bool a1 = false;
    private float Recharge_shoot_time = 0.8f;

    
    private float Recharge_time = 0;
    private int bullets = 8;
    private int a2 = 0;
    private bool a3 = false;

    public Texture2D Sight;

    public Transform Bullet_pos;
    public GameObject Bullet;

    public AudioClip shoot;
    public AudioClip recharge;

    void Start()
    {

        GetComponent<Animation>()[Anim_Pistol_shoot_1.name].speed = Anim_shoot_speed;
        Time_1 = Recharge_shoot_time;

    }


    void Update()
          {
              if (g1 == false && g2 == false)
              {
                  Pistol_1.SetActive(false);
                  Pistol_2.SetActive(false);
              }

        if (g1 == true)
        {
            Pistol_1.SetActive(true);
            Pistol_2.SetActive(false);
            g1 = true;
            g2 = false;
        }
        if (g2 == true)
        {
            Pistol_2.SetActive(true);
            Pistol_1.SetActive(false);
            g2 = true;
            g1 = false;
        }


        if (Pistol_1 == true || Pistol_2 == true)
        {
            if (Input.GetMouseButton(0) && Time_1 >= Recharge_shoot_time && a3 == false && FPC.GetComponent<Weapon>().Pistol_holder > 0)
            {
                if (a2 < bullets)
                {
                    GetComponent<Animation>().Play(Anim_Pistol_shoot_1.name);

                    Instantiate(Bullet, Bullet_pos.transform.position, Bullet_pos.rotation);

                    GetComponent<AudioSource>().PlayOneShot(shoot);

                    Time_1 = 0;
                    a2 = a2 + 1;
                    a1 = true;

                }
                else
                {
                    a1 = true;
                    a2 = a2 + 1;
                }

            }

                     
            if (a1 == true)
            {
                Time_1 += Time.deltaTime;
                if (Time_1 >= Recharge_shoot_time)
                {
                    a1 = false;
                }
            }

            if (a2 > bullets)
            {
                GetComponent<Animation>().Play(Anim_Pistol_recharge.name);
                a2 = 0;
                a3 = true;
                GetComponent<AudioSource>().PlayOneShot(recharge);
                FPC.GetComponent<Weapon>().Pistol_holder --;
            }

            if (a3 == true)
            {
                Recharge_time += Time.deltaTime;
            }

            if (Recharge_time >= 1)
            {
                Recharge_time = 0;
                a3 = false;

            }

        }
    }
    


    void OnGUI()
    {
        GUI.DrawTexture(new Rect((Screen.width - 50) / 2, (Screen.height - 50) / 2, 50, 50), Sight);
    }
}

