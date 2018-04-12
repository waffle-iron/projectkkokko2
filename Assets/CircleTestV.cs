using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CircleTestV : MonoBehaviour
{

    [SerializeField]
    private Image _outer;
    [SerializeField]
    private Image _safe;
    [SerializeField]
    private Image _inner;

    public float innerEdge = 100;
    public float outerEdge = 300;

    [Range(0f, 1f)]
    public float current = 1f;
    [Range(0f, 1f)]
    public float safe = .2f;

    public float timer = 3f;
    public Ease ease;

    private float initialDistance = 0f;
    private float currTime = 0f;

    private void Start ()
    {
        ResizeXY(_outer, new Vector2(outerEdge, outerEdge));
        ResizeXY(_inner, new Vector2(innerEdge, innerEdge));

        initialDistance = outerEdge - innerEdge;

        currTime = timer;

        var safeDistance = (initialDistance * safe) + innerEdge;
        ResizeXY(_safe, new Vector2(safeDistance, safeDistance));

        _outer.rectTransform.DOSizeDelta(_inner.rectTransform.sizeDelta, timer)
            .SetEase(ease).Play();
    }

    // Update is called once per frame
    void Update ()
    {
        //current = (currTime / timer);

        //var currDistance = (initialDistance * current) + innerEdge;
        //ResizeXY(_outer, new Vector2(currDistance, currDistance));

        //currTime -= Time.deltaTime;
        //currTime = Mathf.Clamp(currTime, 0f, timer);
    }

    void ResizeXY (Image image, Vector2 value)
    {
        image.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, value.x);
        image.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, value.y);
    }

    void AnchorStretchAll (Image image)
    {
        image.rectTransform.anchorMin = Vector2.zero;
        image.rectTransform.anchorMax = Vector2.one;
    }

    void AnchorMiddleCenter (Image image)
    {
        image.rectTransform.anchorMin = new Vector2(.5f, .5f);
        image.rectTransform.anchorMax = new Vector2(.5f, .5f);
    }
}
