using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{

    public Animator anim;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightControl))
        {
            FadeToScene();
        }
    }
    public void FadeToScene()
    {
        anim.SetTrigger("FadeOut");
        
    }
}
