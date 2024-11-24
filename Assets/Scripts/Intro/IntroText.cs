using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class IntroText : MonoBehaviour
{
    private TMP_Text text;
    private string first_string = "오래전 왕국에 한 여자가 살고있었습니다. \n여느 때와 같던 어느날 여자에게 신의 빛이 비추어 내려왔습니다. \n신께서 말씀하시길, \n\"나의 어린 양아, 내 부름을 받아 세상에 가장 강력한 무기를 얻어라. \n그리고 악마들의 소굴로 들어가 너의 운명을 이루거라.\"";
    private string second_string = "이에 여자는 할아버지의 유산인 갑옷을 차려입고 \n모험을 떠나기 시작합니다. 그렇게 산을 넘고 강을 건너 \n험난한 여정끝에 무기가 있는 곳에 도달했습니다.\n신의 빛에 비추어지는 무기의 모습은....";
    private string third_string = " 철로된 톱니바퀴? 뭔가 잘못되었는데? \n신님 이거 무기 배송오류 났는데요? 어라... \n여자는 항의를 해보지만... 아쉬운거죠. 잘하겠죠 뭐.";

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
        StartCoroutine(ShowThirdString());
    }

    private IEnumerator ShowThirdString()
    {
        text.text = third_string;
        text.DOFade(1, 1f);
        yield return new WaitForSeconds(5);
        text.DOFade(0, 1f);
        // 스테이지 시작
    }
}
