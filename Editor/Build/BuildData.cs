[System.Serializable]
public class BuildData
{
    private int clients;

    public BuildData(int Clients)
    {
        clients = Clients;
    }
    public int GetClients()
    {
        return clients;
    }
}
