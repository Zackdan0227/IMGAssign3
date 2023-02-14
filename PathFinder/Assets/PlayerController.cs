using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace ClickToMove
{
    public class PlayerController : MonoBehaviour
    {
        // Start is called before the first frame update
        static bool _IsWalking = false;
        public static bool IsWalking
        {
            get{return _IsWalking;}

        }
        
        public NavMeshAgent agent;
        private bool plant = false;
        // Update is called once per frame
        void Update()
        {
            
            if(Input.GetMouseButtonDown(1))
            {
                Ray movePosition = Camera.main.ScreenPointToRay(Input.mousePosition);
                if(Physics.Raycast(movePosition, out var hitInfo))
                {
                    agent.SetDestination(hitInfo.point);
                    
                    _IsWalking = true;
                }
            }
             if (!agent.pathPending)
            {
                if (agent.remainingDistance <= agent.stoppingDistance)
                    {
                        if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                            {
                                _IsWalking = false;
                            }
                    }
            }
            // print(_IsWalking);
            // }
        }
    }
}