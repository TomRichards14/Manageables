using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnookGameManager : MonoBehaviour {

    public GameObject snakePrefab;
    public GameObject itemPrefab;
    public bool ItemAvailable;

	// Use this for initialization
	void Start ()
    {
        ItemAvailable = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (ItemAvailable == false)
        {
            ItemSpawn();
        }
	}

    void ItemSpawn()
    {
        float XCoord;
        float YCoord;

        XCoord = Random.Range(-3.0f, 3.0f);
        YCoord = Random.Range(-4.4f, 6.4f);

        Instantiate(itemPrefab, new Vector3(XCoord, YCoord, -0.15f), Quaternion.identity);

        ItemAvailable = true;
    }
}
