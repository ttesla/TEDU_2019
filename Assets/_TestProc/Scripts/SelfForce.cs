using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfForce : MonoBehaviour
{
    //public Rigidbody AnotherRigidbody;

    public float Amount;
    public float MoveSpeed;

    private Rigidbody mRigidbody;

    private bool mJump = false;

    private void Awake()
    {
        mRigidbody = GetComponent<Rigidbody>();    
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetButtonDown("Jump"))
        {
            mJump = true;
;       }
	}


    void FixedUpdate()
    {
        if (mJump)
        {
            //mRigidbody.AddForce(Vector3.up * Amount, ForceMode.Impulse);

            mRigidbody.velocity = Vector3.up * Amount;
            mJump = false;
        }

        var defaultVelocity = mRigidbody.velocity;
        mRigidbody.velocity = new Vector3(1 * MoveSpeed, defaultVelocity.y, defaultVelocity.z); //  Vector3.right * MoveSpeed;
    }
}
