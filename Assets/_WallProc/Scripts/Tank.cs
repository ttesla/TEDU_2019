using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{
    public GameObject BulletPrefab;
    public Transform Pivot;
    public Transform FiringPoint;
    public float FiringForce;
    public LayerMask Mask;
    public int PoolSize;
    public Transform BulletPoolParent;
    public float FireDelay;

    private bool mFire = false;
    private Camera mMainCam;
    private List<Bullet> BulletList;
    private int mPoolIndex = 0;

    private float mFireTimer;

    private void Start()
    {
        mMainCam = Camera.main;
        FillBulletPool();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && mFireTimer > FireDelay)
        {
            mFire = true;
            mFireTimer = 0.0f;
        }

        mFireTimer += Time.deltaTime;

        var mousePos = Input.mousePosition;
        var ray = mMainCam.ScreenPointToRay(mousePos);
        RaycastHit info;

        if(Physics.Raycast(ray, out info, 1000.0f, Mask))
        {
            Pivot.LookAt(info.point);

            // Aşağırda bir direction'dan rotation'a dönüşüm örneği var. Üstte aynısını yapan hazır method kullanımı var. 
            // Dikkat edilmesi gereken Y (up) vektörü yukarıyı göstermeli, öyle değilse, LookAt foknsiyonunun diğer parametresini
            // yukarı neyi gösteriyorsa onu seçmelisiniz. Default olarak Up vektörü seçili kabul ediyor. 

            //var dir = (info.point - Pivot.position).normalized;
            //var rot = Quaternion.LookRotation(dir);
            //Pivot.rotation = rot;
        }
    }
    
    /// <summary>
    /// Add force kısımları FixedUpdate içinde yapmalıyız diye söylemiştik. 
    /// Ama Button eventleri Update içinde tüketiliyor, o yüzden Butten eventlerini Update içinde kontrol ettik,
    /// mFire diye bir flag'i true yaptık, sonra onu kullanarak FixedUpdate içinde kullandık. Kullandıktan hemen sonra flag'i tekrar false yaptık. 
    /// </summary>
    void FixedUpdate ()
    {
        if (mFire)
        {
            Bullet bullet = GetNextBullet();
            bullet.Fire(FiringPoint.position, FiringPoint.forward, FiringForce);

            mFire = false;
        }
	}

    /// <summary>
    /// Bullet havuzunu dolduruyoruz. Bunu 1 sefer program başında çağırmamız yeterli. 
    /// </summary>
    void FillBulletPool()
    {
        BulletList = new List<Bullet>();

        for(int i = 0; i< PoolSize; i++)
        {
            var go = GameObject.Instantiate(BulletPrefab, BulletPoolParent);
            var bullet = go.GetComponent<Bullet>();
            bullet.Init();
            BulletList.Add(bullet);
        }
    }

    /// <summary>
    /// Sürekli yeni Bullet yaratmadığımız için, daha önceden yaratılmış Bullet'lardan
    /// sonrakini bize döndüren bir fonksiyon. Sona gelince tekrar başa dönüp, ilk Bullet'i döndürüyor.
    /// </summary>
    Bullet GetNextBullet()
    {
        var nextBullet = BulletList[mPoolIndex];

        mPoolIndex++;

        if(mPoolIndex >= PoolSize)
        {
            mPoolIndex = 0;
        }

        return nextBullet;
    }
}
