using System;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    [SerializeField] private GameObject monoSound;
    [SerializeField] private GameObject[] loopSound;

    [SerializeField] private AudioClip[] audioClips;

    private static AudioManager audioManagerIstance;

    private static AudioSource monoSoundAudio;
    private static List<AudioSource> loopSoundAudios;

    private static int current = 4;

    public enum Song {
        win = 0,
        loose = 1
    }

    void Start() {
        audioManagerIstance = this;

        monoSoundAudio = monoSound.GetComponent<AudioSource>();
        foreach (GameObject audioSource in loopSound) {
            loopSoundAudios.Add(audioSource.GetComponent<AudioSource>());
        }

        loopSoundAudios[4].Play();
        current = 4;

    }
    public AudioClip getAudioClip(int index) {
        return audioClips[index];
    }

    public static void PlayLoop(int index) {
        float time = loopSoundAudios[current].time;
        loopSoundAudios[current].Stop();
        loopSoundAudios[index].time = time;
        loopSoundAudios[index].Play();
        current = index;
    }

    public static void Play(int index) {
        monoSoundAudio.clip = audioManagerIstance.getAudioClip(index);
        monoSoundAudio.Play();
    }
}
