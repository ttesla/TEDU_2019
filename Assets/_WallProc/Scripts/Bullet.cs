using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float DeactivateSeconds;
    public float ExpRadius;
    public float ExpForce;

    private Rigidbody mRigidBody;

    #region UnityMethods
    void Awake()
    {
        mRigidBody = GetComponent<Rigidbody>();
    }

    /// <summary>
    /// Bullet nesnesi bir şeye çarptığında ne yapacağına dair kodlar burada
    /// Burda basit olarak rigidbody'si olan bir şeye çarparsa ona patlama kuvveti uygula diyoruz. (Explosion force) 
    /// </summary>
    void OnCollisionEnter(Collision collision)
    {
        if(collision.contacts.Length > 0)
        {
            var point = collision.contacts[0].point;

            var colliders = Physics.OverlapSphere(point, ExpRadius);

            foreach(var col in colliders)
            {
                var rigidbody = col.GetComponent<Rigidbody>();

                if(rigidbody != null)
                {
                    rigidbody.AddExplosionForce(ExpForce, point, ExpRadius);
                }
            }
        }
    }
    #endregion

    /// <summary>
    /// Bullet'leri biz kontrollü olarak yarattığımız için, Start ve Awake dışında bu metodu tanımladık.
    /// Init'i çağrılan her Bullet, kapalı ve Kinematiği aktif yani fiziği devre dışı olarak başlıyor.
    /// Fire'i çağırdığımızda hem fiziğini hem de nesnenin kendisini aktif hale getiriyoruz.
    /// </summary>
    public void Init()
    {
        gameObject.SetActive(false);
        mRigidBody.isKinematic = true;
    }

    /// <summary>
    /// Bullet ateşlendiğinde, başlangıç pozisyonu, atış yönü ve kuvveti gibi değişkenleri ona uygulamak gerek.
    /// Bunları ilk etapta Tank.cs içinde yapıyorduk, bunları Bullet'in içine taşımamızın nedeni, tasarımsal olarak
    /// daha doğru bir yaklaşım olmasıdır. Tasarımsal olarak hangi kod nereye yazılmalı konusu tamamen size kalmış 
    /// ama konu ile ilgili nesnenin kodları o nesne üzerinde olması daha doğru kabul edilen bir yaklaşımdır. 
    /// </summary>
    public void Fire(Vector3 startPos, Vector3 direction, float force)
    {
        gameObject.SetActive(true);
        mRigidBody.isKinematic = false;
        transform.position = startPos;
        mRigidBody.AddForce(direction * force, ForceMode.Impulse);

        Invoke("Deactivate", DeactivateSeconds);
    }

    /// <summary>
    /// Ateşlenen her Bullet bir süre sonra otomatik olarak Deactivate'i çağırarak kendini kapatır. 
    /// Bu tarz "fire and forget" tarzı kullanımlar işinizi kolaylaştıracaktır. Tasarımlarınızı da böyle yapılar
    /// üzerine kurmanız faydanıza olacaktır. Diğer türlü ateşlenen her Bullet'i takip eden bir BulletManager olmalıydı ve
    /// ara ara kontrol edip, vadesi dolan Bullet'ları temizlemeliydi. Burda ekstra bir manager olmadan Bullet'in ateşlendikten sonra
    /// kendi kendine işini halletsin, bizi uğraştırmasın gibi bir yaklaşım kullandık. 
    /// 
    /// Kinematik aç kapa ve velocity sıfırlama tamamen Bullet havuzu kullandığımız için yaptık. Çünkü havuz bittikten sonra tekrar daha önce
    /// ateşlenen Bullet'a sıra geldiğinde üzerinde önceden kalmış hız ve ivme değerleri olabiliyor.
    /// </summary>
    void Deactivate()
    {
        mRigidBody.velocity = Vector3.zero;
        mRigidBody.isKinematic = true;
        gameObject.SetActive(false);
    }
}
