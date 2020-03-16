using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed;
    private int count;
    public UnityEngine.UI.Text countText;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        CountText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Handle physics related protocols
    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        GetComponent<Rigidbody>().AddForce(movement * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "item")
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            CountText();
        }
        if (other.gameObject.tag == "hazard") {
            other.gameObject.SetActive(false);
            Vector3 jump = new Vector3(0.0f, 30, 0.0f);
            GetComponent<Rigidbody>().AddForce(jump * speed * Time.deltaTime);
        }
    }

    void CountText() {
        countText.text = "Score: " + count.ToString();
    }
}
