using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickObject : MonoBehaviour
{
    public GameObject item;
    public GameObject tempParent;
    public Transform guide;
    private bool boutonEPressé;
    private int forceLancé = 7;
    // Start is called before the first frame update
    void Start()
    {
      item.GetComponent<Rigidbody>().useGravity = true;
    }

    void Update()
    {
      if (Input.GetKeyDown("e"))//si la touche e est pressée
       {
         if (!boutonEPressé)
         {
          boutonEPressé= true;
          prendreObjet(); //prend l'objet en main
         }

         else if (boutonEPressé) //si la touche e avait deja ete pressée
         {
          lacherObjet();
          boutonEPressé = false;
         }
       }

      if (Input.GetKeyDown("a")) //si la touche a est pressé et que la touche e à ete pressée
      {
        jeterObjet();
      }

    }

    void prendreObjet()
    {
      if (Vector3.Distance(guide.transform.position, transform.position) < 1) //si la distance entre l'objet et le joueur est < 1
      {

        item.GetComponent<Rigidbody>().useGravity = false; //rend l'objet insensible à la gravité
        item.GetComponent<Rigidbody>().isKinematic = true; //rend l'objet kinematique (ne tient plus compte des collisions)
        item.GetComponent<Collider>().enabled = false; //desactive son collider
        item.transform.rotation = guide.transform.rotation; //donne à l'objet la rotation du guide (guide est enfant du joueur)
        item.transform.position = guide.transform.position;//deplace l'objet à la position du guide (guide est enfant du joueur)
        item.transform.parent = tempParent.transform; //rend l'objet enfant du guide
      }
    }

    void lacherObjet()
    {
      if (Vector3.Distance(guide.transform.position, transform.position) < 1)
      {
        item.GetComponent<Rigidbody>().useGravity = true;//rend l'objet sensible à la gravité
        item.GetComponent<Rigidbody>().isKinematic = false; //deactive la fonction kinematique
        item.GetComponent<Collider>().enabled = true;//active son collider
        item.transform.parent = null;// l'objet n'est plus enfant de guide
        item.transform.position = guide.transform.position;// redone à l'objet la postion du guide
      }
    }
    void jeterObjet()
    {
      if (Vector3.Distance(guide.transform.position, transform.position) < 1 && boutonEPressé)
      {
        item.GetComponent<Rigidbody>().useGravity = true;//rend l'objet sensible à la gravité
        item.GetComponent<Rigidbody>().isKinematic = false;//deactive la fonction kinematique
        item.GetComponent<Collider>().enabled = true;//active son collider
        item.transform.parent = null;// l'objet n'est plus enfant de guide
        item.transform.position = guide.transform.position;// redone à l'objet la postion du guide
        item.GetComponent<Rigidbody>().AddForce(guide.transform.forward * forceLancé, ForceMode.Impulse); //donne une impulsion de la direction du guide à l'objet 
        boutonEPressé = false;
      }
    }


}
