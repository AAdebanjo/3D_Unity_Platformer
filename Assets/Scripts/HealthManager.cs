using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;

    public Mover player;

    public float invincibilityLength;
    private float invincibilityCounter;

    public Renderer playerRenderer;
    private float flashCounter;
    public float flashLength = 0.1f;

    private bool isRespawning;
    private Vector3 respawnPoint;
    public float respawnLength;

    public Text healthText;

    private GameObject gameObj;

    [SerializeField] AudioSource hitSound;
    [SerializeField] AudioSource deathSound;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        //player = FindObjectOfType<Mover>();

        healthText.text = "Health: " + currentHealth + "/" + maxHealth;

        respawnPoint = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(invincibilityCounter > 0)
        {
            invincibilityCounter -= Time.deltaTime;

            flashCounter -= Time.deltaTime;
            if(flashCounter <= 0 )
            {
                playerRenderer.enabled = !playerRenderer.enabled;
                flashCounter = flashLength;
            }

            if(invincibilityCounter <= 0)
            {
                playerRenderer.enabled = true;
            }
        }
    }

    public int getCurrentHealth()
    {
        return currentHealth;
    }

    public void HurtPlayer(int damage, Vector3 direction)
    {

        if (invincibilityCounter <= 0)
        {

            currentHealth -= damage;
            

            healthText.text = "Health: " + currentHealth + "/" + maxHealth;

            if (currentHealth <= 0)
            {
                deathSound.Play();
                Respawn();
            }
            else
            {

                hitSound.Play();

                player.Knockback(direction);

                invincibilityCounter = invincibilityLength;

                playerRenderer.enabled = false;

                flashCounter = flashLength;
            }
        }
    }

    public void Respawn()
    {


        if (!isRespawning)
        {

            StartCoroutine("RespawnCo");
        }
    }

    public IEnumerator RespawnCo()
    {
        isRespawning = true;

        player.gameObject.SetActive(false);
        yield return new WaitForSeconds(respawnLength);
        isRespawning = false;

        player.gameObject.SetActive(true);

        player.transform.position = respawnPoint;
        currentHealth = maxHealth;

        GameObject playerTemp = GameObject.Find("Player");
        CharacterController charController = playerTemp.GetComponent<CharacterController>();
        charController.enabled = false;
        player.transform.position = respawnPoint;
        currentHealth = maxHealth;
        charController.enabled = true;

        healthText.text = "Health: " + currentHealth + "/" + maxHealth;

        invincibilityCounter = invincibilityLength;

        playerRenderer.enabled = false;

        flashCounter = flashLength;
    }

    public void HealPlayer(int damage)
    {
        currentHealth += damage;

        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    public void SetSpawnPoint(Vector3 newPosition)
    {
        respawnPoint = newPosition;
    }
}
