using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomFPS : MonoBehaviour
{
    public Transform Cam;
    public float MoveSpeed;
    public float MouseSens;
    public Rigidbody Body;

    private float mX;
    private float mY;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        HeadMovement();
        BodyMovement();

        //Cam.Rotate(Vector3.up, x);
        //Cam.Rotate(Vector3.right, y);
	}

    void BodyMovement()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Body.velocity = new Vector3(x, 0, y) * MoveSpeed;

        //transform.transform.position += new Vector3(x, 0, y) * MoveSpeed;

        //for(int i = 0; i < transform.childCount; i++)
        //{
        //    transform.GetChild(i).gameObject.SetActive(false);
        //}
    }

    void HeadMovement()
    {
        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");

        mX += x * MouseSens;
        mY -= y * MouseSens;

        var rot = Quaternion.Euler(mY, mX, 0.0f);
        Cam.localRotation = rot;
    }
}
