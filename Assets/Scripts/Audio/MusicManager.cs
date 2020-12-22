using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicManager : MonoBehaviour {
	public static MusicManager Instance;

	private MusicTrack currentTrack = null;
	private MusicTrack nextTrack = null;
	private List<float> currentCues = new List<float>();

	private double startingTime = 0;
	private double nextCueTime = 0;
	private double nextSchedual = 0;
	private float timeNow = 0f;

	private int nextCueIndex = 0;
	private int nextTrackIndex = 0;

	private AudioSource currentAudioSource = null;

	public GameObject musicPrefab;
	public bool isPlaying = false;
	public float bufferTime = 0.5f;
	public float fadeOutTime = 0.15f;


	void Awake() {
		if (Instance == null) Instance = this;
		else Destroy(gameObject);

		if (Instance == this) DontDestroyOnLoad(gameObject);
	}

	void Update() {
		timeNow = (float)AudioSettings.dspTime;

		if (AudioSettings.dspTime >= nextSchedual) {
			if (isPlaying && nextTrack != null) {
				PlayNewClip(nextTrack.transitions[nextTrackIndex].clip, nextCueTime - nextTrack.transitions[nextTrackIndex].cues[0]);
				if (nextCueIndex < currentCues.Count) StartCoroutine(WaitAndFadeOutAndStop(currentAudioSource, nextCueTime, fadeOutTime));
				currentTrack = nextTrack;
				nextTrack = null;
				currentAudioSource = PlayNewClip(currentTrack.tracks[nextTrackIndex].clip, nextCueTime);

				startingTime = nextCueTime;
				nextCueIndex = 0;
				currentCues = currentTrack.tracks[nextTrackIndex].cues;
				nextTrackIndex = Random.Range(0, currentTrack.tracks.Count);

				PlanNextSchedual();
			} else if (isPlaying && nextTrack == null) {
				if (nextCueIndex >= currentCues.Count) {
					currentAudioSource = PlayNewClip(currentTrack.tracks[nextTrackIndex].clip, nextCueTime);

					startingTime = nextCueTime;
					nextCueIndex = 0;
					currentCues = currentTrack.tracks[nextTrackIndex].cues;
					nextTrackIndex = Random.Range(0, currentTrack.tracks.Count);

					PlanNextSchedual();
				} else {
					PlanNextSchedual();
				}
			}
		}
	}

	public void PlayTrack(MusicTrack newTrack) {
		nextTrack = newTrack;
		PlanNextSchedual();
	}

	private void PlanNextSchedual() {
		if (nextTrack == currentTrack) nextTrack = null;
		
		if (isPlaying && nextTrack != null) {
			nextTrackIndex = Random.Range(0, nextTrack.transitions.Count);
			nextSchedual = startingTime + currentCues[nextCueIndex] - nextTrack.transitions[nextTrackIndex].cues[0] - bufferTime;
			nextCueTime = startingTime + currentCues[nextCueIndex];
			nextCueIndex++;
		} else if (isPlaying && nextTrack == null) {
			nextSchedual = startingTime + currentCues[nextCueIndex] - bufferTime;
			nextCueTime = startingTime + currentCues[nextCueIndex];
			nextCueIndex++;
		} else if (nextTrack != null) {
			nextCueIndex = 0;
			nextTrackIndex = Random.Range(0, nextTrack.intros.Count);
			currentCues = nextTrack.intros[nextTrackIndex].cues;
			currentTrack = nextTrack;
			nextTrack = null;
			startingTime = AudioSettings.dspTime + bufferTime;
			currentAudioSource = PlayNewClip(currentTrack.intros[nextTrackIndex].clip, startingTime);
			nextSchedual = startingTime + currentCues[nextCueIndex] - bufferTime;
			nextCueTime = startingTime + currentCues[nextCueIndex];
			nextCueIndex++;

			isPlaying = true;
		}
	}

	private AudioSource PlayNewClip(AudioClip clip, double startTime) {
		AudioSource freshSource = Instantiate(musicPrefab).GetComponent<AudioSource>();
		freshSource.gameObject.transform.parent = gameObject.transform;
		freshSource.clip = clip;
		freshSource.PlayScheduled(startTime);

		Destroy(freshSource.gameObject, clip.length + (float)(AudioSettings.dspTime - startTime) + fadeOutTime);

		return freshSource;
	}

	IEnumerator WaitAndFadeOutAndStop(AudioSource source, double startTime, float fadeTime) {
		while (AudioSettings.dspTime < startingTime) {
			yield return null;
		}
		StartCoroutine(FadeOutAndStop(source, fadeTime));
	}

	IEnumerator FadeOutAndStop(AudioSource source, float fadeTime) {
		float startTime = Time.time;
		float currentTime = 0f;
		float startVolume = source.volume;

		while (startTime + fadeTime > Time.time) {
			currentTime = Time.time - startTime;

			source.volume = Mathf.Lerp(startVolume, 0f, currentTime/fadeTime);
			yield return null;
		}

		source.Stop();
		Destroy(source.gameObject);
	}

	IEnumerator FadeOut(AudioSource source, float fadeTime) {
		float startTime = Time.time;
		float currentTime = 0f;
		float startVolume = source.volume;

		while (startTime + fadeTime > Time.time) {
			currentTime = Time.time - startTime;

			source.volume = Mathf.Lerp(startVolume, 0f, currentTime/fadeTime);
			yield return null;
		}
	}

	IEnumerator FadeIn(AudioSource source, float fadeTime) {
		float startTime = Time.time;
		float currentTime = 0f;
		float startVolume = source.volume;

		while (startTime + fadeTime > Time.time) {
			currentTime = Time.time - startTime;

			source.volume = Mathf.Lerp(startVolume, 1f, currentTime/fadeTime);
			yield return null;
		}
	}

	IEnumerator FadeTo(AudioSource source, float newVolume ,float fadeTime) {
		float startTime = Time.time;
		float currentTime = 0f;
		float startVolume = source.volume;

		while (startTime + fadeTime > Time.time) {
			currentTime = Time.time - startTime;

			source.volume = Mathf.Lerp(startVolume, newVolume, currentTime/fadeTime);
			yield return null;
		}
	}
}
