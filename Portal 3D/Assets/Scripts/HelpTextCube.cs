using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelpTextCube : MonoBehaviour
{
    private float  timeLeft = 10;
    private bool active= false;
    public GameObject collid;


    void Start()
    {
      gameObject.GetComponent<Text>().enabled = false; //desactive le texte au demarrage
    }

    // Update is called once per frame
    void Update()
    {
      if(collid.GetComponent<ColliderTextCube>().getEtatTrigger()){ //si le joueur entre dans le collider
        active = true;
      }

      if(active){

        gameObject.GetComponent<Text>().enabled = true;//active le texte d'aide
        timeLeft -= Time.deltaTime; //decrementation du time
        if ( timeLeft < 0 ) //le timer atteint 0
        {
          gameObject.GetComponent<Text>().enabled = false; //desactive le texte d'aide
          active = false; //variable inactive
          timeLeft = 10; // réinitialise le timer
        }
      }
    }
}
