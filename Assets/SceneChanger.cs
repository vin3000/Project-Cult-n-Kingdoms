using UnityEngine;

public class SceneChanger : MonoBehaviour
{

    public Animator anim;

    // Update is called once per frame
    void Update()
    {
       
    }
    public void FadeToScene(int SceneIndex)
    {
        anim.SetTrigger("FadeOut");
    }
}
