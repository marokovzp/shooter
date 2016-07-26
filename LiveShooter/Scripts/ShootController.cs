using UnityEngine;
using System.Collections;

public class ShootController : MonoBehaviour
{

    public GameObject MainCamera;

    public AnimationClip shootAnimationClip;
    public AnimationClip rechargeAnimationClip;
    public int shootAnimationClipSpeed = 2;
    public float afterShootTime = 0;
    public float shootDelay;
    public float rechargeDelay;

    public GameObject Bullet;

    public AudioClip shoot;
    public AudioClip recharge;

    private AudioSource shootAudioSorce;

    void Awake()
    {

        animation[shootAnimationClip.name].speed = shootAnimationClipSpeed;
        shootAudioSorce = GetComponent<AudioSource>();

    }

    void Update()
    {
        if (afterShootTime > 0)
            afterShootTime -= Time.fixedDeltaTime;

    }


    public void OneShoot()
    {
            animation.Play(shootAnimationClip.name);
        if (Bullet != null)
        {
            Instantiate(Bullet, MainCamera.transform.position, MainCamera.transform.rotation);
        }
        shootAudioSorce.PlayOneShot(shoot);

        afterShootTime = shootDelay;

    }

    
}
