using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderTestCube : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("CUBE CARPTIM!:" + collision.gameObject.name);


        //if(collision.gameObject.tag == "Bullet")
        //{
        //    collision.gameObject.GetComponent<Bullet>();
        //}
    }

    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("CARPMAYA DEVAM!");
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("CUBE TRIGGER: " + other.name);
    }
}
