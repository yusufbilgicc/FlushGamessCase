using System;
using System.Collections;
using System.Collections.Generic;
using Dev.Scripts.Gem.GemData;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

public abstract class AGem : MonoBehaviour, ITrigger
{
    public GemData gemData;
    public GridController myGrid;
    public Transform gemModel;
    public Collider myCol;
    public float price;
    public float gemUpTime;
    public bool collectable;

    public Sequence moveMoveSeq;

    public Sequence growSeq;

    private Sequence GrowSeq
    {
        get => growSeq;
        set
        {
            growSeq = value;
            growSeq = DOTween.Sequence();
            growSeq.Append(DOTween.To(() => gemModel.localScale, x => gemModel.localScale = x, Vector3.one, gemData.growTime).OnUpdate(
                () =>
                {
                    if (gemModel.localScale.x >= 0.25f&& !collectable)
                    {
                        collectable = true;
                        myCol.enabled = true;

                    }
                }).OnComplete(OnGrownComplete));
        }
    }
    private Sequence MoveSeq
    {
        get => moveMoveSeq;
        set
        {
            moveMoveSeq = value;
            moveMoveSeq = DOTween.Sequence();
            MoveSeq.Append(transform.DOMoveY(.15f, gemUpTime).SetEase(Ease.Linear)).SetLoops(-1, LoopType.Yoyo);
        }
    }
    

   

    public void StartGrow()
    {
        GrowSeq = growSeq;
        GrowSeq.Play();
    }

    private void StartTween()
    {
        MoveSeq = moveMoveSeq;
        MoveSeq.Play();
    }

    public void KillTween()
    {
        MoveSeq.Kill();
        GrowSeq.Kill();
    }
    public void OnGrownComplete()
    {
        StartTween();
    }
    private void OnCollected()
    {
        myGrid.StartSpawnProcess();
        KillTween();
        SetGemPrice();
        transform.DOMoveY(0, 0).OnComplete(() =>
        {
            PlayerCollectList.On_AddList(this);
            PlayerCollectList.On_PlaceGem(this);
        });
    }


    public void SetGemPrice()
    {
        price = gemData.gemPrice+gemModel.localScale.x*100;
    }
    public virtual void ITrig()
    {
        myCol.enabled = false;
        
        OnCollected();
    }
}