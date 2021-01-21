using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinFollow : MonoBehaviour
{
    public static CoinFollow instance;


    Vector3 finalPos, pos;
    public float movementSpeed;
    public Transform destroyPosition;
    public void Start()
    {
        StartSetup();
       
    }
    public void FixedUpdate()
    {
        FixedUpdateSetup();
    }

    public void StartSetup()
    {
        instance = this;

        finalPos = destroyPosition.position;
        pos = transform.position;
    }
    public void FixedUpdateSetup()
    {
        transform.position = Vector3.Lerp(transform.position, pos, Time.deltaTime * movementSpeed);
    }
    public void CollisionDetection()
    {
        pos = finalPos;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        DestroyHere(collision);
    }
    public void DestroyHere(Collider2D collision)
    {
        if (collision.transform.tag == "DestroyHere")
        {
            Destroy(gameObject);
        }
    }

}
