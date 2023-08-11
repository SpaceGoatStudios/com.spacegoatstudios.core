using UnityEngine;

namespace SpacegoatStudios.Core.Helpers
{
    public static class ConverterToIsometric
    {
        public static Vector3 ConvertToIsometric(this Vector3 input, Matrix4x4 isoMatrix)
        {
            Vector3 result = isoMatrix.MultiplyPoint3x4(input);

            return result;
        }
    }
}