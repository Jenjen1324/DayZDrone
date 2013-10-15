using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Diagnostics;
using System.Threading;

namespace DayZMap.Arma2Framework
{
    class Player
    {
        public String playerName;
        
        public float locX;
        public float locY;
        public double Dir;

    }

    class Map
    {
        #region classvariables
        const int DAYTIME = 2000000;
        const int NIGHTTIME = 0;
        const int timeOffset = 0xE256F8;
        const int distanceOffset = 0x0E25718; //0xE25708; //0x00E246C8;
        const int grassOffset = 0x14F0; // objtableaddr + this offset 
        const int rainOffset = 0x13EC;
        const int fogOffset = 0x13F8;

        const float grassOn = 0;
        const float grassOff = 50;

        Thread oThread;

        Preset preset = new Preset();
        

        Player[] playerList = new Player[150];


        int localPlayer;
        float zoomCoeffecicient = 1;

        float playerXCoord, playerYCoord;
        
        ProcessMemory Mem = new ProcessMemory("arma2oa");

        //95208 - 0x0DD3D48
        //95417 - 0x0DE20A8
        //95660 - 0x0DE0FF8
        //95724 - 95777 - 95883 - 0xDE1FF8
        //      - 0xDDF020
        // 

         int[] MasterOffsets = {0x87c + 0x4, 0xb20 + 0x4, 0xdc4 + 0x4};
         int[] TableOffsets = {0x4, 0xac, 0x154, 0x1fc};
        const uint numberMasterOffsets = 3;
        const uint numberTableOffsets = 4;
        const int ObjectTableAddr = 0xDFCDD8; //Latest
        const int PlayerInfoAddr = 0xDEEAE8; // latest 
        #endregion

        #region stringarrays
        string[] pistolArray = new String[] {
            "Makarov",
            "MakarovSD",
            "revolver_EP1",
            "Colt1911",
            "glock17_EP1",
            "UZI_EP1",
            "M9",
            "M9SD"
        };

        string[] shotgunArray = new String[] {
            "MR43",
            "Winchester1866",
            "M1014",
            "Remington870"
            };

        string[] rifleArray = new String[] {
            "AK_74",
            "AKS_74_kobra",
            "AKS_74_U",
            "AK_47_M",
            "FN_FAL",
            "FN_FAL_ANPVS4",
            "BAF_L85A2_RIS_CWS",
            "LeeEnfield",
            "M14_EP1",
            "M16A2",
            "M16A2GL",
            "m16a4_acg",
            "M4A1",
            "M4A1_Aim",
            "M4A1_AIM_SD_camo",
            "M4A1_HWS_GL",
            "M4A3_CCO_EP1",
            "M4A1_RCO_GL",                 
            "AK_107_kobra",
            "AK_107_GL_kobra",
            "AK_107_GL_pso",
            "AK_107_pso",
            "AK_47_S",
            "AK_74_GL",
            "AKS_74_UN_kobra",
            "AKS_GOLD",
            "G36a",
            "G36C",
            "G36_C_SD_eotech",
            "G36K"
        };

        string[] lmgArray = new String[] {
            "M240",
            "M249",
            "Mk_48_DZ",
            "Pecheneg_DZN",
            "PK_DZN",
            "RPK_74",
            "MG36"
        };
        
        string[] sniperArray = new String[] {
            "huntingrifle",
            "M24",
            "DMR",
            "SVD_CAMO",
            "m107_DZ",
            "BAF_AS50_scoped"
        };
        string[] meleeArray = new String[] {
            "MeleeHatchet",
            "MeleeCrowbar "
        };
        string[] backpackArray = new String[] {
            "CZ_VestPouch_EP1",
            "DZ_Patrol_Pack_EP1",
            "DZ_Assault_Pack_EP1",
            "DZ_CivilBackpack_EP1",
            "DZ_ALICE_Pack_EP1",
            "DZ_Backpack_EP1"
        };
        
        
        string[] banditArray = new string[] {
        	"Sniper1_DZ",
        	"Camo1_DZ",
        	"Bandit1_DZ"        	
        };
        
        string[] heroArray = new string[1] {
        	"Survivor3_DZ"
        };
        #endregion
       
        public Map()
        {
            Mem.StartProcess();
        }
        

        public void setZero(int value)
        {
            int objTable = Mem.ReadInt(ObjectTableAddr);
            int objTablePtr = Mem.ReadInt(objTable + 0x13A8);
            int objTablePtr1 = Mem.ReadInt(objTablePtr + 0x4);
            objTablePtr1 = Mem.ReadInt(objTablePtr1 + 0x694);
            int zeroPtr5 = objTablePtr1 + 0x20;
            Mem.WriteMem(zeroPtr5, sizeof(int), (int)value); 
            
        }

        public void disableGrass()
        {
            int grassPtr = Mem.ReadInt(ObjectTableAddr);
            grassPtr = grassPtr + 0x14F0;            
            Mem.WriteFloat(grassPtr, grassOff);
        }

        public void fixBrokenLegs()
        {
            int legAddress = Mem.ReadInt(localPlayer + 0xC0);
            legAddress = legAddress + 0xc;
            Mem.WriteFloat(legAddress, 0);
        }


        public void enableGrass()
        {
            int grassPtr = Mem.ReadInt(ObjectTableAddr);
            grassPtr = grassPtr + 0x14F0;
            Mem.WriteFloat(grassPtr,  grassOn);
        }

        public Player buildPlayerClass(int obj1, double Dir)
        {
            Player tempPlayer = new Player();
            tempPlayer.playerName = string.Copy(getPlayerName(obj1, 0));
            //Positions
            int coords = Mem.ReadInt(obj1 + 0x18);            
            tempPlayer.locX = Mem.ReadFloat(coords + 0x28);
            tempPlayer.locY = Mem.ReadFloat(coords + 0x30);
            tempPlayer.Dir = Dir;
            return tempPlayer;  
        }

        public void enableRain()
        {
            int rainPointer = Mem.ReadInt(ObjectTableAddr);
            rainPointer = rainPointer + rainOffset;
            Mem.WriteFloat(rainPointer, 1.0f);
        }

        public void disableRain()
        {
            int rainPointer = Mem.ReadInt(ObjectTableAddr);
            rainPointer = rainPointer + rainOffset;
            Mem.WriteFloat(rainPointer, 0.0f);
        }

        
        #region gettersandsetters
        public Player[] getPlayerArray()
        {
            return playerList;
        }
        
        public bool getSetDay()
        {
            return preset.setDayTime;
        }

        public void setSetDay(bool input)
        {
            preset.setDayTime = input;
        }

        public void setEnableNightVision(bool input)
        {
            preset.enableNightVisionValue = input;
        }

        public bool getEnableNightVision()
        {
            return preset.enableNightVisionValue;
        }

        public void setShowAnimals(bool input)
        {
            preset.showAnimals = input;
        }

        public void setShowSomeItems(bool input)
        {
            preset.showSomeItems = input;
        }

        public void setShowPlayers(bool input)
        {
            preset.showPlayers = input;
        }

        public void setShowPlayerNames(bool input)
        {
            preset.showPlayerNames = input;
        }

