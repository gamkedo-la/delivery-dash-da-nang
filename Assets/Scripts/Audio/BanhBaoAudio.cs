using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanhBaoAudio : MonoBehaviour {
	public AudioClip banhBaoAnnouncement;
	public float volume = 1f;

	private AudioSource banhBaoSource;
	private VirtualAudioSource virtualBanhBaoSource;
	private VirtualAudioListener thisListener;

	void OnEnable() {
		banhBaoSource = AudioManager.Instance.PlaySoundSFX(banhBaoAnnouncement, gameObject, volume: volume, loop: true);
		virtualBanhBaoSource = banhBaoSource.gameObject.GetComponent<VirtualAudioSource>();
		GameObject topParent = gameObject;
		while (topParent.transform.parent != null) {
			topParent = topParent.transform.parent.gameObject;
			Debug.Log(topParent.name);
		}
		thisListener = topParent.GetComponentInChildren<VirtualAudioListener>();
	}

	void OnDisable() {
		AudioManager.Instance.StopSound(banhBaoSource);
	}

	void Update() {
		if (thisListener == null) {
			gameObject.SetActive(false);
			return;
		}

		int indexToReturn = 0;
		float shortestDistance = Mathf.Infinity;
		for (int i = 0; i < VirtualAudioListener.Listeners.Count; i++) {
			if ((virtualBanhBaoSource.targetPosition - VirtualAudioListener.Listeners[i].transform.position).sqrMagnitude < shortestDistance && VirtualAudioListener.Listeners[i] != thisListener) {
				indexToReturn = i;
				shortestDistance = (virtualBanhBaoSource.targetPosition - VirtualAudioListener.Listeners[i].transform.position).sqrMagnitude;
			}
		}

		virtualBanhBaoSource.listener = VirtualAudioListener.Listeners[indexToReturn];
	}
}
