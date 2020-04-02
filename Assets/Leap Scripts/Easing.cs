using UnityEngine;
using System.Collections;

/// <summary>
/// Easing Functions,
/// ALl Arguments "t" are values between 0.0f to 1.0f.
/// http://easings.net/
/// </summary>
public static class Easing
{
    public static class Back
    {
        public static float easeIn(float t)
        {
            return 3.0f * t * t * t - 2.0f * t * t;
        }

        public static float easeOut(float t)
        {
            return 1.0f - easeIn(1.0f - t);
        }

        public static float easeInOut(float t)
        {
            return (t < 0.5f) ? easeIn(t * 2.0f) * 0.5f : 1 - easeIn(2.0f - t * 2.0f) * 0.5f;
        }
    };


    public static class Bounce
    {
        public static float easeIn(float t)
        {
            float DH = 1.0f / 22.0f;
            float D1 = 1.0f / 11.0f;
            float D2 = 2.0f / 11.0f;
            float D3 = 3.0f / 11.0f;
            float D4 = 4.0f / 11.0f;
            float D5 = 5.0f / 11.0f;
            float D7 = 7.0f / 11.0f;
            float IH = 1.0f / DH;
            float I1 = 1.0f / D1;
            float I2 = 1.0f / D2;
            float I4D = 1.0f / D4 / D4;

            float s;
            if (t < D1)
            {
                s = t - DH;
                s = DH - s * s * IH;
            }
            else if (t < D3)
            {
                s = t - D2;
                s = D1 - s * s * I1;
            }
            else if (t < D7)
            {
                s = t - D5;
                s = D2 - s * s * I2;
            }
            else
            {
                s = t - 1;
                s = 1 - s * s * I4D;
            }
            return s;
        }

        public static float easeOut(float t)
        {
            return 1.0f - easeIn(1.0f - t);
        }

        public static float easeInOut(float t)
        {
            return (t < 0.5f) ? easeIn(t * 2.0f) * 0.5f : 1 - easeIn(2.0f - t * 2.0f) * 0.5f;
        }

    };

    public static class Circ
    {
        public static float easeIn(float t)
        {
            return 1.0f - Mathf.Sqrt(1.0f - t * t);
        }

        public static float easeOut(float t)
        {
            return 1.0f - easeIn(1.0f - t);
        }

        public static float easeInOut(float t)
        {
            return (t < 0.5f) ? easeIn(t * 2.0f) * 0.5f : 1 - easeIn(2.0f - t * 2.0f) * 0.5f;
        }
    };

    public static class Cubic
    {
        public static float easeIn(float t)
        {
            return t * t * t;
        }

        public static float easeOut(float t)
        {
            return 1.0f - easeIn(1.0f - t);
        }

        public static float easeInOut(float t)
        {
            return (t < 0.5) ? easeIn(t * 2.0f) * 0.5f : 1 - easeIn(2.0f - t * 2.0f) * 0.5f;
        }
    };

    public static class Elastic
    {
        public static float easeIn(float t)
        {
            return 1.0f - easeOut(1.0f - t);
        }

        public static float easeOut(float t)
        {
            float s = 1 - t;
            return 1 - Mathf.Pow(s, 8) + Mathf.Sin(t * t * 6 * Mathf.PI) * s * s;
        }

        public static float easeInOut(float t)
        {
            return (t < 0.5) ? easeIn(t * 2.0f) * 0.5f : 1 - easeIn(2.0f - t * 2.0f) * 0.5f;
        }
    };

    public static class Expo
    {
        public static float easeIn(float t)
        {
            return Mathf.Pow(2, 10f * (t - 1));
        }

        public static float easeOut(float t)
        {
            return 1.0f - Mathf.Pow(2, -10 * t);
        }

        public static float easeInOut(float t)
        {
            return (t < 0.5) ? easeIn(t * 2.0f) * 0.5f : 1 - easeIn(2.0f - t * 2.0f) * 0.5f;
        }
    };

    public static class Linear
    {
        public static float easeIn(float t)
        {
            return t;
        }

        public static float easeOut(float t)
        {
            return t;
        }

        public static float easeInOut(float t)
        {
            return t;
        }
    };

    public static class Quad
    {
        public static float easeIn(float t)
        {
            return t * t;
        }

        public static float easeOut(float t)
        {
            return 1.0f - easeIn(1.0f - t);
        }

        public static float easeInOut(float t)
        {
            return (t < 0.5) ? easeIn(t * 2.0f) * 0.5f : 1 - easeIn(2.0f - t * 2.0f) * 0.5f;
        }
    };

    public static class Quart
    {
        public static float easeIn(float t)
        {
            return t * t * t * t;
        }

        public static float easeOut(float t)
        {
            return 1.0f - easeIn(1.0f - t);
        }

        public static float easeInOut(float t)
        {
            return (t < 0.5) ? easeIn(t * 2.0f) * 0.5f : 1 - easeIn(2.0f - t * 2.0f) * 0.5f;
        }
    };

    public static class Quint
    {
        public static float easeIn(float t)
        {
            return t * t * t * t * t;
        }

        public static float easeOut(float t)
        {
            return 1.0f - easeIn(1.0f - t);
        }

        public static float easeInOut(float t)
        {
            return (t < 0.5) ? easeIn(t * 2.0f) * 0.5f : 1 - easeIn(2.0f - t * 2.0f) * 0.5f;
        }
    };

