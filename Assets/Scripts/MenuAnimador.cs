using UnityEngine;

public class MenuAnimador : MonoBehaviour
{
    public Animator jugarAnimator;
    public Animator salirAnimator;

    void Start()
    {
       
        jugarAnimator.Play("BtnJugar_Enter");
        salirAnimator.Play("BtnSalir_Enter");
    }
}
