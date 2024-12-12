using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;  // Velocidad de movimiento del jugador

    private void Update()
    {
        // Obtener la entrada del jugador (teclas A y D)
        float horizontalInput = 0f;

        if (Input.GetKey(KeyCode.D))
        {
            horizontalInput = 1f;  // Moverse a la derecha
        }
        else if (Input.GetKey(KeyCode.A))
        {
            horizontalInput = -1f;  // Moverse a la izquierda
        }

        // Mover al jugador en el eje X
        transform.Translate(Vector2.right * horizontalInput * moveSpeed * Time.deltaTime);
    }
}