        public void setShowVehicles(bool input)
        {
            preset.showVehicles = input;
        }
        public void setShowVehicleNames(bool input)
        {
            preset.showVehicleNames = input;
        }
        public void setShowUnknowns(bool input)
        {
            preset.showUnknowns = input;
        }
        public void setShowUnknownNames(bool input)
        {
            preset.showUnknownNames = input;
        }

        public void setMapSelection(int map)
        {
            preset.mapSelection = map;
        }
        public void setShowPlayerWeapons(bool input)
        {
            preset.showPlayerWeapons = input;
        }
        public int getMapSelection()
        {
            return preset.mapSelection;
        }

        public void setZoomCoefficient(float zCoef)
        {
            zoomCoeffecicient = zCoef;
        }
        public void setShowDistance(bool input)
        {
            preset.showDistance = input;
        }

        public void setShowWeapons(bool input)
        {
            preset.showWeapons = input;
        }

        public void setShowAmmo(bool input)
        {
            preset.showAmmo = input;
        }

        public float getMuzzleVelocity()
        {
            return preset.currentMuzzleVelocity;
        }


        public void setSearchBoxString(string input)
        {
            preset.searchBoxString = string.Copy(input);
        }

        public void setShowTents(bool input)
        {
            preset.showTents = input;
        }

        public void setShowHeloCrashes(bool input)
        {
            preset.showHeloCrashes = input;
        }

        public void setShowRifles(bool input)
        {
            preset.showRifles = input;
        }

        public void setShowSidearms(bool input)
        {
            preset.showSidearms = input;
        }

        public void setShowSMG(bool input)
        {
            preset.showSMG = input;
        }

        public void setShowLMG(bool input)
        {
            preset.showLMG = input;
        }

        public void setShowSniperRifles(bool input)
        {
            preset.showSniperRifles = input;
        }

        public void setShowShotguns(bool input)
        {
            preset.showShotguns = input;
        }

        public void setShowCorpses(bool input)
        {
            preset.showCorpses = input;
        }

        public void setShowBackpacks(bool input)
        {
            preset.showBackpacks = input;
        }
        public void setRefillGrenades(bool input)
        {
            preset.refillGrenades = input;
        }

        public void setFastBullets(bool input)
        {
            preset.fastBullets = input;
        }

        public void setFastFire(bool input)
        {
            preset.fastFire = input;
        }

        public void setShowFOVLines(bool input)
        {
            preset.showFOVLines = input;
        }
        #endregion

        public void startThermalThread()
        {
            if (oThread != null && oThread.IsAlive)
            {
                oThread.Abort();
                return;
            }
            Thermal thermal = new Thermal(this);
            oThread = new Thread(new ThreadStart(thermal.getStarted));
            oThread.Start();
        }

        

        public void setCurrentMuzzleVelocity(float value)
        {            
            int objTable = Mem.ReadInt(ObjectTableAddr);
            int objTablePtr = Mem.ReadInt(objTable + 0x13A8);
            int objTablePtr1 = Mem.ReadInt(objTablePtr + 0x4);
            int objTablePtr2;

            int weaponID = Mem.ReadInt(objTablePtr1 + 0x6E0);
            objTablePtr1 = Mem.ReadInt(objTablePtr1 + 0x694);

            
            objTablePtr2 = Mem.ReadInt(objTablePtr1 + (weaponID * 0x24 + 0x4));
            int maxCntPtr = Mem.ReadInt(objTablePtr2 + 8);                       
            
            Mem.WriteFloat(maxCntPtr + 0x34, value);

        }
        public void setCurrentMuzzleVelocity(int obj, float value)
        {
            obj = Mem.ReadInt(obj + 0x54);
            obj = Mem.ReadInt(obj + 4);
            obj = Mem.ReadInt(obj + 8);
            Mem.WriteFloat(obj + 0x34, value);

        }

        public void setAutoRepair(bool value)
        {
            preset.refuelVehicle = value;
        }

        
        public void setDestructionBullet(float value)
        {
           //Sorry you can't have this        

        }

        public void setIndirectDamage(float value)
        {
            //Sorry you can't have this
        }

        public void setIndirectDamageRange(float value)
        {
            //Sorry you can't have this
        }

        public void setDestructionBullet(int obj, float value)
        {
            // Nope
            
        }

        public void resetDestructionBullet()
        {
            //Sorry you can't have this
        }

        public float getBulletDamage()
        {
            //Sorry you can't have this
            return 0;
        }

        public void setFatigue(float value)
        {
            int objTable = Mem.ReadInt(ObjectTableAddr);
            int objTablePtr = Mem.ReadInt(objTable + 0x13A8);
            int objTablePtr1 = Mem.ReadInt(objTablePtr + 0x4);            
            int fatigueAddress = objTablePtr1 + 0xC44;            
            Mem.WriteFloat(fatigueAddress, value);
        }

        public void refillAmmo(int value)
        {            
            int objTable = Mem.ReadInt(ObjectTableAddr);
            int objTablePtr = Mem.ReadInt(objTable + 0x13A8);
            int objTablePtr1 = Mem.ReadInt(objTablePtr + 0x4);
            int objTablePtr2;

            int weaponID = Mem.ReadInt(objTablePtr1 + 0x6E0);
            objTablePtr1 = Mem.ReadInt(objTablePtr1 + 0x694);

            objTablePtr2 = Mem.ReadInt(objTablePtr1 + (weaponID * 0x24 + 0x4));
            int maxCntPtr = Mem.ReadInt(objTablePtr2 + 8);          


            int maxCnt = Mem.ReadInt(maxCntPtr + 0x2C);
            int timeOut;

            if (maxCnt <= 2 && preset.refillGrenades)
            {
                Mem.WriteMem(maxCntPtr, sizeof(int), 3);
                maxCnt = Mem.ReadInt(maxCntPtr);

            }

            if (maxCnt > 2)
            {
                timeOut = objTablePtr2 + 0x14;
                if (preset.fastFire)
                {
                    //Nope
                }

                value = (int)(maxCnt * .75);
                int ammo1 = objTablePtr2 + 0xc;

                int ammo2 = objTablePtr2 + 0x24;
                uint tempint;
                uint int1 = (uint)(value ^ 0xBABAC8B6);
                tempint = int1;
                int1 = int1 << 1;
                uint int2 = tempint - (int1);
                Mem.WriteMem(ammo1, sizeof(int), (int)int1);
                Mem.WriteMem(ammo2, sizeof(int), (int)int2);                
            }
        }
        public void refillAmmo(int obj, int value)
        {
            
            obj = Mem.ReadInt(obj + 0x54);
            obj = Mem.ReadInt(obj + 4);
            
            int ammo1 = obj + 0xc;

            int ammo2 = obj + 0x24;
            uint tempint;
            uint int1 = ((uint)value ^ 0xBABAC8B6);
            tempint = int1;
            int1 = int1 << 1;
            uint int2 = tempint - (int1);
            Mem.WriteMem(ammo1, sizeof(int), (int)int1);
            Mem.WriteMem(ammo2, sizeof(int), (int)int2);
            
        }        

