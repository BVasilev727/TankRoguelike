using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField]
    GameObject enemy;
    [SerializeField]
    Vector3 spawnArea;
    [SerializeField]
    float spawnTimer;
    float timer;
    [SerializeField]
    GameObject player;
    [SerializeField]
    SimpleTImer simpleTimer;
    [SerializeField]
    float startSpeed;

    public void setSpeed(float speed)
    {
        startSpeed = speed;
    }

    private void FixedUpdate()
    {
        timer -= Time.deltaTime;
        if(timer < 0f)
        {
            SpawnEnemy();
            timer = spawnTimer;
        }
    }
    private void SpawnEnemy()
    {
        Vector3 position = GenerateRandomPosition();

        position += player.transform.position;
        position.y = 1;
        GameObject newEnemy = Instantiate(enemy);
        newEnemy.GetComponent<Enemy>().SetHp(5-simpleTimer.returnMinutes());
        newEnemy.transform.position = position;
        newEnemy.GetComponent<Enemy>().SetTarget(player);
        newEnemy.transform.parent = transform;
        newEnemy.tag = "Enemy";
    }

    private Vector3 GenerateRandomPosition()
    {
        Vector3 position = new Vector3();
        
        float f = UnityEngine.Random.value> 0.5f ? -1f : 1f;
        if (UnityEngine.Random.value > 0.5f)
        {
            position.x = UnityEngine.Random.Range(-spawnArea.x, spawnArea.x);
            position.z = spawnArea.z * f;
        }
        else {
            position.z = UnityEngine.Random.Range(-spawnArea.z, spawnArea.z);
            position.x = spawnArea.x * f;
        }
        position.y = 1f;

        return position;
    }


}
