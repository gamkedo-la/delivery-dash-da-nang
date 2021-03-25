using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownImagesController : MonoBehaviour
{
    public Image countdownDisplay;

    public GameObject[] countdownSpritesList;
    public GameObject currentSprite;

    public Image imageComponent;
    

    public AudioClip[] countdownAudioClipsList;
    public AudioClip currentAudioClip;

    //public AudioManager audioManager;

    public GameObject player;

    private AudioSource countdownImagesAudioSource;


    public void Awake()
    {
        currentSprite = countdownSpritesList[3];
        
        currentAudioClip = countdownAudioClipsList[3];
        countdownImagesAudioSource = transform.GetComponent<AudioSource>();
    }

    private void Start()
    {
        //Debug.Log("anything");
        if (countdownAudioClipsList.Length != 0)
        {
            countdownImagesAudioSource.PlayOneShot(currentAudioClip);
        }    
        
        StartCoroutine(CountdownToStart());
    }

    IEnumerator CountdownToStart()
    {
        int countdownTime = 3;
        
       
        while (countdownTime > -1)
        {
            yield return new WaitForSeconds(1f);
            countdownTime--;
            
            if (countdownTime >= 0)
            {
                countdownSpritesList[countdownTime + 1].SetActive(false);
                countdownSpritesList[countdownTime].SetActive(true);
                currentAudioClip = countdownAudioClipsList[countdownTime];

                if (countdownAudioClipsList.Length != 0)
                {
                    countdownImagesAudioSource.PlayOneShot(currentAudioClip);
                }
            }
        }
        
        gameObject.SetActive(false);
    }
}
