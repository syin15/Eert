using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    [SerializeField] public static AudioClip jumpSound;
    public static AudioClip fallingSound, eyeBallSound, mainMenuSound, doorSound, doorBreakSound;
    [SerializeField] private static AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        jumpSound = Resources.Load<AudioClip>("Nodelay-jumping_effect");
        fallingSound = Resources.Load<AudioClip>("falling_effect");
        eyeBallSound = Resources.Load<AudioClip>("eyeballs_effect");
        mainMenuSound = Resources.Load<AudioClip>("menu_music");
        doorSound = Resources.Load<AudioClip>("Door_effect");
        doorBreakSound = Resources.Load<AudioClip>("Break_effect");
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "jump":
                audioSource.PlayOneShot(jumpSound);
                break;
            case "falling":
                audioSource.PlayOneShot(fallingSound);
                break;
            case "eyeball":
                audioSource.PlayOneShot(eyeBallSound);
                break;
            case "mainmenu music":
                audioSource.PlayOneShot(mainMenuSound);
                break;
            case "door":
                audioSource.PlayOneShot(doorSound);
                break;
            case "doorBreak":
                audioSource.PlayOneShot(doorBreakSound);
                break;
        }
    }
}
