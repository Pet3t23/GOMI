using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 50;  // Vida m�xima del enemigo
    public int currentHealth;    // Vida actual del enemigo

    void Start()
    {
        // Iniciar la vida del enemigo al m�ximo
        currentHealth = maxHealth;
    }

    // M�todo para recibir da�o
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Vida del enemigo restante: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // M�todo para manejar la muerte del enemigo
    void Die()
    {
        Debug.Log("El enemigo ha muerto.");
        Destroy(gameObject);  // Destruye el objeto del enemigo
    }
}
