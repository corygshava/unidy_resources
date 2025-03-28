// this code was generated by chatGPT AI code generator
using UnityEngine;

public class ManipulateArray : MonoBehaviour
{
    // the array, you can change the type to any other you want, just be sure to update the function
    public GameObject[] items;

    public void editArray(GameObject[] who,GameObject what,string req){
        items = who;
        if(req == "add"){
            addtoArray(what);
        } else if(req == "remove"){
            removeFromArray(what);
        }
    }

    public void addtoArray(GameObject me){
        GameObject[] newArray = new GameObject[items.Length + 1];

        for(int x = 0; x <= items.Length;x++){
            if(x == items.Length){
                newArray[x] = me;
            } else {
                newArray[x] = items[x];
            }
        }

        items = newArray;
    }

    public void removeFromArray(GameObject me){
        int found = 0;
        GameObject[] newArray = new GameObject[items.Length - 1];

        for(int x = 0;x<items.Length;x++){
            if(items[x] == me){found += 1;}
            else if(found == 0){newArray[x] = items[x];}
            else {newArray[x] = items[x - found];}
        }

        if(found > 0){items = newArray;}
    }

    // ref from chatGPT
    /*
    public void AddElementToArray(int element, int index){
        if (index < 0 || index > myArray.Length)
        {
            Debug.LogError("Invalid index. Please enter a value between 0 and " + (myArray.Length - 1));
            return;
        }
        int[] newArray = new int[myArray.Length + 1];
        for (int i = 0; i < myArray.Length; i++)
        {
            if (i < index){
                newArray[i] = myArray[i];
            }
            else{
                newArray[i + 1] = myArray[i];
            }
        }
        newArray[index] = element;
        myArray = newArray;
    }

    public void RemoveElementFromArray(int index){
        if (index < 0 || index > myArray.Length - 1){
            Debug.LogError("Invalid index. Please enter a value between 0 and " + (myArray.Length - 1));
            return;
        }

        int[] newArray = new int[myArray.Length - 1];
        for (int i = 0, j = 0; i < myArray.Length; i++){
            if (i != index){
                newArray[j] = myArray[i];
                j++;
            }
        }

        myArray = newArray;
    }
    */
}
