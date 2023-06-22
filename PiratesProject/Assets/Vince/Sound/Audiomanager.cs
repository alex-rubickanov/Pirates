using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audiomanager : MonoBehaviour
{
    public static Audiomanager instance;
    [SerializeField] AudioClip canon;
    [SerializeField] AudioClip explosion;
    private void Awake()
    {
        instance = this; 
    }
    AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();  
    }

    public void PlayCanon()
    {
        audioSource.PlayOneShot(canon, 0.4f);
    }


    public void PlayExplosion()
    {
        audioSource.PlayOneShot(explosion, 1f);
    }
}
