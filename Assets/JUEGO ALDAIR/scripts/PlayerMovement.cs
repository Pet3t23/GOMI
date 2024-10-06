using UnityEngine;
using UnityEngine.SceneManagement;  // Para gestionar escenas

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public Transform headTransform;
    public int maxHealth = 100;  // Vida máxima del personaje
    public int currentHealth;     // Vida actual del personaje

    void Start()
    {
        currentHealth = maxHealth;  // Inicializar la vida del jugador
    }

    void Update()
    {
        Move();
        RotateHeadTowardsMouse();
    }

    void Move()
    {
        // Movimiento del personaje usando las teclas de dirección
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        transform.Translate(movement * speed * Time.deltaTime, Space.World);
    }

    void RotateHeadTowardsMouse()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        Vector2 direction = new Vector2(
            mousePosition.x - headTransform.position.x,
            mousePosition.y - headTransform.position.y
        );
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        headTransform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
    }

    // Método para recibir daño
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;  // Reducir la salud
        Debug.Log("Vida restante: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();  // Llamar a la función de muerte
        }
    }

    // Método para manejar la muerte del jugador
    public void Die()
    {
        Debug.Log("El jugador ha muerto.");
        // Aquí puedes cargar una escena de game over o reiniciar la escena
        SceneManager.LoadScene("GameOverScene");  // Reemplaza "GameOverScene" con el nombre de tu escena de game over
    }
}
