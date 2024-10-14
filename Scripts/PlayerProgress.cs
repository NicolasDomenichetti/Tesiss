using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Es importante que TODAS las escenas tengan la misma copia del playerprogress
[CreateAssetMenu(menuName = "Player Progress")]
public class PlayerProgress : ScriptableObject
{
    public bool eyeProgress;
    public bool bodyProgress;
    public bool wingProgress;

    //La idea seria crear 3 arrays de GameObjects para las partes del cuerpo
    //En el momento de crear la mariposa final, instancian uno de esos GameObjects para cada cosa
    //(Un par de alas, un par de ojos, un cuerpo)

    //Aca guardamos las selecciones del jugador para cada cosa
    //Cuando llegue el momento de que el jugador elija una parte, pondrian en el manager correspondiente
    //progres.eyeIndex = 1

    public int eyeIndex;
    public int bodyIndex;
    public int wingIndex;
}
