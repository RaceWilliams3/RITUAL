using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellObject : MonoBehaviour
{
    /* Hex number system
     *        0
     *     5     1
     *     4     2
     *        3
     *                */

    public GameObject[] neighbors = new GameObject[6];
    public Connector[] connectors;
    public GameManager gameManager;

    public Material emptyMat;
    public Material filledMat;

    public bool isHome;

    private float mouseLastExited = 100000000f;
    private float mouseLeaveBufffer = 0.05f;

    public AudioSource placeAudio;


    

    private Vector3[] cellDirections = {new Vector3(0f,0.2f,1f),
                                        new Vector3(1f,0.2f,0.5f),
                                        new Vector3(1f,0.2f,-0.5f),
                                        new Vector3(0f,0.2f,-1f),
                                        new Vector3(-1f,0.2f,-0.5f),
                                        new Vector3(-1f,0.2f,0.5f)};

    public bool empty = true;

    public void Start()
    {
        connectors = gameObject.GetComponentsInChildren<Connector>();
        checkForNeighbors();
        mouseLastExited = Time.time;
        placeAudio = GetComponent<AudioSource>();

        if (!isHome)
        {
            foreach(Connector x in connectors)
            {
                x.gameObject.SetActive(false);
            }
        }
        else
        {
            GetComponent<MeshRenderer>().material = filledMat;
        }



        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        

    }

    public void connectorCollided(Connector connector)
    {
        if (gameManager != null)
        {
            if (!empty)
            {
                gameManager.updateScore(1);
            }
            
        }
    }

    public void rotatePreview()
    {

        hideConnectors();
        createConnectors(TileManager.instance.currentTile.connectionStates);
        
    }

    void OnMouseDown()
    {
        if (empty && !isHome)
        {
            placeAudio.Play();
            empty = false;
            GetComponent<MeshRenderer>().material = filledMat;

            createConnectors(TileManager.instance.currentTile.connectionStates);

            TileManager.instance.createNewTile();
        }
        

    }

    void OnMouseEnter()
    {
        TileManager.instance.selectedTile = this;
        mouseLastExited = Time.time + 100000f;
        if (empty && !isHome)
        {
            createConnectors(TileManager.instance.currentTile.connectionStates);
            
        }
        
    }

    void OnMouseExit()
    {
        mouseLastExited = Time.time;
        
    }

    private void Update()
    {
        if (mouseLastExited + mouseLeaveBufffer < Time.time)
        {
            hideConnectors();
        }
    }



    public void createConnectors(bool[] connectionMap)
    {
        for (int i = 0; i < 6; i++)
        {
            if (connectionMap[i] == true)
            {
                connectors[i].gameObject.SetActive(true);
            }
        }
    }

    public void hideConnectors()
    {
        if (empty && !isHome)
        {
            for (int i = 0; i < 6; i++)
            {
                connectors[i].gameObject.SetActive(false);
            }
        }
    }

    public void checkForNeighbors()
    {
        RaycastHit hit;
        for (int i = 0; i < 6; i++)
        {
            if (Physics.Raycast(transform.position + new Vector3(0,-0.2f,0), cellDirections[i], out hit, 2))
            {
                Debug.DrawRay(transform.position + new Vector3(0, -0.2f, 0), cellDirections[i], Color.green);
                neighbors[i] = hit.transform.gameObject;
                //Debug.Log("Neighbor ray hit");
            } 
            else
            {
                Debug.DrawRay(transform.position + new Vector3(0, -0.2f, 0), cellDirections[i], Color.red);
            }
        }
    }



    public void updateNeighbors()
    {
        foreach (GameObject x in neighbors)
        {
            if (x != null)
            {
                
            }
            
        }

    }
}

