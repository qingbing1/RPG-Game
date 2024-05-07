using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class PlayerMove : MonoBehaviour
{
    private Animator animator;
    private NavMeshAgent playerAgent;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();// 获取当前游戏对象上的Animator组件
        playerAgent = GetComponent<NavMeshAgent>();// 获取当前游戏对象上的NavMeshAgent组件
    }

    // Update is called once per frame
    void Update()
    {
        //点击鼠标左键并且没有点击UI元素
        if (Input.GetMouseButtonDown(0) && EventSystem.current.IsPointerOverGameObject()==false)
        {
            //摄像机射出一条射线
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            bool isCollide = Physics.Raycast(ray, out hit);
            if (isCollide)
            {
                if (hit.collider.tag == "Ground")
                {
                    playerAgent.stoppingDistance = 0.1f;
                    playerAgent.SetDestination(hit.point);
                    
                }
                else if (hit.collider.tag == "Character")
                {
                    hit.collider.GetComponent<jiaohu>().OnClick(playerAgent);
                }
            }
        }
        if (!playerAgent.pathPending && playerAgent.remainingDistance < playerAgent.stoppingDistance)
        {
            // 移动终止
            animator.SetBool("Run",false);
        }
        else if(playerAgent.pathPending)
        {
            animator.SetBool("Run", true);
        }
    }

}