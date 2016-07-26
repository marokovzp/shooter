using UnityEngine;
using System.Collections.Generic;

public class WeaponController : MonoBehaviour
{

    private List<GameObject> weaponList;
    public GameObject mainCamera;
    private GameObject activeWeapon;



    private void Start()
    {
        weaponList = this.GetComponent<FPC_Equipment>().weaponList;
        activeWeapon = this.GetComponent<FPC_Equipment>().weapon;
    }

    /// <summary>
    /// Реагирует на столкновение с объектом
    /// </summary>
    /// <param name="col">с чем столкнулись</param>
    public void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("weapon")) AddWeapon(col.gameObject);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        { ChangeWeapon(); }
        
        if (this.activeWeapon.GetComponent<WeaponParameters>().holderCount == 0)
        { ChangeWeapon(); }

        if (Input.GetMouseButton(0) && this.activeWeapon.GetComponent<ShootController>().afterShootTime <= 0)
        { this.activeWeapon.GetComponent<ShootController>().OneShoot(); }

    }


    private void AddWeapon(GameObject weapon)
    {
        foreach (GameObject w in weaponList)
        {
            if (w.GetComponent<WeaponParameters>().nameWeapon == weapon.GetComponent<WeaponParameters>().nameWeapon)
            {
                this.GetComponent<FPC_Equipment>().ammunitionList.Add(weapon.GetComponent<WeaponParameters>().holder);
                Destroy(weapon);
                return;
            }
        }
        weaponList.Add(weapon);
        weapon.transform.parent = mainCamera.transform;

        weapon.transform.localPosition = weapon.GetComponent<WeaponParameters>().FPS_usePosition;
        weapon.transform.localScale = weapon.GetComponent<WeaponParameters>().FPS_useScale;
        weapon.transform.localRotation = Quaternion.Euler(weapon.GetComponent<WeaponParameters>().FPS_useRotationEuler);

        weapon.GetComponent<BoxCollider>().enabled = false;
        weapon.SetActive(false);

        Debug.Log(weapon.GetComponent<WeaponParameters>().nameWeapon);
    }

    private void ChangeWeapon()
    {
        Debug.Log("qqqqqq");
        this.activeWeapon.SetActive(false);

        int tmp = weaponList.IndexOf(this.activeWeapon);
        for (int i = tmp + 1; i < weaponList.Count; i++)  //перебираем лист от 0; до последнего; с шагом 
        {
            if (weaponList[i].GetComponent<WeaponParameters>().holderCount != 0)
            {
                //то взять в руку
                this.activeWeapon = weaponList[i];
                this.activeWeapon.SetActive(true);

                return;                                             //выйти из мтода Update()
            }
        }

        for (int i = 0; i <= tmp; ++i)
        {
            if (weaponList[i].GetComponent<WeaponParameters>().holderCount != 0)
            {
                //то взять в руку
                this.activeWeapon = weaponList[i];
                weaponList[i].SetActive(true);
                this.activeWeapon.SetActive(true);
                return;                                             //выйти из мтода Update()
            }
        }
    }

    void OnGUI()
    {
        if (this.activeWeapon.GetComponent<WeaponParameters>().Sight != null)
            GUI.DrawTexture(new Rect((Screen.width - 50) / 2, (Screen.height - 50) / 2, 50, 50), activeWeapon.GetComponent<WeaponParameters>().Sight);
    }
}
