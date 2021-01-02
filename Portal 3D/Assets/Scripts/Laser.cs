using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private GameObject target;
    private int damage = 4;

    void OnTriggerEnter(Collider col)
    {
      if (col.tag == "Player") //si le laser touche le joueur
      {
        target = col.gameObject;
        target.GetComponent<Player>().health -= damage; //baisse la vie du joueur
        target.GetComponent<Player>().hurt = true;//active l'etat touché du joueur

      }
    }
}
