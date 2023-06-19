using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private Sound[] sounds;

    public static AudioManager Instance { get; private set; }

    private void Awake ()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }



        DontDestroyOnLoad(gameObject);

        foreach (Sound sound in sounds)
        {
            sound.audioSource = gameObject.AddComponent<AudioSource>();
            sound.audioSource.clip = sound.clip;
            sound.audioSource.volume = sound.volume;
            sound.audioSource.pitch = sound.pitch;
            sound.audioSource.loop = sound.loop;
        }
    }

    public void PlaySound (string name)
    {
        Sound s = FindSound(name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.audioSource.Play();
    }

    public bool IsPlayingSound(string name)
    {
        Sound sound = FindSound(name);
        if (sound == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return false;
        }
        return sound.audioSource.isPlaying;
    }

    public void StopSound (string name)
    {
        Sound s = FindSound(name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.audioSource.Stop();
    }

    public void PlaySoundAt (GameObject source, string name)
    {
        Sound s = FindSound(name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        AudioSource soundSource = source.AddComponent<AudioSource>();
        soundSource.clip = s.clip;
        soundSource.volume = s.volume;
        soundSource.pitch = s.pitch;
        soundSource.spatialBlend = 0.5f;
        soundSource.Play();
        Destroy(soundSource, (soundSource.clip.length + 1f));
    }

    private Sound FindSound (string name)
    {
        return Array.Find(sounds, sound => sound.name == name);
    }
}