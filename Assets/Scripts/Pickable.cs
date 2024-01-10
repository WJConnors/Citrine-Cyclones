using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : MonoBehaviour
{
   // public bool pickable = true; 
    public float speed = 5.0f;


    public void BeThrown(float throwForce)
    {
       GetComponent<Rigidbody2D>().velocity = new Vector2(speed, throwForce);
    }
}
