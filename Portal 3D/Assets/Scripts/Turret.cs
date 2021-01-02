using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
  private GameObject target;
  private bool targetLocked;

  public GameObject turretTopPart;
  public GameObject bullet;
  public GameObject bulletSpawnPoint;
  public AudioSource audioSource;
  public float fireTimer;
  private bool shotReady;


  void Start()
  {
    shotReady = true;
  }

  void Update()
  {
    if(targetLocked)//si la sible est verrouillé
    {
      turretTopPart.transform.LookAt(target.transform); //tourne le haut de la tourelle en fonction de l'emplacement du joueur
      turretTopPart.transform.Rotate(0,0,0);

      if (shotReady) //si le tir est pret
      {
        Shoot(); //active la fonction tir
      }
    }
  }

  void Shoot()
  {
    audioSource.Play();
    Transform _bullet = Instantiate(bullet.transform, bulletSpawnPoint.transform.position, Quaternion.identity);
    _bullet.transform.rotation = bulletSpawnPoint.transform.rotation; // fait en sorte que le projectile ait la même rotation que son point d'apparition
    shotReady = false; // pour ne tier qu'un seul projectile
    StartCoroutine(FireRate()); // appelle FireRate()
  }

  IEnumerator FireRate()
  {
    yield return new WaitForSeconds(fireTimer); // permet d'attendre fireTimer secondes
    shotReady = true; // pour pouvoir tirer un autre projectile
  }

  void OnTriggerEnter(Collider other)
  {
    if(other.tag == "Player") // si le joueur est détecté dans la portée de la tourelle
    {
      //print(other.tag);
      target = other.gameObject; // le joueur devient la cible
      targetLocked = true; // le joueur est ciblé par la tourelle qui le vise et lui tire dessus
    }
  }

  void OnTriggerExit(Collider other)
  {
    if(other.tag == "Player") // lorsque le joueur sort de la portée de la tourelle
    {
      targetLocked = false; // celui-ci n'est plus ciblé par la tourelle qui ne le vise plus et ne lui tire donc plus dessus
    }
  }
}
