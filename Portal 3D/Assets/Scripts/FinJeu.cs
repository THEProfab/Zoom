using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinJeu : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other){
      if(other.name == "Player"){ //si le touche le collider de fin de niveau
        SceneManager.LoadScene("FIN"); //charge l'ecran de fin
      }

    }
}
