using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour {

    public float speed = -5;
    

	void Start () {

        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 1) * speed;
        GetComponent<Rigidbody2D>().angularVelocity = Random.Range(-200, 200);

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

        }

        if (collision.gameObject.tag == "Spaceship")
        {
            GameObject spaceship = GameObject.FindGameObjectWithTag("Spaceship");
            spaceship.GetComponent<SpriteRenderer>().enabled = false;
            Invoke("DisableAndEnable", 0.25f);

            GameObject cameraShake = GameObject.FindGameObjectWithTag("MainCamera");
            cameraShake.GetComponent<CameraShake>().enabled = true;
            cameraShake.GetComponent<CameraShake>().shakeDuration = 0.2f;

        }
    }

    void DisableAndEnable()
    {
        GameObject spaceship = GameObject.FindGameObjectWithTag("Spaceship");
        spaceship.GetComponent<SpriteRenderer>().enabled = true;
    }
}
