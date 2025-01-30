using System;
using System.Collections.Generic;
using GameFoundation.Scripts.Utilities;
using GameFoundation.Scripts.Utilities.Extension;
using Setting;
using UnityEngine;
using Zenject;


[Serializable]
public class MasterAudioClip
{
    public string    clipName;
    public AudioClip clip;
}

public class MasterAudio : MonoBehaviour
{
    [SerializeField] private List<MasterAudioClip> preloadSounds = new();
    
    public static MasterAudio  Instance;
    private const string       WINSOUND = "win_sound";

    public AudioSource musicAudioSource;
    public AudioSource soundAudioSource;

    [Inject] private SettingManager settingManager;

    private void Awake()
    {
        if (Instance != null) Destroy(gameObject);

        Instance         = this;
        musicAudioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        this.GetCurrentContainer().Inject(this);

        settingManager.OnDataLoadedCompleted += SettingManager_OnDataLoaded;
    }

    void SettingManager_OnDataLoaded()
    {
        musicAudioSource.mute = !settingManager.GetMusicState();
        soundAudioSource.mute = !settingManager.GetSoundState();
    }

    public void ToggleMusic()
    {
        settingManager.SetMusicState(musicAudioSource.mute);
        musicAudioSource.mute = !musicAudioSource.mute;
    }

    public void ToggleSound()
    {
        settingManager.SetSoundState(soundAudioSource.mute);
        soundAudioSource.mute = !soundAudioSource.mute;
    }

    public void PlayWinSound()
    {
        AudioManager.Instance.PlaySound(WINSOUND, soundAudioSource);
    }

    public void PlaySound(string sound)
    {
        foreach (var masterAudioClip in preloadSounds)
        {
            if (masterAudioClip.clipName == sound)
            {
                AudioManager.Instance.PlaySound(masterAudioClip.clip, soundAudioSource);
                return;
            }
        }
        
        AudioManager.Instance.PlaySound(sound, soundAudioSource);
    }
}