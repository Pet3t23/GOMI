using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 10;  // Da�o que inflige la bala

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage);  // Infligir da�o al enemigo
            }
            Destroy(gameObject);  // Destruir la bala despu�s de infligir da�o
        }

        // Aqu� puedes agregar l�gica para infligir da�o al jugador si es necesario
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
