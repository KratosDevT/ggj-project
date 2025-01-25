using UnityEngine;

public class AudioManager : MonoBehaviour {

    [SerializeField] private AudioClip[] audioClips;

    public AudioClip getAudioClip(int index) {
        return audioClips[index];
    }
}
