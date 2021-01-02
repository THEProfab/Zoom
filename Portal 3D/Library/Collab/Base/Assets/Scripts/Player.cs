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
    private float timeLeft =0.5f;

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
        transform.Translate(moveSpeed*Input.GetAxis("Horizontal")*Time.deltaTime, 0f, moveSpeed * Input.GetAxis("Vertical") * Time.deltaTime);
        if(Input.GetButtonDown("Jump") && joueurATerre) {
            rb.AddForce(new Vector3(0, 3, 0), ForceMode.Impulse);
            joueurATerre = false;
        }


        if(hurt){
          timeLeft =3f;
          GameObject.Find("DamageIndicator").GetComponent<Image>().enabled = true;
          timeLeft -= Time.deltaTime*100;
          print(timeLeft);
          if ( timeLeft < 0 )
          {
            GameObject.Find("DamageIndicator").GetComponent<Image>().enabled = false;
            timeLeft = 10;
            audioSource.Play();
            hurt = false;
          }

        }

        if (health == 0) {
          SceneManager.LoadScene("menu_principal");
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Sol")
        {
            joueurATerre = true;
        }
        if(collision.gameObject.tag == "PortalBlue"){
          //print("tu touche le portal");
        }

    }
    void OnMouseDown(){
      Cursor.lockState = CursorLockMode.Locked;
      Cursor.visible = false;
    }



}
