using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    [SerializeField]
    Transform firingPoint;
    
    [SerializeField]
    Projectile projectilePrefab;

    [SerializeField]
    float firingSpeed;
    [SerializeField]
    float rotationSpeed;
    public static PlayerGun Instance;
    [SerializeField]
    GameObject enemy;


    private float lastTimeShot = 0;

    // Start is called before the first frame update
    void Awake()
    {
        Instance = GetComponent<PlayerGun>();
    }
    Transform GetClosestEnemy(Transform[] enemies)
    {
        Transform bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = transform.position;
        foreach (Transform potentialTarget in enemies)
        {
            Vector3 directionToTarget = potentialTarget.position - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if (dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                bestTarget = potentialTarget;
            }
        }
        return bestTarget;
    }
    private void Update()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        List<Transform> targets = new List<Transform>();
        foreach(GameObject gameObject in enemies) {
            targets.Add(gameObject.transform);
        }
        Transform[] enemyPositions = targets.ToArray();
        Transform enemy = GetClosestEnemy(enemyPositions);
        if (Vector3.Distance(enemy.position,this.transform.position) <= projectilePrefab.returnDistance())
        {
            transform.LookAt(enemy.transform.position);
            this.Shoot();
        }
    }

    public void Shoot()
    {
        if(lastTimeShot + firingSpeed <= Time.time)
        {
            Instantiate(projectilePrefab,firingPoint.position, firingPoint.rotation);
            lastTimeShot = Time.time;
        }
    }

    public void RaiseAttackSpeed()
    {
        if (firingSpeed > 0.1f)
        {
            firingSpeed -= 0.1f;
        }
        else return;
    }

}
