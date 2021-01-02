using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float sensiSouris = 100f;
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(-1 * sensiSouris * Input.GetAxis("Mouse Y") * Time.deltaTime, 0, 0); //Rotate sur l'axe x par rapport à l'entrée souris

        player.transform.Rotate(0, Input.GetAxis("Mouse X") * Time.deltaTime * sensiSouris, 0);//Rotate sur l'axe y par rapport à l'entrée souris
    }
}
