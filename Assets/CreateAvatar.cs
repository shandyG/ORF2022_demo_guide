using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateAvatar : MonoBehaviour
{
    int start = 1;
    int end = 23;
    int count = 6;
    int num = 0;
    List<int> numbers = new List<int>();

    public GameObject[] PlaceObj = new GameObject[6];

    // Start is called before the first frame update
    void Start()
    {
        
        for (int i = start; i <= end; i++)
        {
            numbers.Add(i);
        }

        while (count-- > 0)
        {
            
            int index = Random.Range(0, numbers.Count);

            int ransu = numbers[index];
            Debug.Log(ransu);

            GameObject obj = (GameObject)Resources.Load("Avatar" + ransu);


            // プレハブを元にオブジェクトを生成する
            GameObject instance = (GameObject)Instantiate(obj,
                                                          PlaceObj[num].transform.position,
                                                          Quaternion.identity);


            num++;
            numbers.RemoveAt(index);
            
        }
        

        
        /*
        GameObject obj = (GameObject)Resources.Load("Avatar1");
        

        // プレハブを元にオブジェクトを生成する
        GameObject instance = (GameObject)Instantiate(obj,
                                                      Place1.transform.position,
                                                      Quaternion.identity);
        */
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
