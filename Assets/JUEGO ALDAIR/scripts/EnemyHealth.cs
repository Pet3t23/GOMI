using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 50;  // Vida máxima del enemigo
    public int currentHealth;    // Vida actual del enemigo

    void Start()
    {
        // Iniciar la vida del enemigo al máximo
        currentHealth = maxHealth;
    }

    // Método para recibir daño
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Vida del enemigo restante: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // Método para manejar la muerte del enemigo
    void Die()
    {
        Debug.Log("El enemigo ha muerto.");
        Destroy(gameObject);  // Destruye el objeto del enemigo
    }
}
