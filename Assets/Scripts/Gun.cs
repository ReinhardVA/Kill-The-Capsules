using UnityEngine;

public class Gun : MonoBehaviour
{
    public float range = 10.0f;
    public Camera fpsCam;
    public Audio_Manager audioManager;
    private string _soundName = "Shoot";
    
    void Start(){
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<Audio_Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
            PlayShootAudio();
        }
    }

    private void PlayShootAudio()
    {
        audioManager.PlaySoundAtLocation(_soundName, transform.position);
    }

    void Shoot(){

        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out RaycastHit hit, range))
        {
            if (hit.transform.CompareTag("Enemy"))
            {
                Enemy enemy = hit.transform.GetComponent<Enemy>();
                enemy?.KillEnemy();
            }
        }
    }
}