    public static class Sine
    {
        public static float easeIn(float t)
        {
            return 1.0f - Mathf.Cos(t * (Mathf.PI * 0.5f));
        }

        public static float easeOut(float t)
        {
            return 1.0f - easeIn(1.0f - t);
        }

        public static float easeInOut(float t)
        {
            return (t < 0.5) ? easeIn(t * 2.0f) * 0.5f : 1 - easeIn(2.0f - t * 2.0f) * 0.5f;
        }
    };




    //-----------------------------------------------------


    public enum EASE_FUNCTION
    {
        Back, Bounce, Circ, Cubic, Elastic, Expo, Linear, Quad, Quart, Quint, Sine
    }

    public enum EASE_TYPE
    {
        EaseIn, EaseOut, EaseInOut
    }

    /// <summary>
    /// Simply interface for getting interpolated value.
    /// </summary>
    /// <returns>Interpolated value.</returns>
    /// <param name="t">Input value (0 to 1).</param>
    /// <param name="easeFunction">Ease function.</param>
    /// <param name="easeType">Ease type.</param>
    public static float GetInterpolated(float t, EASE_FUNCTION easeFunction, EASE_TYPE easeType)
    {
        switch (easeFunction)
        {
            case EASE_FUNCTION.Back:
                switch (easeType)
                {
                    case EASE_TYPE.EaseIn: return Easing.Back.easeIn(t);
                    case EASE_TYPE.EaseOut: return Easing.Back.easeOut(t);
                    case EASE_TYPE.EaseInOut: return Easing.Back.easeInOut(t);
                }
                break;

            case EASE_FUNCTION.Bounce:
                switch (easeType)
                {
                    case EASE_TYPE.EaseIn: return Easing.Bounce.easeIn(t);
                    case EASE_TYPE.EaseOut: return Easing.Bounce.easeOut(t);
                    case EASE_TYPE.EaseInOut: return Easing.Bounce.easeInOut(t);
                }
                break;

            case EASE_FUNCTION.Circ:
                switch (easeType)
                {
                    case EASE_TYPE.EaseIn: return Easing.Circ.easeIn(t);
                    case EASE_TYPE.EaseOut: return Easing.Circ.easeOut(t);
                    case EASE_TYPE.EaseInOut: return Easing.Circ.easeInOut(t);
                }
                break;

            case EASE_FUNCTION.Cubic:
                switch (easeType)
                {
                    case EASE_TYPE.EaseIn: return Easing.Cubic.easeIn(t);
                    case EASE_TYPE.EaseOut: return Easing.Cubic.easeOut(t);
                    case EASE_TYPE.EaseInOut: return Easing.Cubic.easeInOut(t);
                }
                break;

            case EASE_FUNCTION.Elastic:
                switch (easeType)
                {
                    case EASE_TYPE.EaseIn: return Easing.Elastic.easeIn(t);
                    case EASE_TYPE.EaseOut: return Easing.Elastic.easeOut(t);
                    case EASE_TYPE.EaseInOut: return Easing.Elastic.easeInOut(t);
                }
                break;

            case EASE_FUNCTION.Expo:
                switch (easeType)
                {
                    case EASE_TYPE.EaseIn: return Easing.Expo.easeIn(t);
                    case EASE_TYPE.EaseOut: return Easing.Expo.easeOut(t);
                    case EASE_TYPE.EaseInOut: return Easing.Expo.easeInOut(t);
                }
                break;

            case EASE_FUNCTION.Linear:
                switch (easeType)
                {
                    case EASE_TYPE.EaseIn: return Easing.Linear.easeIn(t);
                    case EASE_TYPE.EaseOut: return Easing.Linear.easeOut(t);
                    case EASE_TYPE.EaseInOut: return Easing.Linear.easeInOut(t);
                }
                break;

            case EASE_FUNCTION.Quad:
                switch (easeType)
                {
                    case EASE_TYPE.EaseIn: return Easing.Quad.easeIn(t);
                    case EASE_TYPE.EaseOut: return Easing.Quad.easeOut(t);
                    case EASE_TYPE.EaseInOut: return Easing.Quad.easeInOut(t);
                }
                break;

            case EASE_FUNCTION.Quart:
                switch (easeType)
                {
                    case EASE_TYPE.EaseIn: return Easing.Quart.easeIn(t);
                    case EASE_TYPE.EaseOut: return Easing.Quart.easeOut(t);
                    case EASE_TYPE.EaseInOut: return Easing.Quart.easeInOut(t);
                }
                break;

            case EASE_FUNCTION.Quint:
                switch (easeType)
                {
                    case EASE_TYPE.EaseIn: return Easing.Quint.easeIn(t);
                    case EASE_TYPE.EaseOut: return Easing.Quint.easeOut(t);
                    case EASE_TYPE.EaseInOut: return Easing.Quint.easeInOut(t);
                }
                break;

            case EASE_FUNCTION.Sine:
                switch (easeType)
                {
                    case EASE_TYPE.EaseIn: return Easing.Sine.easeIn(t);
                    case EASE_TYPE.EaseOut: return Easing.Sine.easeOut(t);
                    case EASE_TYPE.EaseInOut: return Easing.Sine.easeInOut(t);
                }
                break;
        }
        return t;
    }
};
