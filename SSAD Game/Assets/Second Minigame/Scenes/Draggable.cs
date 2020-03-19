using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;



public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    public Transform parentToReturnTo = null; 

    public void OnBeginDrag(PointerEventData eventData)  { //tasks that must occur when you start dragging the use case

        Debug.Log("OnBeginDrag");

        parentToReturnTo = this.transform.parent;
        this.transform.SetParent(this.transform.parent.parent);
        GetComponent<CanvasGroup>().blocksRaycasts=false;
        
    }

    public void OnDrag(PointerEventData eventData) //tasks that must occur when you are dragging the use case
    { 
        Debug.Log("OnDrag");

        this.transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData) //tasks that must occur when you stop dragging the use case

    {

        Debug.Log("OnEndDrag");

        this.transform.SetParent(parentToReturnTo);
        GetComponent<CanvasGroup>().blocksRaycasts=true;
    
    }
}
