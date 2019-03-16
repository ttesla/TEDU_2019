using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileGun : Gun
{
    public float FiringForce;
    public GameObject BallPrefab;

    private bool mFire = false;

    /// <summary>
    /// Fire metodu Gun içerisinde virtual olarak tanımlı ve bir şey yapmıyor. Biz ProjectileGun içerisinde onu "override" ederek, ne yapması gerektiğini belirtiyoruz.
    /// Bir fizik objesi'ne kuvvet vereceğimiz için, bunu FixedUpdate'de yapmak için her zaman kullandığımız flag yöntemini kullanıyoruz. Yani bir bool değişkeni true yapıyoruz
    /// işimiz bittikten sonra false yapıyoruz. 
    /// </summary>
    public override void Fire()
    {
        mFire = true;
    }

    /// <summary>
    /// Bir çok sefer kullandığımız bir obje yaratıp ona kuvvet verme örneği. Burda Bullet'da kullanabilirdik. Ama onu havuzda kullanmak için ekstra gereksinimler ile dontattığımız için
    /// burda sadece basit bir BallPrefab yaratıp onu kullanmayı tercih ettik. 
    /// </summary>
    void FixedUpdate()
    {
        if (mFire)
        {
            var ball = GameObject.Instantiate(BallPrefab, FirePoint.position, Quaternion.identity);
            ball.GetComponent<Rigidbody>().AddForce(FirePoint.forward * FiringForce, ForceMode.Impulse);
            mFire = false;
        }
    }
}
