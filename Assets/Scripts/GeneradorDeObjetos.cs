using UnityEngine;

public class GeneradorDeObjetos : MonoBehaviour
{
    public GameObject objetoPrefab;   // Prefab del objeto que se generará
    public Transform jugador;         // Referencia al jugador para generar objetos cerca de él
    public float tiempoGeneracion = 1f;  // Tiempo entre cada generación
    public float rangoGeneracionY = 5f;  // Rango en Y donde aparecerán los objetos (más alto)
    public float distanciaGeneracionX = 0f;  // Distancia en X para que los objetos aparezcan justo encima del jugador

    private float tiempoTranscurrido = 0f;

    void Update()
    {
        // Contar el tiempo y generar el objeto en el intervalo especificado
        tiempoTranscurrido += Time.deltaTime;

        if (tiempoTranscurrido >= tiempoGeneracion)
        {
            GenerarObjeto();
            tiempoTranscurrido = 0f;  // Reiniciar el temporizador
        }
    }

    void GenerarObjeto()
    {
        // Generamos la posición en Y por encima del jugador
        float posY = jugador.position.y + Random.Range(rangoGeneracionY, rangoGeneracionY + 5f);  // Genera de 5 a 10 unidades por encima del jugador

        // Generamos la posición en X justo encima del jugador (sin desplazamiento horizontal)
        Vector3 posicionGeneracion = new Vector3(jugador.position.x + distanciaGeneracionX, posY, 0f);

        // Instanciamos el objeto
        GameObject objetoGenerado = Instantiate(objetoPrefab, posicionGeneracion, Quaternion.identity);

        // Asegurarnos de que el objeto tiene un Rigidbody2D para que pueda caer
        Rigidbody2D rb = objetoGenerado.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.isKinematic = false;  // Asegurarse de que la física esté activa
        }
    }
}
