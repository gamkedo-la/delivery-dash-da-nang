using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreenFadeOut : MonoBehaviour
{
    
    public static IEnumerator FadeOut(AudioSource audioSource, float FadeTime)
    {
       
        //Debug.Log("fade out coroutine being called");
        float startVolume = audioSource.volume;

        while (audioSource.volume > 0)
        {
            //Debug.Log("audioSource.volume: " + audioSource.volume);
            audioSource.volume -= startVolume * Time.deltaTime / FadeTime;

            yield return null;
        }

        audioSource.Stop();
        audioSource.volume = startVolume;
    }
    
}
