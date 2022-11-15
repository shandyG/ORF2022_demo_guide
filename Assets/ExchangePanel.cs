using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExchangePanel : MonoBehaviour
{
    public GameObject AvatarFukidashi;
    public GameObject DisplayPanel;
    public GameObject ownDestination;
    public GameObject speechKeyRecognition;
    public GameObject TalkingAvatar;

    private Animator animator;

    public string ownDestinationName;
    private bool guide ;

    KeywordRecognition script;
    TargetTracking targetScript;
    ChangeAgentText caScript;

    // Start is called before the first frame update

    [SerializeField] private Transform _self;
    [SerializeField] private Transform _target;

    void Start()
    {
        caScript = AvatarFukidashi.GetComponent<ChangeAgentText>();
        script = speechKeyRecognition.GetComponent<KeywordRecognition>();
        targetScript = TalkingAvatar.GetComponent<TargetTracking>();
        

        animator = DisplayPanel.GetComponent<Animator>();

        guide = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "PlayerCube")
        {
            DisplayPanel.SetActive(true);
            caScript.ChangeText("こんにちは！案内しましょうか？");
            targetScript.TalkWithUser();
            Debug.Log("enter");
            _self.LookAt(_target);
            script.ChangeDestinationObj(ownDestinationName, TalkingAvatar);
            animator.SetBool("Active", true);
            

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "PlayerCube")
        {
            Debug.Log("exit");
            DisplayPanel.SetActive(false);
            AvatarFukidashi.SetActive(true);
            script.ChangeDestinationObj(null, TalkingAvatar);
            animator.SetBool("Active", false);

            if (!guide) // ガイド中は元のテキストには直さない
            {
                caScript.BackToOriginalText();
            }
        }
    }

    public void ChangeBoolGuide(bool answer)
    {
        guide = answer;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
