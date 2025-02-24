using System.Collections;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private GameObject EnemyprojectilePrefab; // Reference to the Enemyprojectile prefab
    [SerializeField] private Transform spawnPoint; // The spawn point on the enemy's body
    [SerializeField] private float attackInterval = 2f; // Time interval between attacks
    [SerializeField] private float EnemyprojectileSpeed = 5f; // Speed of the Enemyprojectile

    private PlayerMove playerMove;  // Reference to the player move script for direction calculations

    void Start()
    {
        // Start the coroutine to spawn Enemyprojectiles periodically
        playerMove = FindObjectOfType<PlayerMove>();  // Find the player in the scene
        StartCoroutine(SpawnEnemyprojectileRoutine());
    }

    private IEnumerator SpawnEnemyprojectileRoutine()
    {
        while (true)
        {
            // Wait for the interval before spawning the next projectile
            yield return new WaitForSeconds(attackInterval);

            // Spawn the Enemyprojectile at the chosen point on the enemy's body
            SpawnEnemyprojectile();
        }
    }

    private void SpawnEnemyprojectile()
    {
        // Instantiate the Enemyprojectile prefab at the spawn point
        GameObject enemyProjectile = Instantiate(EnemyprojectilePrefab, spawnPoint.position, Quaternion.identity);

        // Calculate the direction towards the player (from the spawn point)
        Vector2 directionToPlayer = (playerMove.transform.position - spawnPoint.position).normalized;

        // Get the ProjectileDamage component and set its direction and speed
        ProjectileDamage projectileScript = enemyProjectile.GetComponent<ProjectileDamage>();
        if (projectileScript != null)
        {
            
        }
    }
}
