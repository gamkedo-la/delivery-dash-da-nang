using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneScript : MonoBehaviour
{
    public GameObject HomeScreen, OrdersMenu, GPSMenu, AlertsMenu, RatingsScreen, CurrentScores;

    public AudioClip phoneButtonPressedAudioClip;

    public void OrdersButtonPressed()
    {
		AudioManager.Instance.PlaySoundSFX(phoneButtonPressedAudioClip, gameObject);
        HomeScreen.SetActive(false);
        OrdersMenu.SetActive(true);
    }

    public void OrdersBack() 
	{
		AudioManager.Instance.PlaySoundSFX(phoneButtonPressedAudioClip, gameObject);
		HomeScreen.SetActive(true);
        OrdersMenu.SetActive(false);
    }

    public void RatingsButtonPressed() 
	{
		AudioManager.Instance.PlaySoundSFX(phoneButtonPressedAudioClip, gameObject);
		HomeScreen.SetActive(false);
        RatingsScreen.SetActive(true);
    }

    public void RatingsBack() 
	{
		AudioManager.Instance.PlaySoundSFX(phoneButtonPressedAudioClip, gameObject);
		HomeScreen.SetActive(true);
        RatingsScreen.SetActive(false);
    }

    public void GPSButtonPressed() 
	{
		AudioManager.Instance.PlaySoundSFX(phoneButtonPressedAudioClip, gameObject);
		HomeScreen.SetActive(false);
        GPSMenu.SetActive(true);
    }

    public void GPSButtonBack() 
	{
		AudioManager.Instance.PlaySoundSFX(phoneButtonPressedAudioClip, gameObject);
		GPSMenu.SetActive(false);
        HomeScreen.SetActive(true);
    }

    public void CustomerScoresPressed() 
	{
		AudioManager.Instance.PlaySoundSFX(phoneButtonPressedAudioClip, gameObject);
		HomeScreen.SetActive(false);
        CurrentScores.SetActive(true);
    }

    public void CustomerScoresBack() 
	{
		AudioManager.Instance.PlaySoundSFX(phoneButtonPressedAudioClip, gameObject);
		HomeScreen.SetActive(true);
        CurrentScores.SetActive(false);
    }
}
