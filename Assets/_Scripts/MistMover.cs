using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MistMover : MonoBehaviour
{

    public Transform blockGenerator;
    Vector3 moveSpeed;


    public void SpawnMist(Transform blockGenerator)
    {
        moveSpeed.x = Random.Range(-.09f, -.01f);
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
            pos.y = Random.Range(0f, 0.6f);
            moveSpeed.x = Random.Range(-.09f, -.01f);

            transform.position = pos;
        }
    }
}