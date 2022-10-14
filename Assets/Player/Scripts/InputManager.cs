using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private Movement mov;
    private Rotation rot;
    private Shooting shot;
    private spawnPortals spawnPortal;
    // Start is called before the first frame update
    void Start()
    {
        mov = GetComponent<Movement>();
        rot = GetComponent<Rotation>();
        shot = GetComponent<Shooting>();
        spawnPortal = GetComponent<spawnPortals>();
    }
    private void OnMove(InputValue input)
    {
        mov.movementFunction(input.Get<Vector2>());
    }

    private void OnLook(InputValue input)
    {
        rot.rotateCharacter(input.Get<Vector2>());
    }
    private void OnFire()
    {
        shot.onFire();
    }

    private void OnSpawnPortal()
    {
        spawnPortal.spawnPlayerPortal();
    }
}
