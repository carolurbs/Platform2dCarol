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
    protected Vector3 velocity;
   [SerializeField] protected float speed;
    protected Vector3 target;
    protected Vector3 previousPosition;
     protected bool flipped;
    [SerializeField]protected Transform[] waypoints; 
    public HealthBase healthBase;
    public SO_EnemyDropSetup enemyLoot;
    public ParticleSystem deathVFX;
    public AudioSource deathSFX;
    public AudioSource attackSFX;
    private void Awake()
    {
        if (healthBase != null)
        {
            healthBase.OnKill += OnEnemyKill;
            enemyLoot.enemyposition =transform.position;

        }

    }
    private void Start()
    {
         Init();
    }
    public virtual void Init()
    {
        animator = GetComponentInChildren<Animator>();
        target = waypoints[1].position;
    }
    public virtual void  Update()
    {
        Movement();
    }
    public virtual IEnumerator SetTarget(Vector3 position)
    {
        yield return new WaitForSeconds(5f);
        target=position;
        FaceTowards(position - transform.position);
    }
    public virtual void FaceTowards(Vector3 direction)
    {
        if (direction.x < 0f) transform.localEulerAngles = new Vector3(0, 0, 0);
        else transform.localEulerAngles = new Vector3(0, 180, 0);
    }

    public virtual void Movement()
    {
        velocity = ((transform.position - previousPosition) / Time.deltaTime);
        previousPosition=transform.position;
        if(transform.position!=target)
        {
            transform.position = Vector3.MoveTowards(transform.position,target,speed*Time.deltaTime);
        }
        else
        {
            if(target==waypoints[0].position)
            {
                if (flipped)
                {
                    flipped = !flipped;
                    StartCoroutine("SetTarget", waypoints[1].position);
                }
            }
            else
            {
                if(!flipped)
                {
                    flipped = !flipped;
                    StartCoroutine("SetTarget", waypoints[0].position);
                }
            }
        }
    }
  
    private void OnEnemyKill()
    {
        healthBase.OnKill -= OnEnemyKill;
        if (deathSFX != null) deathSFX.Play();
        PlayDeathAnimaton();
        if (deathVFX != null) deathVFX.transform.SetParent(null);
        deathVFX.Play();
        Destroy(gameObject, timeToDestroy);
        Drop();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.transform.name);
        var health = collision.gameObject.GetComponent<HealthBase>();
        if (health != null)
        {
            if (attackSFX!=null) attackSFX.Play();
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
