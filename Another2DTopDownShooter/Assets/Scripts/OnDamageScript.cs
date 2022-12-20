using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDamageScript : MonoBehaviour
{
    [Header("How much health points our object has?")]
    public float hpAmount;
    private float currentHpAmount;

    [Header("What will couse our object to take damage?")]
    public string enemyTag;

    [Header("Audio sorces for death and hit")]
    public AudioSource damageSound;
    public AudioSource diedSound;

    [Header("Sprites for difrent live times")]
    public SpritesChangeOverDamage objectSprites;

    public ParticleSystem diedEfect;
    public SpriteRenderer objectSpriteRenderer;
    public Collider2D objectCollider;

    private void Awake()
    {
        diedEfect.Stop();
        currentHpAmount = hpAmount;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        TheyHitMe(collision);
    }


    private void TheyHitMe(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(enemyTag))
        {
            damageSound.Play();
            currentHpAmount--;
            SpritesChange();

            Debug.Log(gameObject.name + "hp: " + currentHpAmount.ToString());

            ImDead(currentHpAmount);
        }
    }

    private void ImDead(float hp)
    {
        if (hp <= 0)
        {
            diedSound.Play();
            Destroy(objectSpriteRenderer);
            Destroy(objectCollider);

            if (diedEfect.isPlaying)
            {
                diedEfect.Stop();
                diedEfect.Play();
            }
            else diedEfect.Play();


            Destroy(gameObject, 0.5f);

        }
    }

    private void SpritesChange()
    {
        if (objectSprites != null)
        { 
            Sprite[] sprites = objectSprites.sprites;
            float hpChange = hpAmount / sprites.Length;

            for (int i = 0; i < sprites.Length; i++)
            {

                if (currentHpAmount <= currentHpAmount - hpChange * i && currentHpAmount >= currentHpAmount - hpChange * (i+1))
                {
                    objectSpriteRenderer.sprite = sprites[i];
                }

            }
        }
        

    }


}
