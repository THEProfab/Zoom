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
    // shooting and detecting enemies
    if(targetLocked)
    {
      turretTopPart.transform.LookAt(target.transform);
      turretTopPart.transform.Rotate(0,0,0);

      if (shotReady)
      {
        Shoot();
      }
    }
  }

  void Shoot()
  {
    audioSource.Play();
    Transform _bullet = Instantiate(bullet.transform, bulletSpawnPoint.transform.position, Quaternion.identity);
    _bullet.transform.rotation = bulletSpawnPoint.transform.rotation;
    shotReady = false;
    StartCoroutine(FireRate());
  }

  IEnumerator FireRate()
  {
    yield return new WaitForSeconds(fireTimer);
    shotReady = true;
  }

  void OnTriggerEnter(Collider other)
  {
    if(other.tag == "Player")
    {
      target = other.gameObject;
      targetLocked = true;
    }
  }

  void OnTriggerExit(Collider other)
  {
    if(other.tag == "Player")
    {
      targetLocked = false;
    }
  }
}