        public void fillVehicle(int entity)
        {
            int fuelLevelAddress = Mem.ReadInt(entity + 0x18);
            fuelLevelAddress = fuelLevelAddress + 0xAC;
            int fuelCapAddress = Mem.ReadInt(entity + 0x3C);
            fuelCapAddress = fuelCapAddress + 0x600;
            float fuelCap = Mem.ReadFloat(fuelCapAddress);
            float fuelLevel = Mem.ReadFloat(fuelLevelAddress);            
            Mem.WriteFloat(fuelLevelAddress, fuelCap);
        }

        public void repairVehicle(int entity, string vehicleName)
        {            
            int i = 0, j = 1;                    
                        
            j = Mem.ReadInt(entity + 0xc4);
            int partsAddress = Mem.ReadInt(entity + 0xC0);            
            for (i = 0; i < j; i++)
            {
                Mem.WriteFloat(partsAddress + i * 4, 0);                
            }
        }

        public void destroyVehicle(int entity, string vehicleName)
        {            
            int i = 0, j = 1;
            
            j = Mem.ReadInt(entity + 0xc4);
            int partsAddress = Mem.ReadInt(entity + 0xC0);            
            for (i = 0; i < j; i++)
            {
                Mem.WriteFloat(partsAddress + i * 4, 1);
                Debug.WriteLine("Repaired at address " + (partsAddress + 4 * i).ToString("X"));
            }
        }
        
        public void setRecoil(float value)
        {            
            int recoilPtr = Mem.ReadInt(ObjectTableAddr);
            recoilPtr = Mem.ReadInt(recoilPtr + 0x13A8);
            recoilPtr = Mem.ReadInt(recoilPtr + 0x4);
            recoilPtr = recoilPtr + 0xC28;
            Mem.WriteMem(recoilPtr, sizeof(int), 0);
        }

        public void teleport(float LocX, float LocY)
        {
            int objTable = Mem.ReadInt(ObjectTableAddr);
            int objTablePtr = Mem.ReadInt(objTable + 0x13A8);
            int objTablePtr1 = Mem.ReadInt(objTablePtr + 0x4);
            int coords = Mem.ReadInt(objTablePtr1 + 0x18);
            Mem.WriteFloat(coords + 0x28, LocX);
            Mem.WriteFloat(coords + 0x30, LocY);
            Mem.WriteFloat(coords + 0x2C, 0f);
        }
        
        public void teleport(float LocX, float LocY, double Dir)
        {
            int objTable = Mem.ReadInt(ObjectTableAddr);
            int objTablePtr = Mem.ReadInt(objTable + 0x13A8);
            int objTablePtr1 = Mem.ReadInt(objTablePtr + 0x4);
            int coords = Mem.ReadInt(objTablePtr1 + 0x18);
            int length = 100;
            LocX = (float)(LocX + (Math.Cos(Dir * Math.PI / 180 - Math.PI / 2) * length));
            LocY = (float)(LocY + (Math.Sin(Dir * Math.PI / 180 - Math.PI / 2) * length));


            Mem.WriteFloat(coords + 0x28, LocX);
            Mem.WriteFloat(coords + 0x30, LocY);
            Mem.WriteFloat(coords + 0x2C, 0f);
        }

        String readNameTable(int playerNamePointer)
        {
            int nameLength = Math.Min(Mem.ReadInt(playerNamePointer + 0x4), 32);
            if (nameLength > 0)
                return Mem.ReadStringAscii(playerNamePointer + 8, nameLength);
            else
                return "readNameTableNull";
        }

        int getPlayerInfo(int id)
        {            
            int currentObject = 0, idx, i = 0;         
            int currentPointer = Mem.ReadInt(PlayerInfoAddr + 0x24);
            int playerCount = Mem.ReadInt(currentPointer + 0x1C);
            currentPointer = Mem.ReadInt(currentPointer + 0x18);
            
            while (i < playerCount)
            {                
                currentObject = currentPointer + i * 0xF8; // Used to be F0
                
                idx = Mem.ReadInt(currentObject + 4);             
                if (idx == id)
                {   
                    return currentObject;
                }
                i++;

            }
            return 0;
        }
        String getVehiclePlayerName(int currentObject, int i)
        {
            int currentItem;
            String playerName, playerID;
            playerID = "UnwrittenID";
            playerName = "UnwrittenName";
            int nameID = Mem.ReadInt(currentObject + 0xAC8);

            if (nameID > 0)
            {
                currentItem = getPlayerInfo(nameID);
                if (currentItem != 0)
                {

                    playerID = readNameTable(Mem.ReadInt(currentItem + 0x30));
                    playerName = readNameTable(Mem.ReadInt(currentItem + 0x88)); // used to be 80

                    return playerName;
                }
                else
                    return "NoMatch";
            }
            else
            {
                return nameID.ToString();
            }


        }
        String getPlayerName(int currentObject, int i)
        {
            

            int currentItem;
            String playerName, playerID;
            playerID = "UnwrittenID";
            playerName = "UnwrittenName";
            int nameID = Mem.ReadInt(currentObject + 0xAC8);

            if (nameID == 1)
            {
                currentItem = Mem.ReadInt(currentObject + 0xA20);
                playerName = readNameTable(currentItem);
                return playerName;

            }else if (nameID > 0)
            {
                currentItem = getPlayerInfo(nameID);
                if (currentItem != 0)
                {
                    
                    playerID = readNameTable(Mem.ReadInt(currentItem + 0x30));
                    playerName = readNameTable(Mem.ReadInt(currentItem + 0x88)); // used to be 80
                                        
                    return playerName;
                }
                else
                    return "NoMatch";
            }else
            {
                return nameID.ToString();
            }
            

        }

