using UnityEngine;

public class Turret : MonoBehaviour
{
    public Transform player;         // Referencia al transform del jugador
    public GameObject bulletPrefab;  // Prefab de la bala que disparar� la torreta
    public Transform bulletSpawn;    // Punto donde se generar�n las balas
    public float fireRate = 1f;      // Tasa de disparo en disparos por segundo
    public float range = 10f;         // Rango de detecci�n del jugador
    public float bulletSpeed = 15f;   // Velocidad de la bala (ajustada para m�s fuerza)

    private float nextFireTime;      // Temporizador para controlar el tiempo de disparo

    void Update()
    {
        // Verifica si el jugador est� dentro del rango
        if (Vector2.Distance(transform.position, player.position) <= range)
        {
            AimAtPlayer();  // Apunta hacia el jugador

            // Solo dispara si el jugador est� dentro del rango y ha pasado el tiempo de recarga
            if (Time.time >= nextFireTime)
            {
                Shoot();  // Dispara
                nextFireTime = Time.time + 1f / fireRate;  // Reinicia el temporizador
            }
        }
    }

    void AimAtPlayer()
    {
        // Calcula la direcci�n hacia el jugador
        Vector2 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;  // Convierte a grados

        // Establece la rotaci�n de la torreta
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));  // Ajusta el �ngulo si es necesario
    }

    void Shoot()
    {
        // Instancia la bala en el punto de disparo
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = bullet.transform.up * bulletSpeed;  // Aumenta la velocidad de la bala
    }
}
