using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public WeaponDefinition weapon;
}

public class WeaponDefinition : ScriptableObject, IWeapon
{
    public string name;
    public string GetName() => name;

    //TODO: Implement
    public bool CanReload()
    {
        throw new System.NotImplementedException();
    }

    public bool CanShoot()
    {
        throw new System.NotImplementedException();
    }

    public int GetMagSize()
    {
        throw new System.NotImplementedException();
    }

    public int GetShotsLeft()
    {
        throw new System.NotImplementedException();
    }

    public void Reload()
    {
        throw new System.NotImplementedException();
    }

    public void Shoot()
    {
        throw new System.NotImplementedException();
    }
}
