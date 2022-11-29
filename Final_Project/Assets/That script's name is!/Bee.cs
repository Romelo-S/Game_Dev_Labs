using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bee : MonoBehaviour
{
    private GameObject lastTriggerGo = null;
    private bool alive = true;
    public float respawnTime = 0;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (Main.S.pauseMenu.activeSelf == false && alive == true)
        {
            var mousePos = Input.mousePosition;
            transform.position = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x,mousePos.y,10.0f));
        }else if(alive == false)
        {
            respawnTime += Time.deltaTime;
            if(respawnTime >= 5 )
            {
                alive = true;
                respawnTime = 0;
            }
            
        }
        
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Transform rootT = other.gameObject.transform.root;
        GameObject go = rootT.gameObject;
        /*if (go == lastTriggerGo)
        {    
            return;
        }
        lastTriggerGo = go;*/
        print(go.tag);
        if (go.tag == "Bomb")
        {
            print("collided with bomb");

            if (Main.S.lives > 1)
            {
                Main.S.lives--;
                RespawnBee();
            }
            else
            {
                Main.S.lives--;
                Destroy(this.gameObject);
                SceneManager.LoadScene("GameOver_Scene");
            }
        }
        else if(go.tag == "RedZone")
        {
            print("collided with red zone");

            if (Main.S.lives > 1)
            {
                Main.S.lives--;
                alive = false;
                RespawnBee();
            }
            else
            {
                Main.S.lives--;
                Destroy(this.gameObject);
                SceneManager.LoadScene("GameOver_Scene");
            }
        }
        else if(go.tag == "Balloon")
        {
            print("collided with balloon");
            Main.S.score++;
            Destroy(other.gameObject);
        }
        else
        {
            print("collided with Wall");
            RespawnBee();
            alive = false;
        }
    }

    void RespawnBee()
    {
       print("Respawn bee");
        Vector3 spawnPosition = Main.S.SpawnPositionGO.transform.position; 
        Vector3 newPosition = this.transform.position;
        newPosition.x = spawnPosition.x;
        newPosition.y = spawnPosition.y;
        newPosition.z = spawnPosition.z;
        this.transform.position = newPosition;
        //this.transform.position = position;
    }
}
