using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIBase : MonoBehaviour, IHasHealthNotTracked
{
    // Base health implementation
    [SerializeField] float maxHealth;
    public float MaxHealth => maxHealth;

    float curHealth;
    public float CurrentHealth => curHealth;

    public void Damage(float d)
    {
        curHealth -= d;
    }

    public void Heal(float h)
    {
        curHealth += h;
    }

    public void Kill()
    {
        OnDeath();
    }

    // Delegate common unity callbacks to child implementation ( not sure if unity callbacks work if script is not direct child of MonoBehaviour )
    private void Awake() => InitAI();
    private void Update() => UpdateAI();
    private void OnBecameVisible() => AIBecameVisible();
    private void OnBecameInvisible() => AIBecameInvisible();

    // Abstract methods ( for control of AI lifecycle )
    public abstract void InitAI();
    public abstract void UpdateAI();
    public abstract void OnDeath();
    public abstract void AIBecameVisible();
    public abstract void AIBecameInvisible();
}
