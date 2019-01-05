using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItems : MonoBehaviour
{
    public enum ItemType
    {
        marshmallow, 
        candycane,
        nasty
    }

    #region SerializeFields
    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private float timeBetweenSpawning;

    [SerializeField]
    [Tooltip("The minimum time that can happen between 2 things spawning")]
    private float minTimeBetweenSpawning;

    [SerializeField]
    [Tooltip("The multiplier for rate at which the spawns increase")]
    private float spawnIncreaseSpeed;

    [SerializeField]
    [Tooltip("A number out of 100 that matches the percentage of that item being picked")]
    private int candyCaneProbability, nastyProbability;

    [SerializeField]
    private GameObject marshmallowPrefab, candycanePrefab, nastyPrefab;
    #endregion

    private SpriteRenderer renderer;
    private float rendererExtentsX;

    void Start ()
    {
        renderer = marshmallowPrefab.GetComponent<SpriteRenderer>();
        rendererExtentsX = renderer.bounds.extents.x;
        StartCoroutine(SpawnLoop());
	}
	
	private IEnumerator SpawnLoop()
    {
        for (; ; )
        {
            yield return new WaitForSeconds(timeBetweenSpawning);
            Spawn(ChooseItemToSpawn());//spawns an item
        }
    }

    private ItemType ChooseItemToSpawn()
    {
        int randomNumber = Random.Range(1, 101);//gives us a random number between 1 and 100

        if (randomNumber <= candyCaneProbability)//the smallest number. If it's that number or smaller, give us a candy cane
        {
            return ItemType.candycane;
        }
        else if(randomNumber <= nastyProbability)//if it's not smaller than our candy cane,  but smaller than our nasty, make it a nasty
        {
            return ItemType.nasty;
        }
        else//otherwise we get a marshmallow
        {
            return ItemType.marshmallow;
        }
    }
    private void Spawn(ItemType itemToSpawn)
    {
        GameObject instance;

        if (itemToSpawn == ItemType.candycane)
        {
            instance = Instantiate(candycanePrefab, ChooseSpawnPos(), Quaternion.identity);
            instance.GetComponent<MoveItem>().speed = moveSpeed * 2.5f;//these move a bit faster
        }
        else if (itemToSpawn == ItemType.nasty)
        {
            instance = Instantiate(nastyPrefab, ChooseSpawnPos(), Quaternion.identity);
            instance.GetComponent<MoveItem>().speed = moveSpeed * 2;
        }
        else if (itemToSpawn == ItemType.marshmallow)
        {
            instance = Instantiate(marshmallowPrefab, ChooseSpawnPos(), Quaternion.identity);
            instance.GetComponent<MoveItem>().speed = moveSpeed;
        }

    }

    private Vector2 ChooseSpawnPos()
    {
        return Camera.main.ScreenToWorldPoint(new Vector2(Random.Range(0 15, Screen.width - 15), Screen.height));
    }
}
