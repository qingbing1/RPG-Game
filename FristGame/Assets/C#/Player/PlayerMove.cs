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
        animator = GetComponent<Animator>();// ��ȡ��ǰ��Ϸ�����ϵ�Animator���
        playerAgent = GetComponent<NavMeshAgent>();// ��ȡ��ǰ��Ϸ�����ϵ�NavMeshAgent���
    }

    // Update is called once per frame
    void Update()
    {
        //�������������û�е��UIԪ��
        if (Input.GetMouseButtonDown(0) && EventSystem.current.IsPointerOverGameObject()==false)
        {
            //��������һ������
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
            // �ƶ���ֹ
            animator.SetBool("Run",false);
        }
        else if(playerAgent.pathPending)
        {
            animator.SetBool("Run", true);
        }
    }

}