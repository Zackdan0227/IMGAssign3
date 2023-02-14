using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ClickToMove;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI text_State;
    [SerializeField]
    GameObject Player;
    [SerializeField]
    Animator anim;
    public GameObject checkPlant;
    
    bool isWalking;
    string state;
    bool bomb = false;
    string norm = "idle";
    string plant = "planting";

    string Walking = "walking";
    void Start() 
    {
        anim = gameObject.GetComponent<Animator>();
        state = norm;
    }
    
    void Update()
    {
        
        isWalking = ClickToMove.PlayerController.IsWalking;
        // string animName = anim.GetCurrentAnimatorStateInfo(0).name;
        // if(anim != null)
        // {
            if(isWalking){
               anim.SetBool("IsWalking", true);
               anim.SetBool("Planting", false);
               state = Walking;
            }else if (!isWalking){
                anim.SetBool("IsWalking", false);
                state = norm;
                if(checkPlant == null)
                checkPlant = GameObject.FindGameObjectWithTag("Bomb");

                
                    
                    float distance = Vector3.Distance (checkPlant.transform.position, Player.transform.position);
                    if(distance < 4f){
                        print("can plant");
                        bomb = true;
                        anim.SetBool("Planting", true);
                        state = plant;
                    }
                
                
            }
            
        // }
        
        text_State.text = "Player State = " + state ;
        
    }
}
