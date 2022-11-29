using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedZone : MonoBehaviour
{
    float speed = 1f;
    GameObject[] redzones;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        int index = 0; 
        redzones = GameObject.FindGameObjectsWithTag("RedZone");

        foreach (GameObject redzone in redzones)
        {
            if (index == 0)
            {
                float y = Mathf.PingPong(Time.time * speed, 1) * 6 - 3;
                redzone.transform.position = new Vector3(0, y, 0);
            }
            else if(index == 1)
            {
                float y = Mathf.PingPong(Time.time * speed, 1) * 6 - 3;
                redzone.transform.position = new Vector3(0, -y, 0);
            }else if(index == 2)
            {
                float x = Mathf.PingPong(Time.time * speed, 1) * 6 - 3;
                redzone.transform.position = new Vector3(x, 0, 0);
            }
            else if(index == 3)
            {
                float y = Mathf.PingPong(Time.time * speed, 1) * 6 - 3;
                redzone.transform.position = new Vector3(6f, -y, 0);
            }
            
            index++;
        }
    }

   
}
