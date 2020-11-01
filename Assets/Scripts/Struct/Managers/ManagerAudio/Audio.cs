using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Audio : MonoBehaviour
{
    public static Audio  Ins;

    private AudioSource audioSource;
    [SerializeField]  DataAudioCreate dataAudio;


    private void Awake()
    {
        Ins = this;
        audioSource = GetComponent<AudioSource>();
    }

    public  void Play(string name)
    {
        int index = dataAudio.AudioListString.IndexOf(name);
        audioSource.clip = dataAudio.AudioList[index];
        audioSource.Play();       
    }

    public void PlayOneShot(string name)
    {
        int index = dataAudio.AudioListString.IndexOf(name);
        audioSource.PlayOneShot(dataAudio.AudioList[index]);
    }

    public AudioSource SettingsAudioSorce()
    {
        return audioSource;
    }





}