        //Viewing Direction
        public static Image RotateImage(Image img, float rotationAngle)
        {
            Bitmap b = new Bitmap(img.Width, img.Height);
            Graphics graphic = Graphics.FromImage(b);
            graphic.TranslateTransform((float)b.Width / 2, (float)b.Height / 2);
            graphic.RotateTransform(rotationAngle);
            graphic.TranslateTransform(-(float)b.Width / 2, -(float)b.Height / 2);
            graphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphic.DrawImage(img, new Point(0, 0));
            graphic.Dispose();
            return b;
        }
        public float getRange()
        {
            int rangePtr1 = Mem.ReadInt(ObjectTableAddr);
            int rangePtr2 = Mem.ReadInt(rangePtr1 + 0x8);          

            float rangeValue = Mem.ReadFloat(rangePtr2 + 0x30);
            return rangeValue;
        }
        public void getCurrentPlayer(object sender, PaintEventArgs e)
        {
            int objTable = Mem.ReadInt(ObjectTableAddr);
            int objTablePtr = Mem.ReadInt(objTable + 0x13A8);
            int objTablePtr1 = Mem.ReadInt(objTablePtr + 0x4);
            localPlayer = objTablePtr1;            
            float blood = Mem.ReadFloat(objTablePtr1 + 0xC0);
            

            //Positions
            int coords = Mem.ReadInt(objTablePtr1 + 0x18);
            float LocX = 0, LocY = 0;
            if (preset.mapSelection == 0)
            {
                LocX = (((Mem.ReadFloat(coords + 0x28)) / (15360.0f / 975.0f)));
                LocY = (((15360.0f - Mem.ReadFloat(coords + 0x30)) / (15360.0f / 970.0f)) - 4);
                playerXCoord = LocX;
                playerYCoord = LocY;
            }
            else if (preset.mapSelection == 1)
            {
                LocX = (((Mem.ReadFloat(coords + 0x28)) / 10f) * .975f);
                LocY = (((10000.0f - Mem.ReadFloat(coords + 0x30)) * .0975f) - 2);
            }
            else if (preset.mapSelection == 2)
            {
                LocX = ((Mem.ReadFloat(coords + 0x28)) / 20f) * .75f;
                LocY = (((25600.0f - Mem.ReadFloat(coords + 0x30)) * .0376f) - 2);
            }
            else if (preset.mapSelection == 3)
            {
                LocX = (((Mem.ReadFloat(coords + 0x28))) / 10f) * 1.06f - 140f;
                LocY = (((12800.0f - Mem.ReadFloat(coords + 0x30)) * .106f) +50f);
            }

            playerXCoord = Mem.ReadFloat(coords + 0x28);
            playerYCoord = Mem.ReadFloat(coords + 0x30);

            // coords + 1C = YDirection
            // coords + 20 = ZDirection?
            // coords + 24 = XDirection
            // coords + 28 = XCoord
            // coords + 2C = ZCoord
            // coords + 30 = YCoord
                    
            //Direction
            int direction = 0x01C;
            float Y = Mem.ReadFloat(coords + direction);
            float X = Mem.ReadFloat(coords + direction + 8);
            double Dir = Math.Atan2(Y, X) * (180 / Math.PI);
            if (Dir < 0) Dir = 360 + Dir;
            double Dir2 = Math.Atan2(Y, X);

            if (preset.showLocalFOVLines)
            {
                Pen myPen = new Pen(Color.Green);
                myPen.Width = 1 * (1 / zoomCoeffecicient);
                int length = 50;
                float LocX2 = (float)(LocX + 5 / zoomCoeffecicient + (Math.Cos(Dir * Math.PI / 180 - Math.PI / 2) * length));
                float LocY2 = (float)(LocY + 7.5 / zoomCoeffecicient + (Math.Sin(Dir * Math.PI / 180 - Math.PI / 2) * length));
                e.Graphics.DrawLine(myPen, LocX + 5 / zoomCoeffecicient, LocY + 7.5f / zoomCoeffecicient, LocX2, LocY2);
            }

            Image bmp = RotateImage(global::DayZMap.Properties.Resources.blue_arrow, (float)Dir);
            e.Graphics.DrawImage(bmp, LocX, LocY, 10 * (1 / zoomCoeffecicient), 15 * (1 / zoomCoeffecicient));
        }
        
        public float[] getCurrentPlayerGameCoords()
        {
            int objTable = Mem.ReadInt(ObjectTableAddr);
            int objTablePtr = Mem.ReadInt(objTable + 0x13A8);
            int objTablePtr1 = Mem.ReadInt(objTablePtr + 0x4);

            //Positions
            int coords = Mem.ReadInt(objTablePtr1 + 0x18);
            float LocX = (Mem.ReadFloat(coords + 0x28)) / 100;
            float LocY = (Mem.ReadFloat(coords + 0x30)) / 100;
            float altitude = (Mem.ReadFloat(coords + 0x2c));
            float[] playerCoords = { LocX, LocY, altitude };

            return playerCoords;
        }

        public float[] getCurrentPlayerGameCoordsMap()
        {
            int objTable = Mem.ReadInt(ObjectTableAddr);
            int objTablePtr = Mem.ReadInt(objTable + 0x13A8);
            int objTablePtr1 = Mem.ReadInt(objTablePtr + 0x4);

            //Positions
            int coords = Mem.ReadInt(objTablePtr1 + 0x18);
            float LocX = 0, LocY = 0;

            if (preset.mapSelection == 0)
            {
                
                LocX = (((Mem.ReadFloat(coords + 0x28)) / (15360.0f / 975.0f)));
                LocY = (((15360.0f - Mem.ReadFloat(coords + 0x30)) / (15360.0f / 970.0f)) - 4);
            }


            else if (preset.mapSelection == 1)
            {
                LocX = (((Mem.ReadFloat(coords + 0x28)) / 10f) * .975f);
                LocY = (((10000.0f - Mem.ReadFloat(coords + 0x30)) * .0975f) - 2);
            }
            else if (preset.mapSelection == 2)
            {
                LocX = ((Mem.ReadFloat(coords + 0x28)) / 20f) * .75f;
                LocY = (((25600.0f - Mem.ReadFloat(coords + 0x30)) * .0376f) - 2);
            }
            else if (preset.mapSelection == 3)
            {
                LocX = (((Mem.ReadFloat(coords + 0x28))) / 10f) * 1.06f - 140f;
                LocY = (((12800.0f - Mem.ReadFloat(coords + 0x30)) * .106f) + 50f);
            }

            float[] playerCoords = { LocX, LocY };

            return playerCoords;
        }
        public void enableNightVision()
        {
            //0xDE20A8] + 13A4]+ 4]+C16]
            int objTable = Mem.ReadInt(ObjectTableAddr);
            int objTablePtr = Mem.ReadInt(objTable + 0x13A8);
            int objTablePtr1 = Mem.ReadInt(objTablePtr + 0x4);

            Mem.WriteBool(objTablePtr1 + 0xc16, true);

        }

        public void setViewDistance(float distance)
        {
            if (distance > 1)
            {
                Mem.WriteFloat(distanceOffset, distance);
            }
        }
        // God damn it
        public void setDay()
        {            
            Mem.WriteMem(timeOffset, sizeof(int), DAYTIME);            
        }

        public void setNight()
        {
            Mem.WriteMem(timeOffset, sizeof(int), NIGHTTIME);
        }

        public void forceNightVision()
        {
            //0xDE20A8] + 13A4]+ 4]+C16]
            int objTable = Mem.ReadInt(ObjectTableAddr);
            int objTablePtr = Mem.ReadInt(objTable + 0x13A8);
            int objTablePtr1 = Mem.ReadInt(objTablePtr + 0x4);

            Mem.WriteBool(objTablePtr1 + 0xc15, true);

        }

        public void forceThermalVision()
        {
            //0xDE20A8] + 13A8]+ 4]+C16]
            int objTable = Mem.ReadInt(ObjectTableAddr);
            int objTablePtr = Mem.ReadInt(objTable + 0x13A8);
            int objTablePtr1 = Mem.ReadInt(objTablePtr + 0x4);

            Mem.WriteBool(objTablePtr1 + 0xc18, true);
            

        }

        public String getWeapon(int objAddress)
        {
            int weaponID;
            String weaponName = " ";
            weaponID = Mem.ReadInt(objAddress + 0x678 + 0x68);
            
            if (weaponID != -1)
            {
                int tempPointer = Mem.ReadInt(objAddress + 0x0678 + 0x1c);

                tempPointer = Mem.ReadInt(tempPointer + 0x24 * weaponID + 0x8);
                
                tempPointer = Mem.ReadInt(tempPointer + 0x10);
                int weaponNameAddress = Mem.ReadInt(tempPointer + 0x4);
                if (weaponName != null)
                {
                    weaponName = readArmaString(weaponNameAddress);
                }
            }
            return weaponName;

        }

