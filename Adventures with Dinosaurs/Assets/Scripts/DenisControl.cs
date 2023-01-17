using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DenisControl : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float speed; //�������� ���������
    Vector3 startPosition;
    Rigidbody rb; //������ �� Rigidbody
    Vector3 direction; //����������� ��������
    [SerializeField] float JumpSpid;
    bool isgruunded;
    bool jump;
    Animator anime;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        direction = transform.TransformDirection(-z, 0, x);
        if (isgruunded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(new Vector3(0, JumpSpid, 0), ForceMode.Impulse);
            }
        }
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Corm")
        {
            Destroy(collider.gameObject);

        }
    }
    private void FixedUpdate()
    {
        rb.MovePosition(transform.position + direction * speed * Time.fixedDeltaTime);
    }
    private void OnCollisionStay(Collision other)
    {
        if (other != null)
        {
            isgruunded = true;
        }
    }
    private void OnCollisionExit(Collision other)
    {
        isgruunded = false;
    }
}
