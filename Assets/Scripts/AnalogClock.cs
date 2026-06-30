using System;
using UnityEngine;

public class AnalogClock : MonoBehaviour
{
    [Header("Clock Hands")]
    public Transform hourHand;
    public Transform minuteHand;
    public Transform secondHand;

    [Header("Rotation")]
    [Tooltip("Enable if the hands rotate the wrong direction.")]
    public bool clockwise = true;

    private Vector3 hourStartRot;
    private Vector3 minuteStartRot;
    private Vector3 secondStartRot;

    private void Start()
    {
        hourStartRot = hourHand.localEulerAngles;
        minuteStartRot = minuteHand.localEulerAngles;
        secondStartRot = secondHand.localEulerAngles;
    }

    private void Update()
    {
        DateTime now = DateTime.Now;

        float seconds = now.Second + now.Millisecond / 1000f;
        float minutes = now.Minute + seconds / 60f;
        float hours = (now.Hour % 12) + minutes / 60f;

        float dir = clockwise ? -1f : 1f;

        hourHand.localEulerAngles = new Vector3(
            hourStartRot.x,
            hourStartRot.y,
            hourStartRot.z + dir * hours * 30f);

        minuteHand.localEulerAngles = new Vector3(
            minuteStartRot.x,
            minuteStartRot.y,
            minuteStartRot.z + dir * minutes * 6f);

        secondHand.localEulerAngles = new Vector3(
            secondStartRot.x,
            secondStartRot.y,
            secondStartRot.z + dir * seconds * 6f);
    }
}