using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public Transform player;
    Transform camera;
    Vector3 initialDistance;
    // Start is called before the first frame update
    void Start()
    {
        camera = this.gameObject.GetComponent<Transform>();
        initialDistance = player.position - camera.position;   
    }

    // Update is called once per frame
    void Update()
    {
        camera.position = player.position - initialDistance;  
    }
}
