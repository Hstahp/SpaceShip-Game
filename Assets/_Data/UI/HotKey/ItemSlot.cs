using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : SaiMonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
        GameObject dropObj = eventData.pointerDrag;
        DragItem dragItem = dropObj.GetComponent<DragItem>();
        // Slot gốc (realParent) của item được kéo
        Transform sourceSlot = dragItem.GetRealParent();

        // Nếu slot này (slot thả vào) đã có item con
        if (transform.childCount > 0)
        {
            Transform targetItem = transform.GetChild(0); // item đang ở slot đích

            // Di chuyển item đang ở slot đích về slot gốc
            targetItem.SetParent(sourceSlot);
            targetItem.localPosition = Vector3.zero;

            // Cập nhật realParent cho DragItem của item đang ở slot đích
            DragItem targetDragItem = targetItem.GetComponent<DragItem>();
            if (targetDragItem != null)
            {
                targetDragItem.SetRealParent(sourceSlot);
            }
        }

        // Đưa item đang kéo vào slot này (slot đích)
        dragItem.SetRealParent(transform);
        dropObj.transform.SetParent(transform);
        dropObj.transform.localPosition = Vector3.zero;

    }
}
