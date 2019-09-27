using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //This allows use of uGUI features.

public class Basket : MonoBehaviour
{
    [Header("Set Dynamically")]
    public Text scoreGT;
    // Start is called before the first frame update
    void Start()
    {
        //Find a reference to the ScoreCounter GameObject
        GameObject scoreGo = GameObject.Find("ScoreCounter");
        //Get the Text Component of that GameObject
        scoreGT = scoreGo.GetComponent<Text>();
        //Set the stating number of points to 0
        scoreGT.text = "0";

    }

    // Update is called once per frame
    void Update()
    {
        //Get the current screen position of the mouse form Input
        Vector3 mousePos2D = Input.mousePosition;

        //The Camera's position sets how far to push the mouse into 3D
        mousePos2D.z = -Camera.main.transform.position.z;

        //Convert the point from 2D screen space into 3D game world space
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        //Move the x positions of this Basket to this x position of the Mouse
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;

    }

    void OnCollisionEnter(Collision coll)
    {
        //Find out what hit this basket
        GameObject collideWith = coll.gameObject;
        if(collideWith.tag == "Apple")
        {
            Destroy(collideWith);
        }
        //Parse the text of the scoreGT into an int
        int score = int.Parse(scoreGT.text);
        //Add points for catching the Apple
        score += 100;
        //Convert the score back to a string and display it
        scoreGT.text = score.ToString();
    }

}
