using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 10;  // Daño que inflige la bala

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage);  // Infligir daño al enemigo
            }
            Destroy(gameObject);  // Destruir la bala después de infligir daño
        }

        // Aquí puedes agregar lógica para infligir daño al jugador si es necesario
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
