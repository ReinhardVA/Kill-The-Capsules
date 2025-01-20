using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float speed = 5.0f;
    public Player player;
    public Audio_Manager audioManager;
    private string _enemyDeathSound = "Death";
    private Rigidbody rb;
    private UI_Manager _uiManager;
    private int _pointValue = 10;

    [SerializeField] Animator _enemyAnimator;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<Audio_Manager>();
        _uiManager = GameObject.Find("UI Manager").GetComponent<UI_Manager>();
    }

    // Update is called once per frame
    void FixedUpdate(){
        if(player == null){
            Destroy(this.gameObject);
        }
        else{
            Vector3 distanceToPlayer = (player.transform.position - transform.position).normalized;
            Vector3 movement = speed * Time.fixedDeltaTime * distanceToPlayer;
            Vector3 targetPosition = new(player.transform.position.x, transform.position.y, player.transform.position.z);
            transform.LookAt(targetPosition);
            rb.MovePosition(rb.position + movement);
            _enemyAnimator.SetBool("IsRunning", true);
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
        if(_uiManager != null){
            _uiManager.IncreaseScore(_pointValue);
        }
        audioManager.PlaySoundAtLocation(_enemyDeathSound, transform.position);
        _enemyAnimator.SetBool("IsDeath", true);
        speed = 0.0f;
        Destroy(this.gameObject, 2.0f);
    }
}
