using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class checkpoint_manager : MonoBehaviour
{
    public int checkpoint_crossed;
    public int total_checkpoints = 6;
    public float checkpoint_timer;
    public int[] cp_time;

    public Text cp_crossed_text;
    public Text cp_left_text;
    public Text countdown_text;

    public bool reached = false;

    public GameObject[] checkpoint;
    public GameObject[] spawnpoint;
    public GameObject player;
    public GameObject game_end_canvas;

    private void Start()
    {

        /*for(int k=0; k< total_checkpoints; k++)
        {
            cp_time[k] = 15;
        }*/
        cp_time[0] = 20;
        cp_time[1] = 20;
        cp_time[2] = 20;
        cp_time[3] = 20;
        cp_time[4] = 20;
        checkpoint_timer = cp_time[0];
        checkpoint_crossed = 0;
        total_checkpoints = 5;
        cp_left_text.text = ("" + total_checkpoints).ToString();
    }

    public void load_prev_checkpoint()
    {
        player.transform.position = spawnpoint[checkpoint_crossed].transform.position;

        player.GetComponent<Transform>().rotation = spawnpoint[checkpoint_crossed].GetComponent<Transform>().rotation;
        player.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        //Debug.Log("car reset");
        checkpoint_timer = cp_time[checkpoint_crossed];
    }
    
    private void Update()
    {
        if(checkpoint_crossed != total_checkpoints)
        {
            checkpoint_timer -= Time.deltaTime;
            countdown_text.text = checkpoint_timer.ToString("F1");
            if (reached)
            {
                checkpoint_crossed += 1;
                //Debug.Log("checkpt" + checkpoint_crossed);
                cp_crossed_text.text = checkpoint_crossed.ToString();
                cp_left_text.text = (total_checkpoints - checkpoint_crossed).ToString();
                if (checkpoint_crossed < total_checkpoints)
                {
                    checkpoint[checkpoint_crossed].GetComponent<BoxCollider>().isTrigger = true;
                    checkpoint_timer += cp_time[checkpoint_crossed];
                }
                reached = false;
            }

            if (checkpoint_timer <= 0)
            {
                //reset at checkpoint crossed pos
                //321 timer
                //cp[cp_crossed -1] pos send
                // speed=0
                // first, find the closest safe place

                player.transform.position = spawnpoint[checkpoint_crossed].transform.position;

                player.GetComponent<Transform>().rotation = spawnpoint[checkpoint_crossed].GetComponent<Transform>().rotation;
                player.GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
                //Debug.Log("car reset");
                checkpoint_timer = cp_time[checkpoint_crossed];
            }
        }
        else
        {
            countdown_text.text = "Nil";
            Time.timeScale = 0f;
            game_end_canvas.SetActive(true);
        }

    }
}
