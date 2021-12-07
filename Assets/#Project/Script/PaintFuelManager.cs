using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PaintFuelManager : MonoBehaviour
{
    public float paintFuel;
    public float maxFuel = 100;
    public GameObject player;
    public Slider paintFuelBar;
    public bool paintFinish = false;
    public float paintLessAmount = 100;
    public float paintMoreAmount = 5;
    public float smoothing = 5;
    //public bool oneShootYet =false;


    void Awake()
    {
        if(paintFuelBar == null)
        {
            paintFuelBar = GameObject.FindGameObjectWithTag("PaintFuelSlider").GetComponent<Slider>();
        }
        // if(paintFuelBar == null)
        // {
        //     paintFuelBar = (Slider)FindObjectOfType(typeof(Slider));
        //     Debug.Log("paintfuelbar found ... because null");
        // }
        
        paintFuel = maxFuel;
        paintFuelBar.maxValue = maxFuel;
        paintFuelBar.value = paintFuel;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(paintFuelBar.value != paintFuel)
        {
            paintFuelBar.value = Mathf.Lerp(paintFuelBar.value, paintFuel, smoothing*Time.deltaTime);
        }
        if(paintFuel == 0 || paintFuel <100)
        {
            paintFuel += paintMoreAmount * Time.deltaTime;
            paintFuelBar.value = paintFuel;
        }
        
        // if (oneShootYet)
        // {
        //     paintFinish = false;
        //     Debug.Log("paint finish false and paint fuel amount total " + paintFinish + " " + paintFuel);
        // }


    }

    public void paintFuelLess()
    {
        paintFuel -= paintLessAmount;

        paintFuelBar.value = paintFuel;
        //oneShootYet = true;
        
        if(paintFuel<=0.0f)
        {
            // paintFinish = true;
            paintFuel = 0;
            Debug.Log("fuel finish" + paintFuel);
        }
    }
    

    
}
