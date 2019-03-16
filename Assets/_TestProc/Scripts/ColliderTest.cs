using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// En çok kullanılan Trigger ve Collision kullanım örnekleri.
/// </summary>
public class ColliderTest : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("SPHERE CARPTIM!:" + collision.gameObject.name);


        // Tag kullanarak neye çarptığımızı nasıl buluruz, örneği:
        // En yaygın kullanımı tag'a bakmak.

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
        Debug.Log("SPHERE TRIGGER: " + other.name);
    }
}
