using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextWelcome : MonoBehaviour
{
    // Start is called before the first frame update
    private float  timeLeft;

    void Start()
    {
      timeLeft = 8f;
    }

    // Update is called once per frame
    void Update()
    {
       timeLeft -= Time.deltaTime; //decrementation du timer
       if ( timeLeft < 0 )
       {
          gameObject.SetActive(false); //desactive le texte de bienvenu
       }
    }
}
