using System;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    [SerializeField] private AudioClip[] audioClips;

    private static AudioManager audioManagerIstance;

    private static AudioSource audioSource;


    public enum Song {
        win = 0,
        loose = 1
    }

    void Start() {
        audioSource = GetComponent<AudioSource>();
        audioManagerIstance = this;
    }
    public AudioClip getAudioClip(int index) {
        return audioClips[index];
    }

    public static void Play(AudioClip clip) {
        audioSource.clip = clip;
        audioSource.Play();
    }

    public static void Play(int index) {
        audioSource.clip = audioManagerIstance.audioClips[index];
        audioSource.Play();
    }
}
