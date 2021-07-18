using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Vector3 direction;
    //hold our player's location
    public float speed;
    public float speedUp;
    public FloorSpawner groundSpawnerScript;

    public static bool isGameStarted;
    public static bool isFalling;

    void Start()
    {
        direction = Vector3.forward;
        isFalling = false;
        isGameStarted = false;
    }

    
    void Update()
    {
        if(transform.position.y<= 0.5f)
        {
            isFalling = true;
        }

        if (isFalling)
        {
            SceneManager.LoadScene(1);
            return;
            //this return helps us not to work other code part in this script
        }

        //when pressed to the screeen change the direction of ball
        //or controlling the player ZIGZAG game style

        if (Input.GetMouseButtonDown(0))
        {
            if(direction.x == 0)
            {
                direction = Vector3.left;
            }
            else
            {
                direction = Vector3.forward;
            }
            speed = speed + speedUp * Time.deltaTime;
        }


    }

    //to create movement we used fixedupdate
    private void FixedUpdate()
    {

        Vector3 move = direction * Time.deltaTime * speed;
        transform.position += move;
    }

    //when our ball exits the single square we are going to create a new one and add it to the last edge.
    private void OnCollisionExit(Collision collision)
    {
        ScoreController.score++;

        if(collision.gameObject.tag == "Ground")
        {
            collision.gameObject.AddComponent<Rigidbody>();

            groundSpawnerScript.createFloor();
            StartCoroutine(GroundRemove(collision.gameObject));
        }
    }

    //we want to remove old or passed grounds by time
    IEnumerator GroundRemove(GameObject RemovableGround)
    {
        yield return new WaitForSeconds(3f);
        Destroy(RemovableGround);
    }
}
