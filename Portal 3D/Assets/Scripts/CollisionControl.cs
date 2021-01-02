using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionControl : MonoBehaviour
{

    public string OnCollisionEnter(Collision collision)
    {
        //print("touche " + collision.gameObject.name);
        return(collision.gameObject.name);
    }

    public string OnCollisionStay(Collision collision)
    {
        //print("marche sur " + collision.gameObject.name);
        return(collision.gameObject.name);
    }

    public string OnCollisionExit(Collision collision)
    {
        // print("est parti de " + collision.gameObject.name);
        return(collision.gameObject.name);
    }
}
