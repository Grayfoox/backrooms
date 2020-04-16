using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile{
    public  GameObject the_tile;
    public float creation_time;

    public Tile(GameObject t,float ct){
    the_tile = t;
    creation_time = ct;
    }
}

public class Tile_generator : MonoBehaviour
{
    public GameObject[] tile_prefabs;
    private float tile_size = 10.0f;
    public Transform player_last_transform;
    public int number_of_tile_x;
    public int number_of_tile_z;
    
    public GameObject parent_object;
    //hastable tiles = new Hastable();

    // Start is called before the first frame update
    void Start()
    {
            for(int i = -number_of_tile_x; i < number_of_tile_x;i++){
                for(int j = -number_of_tile_z; j < number_of_tile_z;j++){
                    int picked_tile = Random.Range(0, tile_prefabs.Length);
                    
                    Vector3 pos = new Vector3((i*tile_size),0.0f,(j*tile_size));//přidat player pos
                    
                    GameObject t = (GameObject) Instantiate(tile_prefabs[picked_tile]);
                    t.transform.position = pos;
                    t.transform.Rotate(0.0f, (Random.Range(0, 5) * 90.0f), 0.0f,Space.Self);
                    
                    string tile_name = "Tile_"+((int)(pos.x)).ToString() + "_" +((int)(pos.z)).ToString() +": "+picked_tile.ToString();
                    t.name = tile_name;
                    
                     t.transform.parent = parent_object.transform;


                    //Tile tile = new Tile(t,updateTime);
                    //tiles.Add(tile_name, tile);

                }
            }
    }

    // Update is called once per frame
    void Update()
    {
        //todo delete tiles 

        //todo check tiles in range


    }

}
