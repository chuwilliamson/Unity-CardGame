using System;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardBehaviour : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private TextMesh textComponent;

    private TextVariable _info;

    private void Start()
    {
        _info = new TextVariable
        {
            Value = textComponent.text,
            
        };
        
        _info.PropertyChanged += NpcOnPropertyChanged;
    }

    private void NpcOnPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        var prop = sender as TextVariable;
        textComponent.text = prop?.Value;
    }

    
    

    public void OnBeginDrag(PointerEventData eventData)
    {
        _info.Value = "Begin Drag";
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _info.Value = "End Drag";
    }

    public void OnDrag(PointerEventData eventData)
    {
        var cam = Camera.main;
        if (cam == null)
        {
            Debug.Log("no camera");
            return;
        }

        _info.Value = "Dragging";
        //convert from world to screen
        var screenPoint = cam.WorldToScreenPoint(transform.position);
        //apply the delta in screen space
        var newPosition =screenPoint += new Vector3(eventData.delta.x, eventData.delta.y, 0);
        //convert back to world from screen
        transform.position = cam.ScreenToWorldPoint(newPosition);

    }
}