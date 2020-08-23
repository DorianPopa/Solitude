using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public float parallaxEffect;
    public GameObject cam;
    
    private float length, startpos;

    // Start is called before the first frame update
    void Start()
    {
        startpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }
    
    void FixedUpdate()
    {
        float dist = cam.transform.position.x * parallaxEffect;
        
        Vector3 position = transform.position;
        Vector3 newPosition = new Vector3(startpos + dist, position.y, position.z);
        transform.SetPositionAndRotation(newPosition, Quaternion.identity);

        float temp = cam.transform.position.x * (1 - parallaxEffect);
        if (temp > startpos + length) 
            startpos += length;
        else if (temp < startpos - length) 
            startpos -= length;
    }
}
