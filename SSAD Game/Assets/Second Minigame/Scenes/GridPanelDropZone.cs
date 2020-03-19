using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;


public class GridPanelDropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{

    public void OnPointerEnter(PointerEventData eventData)
    {
        //Debug.Log("OnPointerEnter");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //Debug.Log("OnPointerExit");
    }

    public void OnDrop(PointerEventData eventData) //to drop the dragged objects in a particular region
    {
        Image[] images = this.GetComponentsInChildren<Image>();

        if (images.Length > 2 == false) { //to make sure no grid panel has more than 2 use cases at one point in time
            Debug.Log(eventData.pointerDrag.name + " was dropped on " + gameObject.name);

            Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
            if (d != null)
            {
                d.parentToReturnTo = this.transform;
            }
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
