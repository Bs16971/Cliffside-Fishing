using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandRipple : MonoBehaviour
{
    public Material sandMaterial;
    public float speed = 0.1f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float offset = Time.time * speed;
        sandMaterial.mainTextureOffset = new Vector2(offset, offset);
    }
}
