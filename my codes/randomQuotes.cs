using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomQuotes : MonoBehaviour
{
    // it does exactly what you think it does
    // Hi this script displays random quotes onto a UI text object

    public string[] quotes = new string[]{"quote1","quote2"};
    public int quoteid;

    [Header("runtime data")]
    public GameObject displayTxt;
    public string quote;

    [Header("switches")]
    public bool pick = true;
    public bool runOnEnable = false;
    public bool runOnAwake = true;
    public bool showNumberInstead = false;

    // Start is called before the first frame update
    void Start(){
        if(runOnAwake){pick = true;}
    }

    private void OnEnable() {
        if(runOnEnable){pick = true;}
    }

    // Update is called once per frame
    void Update(){
        if(pick){pick = false;pickOne();}
    }

    public void pickOne(){
        int res = 0;
        if(showNumberInstead){
            // in case the user knows what he/she is doing
            // it allows one to display a random number from a range, either preset or user defined

            string[] wads = new string[]{"0","100"};
            if(quotes.Length >= 1){
                if(quotes[0] != ""){
                    wads = cm.splitTxt("|",quotes[0]);
                }
            }

            quote = "" + (Random.Range(int.Parse(wads[0]),int.Parse(wads[1])));
        } else {
            // displays a random quote from the list of given quotes

            if(quotes.Length > 0){
                do{
                    res = Random.Range(0,quotes.Length);
                } while(res >= quotes.Length);

                quoteid = res;
                quote = quotes[quoteid];
            } else {
                quote = "add a quote to display correctly";
            }
        }

        if(displayTxt != null){cm.seTxt(displayTxt,quote);}
    }
}
