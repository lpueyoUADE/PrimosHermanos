using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesertSpriteWalk : MonoBehaviour
{
    public GameObject[] movementPoints;
    public float speed = 10;
    public float moveEvery = 1;
    private float currentTime = 0;

    public int currentSelection = 0;
    public Vector3 currentObjetive;

    public GameObject scaleObjetive;
    public float scaleDivisor = 1;


    private void Start()
    {
        currentObjetive = movementPoints[0].transform.position;
    }

    void FixedUpdate()
    {
        float t = Time.deltaTime;
        currentTime += t;

        if (currentTime >= moveEvery)
        {
            currentSelection = Random.Range(0, movementPoints.Length);
            currentTime = 0;
        }

        this.transform.position = Vector3.MoveTowards(this.transform.position, movementPoints[currentSelection].transform.position, speed);

        if (scaleObjetive != null)
            this.transform.localScale = scaleObjetive.transform.localScale / scaleDivisor;
    }
}
