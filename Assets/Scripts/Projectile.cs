using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Vector3 firingPoint;

    [SerializeField]
    float projectileSpeed;
    [SerializeField]
    float maxProjectileDistance;
    [SerializeField]
    int damage = 1;
    [SerializeField]
    Character character;
    PauseManager pauseManager;

    void Start()
    {
        firingPoint = transform.position;
        character = GameObject.FindWithTag("Player").GetComponent<Character>();
    }

    void Update()
    {
       MoveProjectile();
    }

    public float returnDistance()
    {
        return maxProjectileDistance;
    }

    void MoveProjectile()
    {
        if(Vector3.Distance(firingPoint,transform.position) > maxProjectileDistance) 
        {
            Destroy(this.gameObject);
        }
        else transform.Translate(Vector3.forward * projectileSpeed * Time.deltaTime);
    
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent<Enemy>(out Enemy enemyComponent))
        {
            enemyComponent.TakeDamage(damage*character.GetDamage());
            Destroy(this.gameObject);
        }
    }

}
