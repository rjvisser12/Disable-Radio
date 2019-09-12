using GTA;
using System;
using GTA.Native;
using System.Windows.Forms;

namespace Disable_Radio
{
    public class Disable_Radio : Script
    {
        private bool enabled;
        private ScriptSettings config;
        private readonly int cheatString;
        private Keys Toggle_Radio;

        public Disable_Radio()
        {

            enabled = Settings.GetValue("SETTINGS", "ENABLED_ON_STARTUP", true);
            cheatString = Game.GenerateHash(Settings.GetValue("SETTINGS", "CHEAT_STRING", "radio"));
            config = ScriptSettings.Load("scripts\\Disable_Radio.ini");
            Toggle_Radio = config.GetValue<Keys>("Options", "Toggle_Radio:", Keys.None);

            Interval = 0;
            Tick += DisableRadio_Tick;
            KeyDown += ToggleRadio_Down;

        }

        private void DisableRadio_Tick(object sender, EventArgs e)
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
                        Function.Call(Hash.SET_VEHICLE_RADIO_ENABLED, veh, true);
                    }
                }
            }

            if (enabled && Game.Player.Character.IsInVehicle())
            {
                Vehicle veh = Game.Player.Character.CurrentVehicle;

                if (veh != null && veh.Exists() && veh.IsAlive)
                {
                    Function.Call(Hash.SET_VEHICLE_RADIO_ENABLED, Game.Player.Character.CurrentVehicle, false);
                }
            }
        }

        private void ToggleRadio_Down(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Toggle_Radio)
            {
                enabled = !enabled;
                UI.ShowSubtitle("~g~TESTTTTTTTTTT~g~");

                if (!enabled && Game.Player.Character.IsInVehicle())
                {
                    Vehicle veh = Game.Player.Character.CurrentVehicle;

                    if (veh != null && veh.Exists() && veh.IsAlive)
                    {
                        //enable radio when disable mod
                        Function.Call(Hash.SET_VEHICLE_RADIO_ENABLED, veh, true);
                    }
                }
            }

            if (enabled && Game.Player.Character.IsInVehicle())
            {
                Vehicle veh = Game.Player.Character.CurrentVehicle;

                if (veh != null && veh.Exists() && veh.IsAlive)
                {
                    Function.Call(Hash.SET_VEHICLE_RADIO_ENABLED, Game.Player.Character.CurrentVehicle, false);
                }
            }
        }
    }
}
