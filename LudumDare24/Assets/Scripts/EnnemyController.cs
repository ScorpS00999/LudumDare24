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

    //[SerializeField] Collider2D colliderZone;
    private SpriteRenderer spriteRenderer;

    [SerializeField] Collider2D colliderZone;

    bool mort;

    void Start()
    {
        startPosition = transform.position; // Position de départ
        spriteRenderer = GetComponent<SpriteRenderer>();

        mort = false;
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
                spriteRenderer.flipX = true;

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
                spriteRenderer.flipX = false;
            }
        }
    }
    public void TakeDamage(int damage)
    {
        ennemyLifePoints -= damage;
        StartCoroutine(changeColor());

        if (ennemyLifePoints <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        mort = true;
        StartCoroutine(changeColor());
        colliderZone.enabled = false;
        ValidationZone.Instance.Validation();
    }

    IEnumerator changeColor()
    {
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.2f);
        if (mort)
        {
            Destroy(gameObject);
        }
        else
        {
            this.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }
}