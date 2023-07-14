using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSizeOnPlayerDistance : MonoBehaviour
{
    public GameObject playerRef;

    [Header("configs")]
    public float minDistance = 200;
    public float scaleModifier = 5;
    public float maxScale = 1;

    [Header("remove stuff")]
    public float removeDistance = 30;
    public GameObject[] removeThis;

    private void Start()
    {
        this.transform.localScale = new Vector3(maxScale, maxScale);
        maxScale = minDistance / scaleModifier;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = (this.transform.position - playerRef.transform.position).magnitude;
        float newScale = (distance / scaleModifier);
        Vector3 scale = new Vector3(newScale, newScale);

        if (distance < minDistance)
        {
            if (scale.magnitude <= new Vector3(maxScale, maxScale).magnitude)
                this.transform.localScale = scale;
        }
        else
            this.transform.localScale = new Vector3(maxScale, maxScale);

        if (distance <= removeDistance && removeThis.Length != 0)
        {
            for (int i = 0; i < removeThis.Length; i++)
            {
                removeThis[i].gameObject.SetActive(false);
            }
        }
    }
}
