using System.Collections;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject fallingObjectPrefab;  // Prefab del objeto que caerá
    public float spawnRate = 4f;            // Frecuencia de generación de objetos
    public float spawnHeight = 10f;         // Altura desde la que caen los objetos
    public float spawnRangeX = 7f;          // Rango de aparición en el eje X (a la izquierda y derecha de la pantalla)

    private void Start()
    {
        // Comienza a generar objetos con una tasa de generación definida
        StartCoroutine(SpawnObjects());
    }

    private IEnumerator SpawnObjects()
    {
        while (true)
        {
            // Genera un objeto en una posición aleatoria en el eje X
            float spawnPosX = Random.Range(-spawnRangeX, spawnRangeX);
            Vector3 spawnPos = new Vector3(spawnPosX, spawnHeight, 0);

            // Instancia el objeto en la posición calculada
            Instantiate(fallingObjectPrefab, spawnPos, Quaternion.identity);

            // Espera antes de generar el siguiente objeto
            yield return new WaitForSeconds(spawnRate);
        }
    }
}
