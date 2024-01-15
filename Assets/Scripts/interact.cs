using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IInteractable {
    public void Interact();
}
    
public class interact : MonoBehaviour
{
    public Transform interactsource;
    public float interactRange;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per framef12cä <zxsdfip,.jkm 
    void Update() {
        if (Input.GetKeyDown(KeyCode.E)) {
            Ray r = new Ray(interactsource.position, interactsource.forward);
            if (Physics.Raycast(r, out RaycastHit hitInfo, interactRange)) {
                if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interacObj)) {
                    interacObj.Interact();
                  }
              }
          }
      }
}
