using System;

[Serializable]
public class Coordinates : IEquatable<Coordinates>
{
    
    private const int HASH_CODE_BASE_VALUE = 10303;
    private const int HASH_CODE_MULTIPLICATION_VALUE = 15173;

    public int X;
    public int Y;

    public Coordinates(int coordinateX, int coordinateY)
    {
        X = coordinateX;
        Y = coordinateY;
    }

    public bool Equals(Coordinates otherCoordinates)
    {
        if (X == otherCoordinates?.X && Y == otherCoordinates?.Y)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = HASH_CODE_BASE_VALUE;

            hashCode = hashCode * HASH_CODE_MULTIPLICATION_VALUE + X;
            hashCode = hashCode * HASH_CODE_MULTIPLICATION_VALUE + Y;

            return hashCode;
        }
    }
}