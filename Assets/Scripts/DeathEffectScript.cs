using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathEffectScript : MonoBehaviour
{
    public float life = 2;
    // Start is called before the first frame update
    private void Awake()
    {
        Destroy(gameObject, life);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
