using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ufo : MonoBehaviour
{
    public static ufo Instance;

    [SerializeField] private Transform[] spawnpontok;
    [SerializeField] private ParticleSystem spawnEffect;
    [SerializeField] private Transform spawnPont;
    [SerializeField] private GameObject enemy;
    private Rigidbody2D spaceship;
    private Vector3 pos;
    [SerializeField] private int enemies;
    private int max;
    private int enemiesMax;
    private bool szunet;
    private bool spawn;
    public static bool wave;
    public static int waveCount;


    private void Awake() {
        Instance = this;
    }
    private void Start() {
        spaceship = GetComponent<Rigidbody2D>();
        pos = spawnRandom();
        spawn = true;
        szunet = true;
        enemies = 0;
        max = 3;
        waveCount = 0;
        enemiesMax = max;        
    }
    private void Update() {      
        spaceship.velocity = ((pos - transform.position));

        if(enemiesMax == max)
        {
            StartCoroutine(cooldown());
        }
        else
        {           
            StartCoroutine(spawnenemy());           
        }
    }
    private IEnumerator cooldown()
    {
        if(enemies == 0)
        {
        wave = true;
        if(szunet){
        CDUI.timeSet();
        waveCount++;
        max++;
        }
        szunet = false;      
        spawn = false;
        yield return new WaitForSeconds(11); 
        enemiesMax = 0;
        spawn = true;
        }
        else if (enemies >= 1)
        {
            szunet = true;
            pos = (new Vector2(6,6));
        }
    }
    private IEnumerator spawnenemy()
    {       
        if(Vector3.Distance(transform.position, pos) < 1 && spawn){
        spawn = false;
        Instantiate(enemy, spawnPont.position, Quaternion.identity);
        Instantiate(spawnEffect, spawnPont.position, Quaternion.identity);
        enemies++;
        enemiesMax++;      
        yield return new WaitForSeconds(1);
        wave = false;
        pos = spawnRandom();
        spawn = true;
        }
    }
    public void enemyDeath()
    {
        enemies--;
    }
    private Vector3 spawnRandom()
    {
        float x = Random.Range(spawnpontok[0].position.x, spawnpontok[1].position.x);

        return new Vector3(x, 5, 0);
    }
}
