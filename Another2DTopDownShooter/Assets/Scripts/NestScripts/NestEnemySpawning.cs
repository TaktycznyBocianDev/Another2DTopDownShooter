using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NestEnemySpawning : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float pushForce;
    public float spawnDelay;

    public Transform posOne, posTwo, posThree;

    public ParticleSystem left, right, lower;

    private void Awake()
    {
        StartCoroutine(Spawning());
        left.Stop();
        right.Stop();
        lower.Stop();
    }


    IEnumerator Spawning()
    {
        while (true)
        {
            //Some effect
            forceEffect(left);
            forceEffect(right);
            forceEffect(lower);

            //Instantiate new anemies
            GameObject firstEnemy = Instantiate(enemyPrefab, posOne.position, Quaternion.Euler(0,0,90));
            GameObject secondEnemy = Instantiate(enemyPrefab, posTwo.position, Quaternion.Euler(0,0,-90));
            GameObject thirdEnemy = Instantiate(enemyPrefab, posThree.position, Quaternion.Euler(0,0,180));

            //Little push :)
            firstEnemy.GetComponent<Rigidbody2D>().AddForce(Vector2.left * pushForce, ForceMode2D.Impulse);
            secondEnemy.GetComponent<Rigidbody2D>().AddForce(Vector2.right * pushForce, ForceMode2D.Impulse);
            thirdEnemy.GetComponent<Rigidbody2D>().AddForce(Vector2.down * pushForce, ForceMode2D.Impulse);

            

            yield return new WaitForSeconds(spawnDelay);

        }
    }

    private void forceEffect(ParticleSystem system)
    {
        if (system.isPlaying)
        {
            system.Stop();
            system.Play();
        }
        else system.Play();
    }

}
