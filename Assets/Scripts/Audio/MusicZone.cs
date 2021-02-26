using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MusicZone : MonoBehaviour {
	public MusicTrack track;
	public string triggerTag;

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == triggerTag) {
			MusicManager.Instance.PlayTrack(track);
		}
	}
}

#if UNITY_EDITOR
[CustomEditor(typeof(MusicZone))]
public class MusicZoneEditor : Editor {
	public override void OnInspectorGUI() {
		base.OnInspectorGUI();

		if (GUILayout.Button("Play Track")) {
			MusicZone musicZone = (target as MusicZone);

			MusicManager.Instance.PlayTrack(musicZone.track);
		}
	}
}
#endif