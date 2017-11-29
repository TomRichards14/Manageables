using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnookGameManager : MonoBehaviour {

    public List<Transform> SnakeBody = new List<Transform>();

    public GameObject snakePrefab;
    public GameObject itemPrefab;
    public Transform CurrentSnakeBlock;
    public Transform PreviousSnakeBlock;
    public bool ItemAvailable;
    public float BodyMinDistance = 0.1f;
    public float SnakeRotationSpeed = 0.25f;
    public int SnakeStartSize = 3;

    private float DistanceBetweenBodyParts;

	// Use this for initialization
	void Start ()
    {
        for (int j = 0; j < SnakeStartSize; j++ )
        {
            AddToSnake();
        }

        ItemAvailable = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (ItemAvailable == false)
        {
            ItemSpawn();
        }

        SnakeMovement();

        if (Input.GetKey(KeyCode.Q))
        {
            AddToSnake();
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

    void SnakeMovement()
    {
        float SnakeSpeed = 1.0f;

        SnakeBody[0].Translate(SnakeBody[0].forward * SnakeSpeed * Time.smoothDeltaTime);

        if (Input.GetAxis("Horizontal") != 0)
        {
            SnakeBody[0].Rotate(Vector3.up * SnakeRotationSpeed * Time.deltaTime * Input.GetAxis("Horizontal"));
        }

        for (int i = 1; i < SnakeBody.Count; i++)
        {
            CurrentSnakeBlock = SnakeBody[i];
            PreviousSnakeBlock = SnakeBody[i - 1];

            DistanceBetweenBodyParts = Vector3.Distance(CurrentSnakeBlock.position, PreviousSnakeBlock.position);

            Vector3 TargetLocation = PreviousSnakeBlock.position;

            TargetLocation.y = SnakeBody[0].position.y;

            float MoveToTargetSpeed = Time.deltaTime * DistanceBetweenBodyParts / BodyMinDistance * SnakeSpeed;

            if (MoveToTargetSpeed > 0.5f)
            {
                MoveToTargetSpeed = 0.5f;
            }

            CurrentSnakeBlock.position = Vector3.Slerp(CurrentSnakeBlock.position, TargetLocation, MoveToTargetSpeed);
            CurrentSnakeBlock.rotation = Quaternion.Slerp(CurrentSnakeBlock.rotation, PreviousSnakeBlock.rotation, MoveToTargetSpeed);
        }
    }

    void AddToSnake()
    {
        Transform NewSnakeBlock = (Instantiate(snakePrefab, SnakeBody[SnakeBody.Count - 1].position, SnakeBody[SnakeBody.Count - 1].rotation) as GameObject).transform;

        NewSnakeBlock.SetParent(transform);

        SnakeBody.Add(NewSnakeBlock);
    }
}
