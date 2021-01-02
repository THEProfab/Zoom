using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pedestalButton : MonoBehaviour
{
    private bool boutonPresse = false;
    public Transform guide;
    public AudioSource audioSource;

    void Start()
    {
      boutonPresse = false;
    }

    void Update()
    {
      if (Input.GetKeyDown("e") && Vector3.Distance(guide.transform.position, transform.position) < 1.5f) //si le bouton "e" est pressé sur le bouton, à une certaine distance
      {
         audioSource.Play(); //joue le son du bouton
         boutonPresse = true; //active le bouton
      }
    }

    public bool getBoutonPresse() //gette du bouton (utilisé dans le script ItemDropper)
    {
        return boutonPresse;
    }
}
