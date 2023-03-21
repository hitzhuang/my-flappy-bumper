using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawnScript : MonoBehaviour
{
    public GameObject clouds;

    public float heightOffset = 15;
    public float spawnRate = 2;
    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        spawnCloud();
    }

    void Update()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            spawnCloud();
            timer = 0;
        }
    }

    // Update is called once per frame
    void spawnCloud()
    {
        float lowestPt = transform.position.y - heightOffset;
        float highestPt = transform.position.y + heightOffset;
        Vector3 newPoint = new Vector3(transform.position.x, Random.Range(lowestPt, highestPt), 0);

        spawnRate = Random.Range(2, 7);

        Instantiate(clouds, newPoint, transform.rotation);
    }
}
