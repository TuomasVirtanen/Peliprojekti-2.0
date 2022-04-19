using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{

    public static AudioClip runSound, attackSound, jumpSound, portalSound;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        runSound = Resources.Load<AudioClip>("run");
        attackSound = Resources.Load<AudioClip>("hit");
        jumpSound = Resources.Load<AudioClip>("jump");
        portalSound = Resources.Load<AudioClip>("portal");

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound (string clip)
    {
        switch (clip)
        {
            case "run":
                audioSrc.PlayOneShot(runSound);
                break;
            case "hit":
                audioSrc.PlayOneShot(attackSound);
                break;
            case "jump":
                audioSrc.PlayOneShot(jumpSound);
                break;
            case "portal":
                audioSrc.PlayOneShot(portalSound);
                break;
        }
    }
}
