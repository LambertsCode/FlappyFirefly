using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMover : MonoBehaviour
{

    public Transform blockGenerator;
    Vector3 moveSpeed;


    public void SpawnCloud(Transform blockGenerator)
    {
        moveSpeed.x = Random.Range(-.15f, -.01f);
        this.blockGenerator = blockGenerator;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += moveSpeed * Time.fixedDeltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Cleaner")
        {
            Vector3 pos = transform.position;
            pos.x = blockGenerator.position.x;
            pos.y = Random.Range(1.6f, 2f);
            moveSpeed.x = Random.Range(-.15f, -.01f);

            transform.position = pos;
        }
    }
}
