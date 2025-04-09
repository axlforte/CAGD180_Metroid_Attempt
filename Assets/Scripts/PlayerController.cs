using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10;
    public float jumpForce = 5;

    public float health;
    public float maxHealth;
    public bool iAmInvincible;

    public bool facingLeft;

    public bool canBall;

    public GameObject blastPrefab;
    public float timeBetweenFires;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        Fire();
    }

    void FixedUpdate()
    {
        Move();
    }

    /// <summary>
    /// Check for input to move the player left or right
    /// </summary>
    private void Move()
    {
        //Check if D key is held
        if (Input.GetKey(KeyCode.D))
        {
            GetComponent<Rigidbody>().MovePosition(transform.position + (Vector3.right * speed * Time.deltaTime));
            //transform.position += Vector3.right * speed * Time.deltaTime;
            //make facingLeft true
            facingLeft = false;
        }

        //Check if A key is held
        if (Input.GetKey(KeyCode.A))
        {
            GetComponent<Rigidbody>().MovePosition(transform.position + (Vector3.left * speed * Time.deltaTime));
            //transform.position += Vector3.left * speed * Time.deltaTime;
            //make facingleft false
            facingLeft = true;
        }
    }

    /// <summary>
    /// if player presses W and is on ground, player jumps
    /// </summary>
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.W) && OnGround())
        {
            print("Player Jumped");
            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void Slide()
    {
        if(Input.GetKeyDown(KeyCode.S) && canBall == true)
        {

        }
    }

    /// <summary>
    /// checks if player is on ground
    /// </summary>
    /// <returns></returns>
    private bool OnGround()
    {
        bool onGround = false;

        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1.2f))
        {
            print("Touching Ground");
            onGround = true;
        }

        return onGround;
    }

    private void Fire()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(ShootBaseBullet());
        }
    }
    

    /// <summary>
    /// Fires a projectile then waits one third of a second so that you can onlt fire two shots per second (I might not have mathed that right)
    /// </summary>
    /// <returns></returns>
    IEnumerator ShootBaseBullet()
    {
        GameObject projectile = Instantiate(blastPrefab, transform.position, blastPrefab.transform.rotation);
        if (projectile.GetComponent<BlastProjectileScript>())
        {
            projectile.GetComponent<BlastProjectileScript>().facingLeft = facingLeft;
        }
        yield return new WaitForSeconds(timeBetweenFires);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<enemy>() && iAmInvincible == false)
        {
            health -= 15;
            StartCoroutine(BasicHit());
        }

        if (other.GetComponent<JumpPowerUp>())
        {
            jumpForce = jumpForce * 2;
            Destroy(other.gameObject);
        }

        if (other.GetComponent<HealthPickUp>())
        {
            health = Mathf.Clamp(health + other.GetComponent<HealthPickUp>().healthGiven, 0, maxHealth);
            Destroy(other.gameObject);
        }

        if (other.GetComponent<MaxHealthBooster>())
        {
            maxHealth = maxHealth + other.GetComponent<MaxHealthBooster>().maxHealthGiven;
            health = Mathf.Clamp(maxHealth, 0, maxHealth);
            Destroy(other.gameObject);
        }
    }

    IEnumerator BasicHit()
    {
        iAmInvincible = true;
        yield return new WaitForSeconds(5);
        iAmInvincible = false;
    }

    IEnumerator Sliding()
    {
        RaycastHit hit;

        speed = 12;
        transform.localScale = new Vector3(1, 0.5f, 1);
        yield return new WaitForSeconds(1);

    }
}
