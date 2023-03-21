using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawnScript : MonoBehaviour
{
    public GameObject pipe;
    public float heightOffset = 10;
    public float spawnRate = 4;
    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        spawnPipe();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            spawnPipe();
            timer = 0;
        }
    }

    void spawnPipe()
    {
        float lowestPt = transform.position.y - heightOffset;
        float highestPt = transform.position.y + heightOffset;
        Vector3 newPoint = new Vector3(transform.position.x, Random.Range(lowestPt, highestPt), 0);

        Instantiate(pipe, newPoint, transform.rotation);
    }
}
