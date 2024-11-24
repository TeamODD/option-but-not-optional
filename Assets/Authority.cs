using UnityEngine;

public class Authority : MonoBehaviour
{
    public GameObject HavetoRemoved;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        HavetoRemoved = GameObject.Find("Canvas");
        if (HavetoRemoved != null)
        {
            Destroy(HavetoRemoved);
        }
    }


    private void Start()
    {
        HavetoRemoved = GameObject.Find("Canvas");
        if (HavetoRemoved != null)
        {
            Destroy(HavetoRemoved);
        }
    }

    // Update is called once per frame
    private void Update()
    {
    }
}