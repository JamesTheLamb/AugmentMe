using UnityEngine;
using System.Collections;

public class Collision : MonoBehaviour {

    //for this to work both need colliders, one must have rigid body (spaceship) the other must have is trigger checked.
    void OnTriggerEnter(Collider col)
    {

        Destroy(col.gameObject);


        if (GameObject.FindGameObjectsWithTag("Player").Length == 0)
        {

            GameObject enemy = Instantiate(Resources.Load("enemy", typeof(GameObject))) as GameObject;
            GameObject enemy1 = Instantiate(Resources.Load("enemy1", typeof(GameObject))) as GameObject;
            GameObject enemy2 = Instantiate(Resources.Load("enemy2", typeof(GameObject))) as GameObject;
            GameObject enemy3 = Instantiate(Resources.Load("enemy3", typeof(GameObject))) as GameObject;

        }

        Destroy(gameObject);


    }
}
