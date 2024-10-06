using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;          // Referencia al transform del jugador
    public float followSpeed = 2f;    // Velocidad de seguimiento de la c�mara
    public Vector3 offset;             // Desplazamiento de la c�mara respecto al jugador

    void Start()
    {
        // Configura el desplazamiento inicial de la c�mara
        offset = transform.position - player.position;
    }

    void LateUpdate()
    {
        // Calcula la nueva posici�n de la c�mara
        Vector3 targetPosition = player.position + offset;

        // Mueve la c�mara hacia la posici�n objetivo suavemente
        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
    }
}
