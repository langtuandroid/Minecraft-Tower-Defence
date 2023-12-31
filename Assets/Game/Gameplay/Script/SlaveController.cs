using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class SlaveController : MonoBehaviour
{
    private TreeController target;
    [SerializeField] private Animator anim;
    private Tween _tween1;
    [SerializeField] private BeController beController;
    private int level;
    public void Init(int lv, TreeController tg, BeController be)
    {
        level = lv;
        target = tg;
        beController = be;
        Farm();
    }
    private void Start()
    {
        
    }

    
    private void Update()
    {
        if (target.gameObject.activeSelf)
            return;
        Farm();
    }

    private void Farm()
    {
        switch (level)
        {
            case 1:
            {
                if (beController.listTree1.Count == 0)
                    beController.BornTree(1);
                else target = beController.listTree1[0];
                break;
            }
            case 2:
                if (beController.listTree2.Count == 0)
                    beController.BornTree(2);
                else target = beController.listTree2[0];
                break;
        }

        _tween1.Kill();
        _tween1 = transform.DOMove(target.transform.position, 5f);
        transform.LookAt(target.transform);
        anim.SetTrigger("Run");
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Tree")) return;
        _tween1.Kill();
        target = other.GetComponent<TreeController>();
        anim.SetTrigger("Chopping");
    }
}
