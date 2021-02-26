using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "MusicTrack", menuName = "AddMusicTrackAsset")]
public class MusicTrack : ScriptableObject {
	public List<ClipAndCues> intros = new List<ClipAndCues>();
	public List<ClipAndCues> tracks = new List<ClipAndCues>();
	public List<ClipAndCues> transitions = new List<ClipAndCues>();
}

[Serializable]
public class ClipAndCues {
	public AudioClip clip = null;
	public List<float> cues = new List<float>();
}

#if UNITY_EDITOR
[CustomEditor(typeof(MusicTrack))]
public class MusicTrackEditor : Editor {

	public override void OnInspectorGUI() {
		EditorGUI.BeginChangeCheck();

		MusicTrack musicTrack = (target as MusicTrack);
		
		EditorGUILayout.BeginHorizontal();
		EditorGUILayout.LabelField("Intro");
		if (GUILayout.Button("-") && musicTrack.intros.Count > 1) { musicTrack.intros.RemoveAt(musicTrack.intros.Count-1); }
		if (GUILayout.Button("+")) { musicTrack.intros.Add(new ClipAndCues()); }
		EditorGUILayout.EndHorizontal();
		if (musicTrack.intros.Count <= 0) musicTrack.intros.Add(new ClipAndCues());
		for (int i = 0; i < musicTrack.intros.Count; i++) {
			musicTrack.intros[i].clip = (AudioClip)EditorGUILayout.ObjectField(musicTrack.intros[i].clip, typeof(AudioClip), false);

			EditorGUILayout.BeginHorizontal();
			EditorGUILayout.LabelField(" ");
			if (GUILayout.Button("-") && musicTrack.intros[i].cues.Count > 1) { musicTrack.intros[i].cues.RemoveAt(musicTrack.intros.Count-1); }
			if (GUILayout.Button("+")) { musicTrack.intros[i].cues.Add(0); }
			EditorGUILayout.EndHorizontal();

			EditorGUILayout.BeginHorizontal();
			if (musicTrack.intros[i].cues.Count <= 0) musicTrack.intros[i].cues.Add(0);
			for (int j = 0; j < musicTrack.intros[i].cues.Count; j++) {
				musicTrack.intros[i].cues[j] = EditorGUILayout.FloatField(musicTrack.intros[i].cues[j]);
				if ((j + 1) % 5 == 0) {
					EditorGUILayout.EndHorizontal();
					EditorGUILayout.BeginHorizontal();
				}
			}
			EditorGUILayout.EndHorizontal();

			EditorGUILayout.Space();
		}
		EditorGUILayout.LabelField(" ");

		EditorGUILayout.BeginHorizontal();
		EditorGUILayout.LabelField("Main Track");
		if (GUILayout.Button("-") && musicTrack.tracks.Count > 1) { musicTrack.tracks.RemoveAt(musicTrack.tracks.Count-1); }
		if (GUILayout.Button("+")) { musicTrack.tracks.Add(new ClipAndCues()); }
		EditorGUILayout.EndHorizontal();
		if (musicTrack.tracks.Count <= 0) musicTrack.tracks.Add(new ClipAndCues());
		for (int i = 0; i < musicTrack.tracks.Count; i++) {
			musicTrack.tracks[i].clip = (AudioClip)EditorGUILayout.ObjectField(musicTrack.tracks[i].clip, typeof(AudioClip), false);

			EditorGUILayout.BeginHorizontal();
			EditorGUILayout.LabelField(" ");
			if (GUILayout.Button("-") && musicTrack.tracks[i].cues.Count > 1) { musicTrack.tracks[i].cues.RemoveAt(musicTrack.tracks.Count-1); }
			if (GUILayout.Button("+")) { musicTrack.tracks[i].cues.Add(0); }
			EditorGUILayout.EndHorizontal();

			EditorGUILayout.BeginHorizontal();
			if (musicTrack.tracks[i].cues.Count <= 0) musicTrack.tracks[i].cues.Add(0);
			for (int j = 0; j < musicTrack.tracks[i].cues.Count; j++) {
				musicTrack.tracks[i].cues[j] = EditorGUILayout.FloatField(musicTrack.tracks[i].cues[j]);
				if ((j + 1) % 5 == 0) {
					EditorGUILayout.EndHorizontal();
					EditorGUILayout.BeginHorizontal();
				}
			}
			EditorGUILayout.EndHorizontal();

			EditorGUILayout.Space();
		}
		EditorGUILayout.LabelField(" ");

		EditorGUILayout.BeginHorizontal();
		EditorGUILayout.LabelField("Transition");
		if (GUILayout.Button("-") && musicTrack.transitions.Count > 1) { musicTrack.transitions.RemoveAt(musicTrack.transitions.Count-1); }
		if (GUILayout.Button("+")) { musicTrack.transitions.Add(new ClipAndCues()); }
		EditorGUILayout.EndHorizontal();
		if (musicTrack.transitions.Count <= 0) musicTrack.transitions.Add(new ClipAndCues());
		for (int i = 0; i < musicTrack.transitions.Count; i++) {
			musicTrack.transitions[i].clip = (AudioClip)EditorGUILayout.ObjectField(musicTrack.transitions[i].clip, typeof(AudioClip), false);
			
			if (musicTrack.transitions[i].cues.Count <= 0) musicTrack.transitions[i].cues.Add(0);
			musicTrack.transitions[i].cues[0] = EditorGUILayout.FloatField(musicTrack.transitions[i].cues[0]);

			EditorGUILayout.Space();
		}

		//base.OnInspectorGUI();

		if (EditorGUI.EndChangeCheck()) {
			EditorUtility.SetDirty(target);
		}

	}
}
#endif