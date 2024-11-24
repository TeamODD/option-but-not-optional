using UnityEngine;
using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class EndingText : MonoBehaviour
{
    private TMP_Text text;
    private string first_string = "동물들의 방해를 벗어나 겨우 악마의 소굴에 도달한 용사는\n인근 주민의 신고를 받고온 경찰들에 의해 연행되고 만다.";
    private string second_string = "죄목은 동물학대였으며, 용사는 자신의 무죄를 주장한다.\n끌려가는 용사를 끝으로\n오늘도 \"오래전\" 왕국은 평화로운 하루를 보낸다.";
    private List<string> work = new List<string> { "기획", "그래픽", "프로그래밍", "용병" };
    private List<string> workername = new List<string> { "김지현", "김지성", "권예준, 이상원", "박기범" };

    private void Awake()
    {
        text = this.GetComponent<TMP_Text>();
    }
    private void Start()
    {
        text.color = new Color(1, 1, 1, 0);
        StartCoroutine(ShowFirstString());
    }

    private IEnumerator ShowFirstString()
    {
        text.text = first_string;
        text.DOFade(1, 1f);
        yield return new WaitForSeconds(5);
        text.DOFade(0, 1f);
        yield return new WaitForSeconds(1);
        StartCoroutine(ShowSecondString());
    }

    private IEnumerator ShowSecondString()
    {
        text.text = second_string;
        text.DOFade(1, 1f);
        yield return new WaitForSeconds(5);
        text.DOFade(0, 1f);
        yield return new WaitForSeconds(1);
        StartCoroutine(ShowEnding());
    }

    private IEnumerator ShowEnding()
    {
        text.text = "끝";
        text.fontSize = 10;
        text.DOFade(1, 1f);
        yield return new WaitForSeconds(5);
        text.DOFade(0, 1f);
        yield return new WaitForSeconds(1);
        StartCoroutine(ShowWorkers());
    }

    private IEnumerator ShowWorkers()
    {
        text.text = work[0] + " : " + workername[0] + "\n" + work[1] + " : " + workername[1] + "\n" + work[2] + " : " + workername[2] + "\n" + work[3] + " : " + workername[3];
        text.fontSize = 6;
        text.DOFade(1, 1f);
        yield return new WaitForSeconds(5);
        text.DOFade(0, 1f);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("StartMenuScene");
    }
}
