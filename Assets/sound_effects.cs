using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sound_effects : MonoBehaviour
{
    public AudioSource src;

    public void Start()
    {
        src.Play();
    }
}
