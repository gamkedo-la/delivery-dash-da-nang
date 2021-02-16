using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneScript : MonoBehaviour
{
    public GameObject HomeScreen, OrdersMenu, GPSMenu, AlertsMenu, RatingsScreen, CurrentScores;

    public AudioClip phoneButtonPressedAudioClip;
    private AudioSource phoneButtonPressedAudioSource;

    private void Start()
    {
        phoneButtonPressedAudioSource = AudioManager.Instance.PlaySoundSFX(phoneButtonPressedAudioClip, gameObject, loop: false, volume: 0.1f);
        phoneButtonPressedAudioSource.Stop();
    }

    public void OrdersButtonPressed()
    {
        phoneButtonPressedAudioSource.Play();
        HomeScreen.SetActive(false);
        OrdersMenu.SetActive(true);
    }

    public void OrdersBack()
    {
        phoneButtonPressedAudioSource.Play();
        HomeScreen.SetActive(true);
        OrdersMenu.SetActive(false);
    }

    public void RatingsButtonPressed()
    {
        phoneButtonPressedAudioSource.Play();
        HomeScreen.SetActive(false);
        RatingsScreen.SetActive(true);
    }

    public void RatingsBack()
    {
        phoneButtonPressedAudioSource.Play();
        HomeScreen.SetActive(true);
        RatingsScreen.SetActive(false);
    }

    public void GPSButtonPressed()
    {
        phoneButtonPressedAudioSource.Play();
        HomeScreen.SetActive(false);
        GPSMenu.SetActive(true);
    }

    public void GPSButtonBack()
    {
        phoneButtonPressedAudioSource.Play();
        GPSMenu.SetActive(false);
        HomeScreen.SetActive(true);
    }

    public void CustomerScoresPressed()
    {
        phoneButtonPressedAudioSource.Play();
        HomeScreen.SetActive(false);
        CurrentScores.SetActive(true);
    }

    public void CustomerScoresBack()
    {
        phoneButtonPressedAudioSource.Play();
        HomeScreen.SetActive(true);
        CurrentScores.SetActive(false);
    }
}
