using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float speed = 10;

    GameObject scoreboard;
    int score = 0;


	void Start () {

        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 1) * speed;
        scoreboard = GameObject.Find("ScoreBoard");
    }

    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemyship")
        {
            scoreboard.GetComponent<Score>().score += 1;
        }
    }
}
