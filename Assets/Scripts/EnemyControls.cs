using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControls : MonoBehaviour
{
    private int enemySpeed = 2;
    [SerializeField]
    private GameObject Enemy_ExplosionPrefab;

    //[SerializeField]
    //private AudioClip explosionSound;

    void Start()
    {
        
    }


    void Update()
    {
        transform.Translate(Vector3.down * enemySpeed * Time.deltaTime);

        if (transform.position.y < -6.0f)
        {
            transform.position = new Vector3(Random.Range(-7.5f, 7.5f), 6.0f, 0);
        }
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Laser")
        {
            Destroy(collision.gameObject);
            Instantiate(Enemy_ExplosionPrefab, transform.position, Quaternion.identity);
           //AudioSource.PlayClipAtPoint (explosionSound, Camera.main, transform.position, 1.0f);
            Destroy(this.gameObject);
        }
        else if (collision.tag == "Player")
        {
            PlayerControls playerControls = collision.GetComponent<PlayerControls>();
            
            if (playerControls != null)
            {
                playerControls.LifeSubstraction();
            }
            Instantiate(Enemy_ExplosionPrefab, transform.position, Quaternion.identity);
            //AudioSource.PlayClipAtPoint (explosionSound, Camera.main, transform.position, 1.0f);
            Destroy(this.gameObject);
        }
    }

}
