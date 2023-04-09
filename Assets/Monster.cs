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
        //몬스터가 스스로 생각해서 판단 (-1:왼쪽이동 ,1:오른쪽 이동 ,0:멈춤  으로 3가지 행동을 판단)

        //Random.Range : 최소<= 난수 <최대 /범위의 랜덤 수를 생성(최대는 제외이므로 주의해야함)
        nextMove = Random.Range(-1, 2);

        float time = Random.Range(0.5f, 0.8f); //생각하는 시간을 랜덤으로 부여 
        //Think(); : 재귀함수 : 딜레이를 쓰지 않으면 CPU과부화 되므로 재귀함수쓸 때는 항상 주의 ->Think()를 직접 호출하는 대신 Invoke()사용
        Invoke("Think", time); //매개변수로 받은 함수를 time초의 딜레이를 부여하여 재실행 
    }
    private void Awake()
    {
        rd2d = gameObject.GetComponent<Rigidbody2D>();
        Invoke("Think", 5); // 초기화 함수 안에 넣어서 실행될 때 마다(최초 1회) nextMove변수가 초기화 되도록함 
    }
    void Start()
    {
        //rd2d = gameObject.AddComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Move
        rd2d.velocity = new Vector3(nextMove, rd2d.velocity.y); //nextMove 에 0:멈춤 -1:왼쪽 1:오른쪽 으로 
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
