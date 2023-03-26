using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Utility;
using Random = UnityEngine.Random;
namespace UnityStandardAssets.Characters.FirstPerson
{
    public class Playermove2 : MonoBehaviour
    {
        [SerializeField] private bool m_IsWalking;
        [SerializeField] private GameObject player;
        [SerializeField] private float m_WalkSpeed;
        [SerializeField] private float m_RunSpeed;
        [SerializeField] [Range(0f, 1f)] private float m_RunstepLenghten;
        [SerializeField] private float m_JumpSpeed;
        [SerializeField] private float m_StickToGroundForce;
        [SerializeField] private float m_GravityMultiplier;
        [SerializeField] private MouseLook m_MouseLook;
        [SerializeField] private bool m_UseFovKick;
        [SerializeField] private FOVKick m_FovKick = new FOVKick();
        [SerializeField] private bool m_UseHeadBob;
        [SerializeField] private CurveControlledBob m_HeadBob = new CurveControlledBob();
        [SerializeField] private LerpControlledBob m_JumpBob = new LerpControlledBob();
        [SerializeField] private float m_StepInterval;
        [SerializeField] private AudioClip[] m_FootstepSounds;    // an array of footstep sounds that will be randomly selected from.
        [SerializeField] private AudioClip m_JumpSound;           // the sound played when character leaves the ground.
        [SerializeField] private AudioClip m_LandSound;           // the sound played when character touches back on ground.


        private Camera m_Camera;
        public float speed2;
        public float x;
        public float z;
        public float y;
        plugindemo test;
        private CharacterController controller;
        private Vector2 m_Input;
        private Vector3 m_MoveDir = Vector3.zero;
        private CollisionFlags m_CollisionFlags;
        private bool m_PreviouslyGrounded;
        private Vector3 m_OriginalCameraPosition;
        private float m_StepCycle;
        private float m_NextStep;
        private bool m_Jumping;
        private bool m_Jump;
        private float angle = 0;
        private AudioSource m_AudioSource;
        Vector3 rotationVelocity;
        void Start()
        {
            speed2 = 4.5f;
            test = GetComponent<plugindemo>();
            controller = GetComponent<CharacterController>();
            m_Camera = Camera.main;
            m_OriginalCameraPosition = m_Camera.transform.localPosition;
            m_FovKick.Setup(m_Camera);
            m_HeadBob.Setup(m_Camera, m_StepInterval);
            m_StepCycle = 0f;
            m_NextStep = m_StepCycle / 2f;
            m_Jumping = false;
            m_AudioSource = GetComponent<AudioSource>();
            m_MouseLook.Init(transform, m_Camera.transform);
            Input.gyro.enabled = true;

            Input.gyro.updateInterval = 0.1f;
        }

        // Update is called once per frame
        void Update()
        {
            angle = player.transform.eulerAngles.y;
            // controller.transform.eulerAngles = new Vector3(controller.transform.eulerAngles.x, (test.gets()), controller.transform.eulerAngles.z);
            // the jump state needs to read here to make sure it is not missed
            if (!m_Jump)
            {
                m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
            }

            if (!m_PreviouslyGrounded && controller.isGrounded)
            {
                StartCoroutine(m_JumpBob.DoBobCycle());

                m_MoveDir.y = 0f;
                m_Jumping = false;
            }
            if (!controller.isGrounded && !m_Jumping && m_PreviouslyGrounded)
            {
                m_MoveDir.y = 0f;
            }

            m_PreviouslyGrounded = controller.isGrounded;
            //左右移動
            /* if (test.getb() > 0.5 )
             {
                 controller.Move(new Vector3(-(Mathf.Cos(angle * Mathf.Deg2Rad)), 0, Mathf.Sin(angle * Mathf.Deg2Rad)) * (speed2) * Time.deltaTime);
             }
             if (test.getb() < -0.5)
             {
                 controller.Move(new Vector3((Mathf.Cos(angle * Mathf.Deg2Rad)), 0, -Mathf.Sin(angle * Mathf.Deg2Rad)) * (speed2) * Time.deltaTime);
             }*/
            //前後移動
            /*else
            {
                if (test.getc() > 1)
                {
                    controller.Move(new Vector3(Mathf.Sin(angle * Mathf.Deg2Rad), 0, Mathf.Cos(angle * Mathf.Deg2Rad)) * (speed2) * Time.deltaTime);
                }
                else if (test.geta() > 0.3)
                {
                    controller.Move(new Vector3(Mathf.Sin(angle * Mathf.Deg2Rad), 0, Mathf.Cos(angle * Mathf.Deg2Rad)) * (speed2) * Time.deltaTime);
                }
                if (test.getc() < -0.8)
                {
                    controller.Move(new Vector3(-Mathf.Sin(angle * Mathf.Deg2Rad), 0, -Mathf.Cos(angle * Mathf.Deg2Rad)) * (speed2) * Time.deltaTime);
                }
                else if (test.geta() < -0.3)
                {
                    controller.Move(new Vector3(-Mathf.Sin(angle * Mathf.Deg2Rad), 0, -Mathf.Cos(angle * Mathf.Deg2Rad)) * (speed2) * Time.deltaTime);
                }
            }*/


            /*if (Input.GetKey("w"))
            {
                controller.Move(new Vector3(Mathf.Sin(angle * Mathf.Deg2Rad),0, Mathf.Cos(angle * Mathf.Deg2Rad)) * (speed2) * Time.deltaTime);
            }
            if (Input.GetKey("s"))
            {
                controller.Move(new Vector3(-Mathf.Sin(angle * Mathf.Deg2Rad), 0, -Mathf.Cos(angle * Mathf.Deg2Rad)) * (speed2) * Time.deltaTime);
            }
            if (Input.GetKey("a"))
            {
                controller.Move(new Vector3(-(Mathf.Cos(angle * Mathf.Deg2Rad)), 0, Mathf.Sin(angle * Mathf.Deg2Rad)) * (speed2) * Time.deltaTime);
            }
            if (Input.GetKey("d"))
            {
                controller.Move(new Vector3((Mathf.Cos(angle * Mathf.Deg2Rad)), 0, -Mathf.Sin(angle * Mathf.Deg2Rad)) * (speed2) * Time.deltaTime);
            }*/

            //原地踏步


        }

