using UnityEngine;

public class GeneradorDeObjetos : MonoBehaviour
{
    public GameObject objetoPrefab;   
    public Transform jugador;       
    public float tiempoGeneracion = 1f;  
    public float rangoGeneracionY = 5f;  
    public float distanciaGeneracionX = 0f;  

    private float tiempoTranscurrido = 0f;

    void Update()
    {
        
        tiempoTranscurrido += Time.deltaTime;

        if (tiempoTranscurrido >= tiempoGeneracion)
        {
            GenerarObjeto();
            tiempoTranscurrido = 0f;  
        }
    }

    void GenerarObjeto()
    {
        
        float posY = jugador.position.y + Random.Range(rangoGeneracionY, rangoGeneracionY + 5f);  

      
        Vector3 posicionGeneracion = new Vector3(jugador.position.x + distanciaGeneracionX, posY, 0f);

       
        GameObject objetoGenerado = Instantiate(objetoPrefab, posicionGeneracion, Quaternion.identity);

        
        Rigidbody2D rb = objetoGenerado.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.isKinematic = false;  
        }
    }
}
