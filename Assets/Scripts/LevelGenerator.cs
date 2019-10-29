using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class LevelGenerator : MonoBehaviour
{
    //0 UP
    //1 RIGHT
    //2 DOWN
    //3 RIGHT 
    public int doorDirection;
    private bool spawned;
    private LevelTemplate templates;
    private Transform level;

    void Start()
    {
        spawned = false;
        level = GameObject.FindWithTag("Level").transform;
        templates = GameObject.FindWithTag("LvlTemp").GetComponent<LevelTemplate>();
        Invoke("Spawn", 1f);
    }

    void Spawn()
    {
        if (!spawned)
        {
            if (doorDirection == 0)
            {
                int r = Random.Range(0, templates.roomsWithDownDoors.Length);
                Transform room = Instantiate(templates.roomsWithDownDoors[r],
                    transform.position, templates.roomsWithDownDoors[r].rotation);
                room.parent = level;
            }
            else if (doorDirection == 1)
            {
                int r = Random.Range(0, templates.roomsWithLeftDoors.Length);
                Transform room = Instantiate(templates.roomsWithLeftDoors[r],
                    transform.position, templates.roomsWithLeftDoors[r].rotation);
                room.parent = level;
            }
            else if (doorDirection == 2)
            {
                int r = Random.Range(0, templates.roomsWithUpDoors.Length);
                Transform room = Instantiate(
                    templates.roomsWithUpDoors[r],
                    transform.position, templates.roomsWithUpDoors[r].rotation);
                room.parent = level;
            }
            else if (doorDirection == 3)
            {
                int r = Random.Range(0, templates.roomsWithRightDoors.Length);
                Transform room = Instantiate(
                    templates.roomsWithRightDoors[r],
                    transform.position, templates.roomsWithRightDoors[r].rotation);
                room.parent = level;
            }

            spawned = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "SpawnPoint")
        {
            Destroy(gameObject);
        }
    }
}