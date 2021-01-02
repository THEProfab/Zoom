using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Bouton : MonoBehaviour
{
    private bool boutonPresse = false;
    private Vector3 boutonAppui;
    private Vector3 boutonRelache;
    public Transform bouton;
    public GameObject cubeLié;

    void Start()
    {
        boutonAppui = new Vector3(transform.position.x, transform.position.y - 3.50f, transform.position.z); //initialise la position du bouton appuyé
        boutonRelache = new Vector3(transform.position.x, transform.position.y + 3.50f, transform.position.z);//initialise la position du bouton relaché

    }

    private void OnCollisionEnter(Collision collision)
    {
        if ((collision.gameObject.name == "Player" || collision.gameObject.name == cubeLié.gameObject.name) && boutonPresse == false)// si le joueur ou le cube touche le bouton et que le bouton n'est pas pressé
        {
            boutonPresse = true;//le bouton est pressé
            descenteBouton(); //active la descente du bouton
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if ((collision.gameObject.name == "Player" || collision.gameObject.name == cubeLié.gameObject.name) && boutonPresse == true) // si le joueur ou le cube part du bouton et que le bouton est pressé

        {
            boutonPresse = false; //le bouton n'est plus pressé
            monteeBouton(); //active la montée du bouton
        }
    }


    private void descenteBouton(){
      bouton.transform.position = Vector3.MoveTowards(transform.position, boutonAppui, 0.001f); //bouge le bouton jusqu'a sa position appuyé
    }
    private void monteeBouton(){
      bouton.transform.position = Vector3.MoveTowards(transform.position, boutonRelache, 0.001f);//bouge le bouton jusqu'a sa position relaché
    }

    public bool getBoutonPresse() //getter du bouton pressé (utilisé dans le script de la porte)
    {
        return boutonPresse;
    }
}