        public String readArmaString(int weaponNameAddress)
        {
            const int maxStringLength = 0x40;
            int absoluteLength = Mem.ReadInt(weaponNameAddress + 0x4);
            if (absoluteLength > maxStringLength)
            {
                return "";
            }
            
            return Mem.ReadStringAscii(weaponNameAddress + 8, absoluteLength);


        }

        public void suicide()
        {
            int objTable = Mem.ReadInt(ObjectTableAddr);
            int objTablePtr = Mem.ReadInt(objTable + 0x13A8);
            int objTablePtr1 = Mem.ReadInt(objTablePtr + 0x4);
            
            //Positions
            int coords = Mem.ReadInt(objTablePtr1 + 0x18);
            float LocX = (Mem.ReadFloat(coords + 0x28));
            float LocY = (Mem.ReadFloat(coords + 0x30));
            float LocZ = (Mem.ReadFloat(coords + 0x2c));
            Mem.WriteFloat(coords + 0x28, LocX + 50);
            //Mem.WriteFloat(coords + 0x2c, 0);
        }


        public float[] getCurrentPlayerCoords()
        {
            int objTable = Mem.ReadInt(ObjectTableAddr);
            int objTablePtr = Mem.ReadInt(objTable + 0x13A8);
            int objTablePtr1 = Mem.ReadInt(objTablePtr + 0x4);
            float LocX = 0, LocY = 0;
            //Positions
            int coords = Mem.ReadInt(objTablePtr1 + 0x18);

            if (preset.mapSelection == 0) 
            {
                LocX = (((Mem.ReadFloat(coords + 0x28)) / (15360.0f / 975.0f)));
                LocY = (((15360.0f - Mem.ReadFloat(coords + 0x30)) / (15360.0f / 970.0f)) - 4);
            }
            else if (preset.mapSelection == 1)
            {
                LocX = (((Mem.ReadFloat(coords + 0x28)) / 10f) * .975f);
                LocY = (((10000.0f - Mem.ReadFloat(coords + 0x30)) * .0975f) - 2);
            }
            else if (preset.mapSelection == 2)
            {
                LocX = ((Mem.ReadFloat(coords + 0x28)) / 20f) * .75f;
                LocY = (((25600.0f - Mem.ReadFloat(coords + 0x30)) * .0376f) - 2);
            }
            else if (preset.mapSelection == 3)
            {
                LocX = (((Mem.ReadFloat(coords + 0x28))) / 10f) * 1.06f - 140f;
                LocY = (((12800.0f - Mem.ReadFloat(coords + 0x30)) * .106f) + 50f);
            }
            // Class wide coordinates to calculate distance in map draw function
            playerXCoord = LocX;
            playerYCoord = LocY;

            float[] playerCoords= {LocX, LocY};

            return playerCoords;
        }

        public void IterateEntityTables(object sender, PaintEventArgs e)
        {
            for (uint i = 0; i < numberMasterOffsets; i++)
            {
                IterateEntityTables(MasterOffsets[i], sender, e);
            }
        }

        public void IterateEntityTables(int masterOffset, object sender, PaintEventArgs e)
        {
            uint[] baseOffset = new uint[] { 0 };
            int entityTableBasePtr = Mem.ReadInt(ObjectTableAddr) + masterOffset;

            for (uint i = 0; i < numberTableOffsets; i++)
            {
                int size = Mem.ReadInt(entityTableBasePtr + 0x8 + TableOffsets[i]);
                IterateEntityTable(entityTableBasePtr + TableOffsets[i], size, sender, e);

                Font drawFont = new Font("Arial", 8 * 1 / zoomCoeffecicient);
                Brush blackBrush = Brushes.Black;
                
            }
        }

        public void IterateEntityTable(int begin, int size, object sender, PaintEventArgs e)
        {
            for (int i = 0; i < size; i++)
            {
                int[] entityOffsets = new int[] { 4, 4 * i };
                int firstPointer = Mem.ReadInt(begin + 4);
                int entityAddress = Mem.ReadInt(firstPointer + 4*i);
                handleEntity(entityAddress, sender, e);
            }
        }

