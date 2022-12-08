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
    public SO_EnemyDropSetup enemyLoot;
    public ParticleSystem deathVFX;
    private void Awake()
    {
        if (healthBase != null)
        {
            healthBase.OnKill += OnEnemyKill;
            enemyLoot.enemyposition =transform.position;
            if (deathVFX != null) deathVFX.transform.SetParent(null);

        }

    }

    private void OnEnemyKill()
    {
        healthBase.OnKill -= OnEnemyKill;
        PlayDeathAnimaton();
        Destroy(gameObject, timeToDestroy);
        Drop();
        deathVFX.Play();
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
    public void Damage(int amount)
    {
        healthBase.Damage(amount);
    }

    private void Drop()
    {
        {
            Instantiate(enemyLoot.loot[Random.Range(enemyLoot.minValue, enemyLoot.maxValue)], new Vector2(enemyLoot.enemyposition.x, enemyLoot.enemyposition.y), Quaternion.identity);
            Debug.Log("Drop");
        }
    }
}
