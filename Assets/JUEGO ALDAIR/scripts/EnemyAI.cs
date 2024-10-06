using UnityEngine;
using UnityEngine.SceneManagement;  // Para gestionar escenas

public class EnemyAI : MonoBehaviour
{
    public Transform player;           // Referencia al transform del jugador
    public float speed = 3f;           // Velocidad del enemigo
    public int damage = 10;            // Da�o que el enemigo inflige al jugador
    public float visionRange = 5f;     // Rango de visi�n del enemigo

    void Update()
    {
        FollowPlayer();  // Seguir al jugador si est� dentro del rango
    }

    void FollowPlayer()
    {
        // Comprobar si el jugador est� dentro del rango de visi�n
        if (player != null && Vector2.Distance(transform.position, player.position) <= visionRange)
        {
            // Direcci�n hacia el jugador
            Vector2 direction = (player.position - transform.position).normalized;

            // Mover al enemigo hacia el jugador
            transform.Translate(direction * speed * Time.deltaTime);
        }
    }

    // M�todo para infligir da�o al jugador cuando colisiona con �l
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerMovement playerMovement = collision.gameObject.GetComponent<PlayerMovement>();
            if (playerMovement != null)
            {
                playerMovement.TakeDamage(damage);  // Infligir da�o al jugador
                Debug.Log("El enemigo ha da�ado al jugador: " + damage);

                // Finaliza la escena inmediatamente cuando el jugador es golpeado
                playerMovement.Die();  // Llama al m�todo Die del jugador
            }
        }
    }
}
