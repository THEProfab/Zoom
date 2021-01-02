using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCamera : MonoBehaviour
{
    public Transform playerCamera;
    public Transform player;
    public Transform interieurPortal;
    public Transform interieurAutrePortal;
    public Transform portal;
    public Transform autrePortal;



    // Update is called once per frame
    void Update()
    {
      Vector3 vuDuJoueurATraversPortail = playerCamera.position - interieurAutrePortal.position;

      //Selon la rotation du portail, la camera change d'emplacement
      if(portal.transform.rotation.eulerAngles.y == 0f)
      {
        transform.position = interieurPortal.position + new Vector3(vuDuJoueurATraversPortail.x*0f, -vuDuJoueurATraversPortail.y, -vuDuJoueurATraversPortail.z*0f);
      }

      else if(portal.transform.rotation.eulerAngles.y == 180f)
      {
        transform.position = interieurPortal.position + new Vector3(vuDuJoueurATraversPortail.x*0f, vuDuJoueurATraversPortail.y, -vuDuJoueurATraversPortail.z*0f);
      }

      else if(portal.transform.rotation.eulerAngles.y == 270f)
      {
        transform.position = interieurPortal.position + new Vector3(vuDuJoueurATraversPortail.x*0f, -vuDuJoueurATraversPortail.y, vuDuJoueurATraversPortail.z*0f);
      }
      else if(portal.transform.rotation.eulerAngles.y == 90f)
      {
        transform.position = interieurPortal.position + new Vector3(vuDuJoueurATraversPortail.x*0f, vuDuJoueurATraversPortail.y, -vuDuJoueurATraversPortail.z*0f);
      }


      float differenceAngulaireEntreRotationPortails = Quaternion.Angle(interieurPortal.rotation, interieurAutrePortal.rotation);
      Quaternion portalRotationDifference = Quaternion.AngleAxis(differenceAngulaireEntreRotationPortails, Vector3.up);
      Vector3 newCameraDirection = portalRotationDifference * playerCamera.forward;
      transform.eulerAngles = new Vector3(playerCamera.transform.eulerAngles.x, (player.transform.eulerAngles.y + autrePortal.transform.eulerAngles.y), playerCamera.transform.eulerAngles.z);
    }
}
