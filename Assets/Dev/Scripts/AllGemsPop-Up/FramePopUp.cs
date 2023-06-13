using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class FramePopUp : MonoBehaviour
{
   public GameObject popUp;
   public float openTime;
   public GameObject openButton;


   private void OpenPopUp()
   {
      openButton.transform.DOScale(Vector3.zero, 0.5f).SetEase(Ease.InBounce);
      popUp.transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.InCirc);

   }

   private void ClosePopUp()
   {
      openButton.transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutBounce);
      popUp.transform.DOScale(Vector3.zero, 0.5f).SetEase(Ease.OutCirc);

   }
    
   public void PopUpCloseButton()
   {
      ClosePopUp();
   }

   public void PopUpOpenButton()
   {
      OpenPopUp();
   }
}
