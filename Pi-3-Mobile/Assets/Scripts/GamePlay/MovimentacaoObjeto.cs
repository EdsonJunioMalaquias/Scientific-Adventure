using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentacaoObjeto : MonoBehaviour {
    public List<Transform> wayPoint;
    private Vector3 targetPoint;
    public float movimento;
    private int pontoAtual;
    public float distanciaDeTolerancia;
	
	void Start () {
		foreach (Transform point in wayPoint)        {

            point.SetParent(null);
        }
       
        ChangeWayPoint();
	}
	
	
	void Update () {
        float distanciaDoPonto = Vector3.Distance(targetPoint, transform.position);
        if (distanciaDoPonto >= distanciaDeTolerancia)        {
            transform.position = Vector3.Lerp(transform.transform.position, targetPoint, movimento*Time.deltaTime);
        }
        else        {
            ChangeWayPoint();
        }

    }
    private void ChangeWayPoint()
    {
        if(pontoAtual < wayPoint.Count -1)        {
            pontoAtual++;
        }        else        {
            pontoAtual = 0;
        }
        targetPoint = wayPoint[pontoAtual].position;

    }
}
