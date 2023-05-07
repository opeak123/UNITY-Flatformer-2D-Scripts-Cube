using UnityEngine;
using UnityEngine.Audio;
using System.Collections.Generic;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    public AudioMixer mixer;

    public AudioSource[] sfxSources;
    public AudioSource[] bgmSources;

    public Dictionary<string, AudioClip> clipDict = new Dictionary<string, AudioClip>();

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(this.gameObject);

        // AudioClip dictionary에 모든 AudioClip을 추가
        AudioClip[] clips = Resources.LoadAll<AudioClip>("Audio");
        foreach (AudioClip clip in clips)
        {
            clipDict.Add(clip.name, clip);
        }
    }

    public void PlaySFX(string name, float volume)
    {
        // 비어있는 AudioSource를 찾아서 SFX를 재생
        foreach (AudioSource source in sfxSources)
        {
            if (!source.isPlaying)
            {
                source.clip = clipDict[name];
                source.volume = volume;
                source.Play();
                return;
            }
        }
    }

    public void PlayBGM(string name, float volume)
    {
        //모든 BGM AudioSource를 정지 선택된 BGM을 재생
        foreach (AudioSource source in bgmSources)
        {
            source.Stop();
        }

        // 선택된 BGM 재생
        foreach (AudioSource source in bgmSources)
        {
            if (source.clip == null || source.clip.name != name)
            {
                source.clip = clipDict[name];
                source.volume = volume;
                source.loop = true;
                source.Play();
                return;
            }
        }
    }

    public void SetSFXVolume(float volume)
    {
        mixer.SetFloat("SFXVolume", volume);
    }

    public void SetBGMVolume(float volume)
    {
        mixer.SetFloat("BGMVolume", volume);
    }
}
