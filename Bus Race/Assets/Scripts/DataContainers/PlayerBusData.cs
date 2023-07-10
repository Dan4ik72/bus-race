public class PlayerBusData
{
    public int FareAmount { get; private set; }
    public float BusSpeed { get; private set; }

    public void SetFareAmount(int fareAmount)
    {
        if (fareAmount < 0)
            throw new System.ArgumentOutOfRangeException(nameof(fareAmount));

        FareAmount = fareAmount;
    }

    public void SetBusSpeed(float busSpeed)
    {
        if (busSpeed < 0)
            throw new System.ArgumentOutOfRangeException(nameof(busSpeed));

        BusSpeed = busSpeed;
    }
}
