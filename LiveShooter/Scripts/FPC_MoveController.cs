using UnityEngine;
using System.Collections;

public class FPC_MoveController : MonoBehaviour {
    private AudioSource audioSorce;
    public AudioClip pickUpObjectAudio;

    void Start()
    {
        audioSorce = this.GetComponent<AudioSource>();
    }

    /// <summary>
    /// Реагирует на столкновение с объектом
    /// </summary>
    /// <param name="col">с чем столкнулись</param>
    public void OnTriggerEnter(Collider col)
    {
        Debug.Log(col.gameObject.name);
        if (col.CompareTag("weapon"))
        {
            this.GetComponent<WeaponController>().AddWeapon(col.gameObject);
            PlayAudio(pickUpObjectAudio);
        }
        else if (col.CompareTag("ammunition"))
        {
            this.GetComponent<AmmunitionController>().AddAmmunition(col.gameObject);
            PlayAudio(pickUpObjectAudio);
        }
    }

    private void PlayAudio(AudioClip clip)
    {
        audioSorce.PlayOneShot(clip);
    }
}
