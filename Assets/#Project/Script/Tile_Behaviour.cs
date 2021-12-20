using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.AI;

public class Tile_Behaviour : MonoBehaviour
{
    Material tryTileMaterial_Grey;
    
    Material tryTileMaterial_Green;
    
    //public bool mouseOver = false;
    public int id= -1;
    public LevelManager manager;
    private Animator animator;
    public UnityEvent whenBulletUp;
    public Tile_Behaviour tryTile;
  
    public bool isTileTrasformed = false;
    public UnityEvent whenGreenyUp;
    //public UnityEvent whenGreenyDown;
    public UnityEvent whenFallingTile;

    public Vector3 positionTile;
    public Grizzy grizzy;
    public TileHighlight tileHighlight;
    //public Animator falledTile;
    public AudioSource audioSource;

            
    void Start()
    {
        animator = GetComponent<Animator>();
        // GameObject fallingTile = GameObject.Find("FallingTile");
        // falledTile = fallingTile.GetComponent<Animator>();
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player"))
        {
            //je voudrais faire illuminer le tile quand Greeny est sur le tile
            Debug.Log("Greeny est sur le tile avant coroutine");
            whenGreenyUp?.Invoke();
            Debug.Log("Greeny est sur le tile apres la coroutine");

        }
        else if (other.CompareTag("Bullet"))
        {
            audioSource.Play();
            positionTile = this.transform.position;
            //Debug.Log("tile vector3");
            //Debug.Log(positionTile); ////ne marche passssss!!!

            // il faut absolutement condition si grizzy est sur le tile no green color 
            whenBulletUp?.Invoke();
            // je voudrais faire une animation du tile quand change coleur
            isTileTrasformed = true;
            //Debug.Log("the bullet is on the tile");
            animator.SetBool("TileisColored", true);
            // Destroy(gameObject);
            
            manager.changeColorTile(id);
            // targetPoint.originalPos = positionTile;
            // Debug.Log("target "+ targetPoint.originalPos);
        }
        else if(other.CompareTag("Grizzy"))
        {
            
            //Debug.Log("Grizzy est sur le tile et il veut colorer de noveau en gris");
            manager.changeColorTileBackGrey(id);
        }
        else if(other.CompareTag("FallingTile"))
        {
            manager.changeColorTileBackGrey(id);

            Debug.Log("Falling Tile yuyu " + other);
            
            whenFallingTile?.Invoke();

            //DestroyImmediate(other,2f);

            Debug.Log(other + " other falling tile?");


            //falledTile.isFallingTile = true;
            //falledTile.SetBool("isFalled", true);
        }
        else
        {
            
            Debug.Log("else invoke");
        }
        }

}
