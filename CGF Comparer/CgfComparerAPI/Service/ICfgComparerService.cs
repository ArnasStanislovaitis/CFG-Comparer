namespace CgfComparerAPI.Service
{
    public interface ICfgComparerService
    {
        string GetComparedData();
        public Task<string?> ReadFile(IFormFile file);
    }
}