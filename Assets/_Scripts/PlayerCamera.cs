using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCamera : MonoBehaviour
{

    public Transform playerTransform;
    public FloatVariable darkness;
    public Image darknessImage;
    public BoolVariable playerAlive;
    float offsetx;

    // Start is called before the first frame update
    void Start()
    {
        offsetx = transform.position.x - playerTransform.position.x;

        darkness.value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position;
        position.x = playerTransform.position.x + offsetx;

        transform.position = position;
    }
    private void FixedUpdate()
    {
        if (playerAlive.value)
        {
            darkness.value += (Time.fixedDeltaTime / 13f);
        }
        else
        {
            darkness.value = 0;
        }

        darknessImage.color = new Color(0,0,0, darkness.value);
    }
}
