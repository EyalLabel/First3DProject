using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightControllerScript : MonoBehaviour
{
    public new Light light;

    [Tooltip("Minimum random light intensity")]
    public float minIntensity = 0.2f;
    [Tooltip("Maximum random light intensity")]
    public float maxIntensity = 2f;
    [Tooltip("How much to smooth out the randomness; lower values = sparks, higher = lantern")]
    [Range(1, 50)]
    public int smoothing = 5;

    Queue<float> smoothQueue;
    float lastSum = 0;
    // Start is called before the first frame update

    public void Reset()
    {
        //smoothQueue.Clear();
        lastSum = 0;
    }
    void Start()
    {
        light = GetComponent<Light>();

    }

    // Update is called once per frame
    void Update()
    {
        if (light == null)
            return;
        /*
        while (smoothQueue.Count >= smoothing)
        {
            lastSum -= smoothQueue.Dequeue();
        }
        
        float newVal = Random.Range(minIntensity, maxIntensity);
       // smoothQueue.Enqueue(newVal);
        lastSum = newVal;

        // Calculate new smoothed average
        light.intensity = lastSum ;
        Debug.Log(light.intensity);
        */
    }
}
