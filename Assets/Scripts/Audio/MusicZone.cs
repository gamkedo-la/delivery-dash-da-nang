using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicZone : MonoBehaviour {
	public MusicTrack track;
	public string triggerTag;

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == triggerTag) {
			MusicManager.Instance.PlayTrack(track);
		}
	}
}
