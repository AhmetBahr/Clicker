using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FlyingAdmob : MonoBehaviour
{
    [Header("Flying Addmob")]
    [SerializeField] private float ObjectSpeed;
    [SerializeField] private Transform pivot1;
    [SerializeField] private Transform pivot2;
    [SerializeField] private Transform pivotObj;
    [SerializeField] private GameObject Addmob;


    GameManager gm;


   

    Sequence sq;

    private void Start()
    {
        gm = GameObject.Find("Manager").GetComponent<GameManager>();
        moveAddmobRight();
    }


    public void moveAddmobRight()
    {
        sq = DOTween.Sequence();

        sq.Append(transform.DOMove(pivot1.position, ObjectSpeed)).OnComplete(() => moveAddmobLeft());
    }

    public void moveAddmobLeft()
    {
        sq = DOTween.Sequence();

        sq.Append(transform.DOMove(pivot2.position, ObjectSpeed)).OnComplete(() => moveAddmobRight());
    }

    public void moveAddmobObj()
    {
        sq = DOTween.Sequence();

        sq.Append(transform.DOMove(pivotObj.position, ObjectSpeed));
    }

    public void moveStope()
    {
        moveAddmobObj();
        StartCoroutine(waitSec());
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }

    IEnumerator waitSec()
    {
        yield return new WaitForSeconds(1f);
        gm.PopupActive();
        Destroy();
    }

}
