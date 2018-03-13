using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Entitas;
using DG.Tweening;

public class SecondaryNeedView : View, IGameTriggerListener
{
    [SerializeField]
    private RectTransform _image;
    [SerializeField]
    private NeedType _need;

    private Tween animation;

    public void OnTrigger (GameEntity entity, DurationType duration, bool state)
    {
        if (entity.hasNeed && _need == entity.need.type)
        {
            if (animation != null)
            {
                animation.Kill();
            }
            if (state == true)
            {
                Show();
            }
            else
            {
                Hide();
            }
        }
    }

    protected override void RegisterListeners (IEntity entity, IContext context)
    {
        var gameEntity = (GameEntity)entity;
        gameEntity.AddGameTriggerListener(this);
    }


    void Show ()
    {
        _image.GetComponent<Image>().enabled = true;
        animation = _image.DOShakeScale(3f).SetLoops(-1).Play();
    }

    void Hide ()
    {
        _image.GetComponent<Image>().enabled = false;
    }
}
