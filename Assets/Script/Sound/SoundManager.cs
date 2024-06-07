using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public SoundType[] Sounds;
    private static SoundManager instance;
    public AudioSource soundEffect;
    public AudioSource soundMusic;
    public bool isMute = false;
    public float _volume = 1f;
    public static SoundManager Instance
    {
        get
        { return instance; }
    }

    void Awake()

    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    void Start()
    {
        SetVolume(0.75f);
        PlayMusic(global::Sounds.Music);

    }

    public void Mute(bool status)
    {
        isMute = status;
    }

    public void SetVolume(float volume)
    {
        _volume = volume ;
        soundEffect.volume = _volume;
        soundMusic.volume = _volume;
    }
    public void PlayMusic(Sounds sound)
    {
        if (isMute)
            return;

        AudioClip clip = GetSoundClip(sound);
        if (clip != null)
        {
            soundMusic.clip = clip;
            soundMusic.Play();

        }
        else
        {
            Debug.LogError("Sound " + sound + " not found!");
        }
    }

    public void Play(Sounds sound)
    {
        if (isMute)
            return;

        AudioClip clip = GetSoundClip(sound);
        if (clip != null)
        {
            soundEffect.PlayOneShot(clip);

        }
        else
        {
            Debug.LogError("Sound " + sound + " not found!");
        }
    }


    private AudioClip GetSoundClip(Sounds sound)
    {
        SoundType item = Array.Find(Sounds, i => i.soundType == sound);
        if (item != null)
        {
            return item.soundClip;
        }
        return null;
    }




}//

[Serializable]
public class SoundType
{
    public Sounds soundType;
    public AudioClip soundClip;
}

public enum Sounds
{
    ButtonClick,
    PlayerMove,
    PlayerDeath,
    EnemyDeath,
    Music
}
