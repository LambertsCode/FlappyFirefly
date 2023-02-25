using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LightOperator : MonoBehaviour
{

    Transform player;
    public Transform blockGenerator;
    public Light2D globalLight;

    int blockNumber;
    public float lightGenerated = 0.2f;


    public void SpawnAndSetBlockNumber(int _blockNumber, Transform _player, Transform _blockGenerator)
    {
        blockNumber = _blockNumber;
        player = _player;
        blockGenerator = _blockGenerator;

        Vector3 pos = transform.position;
        pos.x = player.position.x + 1.75f + blockNumber;
        pos.y = UnityEngine.Random.Range(0.4f, 2.0f);

        transform.position = pos;

    }

    void EnableRenderer()
    {
        GetComponent<Renderer>().enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            GetComponent<Renderer>().enabled = false;
            gameObject.GetComponentInChildren<Light2D>().enabled = false;
            
            Debug.Log(globalLight.intensity);

            if ((globalLight.intensity + lightGenerated) > 0)
            {

                globalLight.intensity += lightGenerated;

            }
            else
            {
                globalLight.intensity = 0;
            }
            Invoke("EnableRenderer", 10f);
        }
        else if(collision.tag == "Cleaner")
        {
            Move();
            gameObject.GetComponentInChildren<Light2D>().enabled = true;
        }
    }

    private void Move()
    {
        Vector3 pos = transform.position;
        pos.x = blockGenerator.position.x;
        pos.y = UnityEngine.Random.Range(0.4f, 2f);

        transform.position = pos;
    }
}
