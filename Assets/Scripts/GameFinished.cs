using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameFinished : MonoBehaviour
{
    [SerializeField] private GameObject gameFinishedPanel;

    [SerializeField] private Animator gameFinishedAnim, star1Anim, star2Anim, star3Anim, textAnim;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //ShowGameFinishedPanel(3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowGameFinishedPanel(int stars)
    {

        StartCoroutine(ShowPanel(stars));
    }

    public void HideGameFinishedPanel()
    {
        if(gameFinishedPanel.activeInHierarchy)
        {
            StartCoroutine(HidePanel());
        }
    }

    IEnumerator ShowPanel(int stars)
    {
        gameFinishedPanel.SetActive(true);
        gameFinishedAnim.Play("FinishPanelFadeIn");
        yield return new WaitForSeconds(1.7f);

        switch (stars)
        {
            case 1:

                star1Anim.Play("FinishPanelStarFadeIn");
                yield return new WaitForSeconds(0.1f);
                textAnim.Play("FinishPanelTextFadeIn");
                break;

            case 2:
                star1Anim.Play("FinishPanelStarFadeIn");
                yield return new WaitForSeconds(0.25f);

                star2Anim.Play("FinishPanelStarFadeIn");
                yield return new WaitForSeconds(0.1f);

                textAnim.Play("FinishPanelTextFadeIn");
                break;

            case 3:
                star1Anim.Play("FinishPanelStarFadeIn");
                yield return new WaitForSeconds(0.25f);

                star2Anim.Play("FinishPanelStarFadeIn");
                yield return new WaitForSeconds(0.25f);

                star3Anim.Play("FinishPanelStarFadeIn");
                yield return new WaitForSeconds(0.1f);

                textAnim.Play("FinishPanelTextFadeIn");
                break;
        }
    }

    IEnumerator HidePanel()
    {
        gameFinishedAnim.Play("FinishPanelFadeOut");
        star1Anim.Play("FinishPanelStarFadeOut");
        star2Anim.Play("FinishPanelStarFadeOut");
        star3Anim.Play("FinishPanelStarFadeOut");
        textAnim.Play("FinishPanelTextFadeOut");
        yield return new WaitForSeconds(1.5f);

        gameFinishedPanel.SetActive(false);
    }


}
