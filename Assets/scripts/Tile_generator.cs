using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile_generator : MonoBehaviour
{
    public GameObject[] tile_prefabs;
    private float tile_size = 10.0f;
    public Transform player_object_transform;
    public int number_of_tile_on_screen;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //todo delete tiles 

        //todo check tiles in range


    }

    private void Spawn_tile(int prefab_index = -1){
        GameObject tile;
        tile = Instantiate(tile_prefabs[0]) as GameObject; //todo random
        //tile.transform.setParent
        tile.transform.position = Vector3.forward;
    }
}
