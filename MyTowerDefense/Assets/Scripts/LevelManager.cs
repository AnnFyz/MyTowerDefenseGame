using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LevelManager : MonoBehaviour
{

    [SerializeField] private GameObject mapTile;
    [SerializeField] private GameObject pathTile;
    [SerializeField]  private int mapWidth;
    [SerializeField]  private int mapHeight;

    private List<GameObject> mapTiles = new List<GameObject>();
    private List<GameObject> pathTiles = new List<GameObject>();

    GameObject curretTile;
    private int currentIndex;
    private int nextIndex;
    public bool reachedX = false;
    public bool reachedY = false;
    private void Start()
    {
        CreateLevel();
       
    }
    public float TileSize
    {
        get
        {
            return mapTile.GetComponent<SpriteRenderer>().sprite.bounds.size.x;
        }
    }

    private void CreateLevel()
    {
        Vector3 origin = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));
        mapWidth = (Mathf.RoundToInt(origin.x/ TileSize))*2;
        mapHeight = (Mathf.RoundToInt(origin.y / TileSize))*2;
        for (int y = 0; y < mapHeight; y++)
        {
            for (int x = 0; x < mapWidth; x++)
            {
                PlaceTile(x, y, origin);
            }
        }
        GeneratePath();
    }
    private List<GameObject> GetBottomEdgeTiles()
    {
        List<GameObject> edgeTiles = new List<GameObject>();
        for (int i = mapWidth * (mapHeight-1); i < mapWidth*mapHeight; i++)
        {
            edgeTiles.Add(mapTiles[i]);
        }
        return edgeTiles;
    }

    private List<GameObject> GetLeftEdgeTiles()
    {
        List<GameObject> edgeTiles = new List<GameObject>();
        for (int i = 0; i <= mapWidth * (mapHeight - 1); i += mapWidth)
        {
            edgeTiles.Add(mapTiles[i]);
        }
        return edgeTiles;
    }

    private List<GameObject> GetRightEdgeTiles()
    {
        List<GameObject> edgeTiles = new List<GameObject>();
        for (int i = mapWidth-1; i < mapWidth * mapHeight; i += mapWidth)
        {
            edgeTiles.Add(mapTiles[i]);
        }
        return edgeTiles;
    }

    private List<GameObject> GetTopEdgeTiles()
    {
        List<GameObject> edgeTiles = new List<GameObject>();
        for (int i = 0; i < mapWidth; i++)
        {
            edgeTiles.Add(mapTiles[i]);
        }
        return edgeTiles;
    }
    private void PlaceTile(int x, int y, Vector3 origin)
    {
        GameObject newMapTile = Instantiate(mapTile);
        mapTiles.Add(newMapTile);
        newMapTile.transform.position = new Vector3((TileSize * x) - origin.x + TileSize/2, origin.y - (TileSize * y) - TileSize / 2);
             
    }

    private void GeneratePath()
    {
        List<GameObject> topEdgeTiles = GetTopEdgeTiles();
        List<GameObject> bottomEdgeTiles = GetBottomEdgeTiles();
        List<GameObject> leftEdgeTiles = GetLeftEdgeTiles();
        List<GameObject> rightEdgeTiles = GetRightEdgeTiles();

        GameObject startTile;
        GameObject endTile;

        int randStart = Random.Range(0, mapWidth);
        int randEnd = Random.Range(0, mapWidth);

        startTile = topEdgeTiles[randStart];
        endTile = bottomEdgeTiles[randEnd];

        curretTile = startTile;
        currentIndex = mapTiles.IndexOf(startTile);


        int firstRandomTurn = Random.Range(1, mapHeight-1);
        int secondRandomTurn = Random.Range(1, mapHeight-1);
        for (int i = 0; i < mapHeight*2; i++)
        {
           
            if (firstRandomTurn == i || secondRandomTurn == i)
            {
                if(curretTile == leftEdgeTiles[i])
                {
                    for (int q = 0; q < 3; q++)
                    {
                        MoveRight();
                    }
                    MoveDown();
                    MoveDown();
                }
                else
                {
                    for (int q = 0; q < 2; q++)
                    {
                        MoveLeft();
                    }
                    MoveDown();
                    MoveDown();
                }

                if (curretTile == rightEdgeTiles[i])
                {
                    for (int q = 0; q < 3; q++)
                    {
                        MoveLeft();
                    }
                    MoveDown();
                    MoveDown();
                }
                else
                {
                    for (int q = 0; q < 2; q++)
                    {
                        MoveRight();
                    }
                    MoveDown();
                    MoveDown();
                }
            }
            else
            {
                MoveDown();
            }

            if(bottomEdgeTiles[i] != null)
            {
                if(curretTile == bottomEdgeTiles[i])
                break;
            }
        }

        foreach (var item in pathTiles)
        {
            Destroy(item);
        }

        GameObject startPathTile = Instantiate(pathTile, startTile.transform.position, Quaternion.identity);
        Destroy(startTile);

    }


    private void MoveDown()
    {
        pathTiles.Add(curretTile);
        currentIndex = mapTiles.IndexOf(curretTile);
        nextIndex = currentIndex + mapWidth;
        if(nextIndex <= mapTiles.Count)
        {
            curretTile = mapTiles[nextIndex];
            GameObject newPathTile = Instantiate(pathTile, curretTile.transform.position, Quaternion.identity);
        }
    }

    

    private void MoveLeft()
    {
        pathTiles.Add(curretTile);
        currentIndex = mapTiles.IndexOf(curretTile);
        nextIndex = currentIndex - 1;
        curretTile = mapTiles[nextIndex];
        GameObject newPathTile = Instantiate(pathTile, curretTile.transform.position, Quaternion.identity);
    }

    private void MoveRight()
    {
        pathTiles.Add(curretTile);
        currentIndex = mapTiles.IndexOf(curretTile);
        nextIndex = currentIndex + 1;
        curretTile = mapTiles[nextIndex];
        GameObject newPathTile = Instantiate(pathTile, curretTile.transform.position, Quaternion.identity);
    }
}
