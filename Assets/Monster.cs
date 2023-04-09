using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public int score;
    public int hp ;
    private Rigidbody2D rd2d;
    public int nextMove;
    // Start is called before the first frame update

    void Think()
    {
        //���Ͱ� ������ �����ؼ� �Ǵ� (-1:�����̵� ,1:������ �̵� ,0:����  ���� 3���� �ൿ�� �Ǵ�)

        //Random.Range : �ּ�<= ���� <�ִ� /������ ���� ���� ����(�ִ�� �����̹Ƿ� �����ؾ���)
        nextMove = Random.Range(-1, 2);

        float time = Random.Range(0.5f, 0.8f); //�����ϴ� �ð��� �������� �ο� 
        //Think(); : ����Լ� : �����̸� ���� ������ CPU����ȭ �ǹǷ� ����Լ��� ���� �׻� ���� ->Think()�� ���� ȣ���ϴ� ��� Invoke()���
        Invoke("Think", time); //�Ű������� ���� �Լ��� time���� �����̸� �ο��Ͽ� ����� 
    }
    private void Awake()
    {
        rd2d = gameObject.GetComponent<Rigidbody2D>();
        Invoke("Think", 5); // �ʱ�ȭ �Լ� �ȿ� �־ ����� �� ����(���� 1ȸ) nextMove������ �ʱ�ȭ �ǵ����� 
    }
    void Start()
    {
        //rd2d = gameObject.AddComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Move
        rd2d.velocity = new Vector3(nextMove, rd2d.velocity.y); //nextMove �� 0:���� -1:���� 1:������ ���� 
    }
    void Update()
    {
        
    }
    public void hit()
    {
        hp--;
        if (hp<=0)
        {
            Destroy(this.gameObject);
            ScoreSc.score += score;
        }
    }

}
