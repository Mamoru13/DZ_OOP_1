using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Alex_Shurukhin
{
    internal sealed class Player : MonoBehaviour, IDamage
    {
        public float _hp = 100;

        
        [SerializeField] private float _speed = 2;
        [SerializeField] private float _mouseSense = 100f;
        [SerializeField] private Transform _Camera;
        [SerializeField] private float _speedPlayer = 1;
        [SerializeField] private float _forceJump = 3f;
        [SerializeField] private Animation _OpenDoor;
        [SerializeField] private Animation _TrapDoor;
        
        private bool _jump = true;
        
        private bool _SpeedPlus = false;
        private float _SpeedPlusTime = 20f;
        float _xRotation = 0f;
        
        private Vector3 _direction = Vector3.zero;

        private void Update()
        {
            _direction.z = Input.GetAxis("Vertical")* _speedPlayer;
            _direction.x = Input.GetAxis("Horizontal")* _speedPlayer;

            
            float mouseX = Input.GetAxis("Mouse X") * _mouseSense * Time.fixedDeltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * _mouseSense * Time.fixedDeltaTime;

            _xRotation -= mouseY;
            _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);

            _Camera.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
            transform.Rotate(Vector3.up * mouseX);
            
            if (!_SpeedPlus)
            {
                if (Input.GetKeyDown(KeyCode.LeftShift))
                {
                    _speedPlayer = 2;
                }
                else if (Input.GetKeyUp(KeyCode.LeftShift))
                {
                    _speedPlayer = 1;
                }
            }
            
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (_jump)
                {
                    _jump = false;
                    Jump();
                    Invoke("ReloadJump",1);
                }
            }
            if (_SpeedPlus)
            {
                SpeedPlusTime();
            }
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("First_Aid"))
            {
                if (_hp != 100)
                {
                    AddHeal();
                    Destroy(other.gameObject);
                }
                Debug.Log(Hp);
            }

            if (other.CompareTag("SpeedPlus"))
            {
                _speedPlayer = 2.5f;
                _SpeedPlus = true;
                Destroy(other.gameObject, 1);
            }

            if (other.CompareTag("Green_Key"))
            {
                _OpenDoor.Play();
                Destroy(other.gameObject, 0);
            }

            if (other.CompareTag("Enemy"))
            {
                AddDamage();
                Debug.Log(Hp);
            }

            if (other.CompareTag("Trap_Door"))
            {
                _TrapDoor.Play();
            }
            
            if (other.CompareTag("Dead"))
            {
                Debug.Log("You Dead");
                Destroy(gameObject);
            }
        }

        private void SpeedPlusTime()
        {
            _SpeedPlusTime = (_SpeedPlusTime - Time.fixedDeltaTime * 1);
            Debug.Log(_SpeedPlusTime);
            if (_SpeedPlusTime <= 0)
            {
                _speedPlayer = 1;
                _SpeedPlus = false;
            }
        }

        private void FixedUpdate()
        {
            Move();
        }

        private void Move()
        {
            var speed = _direction * _speed * Time.fixedDeltaTime;
            transform.Translate(speed);
        }
        
        private void ReloadJump()
        {
            _jump = true;
        }
        
        private void Jump()
        {
            GetComponent<Rigidbody>().AddForce(_forceJump * Vector3.up, ForceMode.Impulse);
        }

        private void AddHeal()
        {
            _hp += 10;
            if (Hp > 100)
            {
                _hp = 100;
            }
        }
        
        public void AddDamage()
        {
            _hp -= 10;
            if (Hp <= 0.0f)
            {
                Destroy(gameObject);
            }
        }
        
        
        public float Hp
        {
            get { return _hp; }
        }
    }
}

