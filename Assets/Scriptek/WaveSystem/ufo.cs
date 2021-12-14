using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ufo : MonoBehaviour
{
    [SerializeField] private Transform[] spawnpontok;
    [SerializeField] private ParticleSystem spawnEffect;
    [SerializeField] private Transform spawnPont;
    [SerializeField] private GameObject enemy;
    private Rigidbody2D spaceship;
    private Vector3 pos;
    private static int enemies;
    private int enemiesMax;
    private bool szunet;
    public static int waveCount = 0;

    /*
    NOTE TO SELF

    Kivitelezni: Addig spawnoljon elleségeket, amíg el nem éri a maximális számot
    Startban megadni egy random pozicíót az űrhajónak a spawnRandommal, majd
    az fixedUpdate-ben force-ot adni neki, amíg el nem ér oda
    ha ott van, akkor lespawnol egy ellenséges robotot, vár 5 mp-et, majd ezt megismétli.

    a spawnolást egy iEnumerator-ban csináld Instance-el, a spawnPont transformról a spawnEffect kíséretében.

    update-ben ha enemiesMax != max, akkor spawnoljon,
    ha enemiesMax == max, akkor "szünetre küldeni"
    addig maradjon szüneten, amíg az enemies száma el nem éri a nullát, utána 10 mp szünetben legyen elérhető a bolt, amit egy public boolal ellenőrzünk
    szünet után a enemiesMax-ot megint nullázzuk, majd egyel növeljük a max számot
    */
    private void Start() {
        spaceship = GetComponent<Rigidbody2D>();
        pos = spawnRandom();

        enemies = 0;
        enemiesMax = 0;
    }
    private void Update() {      
            //while-al próbáltam itt, de az chrasheli a unityt. Legközelebb egy rendes feltétel kell majd ide.
            StartCoroutine(spawnenemy());
            szunet = true;
        if(enemiesMax == 3)
        {
            StartCoroutine(cooldown());
        }
    }

    private IEnumerator cooldown()
    {
        if(szunet){
        Debug.Log("cd" + Time.time);
        }
        szunet = false;
        spaceship.MovePosition(new Vector2(6,6));
        yield return new WaitForSeconds(10);
        Debug.Log(Time.time);
        enemiesMax = 0;
        enemies = 0;
    }
    private IEnumerator spawnenemy()
    {
        if(Vector3.Distance(transform.position, pos) < 1){
        enemies++;
        enemiesMax++;
        Debug.Log(enemies);
        pos = spawnRandom();
        yield return new WaitForSeconds(50);
        }
        else spaceship.AddForce((pos - transform.position) * 20 * Time.deltaTime, ForceMode2D.Force);
    }
    public static void enemyDeath()
    {
        enemies--;
    }
    private Vector3 spawnRandom()
    {
        float x = Random.Range(spawnpontok[0].position.x, spawnpontok[1].position.x);

        return new Vector3(x, 5, 0);
    }
}
