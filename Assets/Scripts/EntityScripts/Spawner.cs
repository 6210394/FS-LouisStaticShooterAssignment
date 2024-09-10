using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{ 
    [SerializeField]
    GameObject prefabToSpawn;
    public float coolDown = 2.0f;
    public KeyCode spawnKey;

    float coolDownTimer;


    void Update()
    {
        if (Input.GetKeyDown(spawnKey))
        {
            Spawn(prefabToSpawn);
        }
        if (coolDownTimer > 0)
        {
            coolDownTimer -= Time.deltaTime;
        }
    }

    public void Spawn(GameObject newObject)
    {
        if (coolDownTimer > 0)
        {
            return;
        }
        coolDownTimer = coolDown;
        newObject = Instantiate(prefabToSpawn, transform.position, transform.rotation);
    }
}
