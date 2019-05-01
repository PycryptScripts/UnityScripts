using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ParallaxLayer Script by Pycrypt

public class ParallaxLayer : MonoBehaviour
{
    public float parallaxFactor;
    public void Move(float delta)
    {
        Vector3 newPos = transform.localPosition;
        newPos.x -= delta * parallaxFactor;
        transform.localPosition = newPos;
    }
}
