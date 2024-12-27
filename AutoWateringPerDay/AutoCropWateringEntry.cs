using System;
using EnergyConfiguration;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley.Objects;
using StardewValley.TerrainFeatures;
using StardewValley;
using System.Linq;

namespace EnergyConfiguration
{
    public class AutoCropWateringEntry : Mod
    {
        public ModConfig Config { get; set; }

        public override void Entry(IModHelper helper)
        {
            helper.Events.GameLoop.GameLaunched += OnGameLaunched;
            helper.Events.GameLoop.DayStarted += OnDayStarted;

            this.Config = this.Helper.ReadConfig<ModConfig>();
        }

        private void OnDayStarted(object sender, DayStartedEventArgs e)
        {
            // Only run on the weekends
            if (Config.GetDaysToWater().Any(day => day == Game1.Date.DayOfWeek))
            {
                foreach (GameLocation location in Game1.locations)
                {
                    // Each location has terrain features, and some may be able to grow plants
                    foreach (TerrainFeature terrainFeature in location.terrainFeatures.Values)
                    {
                        if (terrainFeature is HoeDirt hoedirt)
                        {
                            // Simple setting its value to 1 marks it as watered
                            hoedirt.state.Value = 1;
                        }
                    }

                    // Pots can be indside buildings as well
                    foreach (IndoorPot indoorPot in location.objects.Values.OfType<IndoorPot>())
                    {
                        indoorPot.showNextIndex.Value = true;
                    }
                }
            }
        }

        private void OnGameLaunched(object sender, GameLaunchedEventArgs e)
        {
            IGenericModConfigMenuApi configMenu = this.Helper.ModRegistry.GetApi<IGenericModConfigMenuApi>("spacechase0.GenericModConfigMenu");

            if (configMenu == null)
            {
                return;
            }

            // Register our mod's manifest
            configMenu.Register(
                mod: this.ModManifest,
                reset: () => Config = new ModConfig(),
                save: () => this.Helper.WriteConfig(this.Config));

            /*****************************************
             *            DAYS TO WATER
             *****************************************/
            configMenu.AddSectionTitle(
                mod: this.ModManifest,
                text: () => "Days to water");
            configMenu.AddParagraph(
                mod: this.ModManifest,
                text: () => "When checked, all crops will be automatically watered on the specified day");

            configMenu.AddBoolOption(
                mod: this.ModManifest,
                getValue: () => Config?.Sunday == true,
                setValue: (newValue) => Config.Sunday = newValue,
                name: () => "Sunday",
                tooltip: () => "Wether or not to water on Sundays");
            configMenu.AddBoolOption(
                mod: this.ModManifest,
                getValue: () => Config.Monday == false,
                setValue: (newValue) => Config.Monday = newValue,
                name: () => "Monday",
                tooltip: () => "Wether or not to water on Mondays");
            configMenu.AddBoolOption(
                mod: this.ModManifest,
                getValue: () => Config.Tuesday == false,
                setValue: (newValue) => Config.Tuesday = newValue,
                name: () => "Tuesday",
                tooltip: () => "Wether or not to water on Tuesdays");
            configMenu.AddBoolOption(
                mod: this.ModManifest,
                getValue: () => Config.Wednesday == false,
                setValue: (newValue) => Config.Wednesday = newValue,
                name: () => "Wednesday",
                tooltip: () => "Wether or not to water on Wednesdays");
            configMenu.AddBoolOption(
                mod: this.ModManifest,
                getValue: () => Config.Thursday == false,
                setValue: (newValue) => Config.Thursday = newValue,
                name: () => "Thursday",
                tooltip: () => "Wether or not to water on Thursdays");
            configMenu.AddBoolOption(
                mod: this.ModManifest,
                getValue: () => Config.Friday == false,
                setValue: (newValue) => Config.Friday = newValue,
                name: () => "Friday",
                tooltip: () => "Wether or not to water on Fridays");
            configMenu.AddBoolOption(
                mod: this.ModManifest,
                getValue: () => Config.Saturday == true,
                setValue: (newValue) => Config.Saturday = newValue,
                name: () => "Saturday",
                tooltip: () => "Wether or not to water on Saturdays");
        }
    }
}
