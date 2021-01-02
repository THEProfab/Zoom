using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

  public float movementSpeed = 100;
  private int damage = 1;
  private GameObject target;

  void Update()
  {
    movementSpeed = 25;
    transform.Translate(Vector3.forward * Time.deltaTime * movementSpeed); //fait avancer la balle droite
  }

  void OnTriggerEnter(Collider col) //quand la balle touche un objet
  {
    if (col.tag == "Player") //si l'objet est le joueur
    {
      target = col.gameObject;
      target.GetComponent<Player>().health -= damage; //baisse la vie du joueur
      target.GetComponent<Player>().hurt = true; //active l'etat touché du joueur
    }
    if (col.tag != "Turret")
      Destroy(this.gameObject); //fait passer la balle a travers le collider de la tourelle
  }

}
