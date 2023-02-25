using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockGenerator : MonoBehaviour
{
    public List<GameObject> smallBlocks;
    public List<GameObject> largeBlocks;
    public List<GameObject> clouds;
    public List<GameObject> mists;

    public GameObject light;
    public Transform player;

    public int blocksToGenerate = 12;
    public int cloudsToGenerate = 12;
    public int mistsToGenerate = 9;

    int blockNumber = 1;
    int lightNumber = 1;

    System.Random rand = new System.Random();


    private void Awake()
    {
        for(int i=0; i<blocksToGenerate; i++)
        {
            int smallBlockToGenerate = rand.Next(0, smallBlocks.Count);
            GameObject smallBlock = GameObject.Instantiate(smallBlocks[smallBlockToGenerate]);
            smallBlock.GetComponent<Block>().SetBlockNumberAndSpawn(blockNumber, transform, true);

            int largeBlockToGenerate = rand.Next(0, largeBlocks.Count);
            GameObject largeBlock = GameObject.Instantiate(largeBlocks[largeBlockToGenerate]);
            largeBlock.GetComponent<Block>().SetBlockNumberAndSpawn(blockNumber, transform, false);

            blockNumber++;

            GameObject lightGO = GameObject.Instantiate(light);
            light.GetComponent<LightOperator>().SpawnAndSetBlockNumber(lightNumber, player, transform);
            lightNumber++;
        }

        for(int i=0; i<cloudsToGenerate; i++)
        {
            int cloudToGenerate = rand.Next(0, clouds.Count);
            GameObject cloud = GameObject.Instantiate(clouds[cloudToGenerate]);

            float cloudHeight = Random.Range(1.6f, 2f);
            float cloudDistance = Random.Range(1f, 15f);

            cloud.transform.position = new Vector3(cloudDistance, cloudHeight, 0);
            cloud.GetComponent<CloudMover>().SpawnCloud(transform);
        }

        for (int i = 0; i < mistsToGenerate; i++)
        {
            int mistToGenerate = rand.Next(0, mists.Count);
            GameObject mist = GameObject.Instantiate(mists[mistToGenerate]);

            float mistHeight = Random.Range(-.3f, 0.6f);
            float mistDistance = Random.Range(0.85f, 15f);

            mist.transform.position = new Vector3(mistDistance, mistHeight, 0);
            mist.GetComponent<MistMover>().SpawnMist(transform);
        }
    }

    private void Start()
    {
        Time.timeScale = 0f;
    }
}
