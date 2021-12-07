using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class MegaBulletController : MonoBehaviour
{
    [SerializeField]
    private GameObject megaBulletDecal;
    private float speed =50f;
    private float TimeToDestroy = 1f; //0.5
    public Vector3 target {get;set;}
    public bool megaHit {get;set;}
    //private Animator A;
    public float timeToSplat=2;
    public UnityEvent whenHitGrizzy;

    public GameObject splatBlood;
    public LayerMask layerShoot;
    private GameObject myMegaSplatty;
    private GameObject myMegaSplat;

    public DecalBehaviour decal;
    
    void start (){
        // A = GetComponent <Animator> ();
        // A.enabled = false;

    }
    private void OnEnable()
    {
        Destroy(gameObject, TimeToDestroy);
    }
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime );
        if (!megaHit && Vector3.Distance(transform.position, target) <.01f)
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
                other.gameObject.GetComponent<GrizzyHealth>().TakeDamage(100f); //50

                GameObject myMegaBullet = GameObject.Instantiate(splatBlood, contact.point + contact.normal *0.0001f,Quaternion.LookRotation(other.transform.up));

                Destroy(myMegaBullet,0.5f);
            }
            //print(other.gameObject.name);
            //if (other.gameObject.CompareTag("Player"))
            if(layerShoot == (layerShoot | (1 << other.gameObject.layer)))
            {
                if (other.gameObject.tag == "Tile")
                {
                    Debug.Log("Parent il tile? ");
                    myMegaSplatty = GameObject.Instantiate(megaBulletDecal, contact.point + contact.normal *0.0001f,Quaternion.LookRotation(other.transform.up));
                    myMegaSplatty.transform.parent = other.transform;
                    //Destroy(gameObject);
                    
                    //gameObject.SetActive(false);
                    decal = myMegaSplatty.GetComponent<DecalBehaviour>();
                    decal.ScaleOverTime();
                    //StartCoroutine("ScaleCoroutine");5.0f, mySplatty
                    //ScaleOverTime();
                }
                else{
                    myMegaSplat = GameObject.Instantiate(megaBulletDecal, contact.point + contact.normal *0.0001f,Quaternion.LookRotation(contact.normal));
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
