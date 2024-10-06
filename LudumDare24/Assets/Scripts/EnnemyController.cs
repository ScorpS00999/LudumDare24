using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyController : MonoBehaviour
{
    [SerializeField] private int ennemyLifePoints = 50;
    [SerializeField] private float speed = 2f;
    [SerializeField] private float distance = 5f;

    private Vector3 startPosition;
    private bool movingRight = true;

    void Start()
    {
        startPosition = transform.position; // Position de départ
    }

    void FixedUpdate()
    {
        Patrol();
    }

    void Patrol()
    {
        // If ennemy go to the right
        if (movingRight)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);

            // If ennemy is at patrol limit, change direction
            if (transform.position.x >= startPosition.x + distance)
            {
                movingRight = false;
            }
        }
        // Si l'ennemi est en mouvement vers la gauche
        else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);

            //If ennemy is back to his init position, change direction
            if (transform.position.x <= startPosition.x - distance)
            {
                movingRight = true;
            }
        }
    }
    public void TakeDamage(int damage)
    {
        ennemyLifePoints -= damage;
        Debug.Log("Ennemy Life Points: " + ennemyLifePoints);

        if (ennemyLifePoints <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Ennemy Died!");
        Destroy(gameObject);

        ValidationZone.Instance.Validation();
    }
}