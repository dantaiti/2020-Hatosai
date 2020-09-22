using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Cinemachine;
public class PlayerMover : MonoBehaviour
{
    private Transform _playerModel;
    // Start is called before the first frame update
    public float xyspeed;
    public float lookspeed;
    private float _leanAxis;
    private  int _key;
    public float forwardSpeed = 6;
    
    [Header("Public References")]
    public Transform aimTarget;

    public Transform cameraParent;

    public CinemachineDollyCart dolly;
   
    void Start()
    {
        _playerModel = transform.GetChild(0);
        SetSpeed(forwardSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        _leanAxis = Input.GetAxis("Fire3");
        
        LocalMove(h,v,xyspeed);
        ClampPos();
        RotationLook(h,v,lookspeed);
        HorizontalLean(_playerModel,h,50,0.1f);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Boost(true);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Boost(false);
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            Break(true);
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            Break(false);
        }
        if (Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.G))
        {
            int dir = Input.GetKeyDown(KeyCode.F) ? -1 : 1;
            QuickSpin(dir);
        }
        
    }

    void LocalMove(float x, float y, float speed)
    {
        transform.localPosition += new Vector3(x,y,0)*speed * Time.deltaTime;
    }
    void ClampPos()
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        pos.x = Mathf.Clamp01(pos.x);
        pos.y = Mathf.Clamp01(pos.y);
        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }
    void RotationLook(float h, float v, float speed)
    {
        aimTarget.parent.position = Vector3.zero;
        aimTarget.localPosition = new Vector3(h, v, 1);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(aimTarget.position), Mathf.Deg2Rad * speed * Time.deltaTime);
    }
    void HorizontalLean(Transform target, float axis, float leanLimit, float lerpTime)
    {
      Vector3 targetEulerAngels = target.localEulerAngles;
      target.localEulerAngles = new Vector3(targetEulerAngels.x, targetEulerAngels.y, Mathf.LerpAngle(targetEulerAngels.z, -axis * leanLimit, lerpTime));
      
      if (Input.GetKey(KeyCode.LeftShift))
      {
          target.localEulerAngles = new Vector3(targetEulerAngels.x, targetEulerAngels.y, Mathf.LerpAngle(targetEulerAngels.z,   90, 0.04f));
      }
      if (Input.GetKey(KeyCode.RightShift))
      {
          target.localEulerAngles = new Vector3(targetEulerAngels.x, targetEulerAngels.y, Mathf.LerpAngle(targetEulerAngels.z,   -90, 0.04f));
      }
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(aimTarget.position, .5f);
        Gizmos.DrawSphere(aimTarget.position, .15f);
    }


    void SetCameraZoom(float zoom, float duration)
    {
        cameraParent.DOLocalMove(new Vector3(0, 0, zoom), duration);
    }
    void SetSpeed(float x)
    {
        dolly.m_Speed = x;
    }
    void Boost(bool state)
    {
        float speed = state ? forwardSpeed * 3 : forwardSpeed;
        float zoom = state ? -8f : 0;

        if (state)
        {
            cameraParent.GetComponentInChildren<CinemachineImpulseSource>().GenerateImpulse();
        }
       

        DOVirtual.Float(dolly.m_Speed, speed, 0.15f, SetSpeed);
        SetCameraZoom(zoom,0.5f);
        
    }

    void Break(bool state)
    {
        float speed = state ? forwardSpeed / 3 : forwardSpeed;
        float zoom = state ? 3f : 0;

        DOVirtual.Float(dolly.m_Speed, speed, 0.15f, SetSpeed);
        SetCameraZoom(zoom,0.5f);
    }
    
    public void QuickSpin(int dir)
    {
        if (!DOTween.IsTweening(_playerModel))
        {
            _playerModel.DOLocalRotate(new Vector3(_playerModel.localEulerAngles.x, _playerModel.localEulerAngles.y, 360 * -dir), .4f, RotateMode.LocalAxisAdd).SetEase(Ease.OutSine);
        }
    }
}
