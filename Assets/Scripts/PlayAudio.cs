using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    [SerializeField] AudioSource src;
    [SerializeField] AudioClip[] sfx;

    public void PlaySFX(int SFXIndex)
    {
        //Debug.Log("played " + SFXIndex);
        src.clip = sfx[SFXIndex];
        src.Play();
    }
}
