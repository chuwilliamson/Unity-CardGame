using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Chuwilliamson
{
    public class CardBehaviour : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
    {
        private Camera _cam;
        private TextVariable _info;
        public AnimationCurve ac;
        public Vector3 startPosition;
        [SerializeField] private TextMesh textComponent;
        private bool BlockingInput { get; set; }

        public void OnBeginDrag(PointerEventData eventData)
        {
            if (BlockingInput)
                return;
            eventData.pointerDrag = gameObject;
            eventData.Use();
            _info.Value = "Begin Drag";
            startPosition = transform.position;
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (BlockingInput)
                return;
            eventData.Use();
            _info.Value = "Dragging";
            //convert from world to screen
            var screenPoint = _cam.WorldToScreenPoint(transform.position);
            //apply the delta in screen space
            var newPosition = screenPoint += new Vector3(eventData.delta.x, eventData.delta.y, 0);
            //convert back to world from screen
            transform.position = _cam.ScreenToWorldPoint(newPosition);
        }
        
        private IDamager _damager;


        public void OnEndDrag(PointerEventData eventData)
        {
            if (BlockingInput)
                return;

            StartCoroutine(MoveBack(startPosition));

            //go through the event systems currently hovered object
            var hovered = eventData.hovered;

          //  NewMethod(hovered);
            NewMethod(GetComponent<ListBehaviour>().GameObjects); 
            
            _info.Value = "End Drag";

            eventData.Use();
        }

        private void NewMethod(List<GameObject> hovered)
        {
            var hoveredchildren = new List<Transform>();


            foreach (var h in hovered)
            {
                var transforms = h.GetComponentsInChildren<Transform>();
                hoveredchildren.AddRange(transforms);
            }

            foreach (var go in hoveredchildren)
            {
                var damageable = go.GetComponent<IDamageable>();
                if (damageable == null)
                    continue;
                _damager.DoDamage(damageable);
            }
        }

        private IEnumerator MoveBack(Vector3 destination)
        {
            BlockingInput = true;
            var currentTime = 0.0f;
            var totalTime = ac.keys[ac.length - 1].time;
            var start = transform.position;

            while (currentTime <= totalTime)
            {
                currentTime += Time.deltaTime;

                transform.position = Vector3.Lerp(start, destination, ac.Evaluate(currentTime));


                yield return null;
            }

            BlockingInput = false;
        }

        [SerializeField] private IntVariable attackVariable;

        private void Start()
        {
            attackVariable = Instantiate(attackVariable);
            _damager = new Damager() { Value = attackVariable.Value };
            _cam = Camera.main;
            _info = new TextVariable
            {
                Value = textComponent.text
            };

            _info.PropertyChanged += NpcOnPropertyChanged;
        }
        
        private void NpcOnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var prop = sender as TextVariable;
            textComponent.text = prop?.Value;
        }
    }
}