using UnityEngine;
using System.Collections;
using Spine.Unity;
using Spine;
using Spine.Unity.Modules.AttachmentTools;

public class SpineCharacterAccessories : MonoBehaviour, IApplySprite
{
    public SkeletonAnimation skeletonAnimation;

    [SpineSkin(dataField: "skeletonAnimation")]
    public string _originalSkin;
    [SerializeField]
    private Material _originalMaterial;

    [Header("Accessories")]

    [SpineSlot(dataField: "skeletonAnimation")]
    public string headSlot;
    [SpineAttachment(dataField: "skeletonAnimation")]
    public string headKey;

    [SpineSlot(dataField: "skeletonAnimation")]
    public string bodySlot;
    [SpineAttachment(dataField: "skeletonAnimation")]
    public string bodyKey;

    [SpineSlot(dataField: "skeletonAnimation")]
    public string footSlot;
    [SpineAttachment(dataField: "skeletonAnimation")]
    public string footKey;

    Material runtimeMaterial;
    Texture2D runtimeAtlas;
    static Skin _customSkin;

    public void Apply (Sprite accessory, AccessoryType type)
    {
        switch (type)
        {
            case AccessoryType.HEAD:
                ApplyToSpine(accessory, headSlot, headKey);
                break;
            case AccessoryType.BODY:
                ApplyToSpine(accessory, bodySlot, bodyKey);
                break;
            case AccessoryType.FOOT:
                ApplyToSpine(accessory, footSlot, footKey);
                break;
            default:
                //do nothing
                break;
        }
    }

    void ApplyToSpine (Sprite accessory, string slot, string key)
    {
        var skeleton = skeletonAnimation.Skeleton;

        if (_customSkin == null)
        {
            _customSkin = new Skin("custom skin");
        }

        var templateSkin = skeleton.data.FindSkin(_originalSkin);

        int index = skeleton.FindSlotIndex(slot);

        Attachment templateAttachment = templateSkin.GetAttachment(index, key);

        if (accessory != null)
        {
            Attachment newAttachment = templateAttachment.GetRemappedClone(accessory, _originalMaterial);
            _customSkin.SetAttachment(index, key, newAttachment);
        }
        else
        {
            _customSkin.SetAttachment(index, key, templateAttachment);
        }

        var repackedSkin = new Skin("repacked skin");
        repackedSkin.Append(skeleton.Data.DefaultSkin);
        repackedSkin.Append(_customSkin);

        repackedSkin = repackedSkin.GetRepackedSkin("repacked skin", _originalMaterial, out runtimeMaterial, out runtimeAtlas);
        skeleton.SetSkin(_customSkin);


        skeleton.SetSlotsToSetupPose();
        skeletonAnimation.Update(0);

        Resources.UnloadUnusedAssets();
    }
}
