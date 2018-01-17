﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionCalibrateForce : ShareAction
{
    enum CalibrationState
    {
        Starting,
        NormalForce,
        MaxForce,
        Finished
    }

    CalibrationState _calibrationState = CalibrationState.Starting;
    float _requiredConstantForceDuration = 3;
    float _forceBuffersPerSecond = 10;
    float _forceBufferTimeout = 0;
    CircularBuffer<float> forceBuffer;
    float maximumForce;
    float idleHoldForce;

    public override void EnterAction()
    {
        base.EnterAction();
        forceBuffer = new CircularBuffer<float>((int)(_requiredConstantForceDuration * _forceBuffersPerSecond));
        ChangeState(CalibrationState.Starting);
    }

    public override bool Finished()
    {
        return _calibrationState == CalibrationState.Finished;
    }

    private void Update()
    {
        if (_active)
        {
            switch (_calibrationState)
            {
                case CalibrationState.NormalForce:
                    if (ShareInputManager.ShareInput.IsPickedUp())
                    {
                        _forceBufferTimeout -= Time.deltaTime;
                        if (_forceBufferTimeout <= 0)
                        {
                            Debug.Log("Adding value");
                            forceBuffer.Push(ShareInputManager.ShareInput.GetForce());
                            _forceBufferTimeout += 1 / _forceBuffersPerSecond;
                        }

                        float min = float.MaxValue;
                        float max = 0;
                        float sum = 0;
                        foreach (float f in forceBuffer)
                        {
                            if (f < min)
                                min = f;

                            if (f > max)
                                max = f;

                            sum += f;
                        }
                        float average = sum / forceBuffer.Count();
                        float minMaxDiff = max - min;
                        Debug.Log("Min Max Diff: " + minMaxDiff);
                        Debug.Log("Average: " + average);
                        if (minMaxDiff < 100 && forceBuffer.Count() == (int)(_requiredConstantForceDuration * _forceBuffersPerSecond) && idleHoldForce < 0.3 * ShareInputManager.ShareInput.MaxForce())
                        {
                            GameSettings.IdleHoldForce = average;
                            ChangeState(CalibrationState.MaxForce);
                        }
                    }
                    
                    break;

                case CalibrationState.MaxForce:
                    float appliedForce = ShareInputManager.ShareInput.MaxAppliedForce();
                    if (!ShareInputManager.ShareInput.IsPickedUp() && appliedForce > idleHoldForce && appliedForce > 300)
                    {
                        GameSettings.MaxPressForce = ShareInputManager.ShareInput.MaxAppliedForce();
                        ChangeState(CalibrationState.Finished);
                    }
                    break;
            }
        }
    }

    void ChangeState(CalibrationState newState)
    {
        OnStateExit(_calibrationState);

        _calibrationState = newState;

        switch (newState)
        {
            case CalibrationState.Starting:
                ChangeState(CalibrationState.NormalForce);
                break;

            case CalibrationState.NormalForce:
                ShowInstructionText(string.Format("Device calibration: Pick up the device and hold it normally with constant force for {0} seconds.", _requiredConstantForceDuration));
                break;

            case CalibrationState.MaxForce:
                ShowInstructionText("Device calibration: Press the device as much as you can. Put it down when you're done.");
                ShareInputManager.ShareInput.ResetMaxAppliedForce();
                break;
        }

        
    }

    void OnStateExit(CalibrationState oldState)
    {
        switch (oldState)
        {
            default:

                break;
        }
    }
}