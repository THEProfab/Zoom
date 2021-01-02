using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimTir : MonoBehaviour
{
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1") || Input.GetButtonDown("Fire2"))//Si clique gauche ou droit sont pressés
          anim.SetTrigger("Tir"); //joue l'animation du portal gun

    }
}
