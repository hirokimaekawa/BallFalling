using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using Leap;
using Leap.Unity;

public class HandGestureManager : MonoBehaviour
{
    // Leap provider
    public LeapServiceProvider _leapProvider;

    // UI
    public GameObject _leapAlart;

    // Event Handler
    public OnUpdateFrame _onUpdateFrame;
    public OnFixedFrame _onFixedFrame;


    #region Properties

    public bool EnableLeapMotion
    {
        set
        {
            if (value)
                RegistorationLeapEvents();
            else
                UnregistorationLeapEvents();

            _leapProvider.enabled = value;
        }
    }

    public bool IsLeftHandVisible { get; private set; }

    public bool IsRightHandVisible { get; private set; }

    #endregion

    #region Menber Methods

    void RegistorationLeapEvents()
    {
        if (_leapProvider)
        {
            _leapProvider.OnUpdateFrame -= OnUpdateFrame;
            _leapProvider.OnUpdateFrame += OnUpdateFrame;

            _leapProvider.OnFixedFrame -= OnFixedFrame;
            _leapProvider.OnFixedFrame += OnFixedFrame;

            var controller = _leapProvider.GetLeapController();
            if (controller != null)
            {
                controller.Device -= OnDevice;
                controller.Device += OnDevice;
                controller.DeviceFailure -= OnDeviceFailur;
                controller.DeviceFailure += OnDeviceFailur;
                controller.DeviceLost -= OnDeviceLost;
                controller.DeviceLost += OnDeviceLost;
                controller.Connect -= OnConnect;
                controller.Connect += OnConnect;
                controller.Disconnect -= OnDisconnect;
                controller.Disconnect += OnDisconnect;
            }
        }
    }

    void UnregistorationLeapEvents()
    {
        if (_leapProvider)
        {
            _leapProvider.OnUpdateFrame -= OnUpdateFrame;
            _leapProvider.OnFixedFrame -= OnFixedFrame;

            var controller = _leapProvider.GetLeapController();
            if (controller != null)
            {
                controller.Device -= OnDevice;
                controller.DeviceFailure -= OnDeviceFailur;
                controller.DeviceLost -= OnDeviceLost;
                controller.Connect -= OnConnect;
                controller.Disconnect -= OnDisconnect;
            }
        }
    }

    #endregion

    #region Unity Events

    void Awake()
    {
        if (_leapAlart) _leapAlart.SetActive(false);
    }

    private void OnEnable()
    {
        if (_leapProvider == null)
        {
            _leapProvider = FindObjectOfType<LeapServiceProvider>();
            if (_leapProvider == null)
            {
                Debug.LogError("Couldn't find LeapServiceProvider");
                return;
            }
        }

        RegistorationLeapEvents();
    }

    private void OnDisable()
    {
        UnregistorationLeapEvents();
    }

    #endregion

    #region Update Frame Handler

    /** Updates the graphics HandRepresentations. */
    protected virtual void OnUpdateFrame(Frame frame)
    {
        if (frame != null)
        {
            if (frame.Hands.Count > 0)
            {
                IsLeftHandVisible = frame.Hands.Any(e => e.IsLeft);
                IsRightHandVisible = frame.Hands.Any(e => e.IsRight);
            }
            else
            {
                IsLeftHandVisible = false;
                IsRightHandVisible = false;
            }

            if (_onUpdateFrame.GetPersistentEventCount() > 0) _onUpdateFrame.Invoke(frame);
        }
    }

    /** Updates the physics HandRepresentations. */
    protected virtual void OnFixedFrame(Frame frame)
    {
        if (frame != null)
        {
            if (_onFixedFrame.GetPersistentEventCount() > 0) _onFixedFrame.Invoke(frame);
        }
    }

    #endregion




    #region Device Event Handler

    void OnDevice(object sender, DeviceEventArgs e)
    {
        Debug.Log("On Device");
        if (_leapAlart) _leapAlart.SetActive(false);
    }

    void OnDeviceFailur(object sender, DeviceFailureEventArgs e)
    {
        Debug.LogWarning("On Device Failur: " + e.ErrorMessage);
    }

    void OnDeviceLost(object sender, DeviceEventArgs e)
    {
        Debug.LogWarning("On Device Lost");
        if (_leapAlart) _leapAlart.SetActive(true);
    }

    void OnConnect(object sender, ConnectionEventArgs e)
    {
        Debug.Log("On Connect");
        if (_leapAlart) _leapAlart.SetActive(false);
    }

    void OnDisconnect(object sender, ConnectionLostEventArgs e)
    {
        Debug.Log("Disconnect");
        if (Application.isPlaying)
        {
            if (_leapAlart) _leapAlart.SetActive(true);
        }
    }

    #endregion
}

[System.Serializable] public class OnUpdateFrame : UnityEvent<Leap.Frame> { }
[System.Serializable] public class OnFixedFrame : UnityEvent<Leap.Frame> { }
