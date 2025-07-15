using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RefreshHeighttByContent : MonoBehaviour
{
    [SerializeField] private GameObject ContentMaster;
    [SerializeField] private GameObject ContentChild;

    public float CantidadDeSuma;
    public float scrollSpeed;


    private void Update()
    {
        UpdateRectTransform(); 
    }


    void UpdateRectTransform() 
    {

        Vector2 sizeHijo = ContentChild.GetComponent<RectTransform>().sizeDelta;
        Vector2 sizePadre = ContentMaster.GetComponent<RectTransform>().sizeDelta;
        sizePadre.y = sizeHijo.y;
        ContentMaster.GetComponent<RectTransform>().sizeDelta = sizePadre; 

    }


    public void ChangePositionY() 
    {

        //add espacio para que el usuario pueda subir

        //Debug.Log(ContentMaster.GetComponent<RectTransform>().anchoredPosition);


        //Vector3 positionContent = ContentMaster.GetComponent<RectTransform>().anchoredPosition;
        //positionContent.y += CantidadDeSuma;
        //ContentMaster.GetComponent<RectTransform>().anchoredPosition = positionContent; 

        ScrollRect scrollRect = ContentMaster.GetComponentInParent<ScrollRect>();
        StartCoroutine(ScrollToBottom(scrollRect));

    }


    private IEnumerator ScrollToBottom(ScrollRect scrollRect)
    {
        yield return new WaitForFrames(2);

        //Canvas.ForceUpdateCanvases();

        //scrollRect.verticalNormalizedPosition = 0;

        //yield return null;
        while (scrollRect.verticalNormalizedPosition > 0.001f) // Use a small epsilon for float comparison
        {
            scrollRect.verticalNormalizedPosition = Mathf.Lerp(scrollRect.verticalNormalizedPosition, 0f, Time.deltaTime * scrollSpeed);
            yield return null;
        }
        scrollRect.verticalNormalizedPosition = 0f; // Snap to exact bottom at the very end

    }

    public class WaitForFrames : CustomYieldInstruction
    {
        private int _targetFrameCount;

        public WaitForFrames(int numberOfFrames)
        {
            _targetFrameCount = Time.frameCount + numberOfFrames;
        }

        public override bool keepWaiting
        {
            get
            {
                return Time.frameCount < _targetFrameCount;
            }
        }
    }
}
