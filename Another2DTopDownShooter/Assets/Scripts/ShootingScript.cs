using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    //From where, how strong and what we will shoot?
    public Transform firePoint;
    public GameObject bulletPref;
    public float bulletForce = 20f;

    //Ammo indicator
    public GameObject ammoBarObj;
    private HealthBarScript ammoBar;

    //Bullet amount
    public float ammoMax;
    private float ammoCurrent;

    public void AddToCurrentAmmo(float ammo)
    {
        if ((ammoCurrent += ammo) > ammoMax)
        {
            ammoCurrent = ammoMax;
        }
        else
        {
            ammoCurrent += ammo;
        }
    }

    private void Awake()
    {
        ammoCurrent = ammoMax;
        ammoBar = ammoBarObj.GetComponent<HealthBarScript>();
        ammoBar.SetMAXHealth(ammoMax);
    }

    void Update()
    {
        // If the player presses the left mouse button
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            // If the player has at least one bullet
            if (ammoCurrent > 0)
            {
                
                Shoot(); // Fire a bullet
                
                ammoCurrent--; // Decrement the current ammo value
                
                ammoBar.SetHealt(ammoCurrent); // Update the ammo indicator UI element
                
                if (ammoCurrent < 0) ammoCurrent = 0; // If the current ammo value is less than zero, set it to zero
                
                Debug.Log(gameObject.name + "ammo: " + ammoCurrent); // Debug log the current ammo value
            }
            else
            {
                // TODO: Play an empty clip sound effect
            }
        }
    }

    private void Shoot()
    {

        GameObject bullet = Instantiate(bulletPref, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }

}
