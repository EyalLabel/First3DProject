using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTrapScript : MonoBehaviour
{
    public GameObject FirePrefab;
    public Transform spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player")) 
        {
            detonate();
        }
    }

    void detonate()
    {
        GameObject fireBall = Instantiate(FirePrefab, spawnPoint.position, FirePrefab.transform.rotation);
        Destroy(gameObject);
    }
}
