using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownImagesController : MonoBehaviour
{
    public Image countdownDisplay;

    public Sprite[] countdownSpritesList;
    public Sprite currentSprite;

    public Image imageComponent;
    

    public AudioClip[] countdownAudioClipsList;
    public AudioClip currentAudioClip;

    //public AudioManager audioManager;

    public GameObject player;

    private AudioSource countdownImagesAudioSource;

    public Camera thisPlayersCamera;


    public void Awake()
    {
        //Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, 10)); imageComponent = transform.GetComponent<Image>();
        //transform.position = new Vector3(Screen.width / 2, Screen.height / 2, 0);

        thisPlayersCamera.ViewportToWorldPoint(new Vector3(1, 1, thisPlayersCamera.nearClipPlane));
        currentSprite = countdownSpritesList[3];
            imageComponent.sprite = currentSprite;
        
        currentAudioClip = countdownAudioClipsList[3];
        countdownImagesAudioSource = transform.GetComponent<AudioSource>();
        
            //AudioManager.Instance.PlaySoundSFX(currentAudioClip, gameObject, loop: false, volume: 1f);
        //audioManager.PlaySoundSFX(currentAudioClip, gameObject);
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

    private void Update()
    {
        //transform.position = new Vector3(Screen.width / 2, Screen.height / 2, 0);
        Debug.Log(Screen.width);
        Debug.Log(Screen.height);
    }
    IEnumerator CountdownToStart()
    {
        int countdownTime = 3;
        
       
        while (countdownTime > -1)
        {
            yield return new WaitForSeconds(1f);
            Debug.Log(countdownTime);
            countdownTime--;
            
            if (countdownTime >= 0)
            {
                
                    imageComponent.sprite = countdownSpritesList[countdownTime];
                    currentAudioClip = countdownAudioClipsList[countdownTime];


                if (countdownAudioClipsList.Length != 0)
                {
                    countdownImagesAudioSource.PlayOneShot(currentAudioClip);
                }
                
            }


            //Debug.Log("CountdownToStart() called");
        }
        
        gameObject.SetActive(false);
    }
}
