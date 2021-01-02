using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PorteGauche : MonoBehaviour
{

    private Vector3 nouvPosPorteGauche;
    private Vector3 PosPorteGauche;
    public float speed;
    public GameObject boutonLié;

    void Start()
    {
        PosPorteGauche = transform.position;
        nouvPosPorteGauche = new Vector3(transform.position.x + 2f, transform.position.y, transform.position.z);//initialise la position de la porte une fois ouverte
    }

    void Update()
    {
      float step = speed * Time.deltaTime;
      if ( boutonLié.GetComponent<Bouton>().getBoutonPresse())//si le bouton lié à la porte est pressé
      {
        ouverturePorte();
      }
      else if ( !(boutonLié.GetComponent<Bouton>().getBoutonPresse()))//si le bouton lié à la porte est relaché
      {
        fermeturePorte();
      }
    }
    void ouverturePorte()
    {
      transform.position = Vector3.MoveTowards(transform.position, nouvPosPorteGauche, 0.01f);//déplace la porte jusqu'a sa position ouverte
    }
    void fermeturePorte()
    {
      transform.position = Vector3.MoveTowards(transform.position, PosPorteGauche, 0.01f); //déplace la porte jusqu'a sa position fermée
    }
}
