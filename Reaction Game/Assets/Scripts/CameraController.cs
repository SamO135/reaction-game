using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset.z = player.position.z - 1;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3 (player.position.x + offset.x, player.position.y + offset.y, player.position.z + offset.z);
    }
}
