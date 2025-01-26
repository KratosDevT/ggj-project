using System;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    [SerializeField] private GameObject monoSound;
    [SerializeField] private GameObject loopSound;

    [SerializeField] private AudioClip[] audioClips;

    private static AudioManager audioManagerIstance;

    private static AudioSource monoSoundAudio;
    private static AudioSource loopSoundAudio;

    public enum Song {
        win = 0,
        loose = 1
    }

    void Start() {
        audioManagerIstance = this;

        monoSoundAudio = monoSound.GetComponent<AudioSource>();
        loopSoundAudio = loopSound.GetComponent<AudioSource>();

        loopSoundAudio.clip = audioClips[2];
        loopSoundAudio.Play();

    }
    public AudioClip getAudioClip(int index) {
        return audioClips[index];
    }

    public static void PlayLoop(AudioClip clip) {
        float time = loopSoundAudio.time;
        loopSoundAudio.clip = clip;
        loopSoundAudio.time = time;
        loopSoundAudio.Play();
    }

    public static void PlayLoop(int index) {
        float time = loopSoundAudio.time;
        loopSoundAudio.clip = audioManagerIstance.getAudioClip(index);
        loopSoundAudio.Play();
        loopSoundAudio.time = time;
    }

    public static void Play(int index) {
        monoSoundAudio.clip = audioManagerIstance.getAudioClip(index);
        monoSoundAudio.Play();
    }
}
