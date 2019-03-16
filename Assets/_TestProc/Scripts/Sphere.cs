using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    public float SelfDestroySeconds;
        
	
	void Start ()
    {
        GameObject.Destroy(gameObject, SelfDestroySeconds);	
	}
	
	
}
