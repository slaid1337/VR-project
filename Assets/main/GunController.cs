using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class GunController : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private GameObject _bulletPlace;
    private float _delay;
    private float _delayDuration;
    private float _switcherSpeed;
    private float _toHigherDelay;
    private float _switcher;
    private float _startToHigherDelay;
    private float _startDelayDuration;

    private SteamVR_Action_Boolean _fireAction;
    private Interactable interactable;


    private void Awake()
    {
        _delay = 0;
        _switcher = 0;
        _startToHigherDelay = _toHigherDelay;
        _startDelayDuration = _delayDuration;

        interactable = GetComponent<Interactable>();
    }

    private void Update()
    {
        if (interactable.attachedToHand != null)
        {
            SteamVR_Input_Sources source = interactable.attachedToHand.handType;


            if (_fireAction[source].stateDown)
            {
                if (Input.GetKey(KeyCode.Space))
                {
                    if (_delay >= 1)
                    {
                        Instantiate(_bullet, _bulletPlace.transform.position, transform.rotation);
                        _delay = 0;
                    }

                    if (_toHigherDelay > 0)
                    {
                        _toHigherDelay -= Time.fixedDeltaTime;
                    }
                    else
                    {
                        if (_switcher < 1) _switcher += Time.fixedDeltaTime * _switcherSpeed;
                        _delayDuration = Mathf.Lerp(10, 2, _switcher);
                    }

                }
                else
                {
                    if (_toHigherDelay < _startToHigherDelay)
                    {
                        _toHigherDelay += Time.fixedDeltaTime;
                    }

                    if (_delayDuration < _startDelayDuration)
                    {
                        _delayDuration += Time.fixedDeltaTime * _switcherSpeed * 8f;
                    }

                    if (_switcher > 0)
                    {
                        _switcher -= Time.fixedDeltaTime * _switcherSpeed;
                    }
                }
            }
        }
        
        _delay += Time.fixedDeltaTime * _delayDuration;
    }

}