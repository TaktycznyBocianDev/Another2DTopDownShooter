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

    public GameObject healthBarObj;
    private HealthBarScript healthBar;
    public ParticleSystem diedEfect;
    public SpriteRenderer objectSpriteRenderer;
    public Collider2D objectCollider;

    private void Awake()
    {
        diedEfect.Stop();
        currentHpAmount = hpAmount;
        healthBar = healthBarObj.GetComponent<HealthBarScript>();
        healthBar.SetMAXHealth(hpAmount);
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
            healthBar.SetHealt(currentHpAmount);

            Debug.Log(gameObject.name + "hp: " + currentHpAmount.ToString());

            ImDead(currentHpAmount);
        }
    }

    private void ImDead(float hp)
    {
        if (hp <= 0)
        {
            diedSound.Play();
            Destroy(healthBarObj);
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

}
