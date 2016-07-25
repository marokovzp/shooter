using UnityEngine;
using System.Collections;

public class FPC_MoveController : MonoBehaviour {

    /// <summary>
    /// Реагирует на столкновение с объектом
    /// </summary>
    /// <param name="col">с чем столкнулись</param>
    public void OnTriggerEnter(Collider col)
    {
        Debug.Log(col.gameObject.name);
        if (col.CompareTag("weapon")) { this.GetComponent<WeaponController>().AddWeapon(col.gameObject); }
        else if (col.CompareTag("ammunition")) { this.GetComponent<FPC_Equipment>().AddAmmunition(col.gameObject); }
    }
}
