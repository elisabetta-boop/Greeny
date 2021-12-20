using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverTitle : MonoBehaviour
{
    public Animator gameOverAnimator;
    public UIManager uIManager;
    public bool okAnim=false;


    private void Awake()
    {
        uIManager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
        gameOverAnimator = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(uIManager.isGameOver)
        {
            gameOverAnimator.SetTrigger("isGameOver");
            Debug.Log("gameOver dai");
            okAnim = true;

        }
    }
}
