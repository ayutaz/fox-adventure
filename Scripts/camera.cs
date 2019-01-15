using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    void Start()
    {
        
    }

    // Update is called once per frames
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10);

    Vector3 myPosition;
    if(transform.position.x < 0){
      myPosition.x = player.transform.position.x;
      myPosition.y = player.transform.position.y;
      myPosition.z = 0f;

      transform.position = myPosition;
    }

        if(transform.position.x >= 18){
            transform.position = new Vector3(18, player.transform.position.y, -10);
        }
    }
}
