using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
  public Transform player;
  public Transform receiver;
  public GameObject gameObjectAutreColliderPlane;
  public GameObject gameObjectColliderPlane;
  public Transform portal;
  public Transform autrePortal;
  public Rigidbody rb;

  //private bool playerIsOverLapping=false;
  private bool chrono;
  private float timeLeft;
  private Vector3 velocity;
  private float[] tabVelocity;

    // Update is called once per frame
    void Update()
    {
      if(chrono) //commence le timer
      {
        timeLeft -= Time.deltaTime*100;
        if ( timeLeft < 0 )
        {
          gameObjectAutreColliderPlane.SetActive(true);
          chrono = false;
        }
      }
    }


    void OnTriggerEnter(Collider col)//Si quelque chose active le portail
    {
      if(col.gameObject.name == "Player" || col.gameObject.tag == "CanBeTeleported") //si l'objet est le joueur ou un objet du tag "CanBeTeleported"
      {
        rb = col.GetComponent<Rigidbody>(); //recopie son rigidbody
        velocity = rb.velocity; //recopier la velocité de l'objet
        col.transform.position = receiver.transform.position; //donne à l'objet la meme position que le portail de sortie
        rb.velocity = Vector3.zero; //enleve toute velocité à l'objet

        col.transform.rotation = autrePortal.transform.rotation;//donne à l'objet la meme rotation que le portail de sortie
        float[] tabVelocity= new float[] {velocity.x, velocity.z}; //recopie les velocités x et z de l'objet
        if(Maximum(tabVelocity) > 5f) //si la velocité max du tableau >5 (on s'assure de prendre la velocité la plus haute)
          rb.AddForce((col.transform.forward * Maximum(tabVelocity)), ForceMode.Impulse); //redonne à l'objet en sortie sa velocité en fonction de l'orientation du portail de sortie
        else
          rb.AddForce((col.transform.forward * Minimum(tabVelocity)*-1), ForceMode.Impulse); //redonne à l'objet en sortie sa velocité inverse en fonction de l'orientation du portail de sortie (il faut inverser la velocité pour faire aller l'objet dans le sens opposé)

        gameObjectAutreColliderPlane.SetActive(false); //descative la fonction de teleportation du portail de sortie pour quelque secondes
        timeLeft = 50f;
        chrono = true; // le timer s'active, à la fin du timer, la fonction de teleportation du portail de sortie sera réactivé
      }


    }
    static float Maximum(float[] tab) //Création de la méthode Maximum (cherche la valeur minimum dans un tableau donné)
    {
      float maximum = tab[0];
      for (int i = 1; i < tab.Length; i++)
          if (tab[i] > maximum) maximum = tab[i];
      return maximum;
    }
    static float Minimum(float[] tab) //Création de la méthode Minimum (cherche la valeur minimum dans un tableau donné)
        {
            float minimum = tab[0];
            for (int i = 1; i < tab.Length; i++)
                if (tab[i] < minimum) minimum = tab[i];
            return minimum;
        }


}
