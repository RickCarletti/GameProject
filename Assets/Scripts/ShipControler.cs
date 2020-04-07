using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipControler : MonoBehaviour
{
    private float _velocidadeatual;
    private float _velocidadeangular = 0;
    private float _x = 0;
    private float _y = 0;
    private Rigidbody2D rigidbody;
    private Animator animator;

    public float velocidadeprincipal = 2;
    public float velocidaderotacao = 10;
    // Start is called before the first frame update
    void Start()
    {
		rigidbody = GetComponent<Rigidbody2D>(); // passando metodo pra um objeto especifico
        animator = GetComponent<Animator>(); // passando metodo pra um objeto especifico
    }

    // Update is called once per frame
    void Update()
    {
        navegate();
    }

    void navegate()
    {
		rigidbody = GetComponent<Rigidbody2D>(); // passando metodo pra um objeto especifico
        animator = GetComponent<Animator>(); // passando metodo pra um objeto especifico
        _velocidadeangular += Input.GetAxis("Horizontal")*velocidaderotacao; // recebendo input horizontal
        _velocidadeatual = Input.GetAxis("Vertical")/10*velocidadeprincipal; // recebendo input vertical

        if (_velocidadeatual > 0 || _velocidadeatual < 0)//Animação do motor funcionando
        {
            animator.SetBool("Working", true);
        }
        else
        {
            animator.SetBool("Working", false);
        }
        
        _x += DoubletoFloat(_velocidadeatual * Math.Sin(rigidbody.rotation*Math.PI/180));//pegando o valor do vetor em X
        _y += DoubletoFloat(_velocidadeatual * Math.Cos(rigidbody.rotation*Math.PI/180));//pegando o valor do vetor em Y

        rigidbody.angularVelocity = _velocidadeangular*(-1);//registrando o valor angular
        rigidbody.velocity = new Vector2(_x, _y*(-1));//registrando a nova velocidade
    }

    float DoubletoFloat(double valorDouble)
    {
        return float.Parse(valorDouble.ToString()); //Passando String pra Float
    }
}