        public void handleEntity(int entityAddress, object sender, PaintEventArgs e)
        {


            int obj1 = entityAddress;
            
            int obj2 = Mem.ReadInt(obj1 + 0x3C);
            int obj3 = Mem.ReadInt(obj2 + 0x30);

            //Name
            string objName = Mem.ReadStringAscii(obj3 + 0x8, 25);
            //Positions
              int coords = Mem.ReadInt(obj1 + 0x18);
            float LocX = 0, LocY = 0, mapLocX, mapLocY;
            mapLocX = Mem.ReadFloat(coords + 0x28);
            mapLocY = Mem.ReadFloat(coords + 0x30);
            if (preset.mapSelection == 0)
            {
                LocX = (((mapLocX) / (15360.0f / 975.0f)));
                LocY = (((15360.0f - mapLocY) / (15360.0f / 970.0f)) - 4);
            }
            else if (preset.mapSelection == 1)
            {
                LocX = (((mapLocX) / 10f) * .975f);
                LocY = (((10000.0f - mapLocY) * .0975f) - 2);
            }
            else if (preset.mapSelection == 2)
            {
                LocX = ((mapLocX) / 20f) * .75f;
                LocY = (((25600.0f - mapLocY) * .0376f) - 2);
            }
            else if (preset.mapSelection == 3)
            {
                LocX = ((mapLocX) / 10f) * 1.06f - 140f;
                LocY = (((12800.0f - mapLocY) * .106f) + 50f);
            }
            int distance = (int)Math.Sqrt(Math.Pow((playerYCoord - mapLocY), 2) + Math.Pow((playerXCoord - mapLocX), 2));
            Font drawFont = new Font("Arial", 6 * 1 / zoomCoeffecicient);
            Brush blackBrush = Brushes.Black;


            if (objName.IndexOf("TentStorage") >= 0 && preset.showTents)
            {
                Image bmp = RotateImage(global::DayZMap.Properties.Resources.tent, 1f);
                e.Graphics.DrawImage(bmp, LocX, LocY, 10 * (1 / zoomCoeffecicient), 15 * (1 / zoomCoeffecicient));
            }

            else if (objName.IndexOf("UH1Wreck") >= 0 && preset.showHeloCrashes)
            {
                Image bmp = RotateImage(global::DayZMap.Properties.Resources.crash_site, 1f);
                e.Graphics.DrawImage(bmp, LocX, LocY, 10 * (1 / zoomCoeffecicient), 15 * (1 / zoomCoeffecicient));                
            }
            else if (((objName.IndexOf("WildBoar") >= 0) || (objName.IndexOf("Rabbit") >= 0) || (objName.IndexOf("Cow") >= 0) || (objName.IndexOf("Sheep") >= 0) || (objName.IndexOf("Goat") >= 0) || (objName.IndexOf("Hen") >= 0)) && preset.showAnimals)
            {
                Image bmp = RotateImage(global::DayZMap.Properties.Resources.animal, 1f);
                e.Graphics.DrawString(objName, drawFont, blackBrush, LocX + 15 * (1/zoomCoeffecicient), LocY);
                e.Graphics.DrawImage(bmp, LocX, LocY, 10 * (1 / zoomCoeffecicient), 15 * (1 / zoomCoeffecicient));
            }
            else if (backpackArray.Contains(objName) && preset.showBackpacks)
            {
                Image bmp = RotateImage(global::DayZMap.Properties.Resources.someItem, 1f);
                e.Graphics.DrawString(objName, drawFont, blackBrush, LocX + 15 * (1/zoomCoeffecicient), LocY);
                e.Graphics.DrawImage(bmp, LocX, LocY, 10 * (1 / zoomCoeffecicient), 15 * (1 / zoomCoeffecicient));
            }
            else if (objName.ToLower().IndexOf("skin") >= 0)
            {
                Image bmp = RotateImage(global::DayZMap.Properties.Resources.animal, 1f);
                e.Graphics.DrawString(objName, drawFont, blackBrush, LocX + 15 * (1 / zoomCoeffecicient), LocY);
                e.Graphics.DrawImage(bmp, LocX, LocY, 10 * (1 / zoomCoeffecicient), 15 * (1 / zoomCoeffecicient));
            }



            else if (objName.IndexOf("WeaponHolder") >= 0 && (preset.showWeapons || preset.showAmmo || preset.showRifles || preset.showSMG || preset.showSidearms || preset.showLMG || preset.showSniperRifles || preset.showShotguns))
            {
                Image bmp = RotateImage(global::DayZMap.Properties.Resources.someItem, 1f);
                int numWeaponsAddress = Mem.ReadInt(entityAddress + 0x21c);
                int numWeapons = Mem.ReadInt(numWeaponsAddress + 0x10);
                int weaponNamePointer1 = Mem.ReadInt(numWeaponsAddress + 0xc);
                int numAmmo = Mem.ReadInt(numWeaponsAddress + 0x1c);
                int ammoNamePointer = Mem.ReadInt(numWeaponsAddress + 0x18);
                int w = 0;
                int a = 0;
                if (true)
                {
                    for (w = 0; w < numWeapons; w++)
                    {
                        int weaponNamePointer2 = Mem.ReadInt(weaponNamePointer1 + 4 * w);
                        int weaponNamePointer3 = Mem.ReadInt(weaponNamePointer2 + 0x10);
                        int weaponNamePointer4 = Mem.ReadInt(weaponNamePointer3 + 0x4);
                        string weaponName = readArmaString(weaponNamePointer4);
                        if (preset.showWeapons)
                        {
                            if ((weaponName.ToLower().IndexOf(preset.searchBoxString.ToLower()) >= 0) || preset.searchBoxString.CompareTo("") == 0)
                            {
                                e.Graphics.DrawString(weaponName, drawFont, blackBrush, LocX + 15 * (1 / zoomCoeffecicient), LocY + w * 10 / zoomCoeffecicient);
                                
                                e.Graphics.DrawImage(bmp, LocX, LocY, 10 * (1 / zoomCoeffecicient), 15 * (1 / zoomCoeffecicient));
                            }
                        }
                        else if (rifleArray.Contains(weaponName) && preset.showRifles)
                        {

                            e.Graphics.DrawString(weaponName, drawFont, blackBrush, LocX + 15 * (1 / zoomCoeffecicient), LocY);
                            e.Graphics.DrawImage(bmp, LocX, LocY, 10 * (1 / zoomCoeffecicient), 15 * (1 / zoomCoeffecicient));
                        }
                        else if ((pistolArray.Contains(weaponName) || meleeArray.Contains(weaponName)) && preset.showSidearms)
                        {

                            e.Graphics.DrawString(weaponName, drawFont, blackBrush, LocX + 15 * (1 / zoomCoeffecicient), LocY);
                            e.Graphics.DrawImage(bmp, LocX, LocY, 10 * (1 / zoomCoeffecicient), 15 * (1 / zoomCoeffecicient));
                        }
                        else if (shotgunArray.Contains(weaponName) && preset.showShotguns)
                        {

                            e.Graphics.DrawString(weaponName, drawFont, blackBrush, LocX + 15 * (1 / zoomCoeffecicient), LocY);
                            e.Graphics.DrawImage(bmp, LocX, LocY, 10 * (1 / zoomCoeffecicient), 15 * (1 / zoomCoeffecicient));
                        }
                        else if (sniperArray.Contains(weaponName) && preset.showSniperRifles)
                        {

                            e.Graphics.DrawString(weaponName, drawFont, blackBrush, LocX + 15 * (1 / zoomCoeffecicient), LocY);
                            e.Graphics.DrawImage(bmp, LocX, LocY, 10 * (1 / zoomCoeffecicient), 15 * (1 / zoomCoeffecicient));
                        }
                        else if (lmgArray.Contains(weaponName) && preset.showLMG)
                        {

                            e.Graphics.DrawString(weaponName, drawFont, blackBrush, LocX + 15 * (1 / zoomCoeffecicient), LocY);
                            e.Graphics.DrawImage(bmp, LocX, LocY, 10 * (1 / zoomCoeffecicient), 15 * (1 / zoomCoeffecicient));
                        }

                    } // for
                }

                if (preset.showAmmo)
                {
                    for (a = 0; a < numAmmo; a++)
                    {
                        int ammoNamePointer2 = Mem.ReadInt(ammoNamePointer + a * 4);
                        int ammoNamePointer3 = Mem.ReadInt(ammoNamePointer2 + 0x8);
                        int ammoNamePointer4 = Mem.ReadInt(ammoNamePointer3 + 0xC);
                        int ammoNamePointer5 = Mem.ReadInt(ammoNamePointer4 + 0x4);
                        string ammoName = readArmaString(ammoNamePointer5);
                        if ((ammoName.ToLower().IndexOf(preset.searchBoxString.ToLower()) >= 0) || preset.searchBoxString.CompareTo("") == 0)
                        {
                            e.Graphics.DrawString(ammoName, drawFont, blackBrush, LocX + 15 * (1 / zoomCoeffecicient), LocY + w * 10 / zoomCoeffecicient);
                            e.Graphics.DrawImage(bmp, LocX, LocY, 10 * (1 / zoomCoeffecicient), 15 * (1 / zoomCoeffecicient));
                        }
                    } // for
                } // if               
            }            
        }
        
