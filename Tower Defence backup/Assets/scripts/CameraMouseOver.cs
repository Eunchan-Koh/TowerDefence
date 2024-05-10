using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMouseOver : MonoBehaviour
{
    public GameObject createTile;
    Vector3 resetPos;
    void Start(){
        resetPos = new Vector3(-13, -4);
    }
    void OnMouseOver(){
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        int x = (int)Mathf.Round(mousePos.x);
        int y = (int)Mathf.Round(mousePos.y);
        Vector2 newPos = new Vector2(x,y);
        // Debug.Log("mouse over! " + newPos);
        RaycastHit2D hit = Physics2D.Raycast(newPos, Vector2.zero,0,LayerMask.GetMask("tower"));
        if(hit.collider != null){
            Debug.Log("there is a tower!");
        }else{
            Debug.Log("can build here!");
            createTile.transform.position = newPos;
        }
    }
    void OnMouseExit()
    {
        //The mouse is no longer hovering over the GameObject so output this message each frame
        createTile.transform.position = resetPos;
        Debug.Log("Mouse is no longer on GameObject.");
    }
}
