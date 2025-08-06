using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragItem : SaiMonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    //[Header("UI Drag Item")]
    //[Header("Stat")]
    //[SerializeField] protected float backSpeed = 1;
    [SerializeField] protected Image image;
    [SerializeField] protected Transform realParent;
    public virtual Transform GetRealParent()
    {
        return this.realParent;
    }
    public virtual void SetRealParent(Transform realParent)
    {
        this.realParent = realParent;   
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadImage();
    }
    protected virtual void LoadImage()
    {
        if (this.image != null) return;
        this.image = GetComponent<Image>();
        Debug.LogWarning(transform.name + ": LoadImage", gameObject);
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log(transform.name + ": Begin Drag", transform.gameObject);
        this.realParent = transform.parent;
        transform.SetParent(UIHotKeyCtrl.Instance.transform);
        this.image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log(transform.name + ": On Drag", transform.gameObject);
        this.FollowMouse();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log(transform.name + ": End Drag", transform.gameObject);
        transform.SetParent(this.realParent);
        this.image.raycastTarget = true;
            
    }
    //===========================================Follow===========================================
    protected virtual void FollowMouse()
    {
        Vector3 mousePos = InputManager.Instance.MouseWorldPos;
        mousePos.z = 0;
        transform.position = mousePos;
    }

    //protected virtual void BackToSlot()
    //{
    //    Vector3 itemSlotPos = transform.parent.position;
    //    Vector3 newPos = Vector3.Lerp(transform.position, itemSlotPos, backSpeed * Time.deltaTime);
    //    transform.position = newPos;

    //    float distance = Mathf.Sqrt(Mathf.Pow(newPos.x - itemSlotPos.x, 2) + Mathf.Pow(newPos.y - itemSlotPos.y, 2));
    //    float error = 0.1f;

    //    if (distance > error) Invoke(nameof(BackToSlot), Time.fixedDeltaTime);
    //    else transform.position = transform.parent.position;
    //}


}
