using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTir : MonoBehaviour
{
    public AudioSource audioSource;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") || Input.GetButtonDown("Fire2")) //Si clique gauche ou droit sont pressés
        {
            audioSource.Play(); //joue le son
        }

     }
}
