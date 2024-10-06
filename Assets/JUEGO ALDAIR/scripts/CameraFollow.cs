using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;          // Referencia al transform del jugador
    public float followSpeed = 2f;    // Velocidad de seguimiento de la cámara
    public Vector3 offset;             // Desplazamiento de la cámara respecto al jugador

    void Start()
    {
        // Configura el desplazamiento inicial de la cámara
        offset = transform.position - player.position;
    }

    void LateUpdate()
    {
        // Calcula la nueva posición de la cámara
        Vector3 targetPosition = player.position + offset;

        // Mueve la cámara hacia la posición objetivo suavemente
        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
    }
}
