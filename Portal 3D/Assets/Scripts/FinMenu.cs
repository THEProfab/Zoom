using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FinMenu : MonoBehaviour
{
    public bool clicked;
    public void EndMenu(){
       clicked = true;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(clicked) SceneManager.LoadScene("menu_principal");
    }
}
