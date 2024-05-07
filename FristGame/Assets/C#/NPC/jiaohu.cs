using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class jiaohu : MonoBehaviour
{
    private NavMeshAgent playerAgent;
    private bool haveInteracted = false;
    public void OnClick(NavMeshAgent playerAgent) 
    {
        this.playerAgent = playerAgent;
        playerAgent.stoppingDistance = 2;
        playerAgent.SetDestination(transform.position);
        haveInteracted = false;
    }
 
    private void Update()
    {
        if (playerAgent != null && haveInteracted == false && playerAgent.pathPending == false)
        {
            if (playerAgent.remainingDistance <= 2)
            {
                Interact();
                haveInteracted = true;
            }
        }
        
    }
    protected virtual void Interact()
    {
        Debug.Log("fuck");
    }

}
