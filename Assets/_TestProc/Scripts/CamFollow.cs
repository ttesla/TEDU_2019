using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Transform Target;
    public float Speed;

    /// <summary>
    /// Çok basit bir kamera takip sistemi. Doğrudan takip etmesin diye biraz Lerp ekledik.
    /// Fizik ile hareket eden objelerde, FixedUpate - Update frekans uyuşmazlığı yüzünden, takip edilen objelerde titreme olabilir.
    /// Bu gibi durumda Fizik objesinin Interpolate ayarlarını Interpolate - Extrapolate'e getirerek düzeltebilirsiniz.  
    /// </summary>
    private void LateUpdate()
    {
        var finalPos       = new Vector3(Target.position.x, transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, finalPos, Time.deltaTime * Speed); 
    }
}
