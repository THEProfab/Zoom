using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropper : MonoBehaviour
{
    public GameObject cube;
    // Update is called once per frame
    void Start()
    {
      cube.GetComponent<PickObject>().enabled = false; //le cube ne peut pas etre recupéré
      cube.GetComponent<Rigidbody>().useGravity = false; //le cube ignore la gravité
    }

    void Update()
    {
      if ( GameObject.Find("pedestalButton").GetComponent<pedestalButton>().getBoutonPresse()) //si le bouton est pressé
      {
        ouverture(); //laisse tomber le cube
      }
    }

    void ouverture()
    {
      cube.GetComponent<Rigidbody>().useGravity = true; //réactive la gravité pour le cube
      cube.GetComponent<PickObject>().enabled = true; //rend le objet utilisable pour le joueur
    }
}
