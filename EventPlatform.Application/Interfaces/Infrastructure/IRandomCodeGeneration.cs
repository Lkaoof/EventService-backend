namespace EventPlatform.RandomCodeGeneration
{
    public interface IRandomCodeGeneration
    {
        string GenerateRandomCode(int length = 10, bool uppercase = true, bool numbers = true);
    }
}