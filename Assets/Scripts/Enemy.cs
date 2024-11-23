using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float speed = 5.0f;
    public Player player;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void FixedUpdate(){
        if(player == null){
            Destroy(this.gameObject);
        }
        else{
            Vector3 distanceToPlayer = (player.transform.position - transform.position).normalized;
            Vector3 movement = speed * Time.fixedDeltaTime * distanceToPlayer;
            rb.MovePosition(rb.position + movement);
        }
    }
    private void OnTriggerEnter(Collider collision){
        if(collision.CompareTag("Player"))
        {
            KillEnemy();
        }
    }

    public void KillEnemy()
    {
        Destroy(this.gameObject);
    }
}
