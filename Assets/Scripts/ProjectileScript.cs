using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject iciclePrefab;
    public float projectileSpeed=10;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            var icicle = Instantiate(iciclePrefab, spawnPoint.position, spawnPoint.rotation);
            icicle.GetComponent<Rigidbody>().velocity = spawnPoint.forward * projectileSpeed;

        }
    }
}
