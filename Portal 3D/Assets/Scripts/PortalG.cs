using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalG : MonoBehaviour
{
    string tagMur = "murPortail";
    public Transform CameraJoueur;
    private Vector3 v2;
    // Update is called once per frame
    void Update()
    {
        RaycastHit tir1;
        RaycastHit tir2;
        Ray aim = new Ray(CameraJoueur.transform.position, CameraJoueur.transform.forward); //initialise direction du rayon
        if(Input.GetButtonDown("Fire1")){ //clique gauche pressé
            if((Physics.Raycast(aim, out tir1)) && (tir1.collider.tag == tagMur)){ //Si le rayon touche un objet et que l'objet à le tag "murPortail"
                Vector3 v = tir1.collider.transform.rotation.eulerAngles; //rotation du mur touché
                Vector3 v2 = new Vector3(tir1.point.x, tir1.point.y, tir1.point.z); //position touché par le raycast

                //selon l'orientation du mur touché, la postition du portails diffère afin qu'il ne reste pas dans le mur
                if(v.y == 0)
                {
                  v2.z -= 0.1f;
                }
                else if(v.y == 90)
                {
                  v2.x -= 0.1f;
                }
                else if(v.y == 180)
                {
                  v2.z += 0.1f;
                }
                else if(v.y == 270)
                {
                  v2.x += 0.1f;
                }
                Portails.portailBleu.transform.position = v2; //deplace le portail jusqu'a la position

                v.x = 0;
                v.z = 0;
                v.y *= -1;
                if(v.y == 0) v.y = 180; //
                Portails.portailBleu.transform.rotation = Quaternion.Euler(v);
            }
        }
        if(Input.GetButtonDown("Fire2")){
            if((Physics.Raycast(aim, out tir2)) && (tir2.collider.tag == tagMur)){
                Vector3 v = tir2.collider.transform.rotation.eulerAngles;
                Vector3 v2 = new Vector3(tir2.point.x, tir2.point.y, tir2.point.z);
                if(v.y == 0)
                {
                  v2.z -= 0.1f;
                }
                else if(v.y == 90)
                {
                  v2.x -= 0.1f;
                }
                else if(v.y == 180)
                {
                  v2.z += 0.1f;
                }
                else if(v.y == 270)
                {
                  v2.x += 0.1f;
                }
                Portails.portailOrange.transform.position = v2;
                v.x = 0;
                v.z = 0;
                v.y *= -1;
                if(v.y == 0) v.y = 180;
                Portails.portailOrange.transform.rotation = Quaternion.Euler(v);
            }
        }
    }
}
