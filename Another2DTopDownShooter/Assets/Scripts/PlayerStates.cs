using UnityEngine;

public class PlayerStates : MonoBehaviour
{

    public float PlayerHealth;
    private float currentHealth;

    private ShootingScript shooting;
    public float ammoBonus;

    public GameObject healthBarObj;
    public GameObject ammoBarObj;
    private HealthBarScript healthBar, ammoBar;

    public Sprite normalSprite;
    public Sprite worldEaterSprite;

    private TypicalPlayerState typicalPlayer;
    private WorldEaterState worldEater;
    private bool isEatingWorlds;


    private void Awake()
    {
        healthBar = healthBarObj.GetComponent<HealthBarScript>();
        healthBar.SetMAXHealth(PlayerHealth);
        currentHealth = PlayerHealth;

        ammoBar = ammoBarObj.GetComponent<HealthBarScript>();
        shooting = GetComponent<ShootingScript>();

        ammoBar.SetMAXHealth(shooting.ammoMax);

        typicalPlayer = new TypicalPlayerState(gameObject, normalSprite);
        worldEater = new WorldEaterState(gameObject, worldEaterSprite);
        isEatingWorlds = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            worldEater.SetEaterState();
            isEatingWorlds = true;
        }

        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            typicalPlayer.SetNormalState();
            isEatingWorlds = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Enemy"))
        {

            if (!isEatingWorlds)
            {
                currentHealth--;
                healthBar.SetHealt(currentHealth);
            }
            if (isEatingWorlds)
            {
                shooting.AddToCurrentAmmo(ammoBonus);
                ammoBar.AddHealth(ammoBonus);
            }

        }
    }

}



public class TypicalPlayerState
{
    public GameObject Player;

    public Sprite playerSprite;

    public TypicalPlayerState(GameObject player, Sprite playerSprite)
    {
        Player = player;
        this.playerSprite = playerSprite;

    }

    public void SetNormalState()
    {
        Player.GetComponent<SpriteRenderer>().sprite = playerSprite;
        Player.GetComponent<ShootingScript>().enabled = true;
    }
}

public class WorldEaterState
{
    public GameObject Player;

    public Sprite playerSprite;

    public WorldEaterState(GameObject player, Sprite playerSprite)
    {
        Player = player;
        this.playerSprite = playerSprite;
    }

    public void SetEaterState()
    {
        Player.GetComponent<SpriteRenderer>().sprite = playerSprite;
        Player.GetComponent<ShootingScript>().enabled = false;

    }
}


