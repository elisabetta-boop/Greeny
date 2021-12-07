using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileHighlight : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    private MeshRenderer meshRenderer2;
    private Material originalMaterial;
    
    public Material originalMaterial2;
    public Material highLightMaterial;
    public float timeHighlight=2;
    
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        
        // if(meshRenderer == null)
        // {
        //     meshRenderer = (MeshRenderer)FindObjectOfType(typeof(MeshRenderer));
        //     Debug.Log("mesh renderer? because null");
        // }
        originalMaterial = meshRenderer.material; 
    }
    void Update()
    {
        // meshRenderer = GetComponent<MeshRenderer>();
        // originalMaterial = meshRenderer.material; 
        //je voulais chequer dans l'update mais malheuresement ne marche pas
    }
    public void Highlight()
    {
        meshRenderer.material = highLightMaterial;
    }
    public void NoHighlight()
    {
        if (meshRenderer != meshRenderer2)
        {
            meshRenderer.material = originalMaterial2;
        }
        else
        {
            meshRenderer.material = originalMaterial;
        }
    }

    IEnumerator Highlighter()
    {
        Highlight();
        yield return new WaitForSeconds(timeHighlight);
        NoHighlight();
    }

    public void theStaterHighlighter()
    {
        StartCoroutine(Highlighter());
    }

    private void ceckingRenderer()
    {
        meshRenderer2 = GetComponent<MeshRenderer>();
        // originalMaterial2 = meshRenderer2.material;
    }
}
