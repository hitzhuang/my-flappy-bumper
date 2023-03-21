using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMoveScript : MonoBehaviour
{
    public float moveSpeed = 7;
    private float deadZone = -50;

    // Update is called once per frame
    void Start()
    {
        Color color = gameObject.GetComponentInChildren<Renderer>().material.color;
        GameObject gameObjectA = gameObject.transform.Find("Top Cloud").gameObject;
        gameObjectA.transform.position += Vector3.up * Random.Range(-1.5f, 1.5f);
        gameObjectA.transform.position += Vector3.left * Random.Range(-15, 15);
        gameObjectA.GetComponent<Renderer>().material.color = new Color(
            color.r,
            color.g,
            color.b,
            Random.Range(0.4f, 1.0f)
        );

        GameObject gameObjectB = gameObject.transform.Find("Bottom Cloud").gameObject;
        gameObjectB.transform.position += Vector3.up * Random.Range(-1.5f, 1.5f);
        gameObjectB.transform.position += Vector3.left * Random.Range(-15, 15);
        gameObjectB.GetComponent<Renderer>().material.color = new Color(
            color.r,
            color.g,
            color.b,
            Random.Range(0.4f, 1.0f)
        );
    }

    void Update()
    {
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;

        if (transform.position.x < deadZone)
        {
            Destroy(gameObject);
        }
    }
}
