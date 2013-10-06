using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DayZMap.Arma2Framework
{
    public class Preset
    {
        public bool showPlayers = false;
        public bool showPlayerNames = false;
        public bool showVehicles = false;
        public bool showVehicleNames = false;
        public bool showUnknowns = false;
        public bool showUnknownNames = false;
        public bool showDistance = false;
        public bool showPlayerWeapons = false;
        public bool enableNightVisionValue = false;
        public bool showAnimals = false;
        public bool showSomeItems = true;
        public bool showWeapons = false;
        public bool showAmmo = false;
        public bool showTents = false;
        public bool showHeloCrashes = false;
        public bool showRifles = false;
        public bool showSidearms = false;
        public bool showSMG = false;
        public bool showLMG = false;
        public bool showSniperRifles = false;
        public bool showShotguns = false;
        public bool showCorpses = false;
        public bool showBackpacks = false;
        public bool showFOVLines = false;
        public bool setDayTime = false;
        public bool showLocalFOVLines = false;
        public bool refuelVehicle = false;
        public bool refillGrenades = false;
        public bool fastBullets = false;
        public bool fastFire = false;
        public string searchBoxString = "wheel";
        public float currentMuzzleVelocity;

        public int mapSelection = 0;

        public static void ClearForm()
        {


        }
    }
}
