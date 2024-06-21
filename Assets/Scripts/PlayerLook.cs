using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLoop : MonoBehaviour
{
  [Space]
  [SerializeField] private float mouseSensitivity = 1f;
  [SerializeField] private float smooth = 2f;
  [Space]
    [SerializeField] private float minClamp = -40f;
    [SerializeField] private float maxClamp = 90f;
  

   private Transform character;
   private Vector2 currentMouseLook;
   private Vector2 appliedMouseDelta;


    private void Start()
    {
        character = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update()
    {
        var smoothMouseDelta = Vector2.Scale(new Vector2(Input.GetAxisRaw("Mouse X"),
            Input.GetAxisRaw("Mouse Y")), Vector2.one * mouseSensitivity * smooth);

        appliedMouseDelta = Vector2.Lerp(appliedMouseDelta, smoothMouseDelta, 1 / smooth);

        currentMouseLook += appliedMouseDelta;
        currentMouseLook.y = Mathf.Clamp(currentMouseLook.y, minClamp, maxClamp);

        character.localRotation = Quaternion.AngleAxis(currentMouseLook.x, Vector3.up);
        transform.localRotation = Quaternion.AngleAxis(-currentMouseLook.y, Vector3.right);


    }
}
