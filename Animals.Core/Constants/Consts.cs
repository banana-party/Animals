namespace Animals.Core.Constants
{
    public static class Consts
    {
        #region Animals
        public const string Cat = "Cat";
        public const string Dog = "Dog";
        public const string Stork = "Stork";
        public const string Chicken = "Chicken";
        public const string Wolf = "Wolf";
        public const string Tiger = "Tiger";
        
        #endregion

        #region SoundStrings
        public static string GetCatSound => "Мяяяу";
        public static string GetDogSound => "ГАВ";
        public static string GetChickenSound => "Пок-пок-пок";
        public static string GetStorkSound => "АААА";
        public static string GetWolfSound => "РЯЯЯ";
        public static string GetTigerSound => "ВУУУУ";

        #endregion

        #region SoundPathStrings

        public static string GetCatSoundPath => @"Sounds\meow.wav";
        public static string GetDogSoundPath =>@"Sounds\bark.wav";
        public static string GetChcikenSoundPath => @"Sounds\chicken.wav";
        public static string GetStorkSoundPath => @"Sounds\stork.wav";
        public static string GetWolfSoundPath => @"Sounds\wolf.wav";
        public static string GetTigerSoundPath => @"Sounds\tiger.wav";

        #endregion
    }
}
