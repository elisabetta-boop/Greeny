using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.AI;
using Cinemachine;
public class LevelManager : MonoBehaviour
{
    public SphereMenuZeroBehaviour sphereMenuZeroBehaviour;
    public GameManager gameManager;
    private int row;
    private int col;
    public int CubeRow;
    public int CubeCol;

    public float gapRow = 3.0f;

    public float gapCol = 3.0f;

    [Range(0f, 5f)]
    public float timeBeforeReset = 1f;
    public bool resetOnGoing = false;
    public GameObject tile_Prefab;
    public Tile_Behaviour[] tiles;
    //public List<TryTile> tryTileTrttry = new TryTile[100];
    public Material[] colors;
    public Material defaultColor;
    public List<int> greenColored = new List<int>();

    public UnityEvent whenPlayerWins;
    private float timer = 0;
    public float timeToWin = 1f;

    public static int lifes = 3;
    public CinemachineVirtualCamera[] playerCams;

    GameObject player;

    public float miao;
    public float bau;
    public bool isWinning;






    void Start()
    {
        isWinning = false;
        row = PlayerPrefs.GetInt("row", CubeRow);
        col = PlayerPrefs.GetInt("col", CubeCol);

        tiles = new Tile_Behaviour[row * col];
        int index = 0;

        miao = CubeRow * gapRow;
        bau = CubeCol * gapCol;

        for (int x = 0; x < col; x++)
        {
            for (int z = 0; z < row; z++)
            {
                Vector3 position = new Vector3(x * gapCol, 0, z * gapRow);
                GameObject tile = Instantiate(tile_Prefab, position, Quaternion.identity);


                tile.GetComponent<Renderer>().material = colors[0];

                tiles[index] = tile.GetComponent<Tile_Behaviour>();
                tiles[index].id = index;
                tiles[index].manager = this;
                index++;
            }
        }

        playerCams=FindObjectsOfType<CinemachineVirtualCamera>();
        if (playerCams.Length == 0)
        {
            Debug.LogError("There is no CinemachineVirtualCamera in your scene");
        }
        else
        {
            for (int i = 0; i < playerCams.Length; i++)
            {
                player = GameObject.FindGameObjectWithTag("Player");
                playerCams[i].LookAt = player.transform;
                playerCams[i].Follow = player.transform;
            }
        }
        sphereMenuZeroBehaviour= GameObject.FindGameObjectWithTag("SphereMenuZero").GetComponent<SphereMenuZeroBehaviour>();
        gameManager= GameObject.FindGameObjectWithTag("MenuGame").GetComponent<GameManager>();

    }
    void Update()
    {
        CeckingWorld();
        timer += Time.deltaTime;
    }
    private void CeckingWorld()
    {
        // float cubicWorld = gapCol*gapRow;
        // int cubicWorldi = (int)cubicWorld;
        int cubicWorldi = CubeRow * CubeCol;
        if (greenColored.Count == 1)
        {
            //Debug.Log("one for the win");
        }
        Debug.Log("how many green tiles: " + greenColored.Count);
        if(gameManager.levelNow==1)
        {
            
            if (greenColored.Count == cubicWorldi || greenColored.Count == (cubicWorldi-1)|| greenColored.Count == (cubicWorldi-2)) 
            {
                Debug.Log("winnnnnnnnn");
                StartCoroutine(PassToWin());
            }
            
        }
        else if(gameManager.levelNow == 2 || gameManager.levelNow == 3 )
        {

            if (greenColored.Count == cubicWorldi || greenColored.Count == (cubicWorldi-1)|| greenColored.Count == (cubicWorldi-2)|| greenColored.Count == (cubicWorldi-3)|| greenColored.Count == (cubicWorldi-4) || greenColored.Count == (cubicWorldi-5))
            {
                Debug.Log("winnnnnnnnn");
                StartCoroutine(PassToWin());
            }
        }
    }
    public void changeColorTile(int id)
    {
        if (!greenColored.Contains(id))
        {
            greenColored.Add(id);
            tiles[id].GetComponent<Renderer>().material = colors[1];
            // targetPoint.Spawn();
            // Debug.Log("miaoooooo");
            //Debug.Log(id);
            //Debug.Log("the id");
        }
    }
    public void changeColorTileBackGrey(int id)
    {
        if (greenColored.Contains(id))
        {
            greenColored.Remove(id);
            tiles[id].GetComponent<Renderer>().material = colors[0];
            //Debug.Log("back to grey");
            tiles[id].isTileTrasformed = false;
        }
    }
    public static void LoseLife()
    {
        lifes--;
        print(lifes);
        // if (lifes <=0)
        // {
        //     SceneManager.LoadScene("GAMEOVER");
        // }
        // else 
        // {
        //     SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        // }
    }
    private IEnumerator PassToWin()
    {
        isWinning = true;
        sphereMenuZeroBehaviour.okAnimSphere = false;
        yield return new WaitForSeconds(timeToWin);
        Win();
    }
    public void Win()
    {
        //Debug.Log("winner");
        whenPlayerWins?.Invoke();

    }


}
