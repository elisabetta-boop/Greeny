using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    public List<Grizzy> grizzys = new List<Grizzy>();
    public GameObject grizzyPrefab;
    
    
    public Grizzy Create(Vector3 position, Quaternion rotation)
    {
        Grizzy grizzy = null;
        if (grizzys.Count >0)
        {
            grizzy = grizzys[0];
            grizzys.RemoveAt(0);
            grizzy.transform.rotation = rotation;
            grizzy.transform.position = position;
            grizzy.gameObject.SetActive(true);
        }
        else
        {
            GameObject grizzyGo = Instantiate(grizzyPrefab, position, rotation); //creation
            grizzy = grizzyGo.GetComponent<Grizzy>(); //chercher composant
        }
        return grizzy;

    }
    public void Kill(Grizzy grizzy)
    {
        grizzy.gameObject.SetActive(false);
        grizzys.Add(grizzy);
    }
}
