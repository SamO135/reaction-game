using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    private Vector3 target;
    public float cameraElasticity;

    public Transform bg1;
    public Transform bg2;
    private float size;
    // Start is called before the first frame update
    void Start()
    {
        offset.z = player.position.z - 1;
        size = bg1.GetComponent<BoxCollider2D>().size.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //camera
       target = new Vector3 (player.position.x, player.position.y, player.position.z) + offset;
       transform.position = Vector3.Lerp(transform.position, target, cameraElasticity);
    
        //background
        if (transform.position.y >= bg2.position.y)
        {
            bg1.position = new Vector3(bg1.position.x, bg2.position.y + size, bg1.position.z);
            SwitchBackground();
        }

        if (transform.position.y < bg1.position.y)
        {
            bg2.position = new Vector3(bg2.position.x, bg1.position.y - size, bg1.position.z);
            SwitchBackground();
        }
    }

    void SwitchBackground()
    {
        Transform temp = bg1;
        bg1 = bg2;
        bg2 = temp;
    }
}
