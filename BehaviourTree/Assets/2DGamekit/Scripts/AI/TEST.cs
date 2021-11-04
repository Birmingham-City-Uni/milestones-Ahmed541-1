using BTAI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


class People
{
    public string Name { get; set; }

    public Vector3 Position { get; set; }

    public People(string name, Vector3 pos)
    {
        this.Name = name;

        this.Position = pos;
    }

    public void Move(Vector3 offset)
    {
        Debug.Log("------>" + this.Name + " move " + offset);
        this.Position = this.Position + offset;
    }

    public float DistanceWithOtherPeople(People otherPeople)
    {
        float dis = Vector3.Distance(this.Position, otherPeople.Position);
        Debug.Log(this.Name + " " + this.Position + " and " + otherPeople.Name + " " + otherPeople.Position + " dis is:" + dis);
        return dis;
    }
}
public class TEST : MonoBehaviour
{
    Root ai;

    public GameObject person1, person2;

    People people1 = new People("Ahmed", new Vector3(-5, 0, 0));

    People people2 = new People("MP135", new Vector3(12, 0, 0));

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("AT BT Start");
        ai = BT.Root();
        ai.OpenBranch(
            BT.While(this.check).OpenBranch(
                BT.Selector(true).OpenBranch(
                    BT.Call(() => people1.Move(new Vector3(1, 0, 0))),
                    BT.Call(() => people2.Move(new Vector3(-1, 0, 0))),
                    BT.Call(() => people2.Move(new Vector3(-2, 0, 0))),
                    BT.Call(() => people2.Move(new Vector3(-3, 0, 0)))
                    )
                ),
            BT.Terminate()
            );
    }

    void getDistance()
    {
        people1.DistanceWithOtherPeople(people2);
    }

    bool check()
    {
        person1.transform.position = people1.Position;
        person2.transform.position = people2.Position;
        float dis = people1.DistanceWithOtherPeople(people2);
        if(dis > 30)
        {
            Debug.Log("People socially distanced, end");
            return false;
        }
        if (dis < 2)
        {
            Debug.Log("Do you want covid?, end");
            return false;
        }
        return true;


    }
    // Update is called once per frame
    void Update()
    {
        ai.Tick();
    }
}
