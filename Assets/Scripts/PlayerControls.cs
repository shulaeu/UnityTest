using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControls : MonoBehaviour
{
    public GameObject laserPrefab;
    private float fireRate = 0.3f;
    private float nextFire;

    [SerializeField]
    private int playerLives = 5;
    [SerializeField]
    private int speed = 6;
    [SerializeField]
    private GameObject Player_ExplosionPrefab;

    [SerializeField]
    private AudioSource laserShot;

    void Start()
    {
        transform.position = new Vector3(0, -3.5f, 0);

        laserShot = GetComponent<AudioSource>();
    }

    void Update()
    {
        SpaceMovement();

        if (Input.GetMouseButton(0))
        {
            if (Time.time > nextFire)
            {
                laserShot.Play();
                Instantiate(laserPrefab, transform.position + new Vector3(0, 2.1f, 0), Quaternion.identity);
                nextFire = Time.time + fireRate;
            }

        }
    }

    public void LifeSubstraction()
    {
        playerLives--;

         if (playerLives < 1)
        {
            Instantiate(Player_ExplosionPrefab, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            SceneManager.LoadScene("GameOver");
        }
}

    private void SpaceMovement()
    {
        float horizonInput = Input.GetAxis("Horizontal");
        float vertInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizonInput);
        transform.Translate(Vector3.up * Time.deltaTime * speed * vertInput);

        if (transform.position.y > 4.0f)
        {
            transform.position = new Vector3(transform.position.x, 4.0f, 0);
        }
        else if (transform.position.y < -4.1f)
        {
            transform.position = new Vector3(transform.position.x, -4.1f, 0);
        }

        if (transform.position.x > 8.5f)
        {
            transform.position = new Vector3(-8.5f, transform.position.y, 0);
        }
        else if (transform.position.x < -8.5f)
        {
            transform.position = new Vector3(8.5f, transform.position.y, 0);
        }
    }
}
