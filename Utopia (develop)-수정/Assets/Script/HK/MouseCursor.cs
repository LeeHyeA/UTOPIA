using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCursor : MonoBehaviour {

    // ���콺 �����ͷ� ����� �ؽ��� �Է� �ޱ�
    public Texture2D BasicCursorTexture;
    public Texture2D EyesCursorTexture;

    private Vector2 hotSpot = Vector2.zero;

    public bool bCursorChage = false;

    void Start()
    {
        hotSpot.x = 12.0f;
        hotSpot.y = 33.0f;
    }

    void Update()
    {
        /*
         * ������Ʈ�� �浹�� eyesĿ���� ����
         * �浹�� �ƴ� ���� basicĿ���� ����  
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
