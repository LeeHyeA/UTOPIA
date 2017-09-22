using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCursor : MonoBehaviour {

    // 마우스 포인터로 사용할 텍스쳐 입력 받기
    public Texture2D BasicCursorTexture;
    public Texture2D EyesCursorTexture;

    private Vector2 hotSpot = Vector2.zero;

    public bool bCursorChage = false;

    void Start()
    {
        hotSpot.x = 10.0f;
        hotSpot.y = 33.0f;
    }

    void Update()
    {
        /*
         * 오브젝트와 충돌시 eyes커서로 변경
         * 충돌이 아닐 때는 basic커서로 변경  
         */
        if (bCursorChage)
            Cursor.SetCursor(EyesCursorTexture, hotSpot, CursorMode.Auto);

        else
            Cursor.SetCursor(BasicCursorTexture, hotSpot, CursorMode.Auto);
    }


    public void PointerChange(bool active)
    {
        bCursorChage = active;
    }
}
