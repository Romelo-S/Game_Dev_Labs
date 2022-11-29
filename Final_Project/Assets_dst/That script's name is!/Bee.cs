using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bee : MonoBehaviour
{
    private GameObject lastTriggerGo = null;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        var mousePos = Input.mousePosition;
        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x,mousePos.y,10.0f));
    }
    private void OnTriggerEnter(Collider other)
    {
        Transform rootT = other.gameObject.transform.root;
        GameObject go = rootT.gameObject;
        
        print("colliding go");

        if (go.tag == "Bomb")
        {
            print("collided with bomb");
            Destroy(this.gameObject);
        }
        else if(go.tag == "RedZone")
        {
            print("collided with red zone");
            Destroy(this.gameObject);
        }
        else if(go.tag == "Balloon")
        {
            print("collided with balloon");
            Main.S.score++; 
            Destroy(other.gameObject);
        }
    }
}
