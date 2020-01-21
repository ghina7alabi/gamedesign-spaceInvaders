using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipController : MonoBehaviour {

    public int speed = 5;
    public GameObject bullet;
    
	
	void Update () {

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        GetComponent<Rigidbody2D>().velocity = new Vector2(horizontal, vertical) * speed;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bullet, transform.position, transform.rotation);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyBullet")
        {
            GameObject enemyBullet = GameObject.FindGameObjectWithTag("EnemyBullet");
            Destroy(enemyBullet);
            //Destroy(this.gameObject);

            GameObject cameraShake = GameObject.FindGameObjectWithTag("MainCamera");
            cameraShake.GetComponent<CameraShake>().enabled = true;
            cameraShake.GetComponent<CameraShake>().shakeDuration = 0.5f;

            //Application.LoadLevel("Gameover");
            
        }
    }
}
