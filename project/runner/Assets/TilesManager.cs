using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesManager : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    public Transform tilePrefabs2;
    public float zAxisSpawn = 0;
    public float tileLength = 0; //20 or 30
    public int numberTilesOnScreen = 3;
    private List<GameObject> activeTiles = new List<GameObject>();
    public Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        /*
        ZAxisTile(0);
        ZAxisTile(1);
        ZAxisTile(2);
        */

        for(int i=0; i<numberTilesOnScreen; i++)
        {
            if(i==0)
                ZAxisTileSpawn(0);
            else
                ZAxisTileSpawn(Random.Range(1,tilePrefabs.Length));
        }
    
    }

    // Update is called once per frame
    void Update()
    {
        if((playerTransform.position.z - 35) > zAxisSpawn - (numberTilesOnScreen * tileLength))
        {
            ZAxisTileSpawn(Random.Range(0,tilePrefabs.Length));
            DeleteTile();
        }
    }

    public void ZAxisTileSpawn(int tileIndex)
    {
        GameObject go = Instantiate(tilePrefabs[tileIndex], transform.forward * zAxisSpawn, transform.rotation, tilePrefabs2);
        activeTiles.Add(go);
        zAxisSpawn += tileLength;
    }

    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
}
