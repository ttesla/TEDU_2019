using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Gun için parent class. 
/// RaycastGun ve ProjectileGun bu sınıftan türüyorlar. 
/// Gun sınıfı boş, ilgili kodlar ilgili Gun sınıfları içerisindedir. 
/// Bu kısım karışık geldiyse C#'da inheritance (kalıtım) konularını biraz çalışabilirsiniz. 
/// </summary>
public class Gun : MonoBehaviour
{
    public float CoolDown;
    public Transform FirePoint;

    public virtual void Fire()
    {

    }

    public void SetActivate(bool value)
    {
        gameObject.SetActive(value);
    }
}
