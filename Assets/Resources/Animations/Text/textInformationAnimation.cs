using UnityEngine;
using UnityEngine.UI;

public class textInformationAnimation : MonoBehaviour {
    public Animator animator;

    public Text text;

	void Start () {
        text.gameObject.SetActive(true);
        AnimatorClipInfo[] clipInfo = animator.GetCurrentAnimatorClipInfo(0);
        Destroy(gameObject, clipInfo[0].clip.length);
	}

    public void setText(string message) {
        text.text = message;
    }
}
