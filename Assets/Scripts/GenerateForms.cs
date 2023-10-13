using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class GenerateForms : MonoBehaviour
{
    public GameObject trianglePrefab;  // Prefab for the triangle shape
    public GameObject rectanglePrefab; // Prefab for the rectangle shape
    public GameObject circlePrefab;    // Prefab for the circle shape
    public Transform imageTarget;
    public float spawnInterval = 2.0f; // Time interval for spawning shapes
    public float moveSpeed = 2.0f; // Speed of movement

    private Vector3 endPosition;

    private void Start()
    {
        endPosition = imageTarget.position;
        StartCoroutine(SpawnShapes());
    }

    IEnumerator SpawnShapes()
    {
        while (true)
        {
            // Randomly choose which shape to spawn
            GameObject shapeToSpawn = GetRandomShape();

            if (shapeToSpawn != null)
            {
                // Instantiate the selected shape on the AR ImageTarget with the random position.
                Vector3 spawnPosition = imageTarget.position;
                spawnPosition.x -= 15f;
                
                Quaternion spawnRotation = imageTarget.rotation;

                GameObject spawnedObject = Instantiate(shapeToSpawn, spawnPosition, spawnRotation);

                StartCoroutine(MoveObject(spawnedObject));
            }

            // Wait for the specified spawn interval before spawning the next shape
            yield return new WaitForSeconds(spawnInterval);
        }
    }


    IEnumerator MoveObject(GameObject objectToMove)
    {
        Vector3 targetPosition = new Vector3(endPosition.x, objectToMove.transform.position.y, objectToMove.transform.position.z);

        while (objectToMove.transform.position != targetPosition)
        {
            objectToMove.transform.position = Vector3.MoveTowards(objectToMove.transform.position, targetPosition, moveSpeed * Time.deltaTime);
            yield return null;
        }

        Destroy(objectToMove);
    }

    GameObject GetRandomShape()
    {
        int randomShape = Random.Range(0, 3);

        return randomShape switch
        {
            0 => trianglePrefab,
            1 => rectanglePrefab,
            2 => circlePrefab,
            _ => null,
        };
    }
}
