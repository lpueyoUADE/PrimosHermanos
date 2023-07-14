using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class desertBackgroundMovement : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = new Vector3(player.transform.position.x, 0, player.transform.position.z);
        transform.position = pos;
    }
}
