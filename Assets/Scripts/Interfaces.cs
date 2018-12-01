using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHasHealthNotTracked
{
    void Damage(float d);
    void Heal(float h);
    void Kill();
}

public interface IHasHealthTracked
{
    void Damage(float d, IHasName damager);
    void Heal(float h, IHasName damager);
    void Kill(IHasName damager);
}

public interface IHasName
{
    string GetName();
}

public interface IWeapon : IHasName
{
    void Shoot();
    void Reload();
    bool CanShoot();
    bool CanReload();
    int GetShotsLeft();
    int GetMagSize();
}