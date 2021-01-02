using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderTextCube : MonoBehaviour
{
    //ceci est le code du collider donnant le tutoriel sur le cube
    private bool trigger;

    void OnTriggerEnter(Collider other){
      if(other.tag == "Player"){
        trigger = true;
      }
    }
    void OnTriggerExit(Collider other){
      if(other.tag == "Player"){
        trigger = false;
      }
    }
    public bool getEtatTrigger(){
      return trigger;
    }
}
