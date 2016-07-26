using UnityEngine;
using System.Collections;

public class Truncheon_hit : MonoBehaviour {

    public GameObject Truncheon;
    public bool g3 = false;
    
    public  AnimationClip    Anim_truncher_hit;
    public  AudioClip        Truncher_hit;
    public float Time_1 = 0.8f;
    private bool b1 = false;

    
	void Update () {

        if (g3 == false)
        {
            Truncheon.SetActive(false);
        }

        if (g3 == true)
        {
            Truncheon.SetActive(true);
        }




        if (Truncheon == true && Input.GetMouseButton(0) && b1 == false)
        {
            animation.Play(Anim_truncher_hit.name);
            audio.PlayOneShot(Truncher_hit);
            b1 = true;
            Time_1 = 0;
        }
        if (b1 == true)
        {
            Time_1 += Time.deltaTime;
        }
        if (Time_1 >= 0.8f)
        {
            b1 = false;
        }
	}
}
