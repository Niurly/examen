using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; 

    private void Update()
    {
       
        float horizontalInput = 0f;

        if (Input.GetKey(KeyCode.D))
        {
            horizontalInput = 1f;  
        }
        else if (Input.GetKey(KeyCode.A))
        {
            horizontalInput = -1f; 
        }

       
        transform.Translate(Vector2.right * horizontalInput * moveSpeed * Time.deltaTime);
    }
}
