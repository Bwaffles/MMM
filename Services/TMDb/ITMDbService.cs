namespace Services.TMDb
{
    public interface ITMDbService
    {
        string GetImagePath(string size, string filePath);
    }
}