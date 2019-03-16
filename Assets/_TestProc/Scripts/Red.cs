using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Red : MonoBehaviour
{
    private bool mOn = true;

    public void Toggle()
    {
        mOn = !mOn;

        gameObject.SetActive(mOn);
    }
}
