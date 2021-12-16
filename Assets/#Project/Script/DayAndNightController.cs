using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DayAndNightController : MonoBehaviour
{
    [SerializeField] private Transform sunTransform;
    [SerializeField] private Light sun;
    [SerializeField] private float angleAtNoon;
    [SerializeField] private Vector3 hourMinuteSecond = new Vector3(6f,0f,0f), hmsSunSet = new Vector3(18f,0f,0f);
    [SerializeField] public int days = 0;
    [SerializeField] public float speed = 100;
    [SerializeField] private float intensityAtNoon = 1f, intensityAtSunSet = 0.5f;
    [SerializeField] private Color fogColorDay = Color.grey, fogColorNight = Color.black;
    [SerializeField] private Transform starsTransform;
    [SerializeField] private Vector3 hmsStarsLight = new Vector3(19f,30f,0f), hmsStarsEstinguish = new Vector3(03f,30f,0f);
    [SerializeField] private float starsFadeInTime = 7200f, starsFadeOutTime = 7200f;

    public float time;
    private float intensity, rotation, prev_rotation = -1f,sunSet,SunRise,sunDayRatio, fade, timeLight, timeEstinguish;
    private Color tintColor = new Color(0.5f,0.5f,0.5f,0.5f);
    private Vector3 dir;
    private Renderer myRend;


    void Start()
    {
        myRend = starsTransform.GetComponent<ParticleSystem>().GetComponent<Renderer>();
        time = HMS_to_Time(hourMinuteSecond.x, hourMinuteSecond.y,hourMinuteSecond.z);
        sunSet = HMS_to_Time(hmsSunSet.x,hmsSunSet.y,hmsSunSet.z);
        SunRise = 86400f-sunSet;
        sunDayRatio = (sunSet -SunRise) / 43200f;
        dir = new Vector3(Mathf.Cos(Mathf.Deg2Rad * angleAtNoon), Mathf.Sin(Mathf.Deg2Rad * angleAtNoon), 0f);
        starsFadeInTime /= speed;
        starsFadeOutTime /= speed;
        timeLight = HMS_to_Time(hmsStarsLight.x,hmsStarsLight.y,hmsStarsLight.z);
        timeEstinguish = HMS_to_Time(hmsStarsEstinguish.x,hmsStarsEstinguish.y,hmsStarsEstinguish.z);
    }

    void Update()
    {
        time+= Time.deltaTime*speed;
        if (time > 86400f)
        {
            days+=1;
            time-= 86400f;
        }
        if(prev_rotation == -1f)
        {
            sunTransform.eulerAngles = Vector3.zero;
            prev_rotation = 0f;
        }
        else prev_rotation = rotation;


        rotation = (time-21600f) / 86400f*360f;
        sunTransform.Rotate(dir, rotation- prev_rotation);
        starsTransform.Rotate(dir, rotation- prev_rotation);

        if(time< SunRise) intensity = intensityAtSunSet *time /sunSet;
        else if(time < 43200f) intensity = intensityAtSunSet + (intensityAtNoon - intensityAtSunSet)/(43200f - sunDayRatio);
        else if(time <sunSet) intensity  = intensityAtNoon - (intensityAtNoon - intensityAtSunSet) / (sunSet -43200f);
        else intensity = intensityAtSunSet - (1f - intensityAtSunSet) * (time-sunSet);

        RenderSettings.fogColor = Color.Lerp(fogColorNight, fogColorDay, intensity * intensity);
        if(sun != null)sun.intensity = intensity;

        if(Time_Fall_Between(time, timeLight, timeEstinguish))
        {
            fade += Time.deltaTime / starsFadeInTime;
            if(fade > 1f) fade =1f;
        }
        else{
            fade -= Time.deltaTime / starsFadeOutTime;
            if(fade < 0f) fade =0f;
        }
        tintColor.a = fade;
        myRend.material.SetColor("_TintColor", tintColor);
    }
    private float HMS_to_Time(float hour, float minute, float second)
    {
        return 3600 * hour + 60* minute + second;
    }
    private bool Time_Fall_Between(float currentTime, float startTime, float endTime)
    {
        if(startTime<endTime)
        {
            if (currentTime >= startTime && currentTime <+ endTime) return true;
        else return false;
        }
        else{
            if (currentTime < startTime && currentTime <+ endTime) return false;
            else return true;
        }
    }

}
