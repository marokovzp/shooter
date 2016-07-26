using UnityEngine;
using System.Collections.Generic;

public class WeaponController : MonoBehaviour {

    private List<GameObject> weaponList;
    public GameObject mainCamera;
    private GameObject activeWeapon;

    private void Start()
    {
        weaponList = this.GetComponent<FPC_Equipment>().weaponList;
        activeWeapon = this.GetComponent<FPC_Equipment>().weapon;
    }

	void Update () {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ChangeWeapon();
        }
        if (this.activeWeapon.GetComponent<WeaponParameters>().holderCount == 0)        //закончились патроны
            if(!RechargeWeapon())                                                       //пробуем перезарядить
                ChangeWeapon();                                                         //или меняем оружие


        if (Input.GetMouseButton(0))
        {
            this.activeWeapon.GetComponent<ShootController>().Shot();
        }
    }

    public void AddWeapon(GameObject weapon)
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
    }

    private void ChangeWeapon()
    {

        this.activeWeapon.SetActive(false);

        int tmp = weaponList.IndexOf(this.activeWeapon);
        for (int i = tmp + 1; i < weaponList.Count; i++)  //перебираем лист от 0; до последнего; с шагом 
        {
            if (weaponList[i].GetComponent<WeaponParameters>().holderCount != 0)
            {                
                //меняем оружие
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

    private bool RechargeWeapon()
    {
        foreach(GameObject amm in this.GetComponent<FPC_Equipment>().ammunitionList)
        {
            //одинаковые ли названия у аммуниции в листе и в активном оружии
            if (amm.GetComponent<AmmunitionParameters>().nameAmmunition == activeWeapon.GetComponent<WeaponParameters>().holder.GetComponent<AmmunitionParameters>().nameAmmunition)
            {
                activeWeapon.GetComponent<WeaponParameters>().holderCount = amm.GetComponent<AmmunitionParameters>().ammunitionCapacity;
                this.GetComponent<FPC_Equipment>().ammunitionList.Remove(amm);
                return true;
            }            
        }
        return false;
    }

    void OnGUI()
    {
        if (activeWeapon.GetComponent<WeaponParameters>().type == "Gun" ||
            activeWeapon.GetComponent<WeaponParameters>().type == "MachineGun")
        {
            GUI.DrawTexture(new Rect((Screen.width - 50) / 2, (Screen.height - 50) / 2, 50, 50), activeWeapon.GetComponent<WeaponParameters>().Sight);
        }
    }
}
