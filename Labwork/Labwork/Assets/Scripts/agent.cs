using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class agent : MonoBehaviour
{
    public stateManager sm;

    public IdleState idle;

    public WanderState wander;

    public seekState seek;

    sensors s;
  
    bool state_change = false;
    void Start()
    {
        sm = new stateManager();
        idle = new IdleState(this, sm);
        wander = new WanderState(this, sm);
        seek = new seekState(this, sm);
        sm.Init(idle);
        s = this.gameObject.GetComponent<sensors>();
    }

    public void Move(float speed, Vector3 wp)
    {
        Vector3 targetVelocity = speed * this.transform.forward * Time.deltaTime;
        this.transform.LookAt(wp);
        this.transform.Translate(targetVelocity, Space.World);
    }
    // Update is called once per frame
    void Update()
    {
        sm.Update();
        if((s.Hit == true) && (sm.getCurrState().GetType() != typeof(seekState)))
        {
            Debug.Log("Hit");
            sm.pushState(seek);
        }

        if ((s.Hit == false) && (sm.getCurrState().GetType() != typeof(WanderState)))
        {
            sm.pushState(wander);
        }
    }
}
