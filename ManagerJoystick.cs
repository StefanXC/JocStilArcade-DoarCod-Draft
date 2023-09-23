using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ManagerJoystick : MonoBehaviour ,IDragHandler, IPointerDownHandler, IPointerUpHandler
{

    private Image joystickBGIMG;
    private Image joystickIMG;

    private Vector2 posInput;


    // Start is called before the first frame update
    void Start()
    {
        joystickBGIMG = GetComponent<Image>();
        joystickIMG = transform.GetChild(0).GetComponent<Image>();
    }

   public void OnDrag(PointerEventData eventData)
    {
        if(RectTransformUtility.ScreenPointToLocalPointInRectangle(
            joystickBGIMG.rectTransform,
            eventData.position,
            eventData.pressEventCamera,
            out posInput))
        {
            posInput.x = posInput.x / (joystickBGIMG.rectTransform.sizeDelta.x);
            posInput.y = posInput.y / (joystickBGIMG.rectTransform.sizeDelta.y);

            Debug.Log(posInput.x.ToString() + " / " + posInput.y.ToString());

            //normalize

            if(posInput.magnitude > 1f)
            {
                posInput = posInput.normalized;
            }


            //joystick move
            joystickIMG.rectTransform.anchoredPosition = new Vector2(
                posInput.x * (joystickBGIMG.rectTransform.sizeDelta.x) / 4,
                posInput.y * (joystickBGIMG.rectTransform.sizeDelta.y) / 4);
        }
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        posInput = Vector2.zero;
        joystickIMG.rectTransform.anchoredPosition = Vector2.zero;
    }

    public float inputHorizontal()
    {
        if (posInput.x != 0)
            return posInput.x;
        else
            return Input.GetAxis("Horizontal");
    }

    public float inputVertical()
    {
        if (posInput.y != 0)
            return posInput.y;
        else
            return Input.GetAxis("Vertical");
    }
}
