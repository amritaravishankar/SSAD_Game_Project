using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;


public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{

    public void OnPointerEnter(PointerEventData eventData) {
        //Debug.Log("OnPointerEnter");
    }

    public void OnPointerExit(PointerEventData eventData) {
        //Debug.Log("OnPointerExit");
    }

    public void OnDrop(PointerEventData eventData) { //to drop the dragged object in a particular region
        Debug.Log(eventData.pointerDrag.name + " was dropped on " + gameObject.name);

        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        if(d != null) {
            d.parentToReturnTo = this.transform;
        }


    }



















    // // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }
}
