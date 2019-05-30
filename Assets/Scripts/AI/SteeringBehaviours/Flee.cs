using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
[CreateAssetMenu(fileName = "Flee", menuName = "SteeringBehaviours/Flee", order = 1)]
public class Flee : SteeringBehaviours
{

    public float stoppingDistance = 1f;
    public override void OnDrawGizmosSelected(AI owner)
    {
        Gizmos.color = Color.red;
        float distance = Vector3.Distance(owner.target.position, owner.transform.position);
        Gizmos.DrawWireSphere(owner.target.position, distance - stoppingDistance);
    }
    public override Vector3 GetForce(AI owner)
    {
        //Create a value to return later
        Vector3 force = Vector3.zero;
        //Modify value here
        if (owner.hasTarget)
        {
            //Get direction from ai agent to target
            force += owner.transform.position - owner.target.position;
        }
        //Return value
        return force.normalized;
    }
}
