using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mira : MonoBehaviour
{
    [SerializeField] Texture2D image;
    [SerializeField] int size;
    [SerializeField] float maxAngle;
    [SerializeField] float minAngle;
    float lookheight;
    public void LookHeight(float value){
        lookheight+=value;

        if(lookheight>maxAngle || lookheight<minAngle){
            lookheight -=value;
        }
    }

    void onGUI(){
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        screenPos.y = Screen.height -screenPos.y;
        GUI.DrawTexture(new Rect(screenPos.x, screenPos.y-lookheight, size, size), image);
        
    }
}