        public void refreshMap(object sender, PaintEventArgs e)
        {
            String passengerName;
            String playerName;
            int maxSeats;
            int driver;
            int passengers;
            int currentPassenger;
            int gunnerptrptr;
            int gunnerptr;
            int gunner;
            int maxGunners;
            int length;
            
            int side;
            float gunnerAngle;
            float LocX2, LocY2, X, Y;

            double gunnerDegrees;
            double Dir;
            Pen myPen;
            if(preset.mapSelection == 0)
                e.Graphics.DrawImage(global::DayZMap.Properties.Resources.bigmap, 0, 0, 980, 980);
            else if(preset.mapSelection == 1)
                e.Graphics.DrawImage(global::DayZMap.Properties.Resources.lingor_map, 0, 0, 980, 980);
            else if(preset.mapSelection == 2)
                e.Graphics.DrawImage(global::DayZMap.Properties.Resources.taviana, 0, 0, 980, 980);
            else if(preset.mapSelection == 3)
                e.Graphics.DrawImage(global::DayZMap.Properties.Resources.namalsk, 0, 0, 980, 980);   
            
                

                int ObjTable = Mem.ReadInt(ObjectTableAddr);
                int objTablePtr = Mem.ReadInt(ObjTable + 0x5FC);
                int objTableArrayPtr = Mem.ReadInt(objTablePtr + 0x0);
                int objTableSize = Mem.ReadInt(objTablePtr + 0x4);

                

                IterateEntityTables(sender, e);

                Debug.WriteLine(objTableSize, "Object Table Count is");
                for (int i = 0; i < objTableSize; i++)
                {
                    int objPtr = Mem.ReadInt(objTableArrayPtr + (i * 52));
                    
                    int obj1 = Mem.ReadInt(objPtr + 0x4);
                    int obj2 = Mem.ReadInt(obj1 + 0x3C);
                    int obj3 = Mem.ReadInt(obj2 + 0x30);
                    int obj4 = Mem.ReadInt(obj3 + 0x3c);
                    int obj5 = Mem.ReadInt(obj2 + 0x6c);

                    //Type
                    String objType = readArmaString(obj5);
                    Debug.WriteLine(objType);

                    //Name
                    string objName = Mem.ReadStringAscii(obj3 + 0x8, 25);
                    
                    //Dead
                    bool IsDead = (Mem.ReadByte(obj1 + 0x20C) > 0);
                    bool isPlayer = false;

                    //side
                    side = Mem.ReadInt(obj1 + 0x15c);

                    //RealPlayer
                    playerName = getPlayerName(obj1, i);
                    bool isRealPlayer = Mem.ReadInt(obj1 + 0xA90) == 1;
                    

                    //Positions
                    int coords = Mem.ReadInt(obj1 + 0x18);
                    float LocX = 0, LocY = 0, mapLocX, mapLocY;
                    mapLocX = Mem.ReadFloat(coords + 0x28);
                    mapLocY = Mem.ReadFloat(coords + 0x30);
                    if (preset.mapSelection == 0)
                    {
                        LocX = (((mapLocX) / (15360.0f / 975.0f)));
                        LocY = (((15360.0f - mapLocY) / (15360.0f / 970.0f)) - 4);
                    }
                    else if (preset.mapSelection == 1)
                    {
                        LocX = (((mapLocX) / 10f) * .975f);
                        LocY = (((10000.0f - mapLocY) * .0975f) - 2);
                    }
                    else if (preset.mapSelection == 2)
                    {
                        LocX = ((mapLocX) / 20f)*.75f ;
                        LocY = (((25600.0f - mapLocY) * .0376f) - 2);
                    }
                    else if (preset.mapSelection == 3)
                    {
                        LocX = ((mapLocX) / 10f) * 1.06f - 140f;
                        LocY = (((12800.0f - mapLocY) * .106f) + 50f);
                    }
                    

                    int distance =(int) Math.Sqrt( Math.Pow( (playerYCoord - mapLocY) , 2 ) + Math.Pow( ( playerXCoord - mapLocX ) , 2 ) );

                    //Direction
                    int direction = 0x01C;
                    Y = Mem.ReadFloat(coords + direction);
                    X = Mem.ReadFloat(coords + direction + 8);
                    Dir = Math.Atan2(Y, X) * (180 / Math.PI);
                    Font drawFont = new Font("Arial", 8 * 1 / zoomCoeffecicient);
                    if (Dir < 0) Dir = 360 + Dir;
                    
                    //Display on the Map
                    if (LocX > 0 && LocY > 0)
                    {
                        Font Arial = new Font("Arial", 8, FontStyle.Regular);

                        //Vehicles                        
                        if (objType.CompareTo("car") == 0 || objType.CompareTo("helicopter") == 0 || objType.CompareTo("tank") == 0 || objType.CompareTo("airplane") == 0 || objType.CompareTo("motorcycle") == 0 || objType.CompareTo("parachute") == 0)
                        {


                            if (preset.refuelVehicle && (obj1 == localPlayer))
                            {
                                fillVehicle(obj1);
                                repairVehicle(obj1, objName);
                            }

                            if (preset.showVehicleNames && preset.showVehicles)
                            {
                                Brush blackBrush = Brushes.Black;
                                e.Graphics.DrawString(objName, drawFont, blackBrush, LocX + 10*(1/zoomCoeffecicient), LocY);
                            }
                            if (preset.showVehicles && !IsDead)
                            {
                                maxSeats = Mem.ReadInt(obj1 + 0xb00);
                                driver = Mem.ReadInt(obj1 + 0xAB0);
                                passengers = Mem.ReadInt(obj1 + 0xAFC);
                                maxGunners = Mem.ReadInt(obj1 + 0xB60);
                                gunnerptrptr = Mem.ReadInt(obj1 + 0xb5c);
                                
                                
                                Brush blackBrush = Brushes.Black;
                                Brush redBrush = Brushes.Red;
                                if (driver != 0)
                                {
                                    passengerName = getPlayerName(driver, i);
                                    if (passengerName.CompareTo(objName) != 0)
                                    {
                                        e.Graphics.DrawString(passengerName, drawFont, blackBrush, LocX + 10 * (1 / zoomCoeffecicient), LocY + 10 / zoomCoeffecicient);
                                    }
                                }

                                for (int ii = 0; ii < maxSeats; ii++)
                                {
                                    currentPassenger = Mem.ReadInt(passengers + 8 * ii);
                                    if (currentPassenger != 0)
                                    {
                                        
                                        passengerName = getPlayerName(currentPassenger, i);
                                        e.Graphics.DrawString(passengerName, drawFont, blackBrush, LocX + 10 * (1 / zoomCoeffecicient), LocY + + 10/zoomCoeffecicient + 10 * (ii + 1) / zoomCoeffecicient);
                                    }
                                }
                                // Reversing gunner positions
                                // Vehicle entity + 0b5c + i*8 + 2cc = pointer to gunner
                                // Vehicle entity + 0v5c + i*8 + 2f8 = x/y angle of gun in radians
                                // Vehicle ammo is gunnerptr + 0x54 + c/0x24
                                for (int j = 0; j < maxGunners; j++)
                                {
                                    gunnerptr = Mem.ReadInt(gunnerptrptr + j*4);
                                    gunner = Mem.ReadInt(gunnerptr + 0x2cc);
                                    gunnerAngle = Mem.ReadFloat(gunnerptr + 0x2f8);
                                    refillAmmo(gunnerptr, 100);
                                    setDestructionBullet(gunnerptr, 50);
                                    setCurrentMuzzleVelocity(gunnerptr, 9000);
                                    if (gunner != 0)
                                    {
                                        passengerName = getPlayerName(gunner, i);
                                        if(passengerName.CompareTo("NoMatch") == 0) break;
                                        
                                        //Debug.WriteLine(j);
                                        e.Graphics.DrawString(passengerName, drawFont, redBrush, LocX + 10 * (1 / zoomCoeffecicient), LocY - 10*(j + 1) / zoomCoeffecicient);

                                        if (preset.showFOVLines)
                                        {
                                            gunnerDegrees = gunnerAngle * (-180 / Math.PI);
                                            if (gunnerDegrees < 0) gunnerDegrees = 360 + gunnerDegrees;

                                            myPen = new Pen(Color.Red);
                                            myPen.Width = 1 * (1 / zoomCoeffecicient);
                                            length = 50;
                                            LocX2 = (float)(LocX + 5 / zoomCoeffecicient + (Math.Cos(gunnerDegrees * Math.PI / 180 - Math.PI / 2) * length));
                                            LocY2 = (float)(LocY + 7.5 / zoomCoeffecicient + (Math.Sin(gunnerDegrees * Math.PI / 180 - Math.PI / 2) * length));
                                            e.Graphics.DrawLine(myPen, LocX + 5 / zoomCoeffecicient, LocY + 7.5f / zoomCoeffecicient, LocX2, LocY2);
                                        }

                                    }
                                }
                                if (objType.CompareTo("parachute") != 0)
                                {
                                    
                                    

                                    Image bmp = RotateImage(global::DayZMap.Properties.Resources.black_arrow, (float)Dir);
                                    e.Graphics.DrawImage(bmp, LocX, LocY, 10 * (1 / zoomCoeffecicient), 15 * (1 / zoomCoeffecicient));
                                }
                                else
                                {
                                    if (Dir > 90 && Dir < 180) Dir = direction - 90;
                                    if (Dir > 180 && Dir < 270) Dir = Dir + 90;
                                    Image bmp = RotateImage(global::DayZMap.Properties.Resources.parachute, (float)Dir);
                                    e.Graphics.DrawImage(bmp, LocX, LocY, 15 * (1 / zoomCoeffecicient), 15 * (1 / zoomCoeffecicient));
                                }
                            }
                        }
                        //Players
                        else if (heroArray.Contains(objName))
                        {
                            isPlayer = true;
                            if (IsDead )
                            {
                                if (preset.showCorpses)
                                {
                                    Image bmp = RotateImage(global::DayZMap.Properties.Resources.dead_x, (float)Dir);
                                    e.Graphics.DrawImage(bmp, LocX, LocY, 10 * (1 / zoomCoeffecicient), 15 * (1 / zoomCoeffecicient));
                                }
                            }
                            else 
                            {
                                if (preset.showPlayers)
                                {
                                    Image bmp = RotateImage(global::DayZMap.Properties.Resources.green_arrow, (float)Dir);
                                    e.Graphics.DrawImage(bmp, LocX, LocY, 10 * (1 / zoomCoeffecicient), 15 * (1 / zoomCoeffecicient));
                                    if (preset.showPlayerNames)
                                    {
                                        playerName = getPlayerName(obj1, i);
                                        Brush greenBrush = Brushes.Green;
                                        e.Graphics.DrawString(objType + " " + playerName, drawFont, greenBrush, LocX + 10  *(1 / zoomCoeffecicient), LocY);
                                    }
                                }
                            }
                        }
                        else if (banditArray.Contains(objName))
                        {
                            isPlayer = true;
                            if (IsDead)
                            {
                                if (preset.showCorpses)
                                {
                                    Image bmp = RotateImage(global::DayZMap.Properties.Resources.dead_x, (float)Dir);
                                    e.Graphics.DrawImage(bmp, LocX, LocY, 10 * (1 / zoomCoeffecicient), 15 * (1 / zoomCoeffecicient));
                                }
                            }
                            else
                            {
                                if (preset.showPlayers)
                                {
                                    Image bmp = RotateImage(global::DayZMap.Properties.Resources.gold_arrow, (float)Dir);
                                    e.Graphics.DrawImage(bmp, LocX, LocY, 10 * (1 / zoomCoeffecicient), 15 * (1 / zoomCoeffecicient));
                                    if (preset.showPlayerNames)
                                    {
                                        playerName = getPlayerName(obj1, i);
                                        Brush purpleBrush = Brushes.Purple;
                                        e.Graphics.DrawString(playerName, drawFont, purpleBrush, LocX + 10 * (1 / zoomCoeffecicient), LocY);
                                    }
                                }
                            }
                        }
                        else if (objType.CompareTo("soldier") == 0)
                        {
                            
                            isPlayer = true;
                            //Display if Player isn't dead
                            if (IsDead)
                            {
                                if (preset.showCorpses)
                                {
                                    Image bmp = RotateImage(global::DayZMap.Properties.Resources.dead_x, (float)Dir);
                                    e.Graphics.DrawImage(bmp, LocX, LocY, 10 * (1 / zoomCoeffecicient), 15 * (1 / zoomCoeffecicient));
                                }
                            }
                            else
                            {
                                if (preset.showPlayers)
                                {
                                    Image bmp = RotateImage(global::DayZMap.Properties.Resources.red_arrow, (float)Dir);
                                    e.Graphics.DrawImage(bmp, LocX, LocY, 10 * (1 / zoomCoeffecicient), 15 * (1 / zoomCoeffecicient));
                                    if (preset.showPlayerNames)
                                    {
                                        playerName = getPlayerName(obj1, i);
                                        Brush redBrush = Brushes.Red;
                                        e.Graphics.DrawString(playerName, drawFont, redBrush, LocX + 10 * (1 / zoomCoeffecicient), LocY);
                                        
                                    }
                                }
                            }
                        }
                        //Unknown
                        else
                        {                            
                            Brush greenBrush = Brushes.Green;
                            Image bmp = RotateImage(global::DayZMap.Properties.Resources.red_arrow, (float)Dir);
                            if (preset.showUnknowns)
                            {
                                e.Graphics.DrawImage(bmp, LocX, LocY, 10 * (1 / zoomCoeffecicient), 15 * (1 / zoomCoeffecicient));
                            }
                            if (preset.showUnknowns && preset.showUnknownNames)
                            {

                                e.Graphics.DrawString(objType + " " + objName, drawFont, greenBrush, LocX + 10 * (1 / zoomCoeffecicient), LocY);
                                
                            }
                            //MessageBox.Show(objName);
                        }
                        if (isPlayer && preset.showPlayerWeapons && (!IsDead || preset.showCorpses))
                        {
                            Brush redBrush = Brushes.Red;
                            String playerWeapon = getWeapon(obj1);
                            e.Graphics.DrawString(playerWeapon, drawFont, redBrush, LocX + 10 * (1 / zoomCoeffecicient), LocY + 15*(1/zoomCoeffecicient));
                        }
                        if (isPlayer && preset.showFOVLines && !IsDead)
                        {
                            myPen = new Pen(Color.Red);
                            myPen.Width = 1 * (1 / zoomCoeffecicient);
                            length = 50;
                            LocX2 = (float)(LocX + 5 / zoomCoeffecicient + (Math.Cos(Dir * Math.PI / 180 - Math.PI / 2) * length));
                            LocY2 = (float)(LocY + 7.5 / zoomCoeffecicient + (Math.Sin(Dir * Math.PI / 180 - Math.PI / 2) * length));
                            e.Graphics.DrawLine(myPen, LocX + 5 / zoomCoeffecicient, LocY + 7.5f / zoomCoeffecicient, LocX2, LocY2);
                        }

                        if (preset.showDistance)
                        {
                            String distanceString = distance + "m";
                            
                            Brush blackBrush = Brushes.Black;
                            
                            e.Graphics.DrawString(distanceString, drawFont, blackBrush, LocX + 10 * (1 / zoomCoeffecicient), LocY - 15 * (1 / zoomCoeffecicient));

                        }
                    }
                }
                getCurrentPlayer(sender, e);
            }
        
    }
}

