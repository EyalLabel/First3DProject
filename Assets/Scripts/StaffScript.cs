using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaffScript : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject iciclePrefab;
    public float projectileSpeed = 10;
   // [SerializeField] Camera GetCamera;
    public GameObject playerCamera;
    public GameObject manaBar;
    public Slider manaSlider;

    public float timeBetweenShooting, reloadTime,timeBetweenShots;
    int Mana=100;
    int manaLeft, manaUsed;
    bool shooting, readyToShoot, reloading;
    bool allowInvoke = true;
    private void Awake()
    {
        manaLeft = Mana;
        readyToShoot = true;
       // manaSlider = manaBar.GetComponent<Slider>();
    }
    private void Update()
    {

        ShootInput();
        if (manaBar.GetComponent<Slider>().value != manaLeft) 
        {
            manaBar.GetComponent<Slider>().value = manaLeft;
        }


    }

   private void ShootInput() 
    {
        shooting = Input.GetKeyDown(KeyCode.Mouse0);
        if (readyToShoot&&shooting&&!reloading&&manaLeft>4)
        {
            Shoot();
            Debug.Log(manaLeft);
        }

        if (Input.GetKeyDown(KeyCode.R)&&manaLeft<Mana&&!reloading) 
        {
            Reload();
        }
        if (readyToShoot && shooting && !reloading && manaLeft < 5) Reload();
    }

    private void Shoot()
    {
        readyToShoot = false;
        
        Transform shootrotation = spawnPoint;
        //shootrotation.rotation.y = shootrotation.rotation.y - 20;
        //shootrotation.Rotate(0, -10, 0);
        //Camera camera = GetComponent<Camera>();
        Camera camera = playerCamera.GetComponent<Camera>();


        Ray ray = camera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit)) targetPoint = hit.point;
        else targetPoint = ray.GetPoint(75);
        Vector3 direction = targetPoint - spawnPoint.position;
        // GameObject icicle = Instantiate(iciclePrefab, spawnPoint.position, Quaternion.Euler(90,0,0));
       // Debug.Log("original " + iciclePrefab.transform.rotation);
        //iciclePrefab.transform.Rotate(90, 0, 0);
        GameObject icicle = Instantiate(iciclePrefab, spawnPoint.position, iciclePrefab.transform.rotation);
        // icicle.GetComponent<Rigidbody>().velocity = spawnPoint.forward * projectileSpeed;
        icicle.transform.forward = direction.normalized;

        icicle.GetComponent<Rigidbody>().AddForce(direction.normalized * projectileSpeed, ForceMode.Impulse);
        //Debug.Log(icicle.transform.rotation);
        manaUsed =manaUsed +5;
        manaLeft = manaLeft-5;

        if (allowInvoke)
        {
            Invoke("ResetShot", timeBetweenShooting);
            allowInvoke = false;
        }
    }

    private void ResetShot()
    {
        allowInvoke = true;
        readyToShoot = true;
    }

    private void Reload() 
    {
        reloading = true;
        Invoke("ReloadFinished", reloadTime);
        Debug.Log("reloading");
    }
    private void ReloadFinished() 
    {
        manaLeft = Mana;
        reloading = false;
    }

}

