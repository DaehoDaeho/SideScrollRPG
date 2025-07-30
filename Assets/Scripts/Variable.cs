using UnityEngine;

public class Variable : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int c = Sum(1, 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int Sum(int a, int b)
    {
        int c = a + b;
        return c;
    }
}
