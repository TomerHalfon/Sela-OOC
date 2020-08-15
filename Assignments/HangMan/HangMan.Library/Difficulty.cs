namespace HangMan.Library
{
    /// <summary>
    /// The Game's difficulty levels
    /// </summary>
    public enum Difficulty : byte
    {
        Easy,
        Medium,
        Hard
    }
}
/*
 * The cool part here is that if we want to increase the amount of difficulties it's easy as adding to the enum.
 * bear in mind the the default word bank is hard coded, therefore when you try play at a new added level (more than 3) and choose to use the default word bank it will reset your difficulty to the default one (Easy = 0)
 */