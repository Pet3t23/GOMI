using UnityEngine;
using UnityEngine.SceneManagement;  // Para gestionar escenas

public class EnemyAI : MonoBehaviour
{
    public Transform player;           // Referencia al transform del jugador
    public float speed = 3f;           // Velocidad del enemigo
    public int damage = 10;            // Daño que el enemigo inflige al jugador
    public float visionRange = 5f;     // Rango de visión del enemigo

    void Update()
    {
        FollowPlayer();  // Seguir al jugador si está dentro del rango
    }

    void FollowPlayer()
    {
        // Comprobar si el jugador está dentro del rango de visión
        if (player != null && Vector2.Distance(transform.position, player.position) <= visionRange)
        {
            // Dirección hacia el jugador
            Vector2 direction = (player.position - transform.position).normalized;

            // Mover al enemigo hacia el jugador
            transform.Translate(direction * speed * Time.deltaTime);
        }
    }

    // Método para infligir daño al jugador cuando colisiona con él
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerMovement playerMovement = collision.gameObject.GetComponent<PlayerMovement>();
            if (playerMovement != null)
            {
                playerMovement.TakeDamage(damage);  // Infligir daño al jugador
                Debug.Log("El enemigo ha dañado al jugador: " + damage);

                // Finaliza la escena inmediatamente cuando el jugador es golpeado
                playerMovement.Die();  // Llama al método Die del jugador
            }
        }
    }
}
