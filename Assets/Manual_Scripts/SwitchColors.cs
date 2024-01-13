using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class SwitchColors : MonoBehaviour
{
    Material _material;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Transparent()
    {
        // Get the Renderer component of the object

        _material = GetComponent<Renderer>().material;

        // Set the surface type to transparent
        _material.SetFloat("_Surface", 1f);

        _material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);

        _material.SetInt("_ZWrite", 1);

        // Set the render queue type to transparent
        _material.SetFloat("_RenderQueueType", 4);
    }   
}
