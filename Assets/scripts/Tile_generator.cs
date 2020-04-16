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
    public Transform player_transform;
    private Transform player_last_transform;

    public int number_of_tile_x;
    public int number_of_tile_z;
    
    public GameObject parent_object;
    Hashtable tiles = new Hashtable();

    // Start is called before the first frame update
    void Start()
    {
        player_last_transform = player_transform; 
            for(int i = -number_of_tile_x; i < number_of_tile_x;i++){
                for(int j = -number_of_tile_z; j < number_of_tile_z;j++){
                    int picked_tile = Random.Range(0, tile_prefabs.Length);
                    
                    Vector3 pos = new Vector3((i*tile_size+player_transform.position.x),0.0f,(j*tile_size+player_transform.position.z));
                    
                    GameObject t = (GameObject) Instantiate(tile_prefabs[picked_tile]);
                    t.transform.position = pos;
                    t.transform.Rotate(0.0f, (Random.Range(0, 5) * 90.0f), 0.0f,Space.Self);
                    
                    string tile_name = "Tile_"+((int)(pos.x)).ToString() + "_" +((int)(pos.z)).ToString();
                    t.name = tile_name;
                    tiles.Add(tile_name,"1");

                     t.transform.parent = parent_object.transform;

                }
            }
    }

    // Update is called once per frame
    void Update()
    {
       int x_move = (int)(Mathf.Floor((player_last_transform.position.x - player_transform.position.x)/tile_size)*tile_size);
       int z_move = (int)(Mathf.Floor((player_last_transform.position.z - player_transform.position.z)/tile_size)*tile_size);
       
       if(Mathf.Abs(x_move)>tile_size || Mathf.Abs(z_move)>tile_size){
            Debug.Log(x_move + " | " + z_move);
            player_last_transform = player_transform; 
            generate_tiles();

       }
      


    }

    void generate_tiles(){
            for(int i = -number_of_tile_x; i < number_of_tile_x;i++){
                for(int j = -number_of_tile_z; j < number_of_tile_z;j++){
                    int picked_tile = Random.Range(0, tile_prefabs.Length);
                    Vector3 pos = new Vector3((i*tile_size+player_transform.position.x),0.0f,(j*tile_size+player_transform.position.z)); //todo dat do ifu for more speed
                    string tile_name = "Tile_"+((int)(pos.x)).ToString() + "_" +((int)(pos.z)).ToString();

                    if(!tiles.ContainsKey(tile_name)){
                        GameObject t = (GameObject) Instantiate(tile_prefabs[picked_tile]);
                        t.transform.position = pos;
                        t.transform.Rotate(0.0f, (Random.Range(0, 5) * 90.0f), 0.0f,Space.Self);
                
                        t.name = tile_name;
                        t.transform.parent = parent_object.transform;
                    }
                }
            }
    }

}
