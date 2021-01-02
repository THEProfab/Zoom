using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public bool clicked;
    public void PlayButton(){
       clicked = true;
       print("Oui");
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(clicked) SceneManager.LoadScene("ScenePrincipale");
    }
}
