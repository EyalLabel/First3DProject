using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class EnemyHealthScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float health = 100;
    [SerializeField] EventManager eventManager;
    public UnityEvent onTakeDamage;
    public UnityEvent onEnemyDeath;
    public GameObject damagePopup1;
    public GameObject damagePopup2;
    public GameObject damagePopup3;
    public Transform spawnPoint;
    public GameObject DeathEffectPrefab;
    public UnityEvent enemyDeath;
    public UnityEvent enemySpawn;
    private bool isDying = false;
    GameController gameController;

    private void Awake()
    {
       //GameManager.OnGameStateChanged += GameManagerOnGameStateChanged;
       // bool alive = true;
        //GameManager.UpdateEnemiesAlive(alive);

    }
    private void Start()
    {
        enemyDeath.AddListener(GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().EnemyKilled);
        enemySpawn.AddListener(GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().EnemySpawned);
        enemySpawn.Invoke();
        // gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }
    private void OnDestroy()
    {
        GameManager.OnGameStateChanged -= GameManagerOnGameStateChanged;
    }
    private void GameManagerOnGameStateChanged(GameManager.GameState obj)
    {
        throw new System.NotImplementedException();
    }

    public void TakeDamage(float damage, Quaternion rotation) 
    {
        health = health - damage;
        Debug.Log("health is"+health);
        PopUP(damage, rotation);
       // onTakeDamage.Invoke(damage);
        if (health < 1) 
        {
            if (!isDying) Die();
           //onEnemyDeath.Invoke();
        }
    }

    public void PopUP(float damage,Quaternion rotation) 
    {
        int popUp = Random.Range(1, 3);
       
        switch (popUp) 
        {
            case 1: 
                damagePopup1.GetComponent<TextMesh>().text = damage.ToString();
                //damagePopup1.transform.rotation.=rotation.x;
                break;
            case 2: 
                damagePopup2.GetComponent<TextMesh>().text = damage.ToString();
               // damagePopup2.transform.rotation = rotation;
                break;
            case 3: 
                damagePopup3.GetComponent<TextMesh>().text = damage.ToString();
               // damagePopup3.transform.rotation = rotation;
                break;
        }

        StartCoroutine("clearDamagePop");
       
    }

    private void Update()
    {
      //  clearDamagePop();   
    }

    private IEnumerator clearDamagePop()
    {
        yield return new WaitForSeconds(0.5f);
        if (damagePopup1.GetComponent<TextMesh>().text!="") damagePopup1.GetComponent<TextMesh>().text = "";
        if (damagePopup2.GetComponent<TextMesh>().text != "") damagePopup2.GetComponent<TextMesh>().text = "";
        if (damagePopup3.GetComponent<TextMesh>().text != "") damagePopup3.GetComponent<TextMesh>().text = "";
    }

    void Die()
    {
        isDying = true;
        enemyDeath.Invoke();
        GameObject DeathEffect = Instantiate(DeathEffectPrefab, spawnPoint.position, DeathEffectPrefab.transform.rotation);
        Destroy(gameObject,2);
    }
}
