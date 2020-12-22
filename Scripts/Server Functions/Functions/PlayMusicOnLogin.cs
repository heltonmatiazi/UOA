using Server;
using Server.Network;

namespace Felladrin.Automations
{
    public static class PlayMusicOnLogin
    {
        public static class Config
        {
            public static bool Enabled = true;                          // Is this system enabled?
            public static bool PlayRandomMusic = true;                  // Should we play a random music from the list?
            public static MusicName SingleMusic = MusicName.Stones2;    // Music to be played if PlayRandomMusic = false.
        }

        public static void Initialize()
        {
            if (Config.Enabled)
                EventSink.Login += OnLogin;
        }

        static void OnLogin(LoginEventArgs args)
        {
            MusicName toPlay = Config.SingleMusic;

            if (Config.PlayRandomMusic)
                toPlay = MusicList[Utility.Random(MusicList.Length)];

            args.Mobile.Send(PlayMusic.GetInstance(toPlay));
        }
        
        public static MusicName[] MusicList = {
            MusicName.Forest_a,
            MusicName.Jungle_a,
            MusicName.Linelle,
            MusicName.Mountn_a,
            MusicName.OldUlt02,
            MusicName.OldUlt03,
            MusicName.OldUlt04,
            MusicName.ParoxysmusLair,
            MusicName.Paws,
            MusicName.Plains_a,
            MusicName.Stones2,
            MusicName.Swamp_a,
            MusicName.Victory
        };
    }
}