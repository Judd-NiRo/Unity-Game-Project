using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using System.Collections;

[RequireComponent(typeof(CharacterController), typeof(PlayerInput), typeof(Animator))]
public class MainCharacterController : MonoBehaviour
{
    private Animator animator;

    private CharacterController characterController;
    private Vector2 move;
    [SerializeField] private float speed = 5;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        characterController = GetComponent<CharacterController>();

        animator = GetComponent<Animator>();
    }

    private void OnMove(InputValue value)
    {
        move = value.Get<Vector2>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 deltaMove = (move.x * transform.right) + (move.y * transform.forward);
        deltaMove.y = 0.0f;
        characterController.Move(deltaMove * Time.deltaTime * speed);

        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            SceneManager.LoadScene("SavingScene");
        }

        if (Keyboard.current.iKey.wasPressedThisFrame){
            
            animator.SetTrigger("Dance");

        }

        if (Keyboard.current.uKey.wasPressedThisFrame){
            
            animator.SetTrigger("Idle1");

        }

        if (Keyboard.current.oKey.wasPressedThisFrame){
            
            animator.SetTrigger("Idle2");

        }
    }
}
