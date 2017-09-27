﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class BGMPlayer : MonoBehaviour {
    private AudioSource audioSource;

    public AudioClip bgm0;
    public AudioClip bgm1;
    public AudioClip bgm2;
    public AudioClip bgm3;
    public AudioClip bgm4;
    public AudioClip bgm5;


    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Use this for initialization
    void Start () {
        audioSource.clip = bgm1;
        audioSource.Play();
        audioSource.loop = true;
    }
	
	// Update is called once per frame
	void Update () {
		
	}


    public void PlayBGM()
    {

    }
}
