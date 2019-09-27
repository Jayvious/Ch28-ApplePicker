using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{

    [Header("Set In Inspector")]

    //Prefab for instantiating apples
    public GameObject applePrefab;

    //Speed at which the AppleTree moves
    public float speed = 1f;


    //Distnace where AppleTree turnd around
    public float leftAndRightEdge = 10f;

    //Chance that the AppleTree will change directions
    public float chanceToChnageDirections = 0.1f;

    //Rate at which Apples will be instanianted
    public float secondsBetweenAppleDrops = 1f;

    // Start is called before the first frame update
    void Start()
    {
        //Dropping Apples every second
        Invoke("DropApple", 2f);
        
    }

    void DropApple()
    {
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position;
        Invoke("DropApple", secondsBetweenAppleDrops);
    }

    // Update is called once per frame
    void Update()
    {
        //Basic Movement
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        //Chnaging Direction
        if(pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed);//Move right
        } else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed); //Move left
        } 

    }


    void FixedUpdate()
    {
        if (Random.value < chanceToChnageDirections)
        {
            speed *= -1;
        }
    }
}
