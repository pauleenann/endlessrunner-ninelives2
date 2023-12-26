using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public Transform[] backgrounds; //holds bgs
    private float[] parallaxScales; //amount of movements for eachlayer
    public float smoothing;

    private Vector3 previousCameraPosition;


    // Start is called before the first frame update
    void Start()
    {
        previousCameraPosition = transform.position;
        parallaxScales = new float[backgrounds.Length];
        for(int i = 0; i < parallaxScales.Length; i++)
        {
            parallaxScales[i] = backgrounds[i].position.z * -1;
        }
    }
    //happens after the update
    void LateUpdate()
    {
     

       for(int i = 0; i < backgrounds.Length; i++)
        {
            Vector3 parallax = (previousCameraPosition - transform.position) * (parallaxScales[i] / smoothing);
            backgrounds[i].position = new Vector3(backgrounds[i].position.x + parallax.x, backgrounds[i].position.y + parallax.y, backgrounds[i].position.z);
        }

        previousCameraPosition = transform.position;

        
    }
}
