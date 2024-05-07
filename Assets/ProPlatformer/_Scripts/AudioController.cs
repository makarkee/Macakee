using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : SingletonMono<AudioController>
{
    [SerializeField] AudioSource BgmAudio;
    [SerializeField] AudioSource SfxAudio;

    public AudioClip Bgm;
    public AudioClip dash;
    public AudioClip strawberry;
    public AudioClip die;

    private void Start()
    {
        BgmAudio.clip = Bgm;
        BgmAudio.Play();
    }

    public void PlaySfx(AudioClip clip)
    {
        SfxAudio.PlayOneShot(clip);
    }
}
