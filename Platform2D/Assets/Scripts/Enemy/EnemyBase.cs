using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public int damage = 10;
    public Animator animator;
    public string triggerAtack = "Attack";
    public string triggerDeath = "Death";
    public float timeToDestroy = 1f;

    public HealthBase healthBase;
 private void Awake()
    {
        if (healthBase!=null)
        {
            healthBase.OnKill += OnEnemyKill; 
        }

    }

    private void OnEnemyKill()
    {
        healthBase.OnKill -= OnEnemyKill;
        PlayDeathAnimaton();
        Destroy(gameObject,timeToDestroy);

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.transform.name);
        var health = collision.gameObject.GetComponent<HealthBase>();
        if (health != null)
        {
            health.Damage(damage);
            PlayAttackAnimaton();
        }
    }
    private void PlayAttackAnimaton()
    {
        animator.SetTrigger(triggerAtack);
    }
    private void PlayDeathAnimaton()
    {
        animator.SetTrigger(triggerDeath);
    }
    public void Damage(int amount )
    {
        healthBase.Damage(amount); 
    }
}
