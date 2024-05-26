using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.Universal;
using UnityEngine.Events;

public class PlayerBodyScript : MonoBehaviour
{
    public GameObject HealthBar;
    //public Volume volume;
    //VolumeProfile volumeProfile;
    Vignette vignette;
    bool allowInvoke = true;
    float damageFlashTime = 1f;
    public UnityEvent playerDeath;
    // public Slider HealthSlider;

    int Health = 100;
    int HealthLeft;
    // Start is called before the first frame update
    void Start()
    {
        HealthLeft = Health;

        playerDeath.AddListener(GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().PlayerKilled);
        /*
        UnityEngine.Rendering.VolumeProfile volumeProfile = GetComponent<UnityEngine.Rendering.Volume>()?.profile;
        if (!volumeProfile) throw new System.NullReferenceException(nameof(UnityEngine.Rendering.VolumeProfile));
       volumeProfile = volume.GetComponent<VolumeProfile>();
       volumeProfile=GetComponent<Volume>().profile;
        volumeProfile.TryGet(out vignette);
        */

    }

    // Update is called once per frame
    void Update()
    {
        testDamage();
        if (HealthBar.GetComponent<Slider>().value != HealthLeft)
        {
            HealthBar.GetComponent<Slider>().value = HealthLeft;
        }
    }

    public void TakeDamage(int damage) 
    {
        HealthLeft = HealthLeft - damage;
        if (HealthLeft <= 0) playerDeath.Invoke();
       // vignette.intensity.Override(0.5f);
        if (allowInvoke)
        {
            Invoke("StopTakeDamage", damageFlashTime);
            allowInvoke = false;
        }
    }

    public void StopTakeDamage() 
    {
        //volume.GetComponent<Vignette>().intensity.Override(0f);
      //  vignette.intensity.Override(0f);
        allowInvoke = true;
    }
    public void testDamage() 
    {
        if (Input.GetKeyDown(KeyCode.K)) 
        {
            TakeDamage(5);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("touched something");
        if (collision.transform.CompareTag("EnemyWeapon")) 
        {
            int damageTaken = collision.gameObject.GetComponent<EnemyWeaponScript>().AttackPower;
            TakeDamage(damageTaken);
        }

        if (collision.transform.CompareTag("Fire")) 
        {
            int damageTaken = 20;
            TakeDamage(damageTaken);
        }
    }
}
