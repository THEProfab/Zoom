using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PorteDroite : MonoBehaviour
{

    private Vector3 nouvPosPorteDroite;
    private Vector3 PosPorteDroite;
    public float speed;
    public GameObject boutonLié;

    void Start()
    {
        PosPorteDroite = transform.position;
        nouvPosPorteDroite = new Vector3(transform.position.x-2f, transform.position.y, transform.position.z);//initialise la position de la porte une fois ouverte
    }

    void Update()
    {
        float step = speed * Time.deltaTime;
        if (boutonLié.GetComponent<Bouton>().getBoutonPresse()) //si le bouton lié à la porte est pressé
        {
          ouverturePorte();
        }
        else if (!(boutonLié.GetComponent<Bouton>().getBoutonPresse()))//si le bouton lié à la porte est relaché
        {
          fermeturePorte();
        }
    }

    void ouverturePorte()
    {
      transform.position = Vector3.MoveTowards(transform.position, nouvPosPorteDroite, 0.01f); //déplace la porte jusqu'a sa position ouverte
    }
    void fermeturePorte()
    {
      transform.position = Vector3.MoveTowards(transform.position, PosPorteDroite, 0.01f); //déplace la porte jusqu'a sa position fermée
    }

}
