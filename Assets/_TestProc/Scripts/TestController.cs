using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestController : MonoBehaviour
{
	void Start ()
    {
        // Bunu kullanmaya gerek kalmadı çünkü, Controller objesine doğrudan ulaşabilmek için bir
        // static değişken kullandık. Controller.cs 'ye bkz. O statik obje olmadan da aşağıdaki gibi
        // bir kullanım ile objeyi bulabilmemiz mümkün.

        var controller = GameObject.FindGameObjectWithTag("GameController").GetComponent<Controller>();
	}
	
    /// <summary>
    /// Controller.cs'ya bkz.
    /// </summary>
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Controller.Instance.BlueManager.Toggle();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Controller.Instance.RedManager.Toggle();
        }
    }
}
