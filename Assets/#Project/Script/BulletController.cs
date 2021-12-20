using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BulletController : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletDecal;
    public PlayerManager playerManager;
    public AudioSource audioSource;
    public WorldAttitude worldAttitude;
    
    private float speed =50f;
    private float TimeToDestroy = 0.5f;
    public Vector3 target {get;set;}
    public bool hit {get;set;}
    private Animator A;
    public float timeToSplat=2;
    public UnityEvent whenHitGrizzy;
   

    public GameObject splatBlood;
    public LayerMask layerShoot;
    private GameObject mySplatty;
    private GameObject mySplat;

    public DecalBehaviour decal;
    
    void start (){
        A = GetComponent <Animator> ();
        A.enabled = false;
        playerManager = GameObject.FindGameObjectWithTag("PlayerManager").GetComponent<PlayerManager>();
        worldAttitude = GameObject.FindGameObjectWithTag("Ambient").GetComponent<WorldAttitude>();
        
    }
    private void OnEnable()
    {
        Destroy(gameObject, TimeToDestroy);
    }
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime );
        if (!hit && Vector3.Distance(transform.position, target) <.01f)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision other)
        {
            ContactPoint contact = other.GetContact(0);

            if (other.gameObject.tag == "Grizzy")
            {
                //Debug.Log("shoooot grizzy");
                StartCoroutine(splatting());
                other.gameObject.GetComponent<GrizzyHealth>().TakeDamage(50f);
                GameObject myBullet = GameObject.Instantiate(splatBlood, contact.point + contact.normal *0.0001f,Quaternion.LookRotation(other.transform.up));
                Destroy(myBullet,0.5f);
            }
            else if( other.gameObject.tag == "Tile")
            {
                //audioSource.Play();
            }
            // else if(other.gameObject.tag == "Ambient")
            // {

            // }
            
            else if (other.gameObject.tag == "HealthSphere")
            {
                playerManager.health +=20;
                
            }
            //print(other.gameObject.name);
            //if (other.gameObject.CompareTag("Player"))
            if(layerShoot == (layerShoot | (1 << other.gameObject.layer)))
            {
                if (other.gameObject.tag == "Tile")
                {
                    Debug.Log("Parent il tile? ");
                    mySplatty = GameObject.Instantiate(bulletDecal, contact.point + contact.normal *0.0001f,Quaternion.LookRotation(other.transform.up));
                    mySplatty.transform.parent = other.transform;
                    //Destroy(gameObject);
                    
                    //gameObject.SetActive(false);
                    decal = mySplatty.GetComponent<DecalBehaviour>();
                    decal.ScaleOverTime();
                    //StartCoroutine("ScaleCoroutine");5.0f, mySplatty
                    //ScaleOverTime();
                }
                else{
                    mySplat = GameObject.Instantiate(bulletDecal, contact.point + contact.normal *0.0001f,Quaternion.LookRotation(contact.normal));
                    worldAttitude.BulletAmbientSound();
                    Destroy(gameObject);
                    //StartCoroutine(ScaleOverTime(1));
                }
            }
        }
    
    public IEnumerator splatting()
    {
        yield return new WaitForSeconds(timeToSplat);
        whenHitGrizzy?.Invoke();
    }
    
}



