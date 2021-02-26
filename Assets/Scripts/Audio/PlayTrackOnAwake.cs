using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayTrackOnAwake : MonoBehaviour {
	public MusicTrack track;

	private void Start() {
		MusicManager.Instance.PlayTrack(track);
	}
}
