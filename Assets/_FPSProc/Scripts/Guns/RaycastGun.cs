using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastGun : Gun
{
    public GameObject DecalPrefab;

    private Camera mMain;

    void Start()
    {
        mMain = Camera.main;  //GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    /// <summary>
    /// Fire metodu Gun nesnesinden geliyor, biz onu "override" ediyoruz. RaycastGun'un Fire mantığını burda yazdık.
    /// </summary>
    public override void Fire()
    {
        var ray = mMain.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

        RaycastHit hitInfo;

        // 200 metre boyunca ray atıyoruz, bir şeye çarparsa bu if'in içine gircek ve çarpma bilgisi
        // hitInfo içine yazılmış olacak. O çarpma bilgisine göre eğer bu bir "Enemy" ise onun doğrudan Minator olduğunu varsayıp, ona 10 zarar ver diyoruz.
        if(Physics.Raycast(ray, out hitInfo, 200.0f))
        {
            var hitPoint = hitInfo.point;
            //hitInfo.normal
            var decal = GameObject.Instantiate(DecalPrefab, hitPoint, Quaternion.identity);
            decal.transform.SetParent(hitInfo.collider.gameObject.transform);

            if(hitInfo.collider.gameObject.tag == "Enemy")
            {
                var minator = hitInfo.collider.gameObject.GetComponent<Minator>();
                minator.Damage(10);
            }
        }
    }
}
