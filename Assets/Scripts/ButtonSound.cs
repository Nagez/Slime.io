using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ButtonSound : MonoBehaviour
{

    /*Sound*/
    public AudioClip Mysound;
    public AudioSource MyAudioSource;
    /*MENU*/
    void Start()
    {
        MyAudioSource = GetComponent<AudioSource>();
    }

    /*OnMouseOver*/
    public void OnMouseEnter()
    {
        //Debug.Log("Play_Audio");
        MyAudioSource.PlayOneShot(Mysound);
    }
}
