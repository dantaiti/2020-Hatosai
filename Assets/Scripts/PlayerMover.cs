using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Cinemachine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class PlayerMover : MonoBehaviour
{
    private Transform _playerModel;
    // Start is called before the first frame update
    public float xyspeed;
    public float lookspeed;
    private float _leanAxis;
    public float forwardSpeed = 6; //機体の速さ
    public float boostMagni; 
    public float fuelEconomy; //燃費　ブレーキとブーストに使用
    public bool isBreak;
    public bool isBoost;

    public float coolDown;//クールダウンの時間
    [SerializeField] private bool onCoolDown;
    [Header("Public References")]
    public Transform aimTarget;
    public Transform cameraParent;
    public CinemachineDollyCart dolly;
    public Image boostGauge;

    void Start()
    {
      //  _uiColorChange = GetComponent<UiColorChange>();
        _playerModel = transform.GetChild(0);
        SetSpeed(forwardSpeed);
        onCoolDown = false;
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

        
        if (Input.GetKeyDown(KeyCode.Space)&&boostGauge.fillAmount>0)
        {
            Boost(true);
            
        }
        
        DecBoostGauge(isBoost,isBreak);

        if (Input.GetKeyUp(KeyCode.Space)||boostGauge.fillAmount<=0)
        {
            Boost(false);
            StartCoroutine(BoostCoolDown());
        }
        
        
        if (Input.GetKeyDown(KeyCode.LeftControl)&&boostGauge.fillAmount>0)
        {
            Break(true);
        }
        if (Input.GetKeyUp(KeyCode.LeftControl)||boostGauge.fillAmount<=0)
        {
            Break(false);
            StartCoroutine(BoostCoolDown());

        }
        if (Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.G))
        {
            int dir = Input.GetKeyDown(KeyCode.F) ? -1 : 1;
            QuickSpin(dir);
        }
        
        Debug.Log(isBoost);
       
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
    
   public void SetSpeed(float x)
    {
        dolly.m_Speed = x;
    }
   public void Boost(bool state)
    {
        
            float speed = state ? forwardSpeed * boostMagni : forwardSpeed;
            float zoom = state ? -18f : 0;
            float orignalFov = state ? 40 : 55;
            float endFov = state ? 55 : 40;

            isBoost = state ? true : false;

       
            if (state)
            {
                cameraParent.GetComponentInChildren<CinemachineImpulseSource>().GenerateImpulse();
            }
           // DOVirtual.Float(orignalFov, endFov, .5f, FovContoroll);
            DOVirtual.Float(dolly.m_Speed, speed, 0.35f, SetSpeed);
            SetCameraZoom(zoom, 0.5f);
        
    }

   public void Break(bool state)
    {
        float speed = state ? forwardSpeed / 3 : forwardSpeed;
        float zoom = state ? 3f : 0; 
        isBreak = state ? true : false;
        
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
    
    void SetCameraZoom(float zoom, float duration)
    {
        cameraParent.DOLocalMove(new Vector3(0, 0, zoom), duration);
    }

    void FovContoroll(float fov)
    {
        cameraParent.GetComponentInChildren<CinemachineVirtualCamera>().m_Lens.FieldOfView = fov;
    }


    IEnumerator BoostCoolDown()
    {
        onCoolDown = true;
            yield return  new WaitForSeconds(coolDown);
            onCoolDown = false;
    }

    void DecBoostGauge(bool isboost,bool isbreak)
    {
        if (isboost||isbreak)//ブースト中またはブレーキ中ゲージを減らす
        {
            boostGauge.fillAmount -= fuelEconomy ;
            
        }
        if (!(isboost||isbreak)&&!onCoolDown)//ブースとブレーキクールダウン中じゃなかったら回復
        {
            boostGauge.fillAmount += 0.001f;
        }
        
    }
}
