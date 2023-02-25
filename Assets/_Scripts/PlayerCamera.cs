using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Experimental.Rendering.Universal;

public class PlayerCamera : MonoBehaviour
{

    public Transform playerTransform;
    public FloatVariable darkness;
    public Image darknessImage;
    public BoolVariable playerAlive;
    float offsetx;
    public Light2D globalLight;

    // Start is called before the first frame update
    void Start()
    {
        offsetx = transform.position.x - playerTransform.position.x;

        globalLight.intensity = 1;
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
            globalLight.intensity -= (Time.fixedDeltaTime / 13f);
        }
        else
        {
            globalLight.intensity = 1;
        }

        darknessImage.color = new Color(0,0,0, darkness.value);
    }
}
