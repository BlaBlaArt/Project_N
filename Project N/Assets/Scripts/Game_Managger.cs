using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Managger : MonoBehaviour
{

    public static Game_Managger Instance
    {
        get
        {
            return instance;
        }
    }

    private static Game_Managger instance = null;


    public int Exp;

    public bool isPoused = false;


    private void Awake()
    {
        if (instance)
        {
            DestroyImmediate(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
