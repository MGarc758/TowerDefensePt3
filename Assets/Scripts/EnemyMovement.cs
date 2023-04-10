using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    private Vector3 end = new Vector3(68.00002f, 1.083333f, 5.499998f);
    private Transform target;
    // private int wavepointIndex = 0;

    private Enemy enemy;

    private void Start()
    {
        // target = Waypoints.waypoints[0];
        enemy = GetComponent<Enemy>();
        
        var enemyAgent = enemy.GetComponent<NavMeshAgent>();
        enemyAgent.SetDestination(end);
    }
    
    private void Update()
    {
        // Vector3 dir = target.position - transform.position;
        // transform.Translate(dir.normalized * (enemy.speed * Time.deltaTime), Space.World);
        //
        // if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        // {
        //     GetNextWaypoint();
        // }
        //
        // enemy.speed = enemy.startSpeed;
        
        
        if (Vector3.Distance(enemy.GetComponent<Transform>().position, end) < 1f)
        {
            EndPath();
            return;
        }
    }

    private void GetNextWaypoint()
    {
        // wavepointIndex++;
        // target = Waypoints.waypoints[wavepointIndex];
    }

    private void EndPath()
    {
        PlayerStats.Lives--;
        WaveSpawner.enemiesAlive--;
        Destroy(gameObject);
    }
}
