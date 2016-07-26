using UnityEngine;
using System.Collections;

public class ShootController : MonoBehaviour {

    public GameObject MainCamera;

    public AnimationClip shootAnimationClip;
    public AnimationClip rechargeAnimationClip;
    private int shootAnimationClipSpeed = 2;
    public float shootDelay;
    private float afterShootTime = 0;
    public float rechargeDelay;

    public GameObject Bullet;

    public AudioClip shoot;
    public AudioClip recharge;

    private AudioSource shootAudioSorce;

	void Awake () {

        GetComponent<Animation>()[shootAnimationClip.name].speed = shootAnimationClipSpeed;
        shootAudioSorce = GetComponent<AudioSource>();
	}
	
    void Start()
    {
        afterShootTime = 0;
    }
	void Update () {

        afterShootTime -= Time.deltaTime;
        if (afterShootTime <= 0)
        {
            GetComponent<Animation>().Play(shootAnimationClip.name);
            Instantiate(Bullet, MainCamera.transform.position, MainCamera.transform.rotation);
            shootAudioSorce.PlayOneShot(shoot);

            afterShootTime = shootDelay;
        }
	}
}
