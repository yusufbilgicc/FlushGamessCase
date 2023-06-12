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

    public float gemUpTime;

    public Sequence _seq;

    private Sequence Seq
    {
        get => _seq;
        set
        {
            _seq = value;
            _seq = DOTween.Sequence();
            Seq.Append(transform.DOMoveY(.15f, gemUpTime).SetEase(Ease.Linear)).SetLoops(-1, LoopType.Yoyo);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Seq.Kill();
        }
    }

    public void StartGrow()
    {
        DOTween.To(() => gemModel.localScale, x => gemModel.localScale = x, Vector3.one, gemData.growTime).OnComplete(
            OnGrownComplete);
    }

    private void StartTween()
    {
        Seq = _seq;
        Seq.Play();
    }

    public void KillTween()
    {
        Seq.Kill();
    }
    public void OnGrownComplete()
    {
        StartTween();
        myCol.enabled = true;
    }
    private void OnCollected()
    {
        myGrid.StartSpawnProcess();
        KillTween();
        transform.DOMoveY(0, 0).OnComplete(() =>
        {
            PlayerCollectList.On_AddList(this);
            PlayerCollectList.On_PlaceGem(this);
        });
    }

   
    public virtual void ITrig()
    {
        myCol.enabled = false;
        OnCollected();
    }
}