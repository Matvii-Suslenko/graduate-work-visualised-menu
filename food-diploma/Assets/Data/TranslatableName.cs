namespace Data
{
    [System.Serializable]
    public class TranslatableName
    {
        public TranslatableName(string ukrainianName, string englishName)
        {
            _ukrainianName = ukrainianName;
            _englishName = englishName;
        }
        
        public string _ukrainianName;
        public string _englishName;
    }
}
