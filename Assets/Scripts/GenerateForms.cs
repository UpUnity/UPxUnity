using System.Collections;
using UnityEngine;

public class GenerateForms : MonoBehaviour
{
    public GameObject trianglePrefab; 
    public GameObject rectanglePrefab;
    public GameObject circlePrefab;
    public Transform imageTarget;
    public float spawnInterval = 4.0f;

    private void Start()
    {
        trianglePrefab.SetActive(false);
        rectanglePrefab.SetActive(false);
        circlePrefab.SetActive(false);
        StartCoroutine(SpawnAndAnimateObjects());
    }

    IEnumerator SpawnAndAnimateObjects()
    {
        while (true)
        {
            GameObject shapeToSpawn = GetRandomShape();

            GameObject spawnedObject = Instantiate(shapeToSpawn, imageTarget.position, imageTarget.rotation);
            spawnedObject.SetActive(true);
            spawnedObject.transform.parent = imageTarget;

            Animate(spawnedObject);

            yield return new WaitForSeconds(spawnInterval);
        }
    }


    private void Animate(GameObject spawnedObject)
    {
        Animator animator = spawnedObject.GetComponent<Animator>();
        animator.SetTrigger("MoveObject");

        float delayToDestroy = 8.0f;
        Destroy(spawnedObject, delayToDestroy);
    }

    private GameObject GetRandomShape()
    {
        int randomShape = Random.Range(0, 3);

        return randomShape switch
        {
            0 => trianglePrefab,
            1 => rectanglePrefab,
            2 => circlePrefab,
            _ => throw new System.NotImplementedException(),
        };
    }
}
