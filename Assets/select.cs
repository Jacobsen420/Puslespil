using UnityEngine;
 using UnityEngine.Events;
 using UnityEngine.EventSystems;
 
 public class select : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
  {
       public GameObject SpilBagrrund;

        public void OnPointerEnter(PointerEventData eventData)
    {
        SpilBagrrund.SetActive(true);
    }
 
    public void OnPointerExit(PointerEventData eventData)
    {
        SpilBagrrund.SetActive(false);
    }



     
  }