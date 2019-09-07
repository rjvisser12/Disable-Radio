using GTA;
using System;
using GTA.Native;


namespace DisablePhone
{
    public class Disable_Radio : Script
    {
        private bool enabled;
        private readonly int cheatString;

        private Ped PlayerPed = Game.Player.Character;
        private Vehicle Vehicle = Game.Player.Character.CurrentVehicle;

        public Disable_Radio()
        {
            enabled = Settings.GetValue("SETTINGS", "ENABLED_ON_STARTUP", true);
            cheatString = Game.GenerateHash(Settings.GetValue("SETTINGS", "CHEAT_STRING", "radio"));



            Interval = 0;
            Tick += Disableradio_Tick;
        }

        private void Disableradio_Tick(object sender, EventArgs e)
        {
            if (Function.Call<bool>(Hash._0x557E43C447E700A8, cheatString)) //_HAS_CHEAT_STRING_JUST_BEEN_ENTERED
            {
                enabled = !enabled;

                if (!enabled)
                {
                    //start radio script when disable
                    Function.Call(Hash.SET_VEHICLE_RADIO_ENABLED, Game.Player.Character.CurrentVehicle, false);
                }
            }

            if (enabled)
            {
                Function.Call(Hash.SET_VEHICLE_RADIO_ENABLED, Game.Player.Character.CurrentVehicle, true);
            }
        }
    }
}