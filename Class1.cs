using GTA;
using System;
using GTA.Native;


namespace Disable_Radio
{
    public class Disable_Radio : Script
    {
        private bool enabled;
        private readonly int cheatString;

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

                if (!enabled && Game.Player.Character.IsInVehicle())
                {
                    Vehicle veh = Game.Player.Character.CurrentVehicle;

                    if (veh != null && veh.Exists() && veh.IsAlive)
                    {
                        //enable radio when disable mod
                        Function.Call(Hash.SET_VEHICLE_RADIO_ENABLED, veh, false);
                    }
                }
            }

            if (enabled && Game.Player.Character.IsInVehicle())
            {
                Vehicle veh = Game.Player.Character.CurrentVehicle;

                if (veh != null && veh.Exists() && veh.IsAlive)
                {
                    Function.Call(Hash.SET_VEHICLE_RADIO_ENABLED, Game.Player.Character.CurrentVehicle, true);
                }
            }
        }
    }
}