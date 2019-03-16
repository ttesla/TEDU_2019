using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blue : MonoBehaviour
{
    private bool mScaleUp = true;

    private Vector3 mDefaultScale;

    void Start()
    {
        mDefaultScale = transform.localScale;
    }

    /// <summary>
    /// Eğer mScaleUp flag'i true ise false yap. 
    /// Bu işlemin sonunda mScaleUp flag'i true ise locakScale'i 10 kat büyüt değilse başlangıç değeri neyse ona eşitle.
    /// </summary>
    public void Toggle()
    {
        mScaleUp = !mScaleUp;

        transform.localScale = mScaleUp ? Vector3.one * 10.0f : mDefaultScale;

        // Yukardaki kullanımın aynısı. Daha açık olarak alt alta yazılmış hali.

        //if (mScaleUp)
        //{
        //    transform.localScale = Vector3.one * 10;
        //}
        //else
        //{
        //    transform.localScale = mDefaultScale;
        //}
    }
}
