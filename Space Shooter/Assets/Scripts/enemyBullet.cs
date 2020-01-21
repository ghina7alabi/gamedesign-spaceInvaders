using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBullet : MonoBehaviour
{

    public float speed = -10;



    void Start()
    {

        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 1) * speed;

    }

    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
