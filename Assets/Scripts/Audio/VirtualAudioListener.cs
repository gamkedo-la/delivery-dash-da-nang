using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualAudioListener : MonoBehaviour
{
	public static AudioListener masterListener;
	public static List<VirtualAudioListener> Listeners = new List<VirtualAudioListener>();

	void OnEnable()
	{
		if (masterListener == null)
		{
			masterListener = (AudioListener)FindObjectOfType(typeof(AudioListener));
		}

		Listeners.Add(this);
	}

	void OnDisable()
	{
		Listeners.Remove(this);
	}
}
