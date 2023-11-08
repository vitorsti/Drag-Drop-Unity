using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleSound : MonoBehaviour
{
    private bool m_IsPlaying = true;

    private AudioListener audio;

    [SerializeField]
    private Sprite soundOn;

    [SerializeField]
    private Sprite soundOff;

    [SerializeField]
    private Button soundBtn;

    private void Start()
    {
        audio = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioListener>();
    }

    public void PressedSound()
    {
        m_IsPlaying = !m_IsPlaying;
        audio.enabled = m_IsPlaying;

        if (m_IsPlaying)
        {
            soundBtn.image.sprite = soundOn;
        }
        else
        {
            soundBtn.image.sprite = soundOff;
        }
    }
}
