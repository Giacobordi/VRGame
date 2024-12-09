using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnTrees : MonoBehaviour
{
    public GameObject little_tree;
    public GameObject medium_tree;
    public GameObject big_tree;
    public Animator animator;
    
    
    // Start is called before the first frame update
    void Start()
    {
        animator.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (alberoInteragibile.alberoATerra)
        {
            animator.SetBool("isCut", true);
        }
        else
        {
            animator.SetBool("isCut", false);
        }
    }

    public void spawnLittle()
    {
        medium_tree.SetActive(false);
        big_tree.SetActive(false);
        little_tree.SetActive(true);
    }

    public void spawnMedium()
    {
        little_tree.SetActive(false);
        medium_tree.SetActive(true);
        big_tree.SetActive(false);
    }

    public void spawnBig()
    {
        little_tree.SetActive(false);
        medium_tree.SetActive(false);
        big_tree.SetActive(true);
    }

    public void BigTreeInteraction()
    {
        
    }

}
