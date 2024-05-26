using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcicleScript : MonoBehaviour
{
    public float life = 3;
    public float damage = 20;
    EnemyHealthScript enemyHealth;

    private void Awake()
    {
        Destroy(gameObject, life);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.root.CompareTag("Enemy"))
        {
            float deliveredDamage = getModifiedDamage(collision.gameObject.tag);
            enemyHealth = collision.gameObject.GetComponentInParent<EnemyHealthScript>();
            enemyHealth.TakeDamage(deliveredDamage,collision.transform.rotation);
        }
        Debug.Log("direct hit");
        Destroy(gameObject);
    }

    private float getModifiedDamage(string tag) 
    {
        float modifiedDamage = 0;
        if (tag == "NormalPoint") modifiedDamage = damage;
        if (tag == "WeakPoint") modifiedDamage = damage*2.5f;
        if (tag == "ImmunePoint") modifiedDamage = 0;

        return modifiedDamage;
    }
}