        private void FixedUpdate()
        {
            float speed;
            GetInput(out speed);
            // always move along the camera forward as it is the direction that it being aimed at
            Vector3 desiredMove = transform.forward * m_Input.y + transform.right * m_Input.x;

            // get a normal for the surface that is being touched to move along it
            RaycastHit hitInfo;
            Physics.SphereCast(transform.position, controller.radius, Vector3.down, out hitInfo,
                               controller.height / 2f, Physics.AllLayers, QueryTriggerInteraction.Ignore);
            desiredMove = Vector3.ProjectOnPlane(desiredMove, hitInfo.normal).normalized;

            m_MoveDir.x = Mathf.Sin(angle * Mathf.Deg2Rad) * m_WalkSpeed * m_Input.y;

            m_MoveDir.z = Mathf.Cos(angle * Mathf.Deg2Rad) * m_WalkSpeed * m_Input.y;


            if (controller.isGrounded)
            {
                m_MoveDir.y = -m_StickToGroundForce;

                if (m_Jump)
                {
                    m_MoveDir.y = m_JumpSpeed;

                    m_Jump = false;
                    m_Jumping = true;
                }
            }
            else
            {
                m_MoveDir += Physics.gravity * m_GravityMultiplier * Time.fixedDeltaTime;
            }
            m_CollisionFlags = controller.Move(m_MoveDir * Time.fixedDeltaTime);

            ProgressStepCycle(speed);


            m_MouseLook.UpdateCursorLock();
        }





        private void ProgressStepCycle(float speed)
        {
            if (controller.velocity.sqrMagnitude > 0 && (m_Input.x != 0 || m_Input.y != 0))
            {
                m_StepCycle += (controller.velocity.magnitude + (speed * (m_IsWalking ? 1f : m_RunstepLenghten))) *
                             Time.fixedDeltaTime;
            }

            if (!(m_StepCycle > m_NextStep))
            {
                return;
            }

            m_NextStep = m_StepCycle + m_StepInterval;
            PlayFootStepAudio();

        }
        private void PlayFootStepAudio()
        {
            if (!controller.isGrounded)
            {
                return;
            }
            // pick & play a random footstep sound from the array,
            // excluding sound at index 0
            int n = Random.Range(1, m_FootstepSounds.Length);
            m_AudioSource.clip = m_FootstepSounds[n];
            m_AudioSource.PlayOneShot(m_AudioSource.clip);
            // move picked sound to index 0 so it's not picked next time
            m_FootstepSounds[n] = m_FootstepSounds[0];
            m_FootstepSounds[0] = m_AudioSource.clip;
        }






        private void GetInput(out float speed)
        {
            // Read input
            float horizontal = 0f;
            float vertical = Input.GetAxis("Vertical");
            rotationVelocity = Input.gyro.rotationRate;
            bool waswalking = m_IsWalking;

#if !MOBILE_INPUT
            // On standalone builds, walk/run speed is modified by a key press.
            // keep track of whether or not the character is walking or running
            m_IsWalking = !Input.GetKey(KeyCode.LeftShift);
#endif

            if ((Mathf.Abs(rotationVelocity.x) + Mathf.Abs(rotationVelocity.y) + Mathf.Abs(rotationVelocity.z)) > 1 || Mathf.Abs(rotationVelocity.x) > 0.35)
                vertical = 0f;
            else if ((Mathf.Abs(test.geta()) + Mathf.Abs(test.getb()) + Mathf.Abs(test.getc())) > 0.8 && Mathf.Abs(test.geta()) > 0.15 && Mathf.Abs(test.getc()) < 0.4)
                vertical = 1f;
            // set the desired speed to be walking or running
            speed = m_IsWalking ? m_WalkSpeed : m_RunSpeed;
            m_Input = new Vector2(horizontal, vertical);

            // normalize input if it exceeds 1 in combined length:
            if (m_Input.sqrMagnitude > 1)
            {
                m_Input.Normalize();
            }

            // handle speed change to give an fov kick
            // only if the player is going to a run, is running and the fovkick is to be used
            if (m_IsWalking != waswalking && m_UseFovKick && controller.velocity.sqrMagnitude > 0)
            {
                StopAllCoroutines();
                StartCoroutine(!m_IsWalking ? m_FovKick.FOVKickUp() : m_FovKick.FOVKickDown());
            }
        }


        private void RotateView()
        {
            //m_MouseLook.LookRotation(transform, m_Camera.transform);
        }


        private void OnControllerColliderHit(ControllerColliderHit hit)
        {
            Rigidbody body = hit.collider.attachedRigidbody;
            //dont move the rigidbody if the character is on top of it
            if (m_CollisionFlags == CollisionFlags.Below)
            {
                return;
            }

            if (body == null || body.isKinematic)
            {
                return;
            }
            body.AddForceAtPosition(controller.velocity * 0.1f, hit.point, ForceMode.Impulse);
        }
    }
}
