using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockEntity : MonoBehaviour
{
    public float speed = 1f;
    GameObject player;
    Vector3 playerPos;
    float rotSpeed = 3f;
    float neighbourDistance = 10f;
    bool turning = true;

    

    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(0.5f, 2f);
        player = GameObject.Find("Player");
        playerPos = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, playerPos) >= GlobalFlock.airSize)
        {
            turning = true;
        }
        else if (transform.position.y <= 10f)
        {
            turning = true;
        }
        else turning = false;
        if (turning)
        {
            Vector3 direction = (playerPos + new Vector3(0, Random.Range(10f, GlobalFlock.airSize)))-transform.position;
            transform.rotation = Quaternion.Slerp(transform.rotation,
                                                   Quaternion.LookRotation(direction),
                                                   rotSpeed * Time.deltaTime);
                                                   speed = Random.Range(0.5f, 3f);
        }

        if (Random.Range(0, 5) < 1)
        {
            GameObject[] goBirds;
            goBirds = GlobalFlock.birds;

            Vector3 vcentre = this.transform.position; //cohesion
            Vector3 vavoid = playerPos; // seperation

            float gSpeed = 0.5f;
            Vector3 goalPos = GlobalFlock.goalPos;

            float dist;
            int groupSize = 0;

            foreach(GameObject go in goBirds)
            {
                if(go != this.gameObject)
                {
                    dist = Vector3.Distance(go.transform.position, this.transform.position);
                    if(dist<= neighbourDistance)
                    {
                        vcentre += go.transform.position;
                        groupSize++;
                        if (dist < 6f)
                        {
                            vavoid = vavoid + (this.transform.position - go.transform.position);
                        }
                        FlockEntity anotherFlockEntity = go.GetComponent<FlockEntity>();
                        gSpeed = gSpeed + anotherFlockEntity.speed;
                    }
                }
            }
            if(groupSize >= 0)
            {
                vcentre = vcentre/groupSize+(goalPos - this.transform.position); //cohesion
                speed = (gSpeed / groupSize) + Random.Range(-0.1f, 0.1f);
                if (speed > 5f)
                {
                    speed = Random.Range(1f, 3f);
                }
                Vector3 direction = vcentre + vavoid - transform.position; //alignment

                transform.rotation = Quaternion.Slerp(transform.rotation,
                                     Quaternion.LookRotation(direction),
                                     rotSpeed * Time.deltaTime);

            }

        }
        transform.Translate(0, 0, Time.deltaTime * speed);
    }
}
