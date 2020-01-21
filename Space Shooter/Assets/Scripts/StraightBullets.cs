using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightBullets : MonoBehaviour
{

    public float speed = 5;
    public GameObject enemyBullet;


    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 1) * speed;
        GetComponent<Rigidbody2D>().angularVelocity = Random.Range(-200, 200);

    }

    void Update()
    {
        Instantiate(enemyBullet, transform.position, transform.rotation);
        Color newColor = new Color(Random.value, Random.value, Random.value, 1.0f);
        GetComponent<SpriteRenderer>().color = newColor;

    }

    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            GameObject bullet = GameObject.FindGameObjectWithTag("Bullet");
            Destroy(bullet);
            Destroy(this.gameObject);

            GameObject cameraShake = GameObject.FindGameObjectWithTag("MainCamera");
            cameraShake.GetComponent<CameraShake>().enabled = true;
            cameraShake.GetComponent<CameraShake>().shakeDuration = 0.32f;

        }

        if (collision.gameObject.tag == "Spaceship")
        {
            GameObject spaceship = GameObject.FindGameObjectWithTag("Spaceship");
            Destroy(spaceship);
            Destroy(this.gameObject);


            Application.LoadLevel("Gameover");

        }
    }
}
