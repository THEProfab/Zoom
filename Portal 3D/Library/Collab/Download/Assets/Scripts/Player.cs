using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour

{
    public float moveSpeed;
    public Rigidbody rb;
    public bool joueurATerre = true;
    public int health;
    public bool hurt;
    public AudioSource audioSource;
    private float timeLeft = 5f; //initialise le timer

    // Start is called before the first frame update
    private void Start()
    {
        moveSpeed = 3f;
        rb = GetComponent<Rigidbody>();
        GameObject.Find("DamageIndicator").GetComponent<Image>().enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        //print(transform.rotation);

        //permet de sauter
        transform.Translate(moveSpeed*Input.GetAxis("Horizontal")*Time.deltaTime, 0f, moveSpeed * Input.GetAxis("Vertical") * Time.deltaTime);//Bouge sur l'axe x et z selon Les entrées horizontales et verticales
        if(Input.GetButtonDown("Jump") && joueurATerre) { //si le bouton espace est pressé et que le jour se situe par terre
            rb.AddForce(new Vector3(0, 3, 0), ForceMode.Impulse); //Impulsion simulant un saut
            joueurATerre = false; //le joueur ne se trouve plus a terre
        }


       if(hurt){ //si le joueur est touché
          GameObject.Find("DamageIndicator").GetComponent<Image>().enabled = true; //active l'ecran rouge (degat subit)
          timeLeft -= Time.deltaTime*100; //decrementation du timer
          if ( timeLeft < 0 ) //une fois le timer terminé:
          {
            GameObject.Find("DamageIndicator").GetComponent<Image>().enabled = false; //desactive l'ecran rouge (degat subit)
            audioSource.Play(); //joue le son de degat subit
            timeLeft = 5f; // On remet le timer pour les prochains dégats
            hurt = false; //le joueur n'est plus touché
          }

        }


        if (health == 0) { //si les points de vie atteignent 0
          SceneManager.LoadScene("menu_principal"); //Charge le menu principal
        }

    }

    private void OnCollisionEnter(Collision collision) //Quand le joueur est touché par un objet
    {
        if(collision.gameObject.tag == "Sol") //Si l'objet en question est un "sol"
        {
            joueurATerre = true; //le joueur se trouve a terre
        }
    }

    void OnMouseDown(){ //quand click pressé
      Cursor.lockState = CursorLockMode.Locked; //verrouille la souris
      Cursor.visible = false; //rend la souris invisible
    }



}