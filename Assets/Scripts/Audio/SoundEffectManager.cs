using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectManager : MonoBehaviour
{

    public static SoundEffectManager Instance = null;


    [SerializeField] private AudioClip clip_CoffeeMachine;
    [SerializeField] private AudioClip clip_MenuClose;
    [SerializeField] private AudioClip clip_MenuOpen;
    [SerializeField] private AudioClip clip_OrderComplete;
    [SerializeField] private AudioClip[] clips_orderReceived;
    [SerializeField] private AudioClip clip_sauceSqueeze;
    [SerializeField] private AudioClip clip_subtaskComplete;
    [SerializeField] private AudioClip clip_pouring;
    [SerializeField] private AudioClip[] clips_CupPut;
    [SerializeField] private AudioClip[] clips_CupLift;

    private AudioSource[] myAudioSources;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        myAudioSources = new AudioSource[1];

        GameObject audioSource1 = new GameObject("audioSource_1");
        Utils.AddAudioListener(audioSource1, false, 1.0f, false);
        audioSource1.transform.parent = transform;
        myAudioSources[0] = audioSource1.GetComponent<AudioSource>();

    }


    public void PlayOpenMenu()
    {
        PlaySound(clip_MenuOpen);   
    }

    public void PlayCloseMenu()
    {
        PlaySound(clip_MenuClose);
    }

    public void PlayCoffeeMachine()
    {
        PlaySound(clip_CoffeeMachine);
    }

    public void PlaySplash()
    {
        PlaySound(clip_pouring);
    }

    public void PlaySauceSqueezing()
    {
        PlaySound(clip_sauceSqueeze);
    }

    public void PlayOrderComplete()
    {
        PlayRandomSound(clips_orderReceived);
    }

    public void PlaySubtaskComplete()
    {
        PlaySound(clip_subtaskComplete);
    }

    
    public void PlayPutCup()
    {
        PlayRandomSound(clips_CupPut);
    }

    public void PlayLiftCup()
    {
        PlayRandomSound(clips_CupLift);
    }



    private void PlaySound(AudioClip clip)
    {
        Debug.Log("Playing audio: " + clip.name);
        foreach (AudioSource aS in myAudioSources)
        {
            if (aS.playOnAwake == true)
            {
                continue;
            }
            else
            {
                Utils.PlaySound(aS, clip);
            }
        }
    }

    private void PlayRandomSound(AudioClip[] clips)
    {
        Debug.Log("Random Sound");
        foreach (AudioSource aS in myAudioSources)
        {
            if (aS.playOnAwake == true)
            {
                continue;
            }
            else
            {
                Utils.PlayRandomSound(aS, clips);
            }
        }
    }



}
