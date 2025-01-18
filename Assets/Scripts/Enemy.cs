using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Transform targetDestination;
    GameObject targetGameObject;
    Character targetCharacter;

    [SerializeField]
    SimpleTImer simpleTImer;

    [SerializeField]
    float speed;

    [SerializeField]
    int hp = 3;
    [SerializeField]
    int damage = 1;

    [SerializeField]
    int experience_reward = 400;

    [SerializeField]
    float avoidanceRange = 2f;
    int timeOfLastSpeedUp;
    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        simpleTImer = GameManager.FindAnyObjectByType<SimpleTImer>();
        timeOfLastSpeedUp = simpleTImer.returnMinutes();
    }

    public void SetTarget(GameObject target)
    {
        targetGameObject = target;
        targetDestination = target.transform;
    }

    private void FixedUpdate()
    {
        Vector3 direction = (targetDestination.position - transform.position).normalized;
        direction.y = 0;
        rb.transform.rotation = Quaternion.LookRotation(direction);
        if(timeOfLastSpeedUp != simpleTImer.returnMinutes())
        {
            timeOfLastSpeedUp = simpleTImer.returnMinutes();
            speed += (5 - simpleTImer.returnMinutes());
        }
        rb.velocity = direction * speed;
    }
    public int returnSpeed()
    {
        return (int)speed;
    }
    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }

    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject == targetGameObject)
        {
            Attack();
        }
    }
    private void Attack()
    {
        if(targetCharacter == null)
        {
            targetCharacter = targetGameObject.GetComponent<Character>();
        }
        targetCharacter.TakeDamage(damage);
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;

        if (hp<1)
        {
            Destroy(gameObject);
            targetGameObject.GetComponent<Level>().AddExperience(experience_reward);
        }
    }

    public void SetHp(int bonusHp)
    {
        this.hp += bonusHp + bonusHp/2;
    }

   private void AvoidOtherEnemies()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in enemies)
        {
            float avoidDistance = Vector3.Distance(transform.position, enemy.transform.position);
            if(avoidDistance < avoidanceRange)
            {
                Vector3 avoidanceDirection = transform.position - enemy.transform.position;
                transform.Translate(avoidanceDirection.normalized * Time.deltaTime * speed);
            }
        }

    }
}
