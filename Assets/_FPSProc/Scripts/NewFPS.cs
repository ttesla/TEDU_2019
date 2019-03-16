using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GunType
{
    RaycastGun,
    ProjectileGun
}

public class NewFPS : MonoBehaviour
{
    public Gun RaycastGun;
    public Gun ProjectileGun;

    private Gun ActiveGun;

    void Start()
    {
        SwitchWeapon(GunType.ProjectileGun);    
    }

    void Update ()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            ActiveGun.Fire();
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwitchWeapon(GunType.ProjectileGun);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SwitchWeapon(GunType.RaycastGun);
        }
    }

    /// <summary>
    /// Silah değiştirme metodu (fonksiyonu)
    /// </summary>
    private void SwitchWeapon(GunType gunType)
    {
        switch (gunType)
        {
            case GunType.RaycastGun:
                RaycastGun.SetActivate(true);
                ProjectileGun.SetActivate(false);
                ActiveGun = RaycastGun;
                break;
            case GunType.ProjectileGun:
                RaycastGun.SetActivate(false);
                ProjectileGun.SetActivate(true);
                ActiveGun = ProjectileGun;
                break;
        }
    }
}
