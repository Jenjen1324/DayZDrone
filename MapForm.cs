using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Diagnostics;
using DayZMap.Arma2Framework;


namespace DayZMap
{
    public partial class MapForm : Form
    {

        Map mapData = new Map();
        private int _countDown = 100; //ms
        private Timer _timer;
        private Timer _nvtimer;
        public bool stayCentered = false;
        private bool autoZero = false;
        private bool setNoFatigue = false;
        private bool infiniteAmmo;
        private Player[] player;
        
        private int zeroDistance;
        private string version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();

        public MapForm()
        {
            InitializeComponent();
            objImageViewer1.Paint += new PaintEventHandler(mapData.refreshMap);
            mapSelectionBox.Items.Add("Chernarus");
            mapSelectionBox.Items.Add("Lingor");
            mapSelectionBox.Items.Add("Taviana");
            mapSelectionBox.Items.Add("Namalsk");
            _timer = new Timer();
            _timer.Interval = 100;
            _timer.Tick += new EventHandler(timer_Tick);
            _timer.Stop();
            _timer.Start();
            _nvtimer = new Timer();
            _nvtimer.Interval = 25;
            _nvtimer.Tick += new EventHandler(nvtimer_Tick);
            _nvtimer.Start();
            bulletDamageTextBox.Text = mapData.getBulletDamage().ToString();
        }

        private void refTick_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        void nvtimer_Tick(object sender, EventArgs e)
        {
            _countDown -= 1000;
            if (_countDown < 0)
            {
                if (forceDayBox.Checked == true)
                  mapData.setDay();
                if(forceNVBox.Checked == true)
                    mapData.setViewDistance(float.Parse(viewDistanceBox.Text));
                if (disableRecoil.Checked == true)
                    mapData.setRecoil(0);
            }


        }

        void timer_Tick(object sender, EventArgs e)
        {
            _countDown -= 100;
            if (_countDown < 0)
            {
                _countDown = 100;
                mapTimer();
            }
        }

        private void mapTimer()
        {
            if (stayCentered)
            {
                float[] playerCoords = mapData.getCurrentPlayerGameCoordsMap();
                Point AP = objImageViewer1.AutoScrollPosition;
                
                playerCoords[0] = playerCoords[0] * objImageViewer1.Zoom-500;
                playerCoords[1] = playerCoords[1] * objImageViewer1.Zoom - 500;
                AP = new Point((int)playerCoords[0], (int)playerCoords[1]);
                objImageViewer1.AutoScrollPosition = AP;

            }
            float range = mapData.getRange();
            float[] coords = mapData.getCurrentPlayerGameCoords();

            if (autoZero)
            {
                zeroDistance = (Convert.ToInt32(mapData.getRange() / 100f));
                if (zeroDistance > 0) zeroDistance--;
                mapData.setZero(zeroDistance);
            }

            xCoordBox.Text = coords[0].ToString();
            yCoordBox.Text = coords[1].ToString();
            zCoordBox.Text = coords[2].ToString();
            if (range != 0)
            {
                textBox2.Text = range.ToString();
            }
            else
            {
                textBox2.Text = "Not linked to process";
            }

            /*if (forceThermalBox.Checked)
            {
                mapData.forceThermalVision();
            }*/

            /*if (enableNightVisionCheckBox.Checked)
            {
                
                mapData.enableNightVision();
            }*/
            //playerBox.Items.Clear();
            player = mapData.getPlayerArray();
            /*if (player != null)
            {
                for (int i = 0; player[i] != null; i++)
                {
                    if(player[i] !=null)
                    playerBox.Items.Add(player[i].playerName);
                }
            }*/
            if (infiniteAmmoBox.Checked == true)
            {
                mapData.refillAmmo(30);
            }

            if (setNoFatigue)
            {
                mapData.setFatigue(0.0f);
            }

            


            //bloodBox.Text = mapData.getBlood().ToString();
            objImageViewer1.Invalidate();
            
        }

        

        private void button2_Click(object sender, EventArgs e)
        {
            objImageViewer1.Zoom -= .1F*(objImageViewer1.Zoom);
            mapData.setZoomCoefficient(objImageViewer1.Zoom);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            objImageViewer1.Zoom += .1F*(objImageViewer1.Zoom);
            mapData.setZoomCoefficient(objImageViewer1.Zoom);
        }
        
        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg,
        System.Windows.Forms.Keys keyData)
        {
            int oUserPrefs = 50;
            
                Point AP = objImageViewer1.AutoScrollPosition;
                if (msg.WParam.ToInt32() == (int)Keys.Left) AP = new Point(-AP.X - oUserPrefs, -AP.Y);
                else if (msg.WParam.ToInt32() == (int)Keys.Right) AP = new Point(-AP.X + oUserPrefs, -AP.Y);
                else if (msg.WParam.ToInt32() == (int)Keys.Down) AP = new Point(-AP.X, -AP.Y + oUserPrefs);
                else if (msg.WParam.ToInt32() == (int)Keys.Up) AP = new Point(-AP.X, -AP.Y - oUserPrefs);
                else return base.ProcessCmdKey(ref msg, keyData);
                Debug.WriteLine(AP.X + " " + AP.Y);
                objImageViewer1.AutoScrollPosition = AP;

                return true;
            
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (!stayCentered)
            {
                stayCentered = true;
            }
            else
            {
                stayCentered = false;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (playerNamesCheckBox.Checked)
                mapData.setShowPlayerNames(true);
            else
                mapData.setShowPlayerNames(false);
        }

        private void playerCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (playerCheckBox.Checked)
                mapData.setShowPlayers(true);
            else
                mapData.setShowPlayers(false);

        }

        private void vehicleCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_vehicle.Checked)
                mapData.setShowVehicles(true);
            else
                mapData.setShowVehicles(false);
        }

        private void vehicleNamesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_vehicleNames.Checked)
                mapData.setShowVehicleNames(true);
            else
                mapData.setShowVehicleNames(false);
        }

       /* private void showUnknowns_CheckedChanged(object sender, EventArgs e)
        {
            if (showUnknowns.Checked)
                mapData.setShowUnknowns(true);
            else
                mapData.setShowUnknowns(false);
        }

        private void showUnknownNames_CheckedChanged(object sender, EventArgs e)
        {
            if (showUnknownNames.Checked)
                mapData.setShowUnknownNames(true);
            else
                mapData.setShowUnknownNames(false);
        }*/

        private void mapSelectionBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            mapData.setMapSelection(mapSelectionBox.SelectedIndex);
        }

        private void distanceCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (distanceCheckBox.Checked)
                mapData.setShowDistance(true);
            else
                mapData.setShowDistance(false);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //checkBox1.Checked = true;
            playerCheckBox.Checked = true;
            playerNamesCheckBox.Checked = true;
            playerWeaponCheckBox.Checked = true;
            checkBox_vehicle.Checked = true;
            checkBox_vehicleNames.Checked = false;
            showFOVBox.Checked = true;
            checkBox_keepCentered.Checked = true;
            infiniteAmmoBox.Checked = true;
            disableRecoil.Checked = true;
            noFatigueBox.Checked = true;
            showTentsBox.Checked = true;
            forceDayBox.Checked = true;
            //showUnknowns.Checked = true;
            //showUnknownNames.Checked = true;
            //distanceCheckBox.Checked = true;
            //refTick.Checked = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            mapData.suicide();
        }

        private void nightVisionButton_Click(object sender, EventArgs e)
        {
            mapData.enableNightVision();
        }

        private void forceNVButton_Click(object sender, EventArgs e)
        {
            mapData.forceNightVision();
        }

        private void forceThermalBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void playerWeaponCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (playerWeaponCheckBox.Checked)
                mapData.setShowPlayerWeapons(true);
            else
                mapData.setShowPlayerWeapons(false);
        }

        /*private void enableNightVisionCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (enableNightVisionCheckBox.Checked)
                mapData.setEnableNightVision(true);
            else
                mapData.setEnableNightVision(false);
        }
        */
        private void showAnimalsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (showAnimalsCheckBox.Checked)
                mapData.setShowAnimals(true);
            else
                mapData.setShowAnimals(false);
        }

        private void showWeaponsBox_CheckedChanged(object sender, EventArgs e)
        {
            if (showWeaponsBox.Checked)
                mapData.setShowWeapons(true);
            else
                mapData.setShowWeapons(false);
        }

        private void showAmmoBox_CheckedChanged(object sender, EventArgs e)
        {
            if (showAmmoBox.Checked)
                mapData.setShowAmmo(true);
            else
                mapData.setShowAmmo(false);
        }

        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            mapData.setSearchBoxString(searchBox.Text);
        }

        private void showTentsBox_CheckedChanged(object sender, EventArgs e)
        {
            if (showTentsBox.Checked)
                mapData.setShowTents(true);
            else
                mapData.setShowTents(false);
        }

        private void showHeloCrashesBox_CheckedChanged(object sender, EventArgs e)
        {
            if (showHeloCrashesBox.Checked)
                mapData.setShowHeloCrashes(true);
            else
                mapData.setShowHeloCrashes(false);
        }

        private void showRiflesBox_CheckedChanged(object sender, EventArgs e)
        {
            if (showRiflesBox.Checked)
                mapData.setShowRifles(true);
            else
                mapData.setShowRifles(false);
        }

        private void showSidearmsBox_CheckedChanged(object sender, EventArgs e)
        {
            if (showSidearmsBox.Checked)
                mapData.setShowSidearms(true);
            else
                mapData.setShowSidearms(false);
        }

        private void checkBox3_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
                mapData.setShowSMG(true);
            else
                mapData.setShowSMG(false);
        }

        private void showLMGBox_CheckedChanged(object sender, EventArgs e)
        {
            if (showLMGBox.Checked)
                mapData.setShowLMG(true);
            else
                mapData.setShowLMG(false);
        }

        private void showSniperBox_CheckedChanged(object sender, EventArgs e)
        {
            if (showSniperBox.Checked)
                mapData.setShowSniperRifles(true);
            else
                mapData.setShowSniperRifles(false);
        }

        private void showShotgunsBox_CheckedChanged(object sender, EventArgs e)
        {
            if (showShotgunsBox.Checked)
                mapData.setShowShotguns(true);
            else
                mapData.setShowShotguns(false);
        }

        private void showCorpsesBox_CheckedChanged(object sender, EventArgs e)
        {
            if (showCorpsesBox.Checked)
                mapData.setShowCorpses(true);
            else
                mapData.setShowCorpses(false);
        }

        private void showBackpackBox_CheckedChanged(object sender, EventArgs e)
        {
            if (showBackpackBox.Checked)
                mapData.setShowBackpacks(true);
            else
                mapData.setShowBackpacks(false);
        }

        private void zoomBar_Scroll(object sender, EventArgs e)
        {
            objImageViewer1.Zoom = 1 + .2F*(zoomBar.Value);
            //objImageViewer1.Zoom += .1F * (objImageViewer1.Zoom);
            mapData.setZoomCoefficient(objImageViewer1.Zoom);
        }

        private void forceNVBox_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void MapForm_Load(object sender, EventArgs e)
        {

        }

        private void viewDistanceBox_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void setViewDistanceButton_Click(object sender, EventArgs e)
        {
            mapData.setViewDistance(float.Parse(viewDistanceBox.Text));
        }

        private void setDay_Click(object sender, EventArgs e)
        {
            if (mapData.getSetDay())
            {
                mapData.setSetDay(false);
            }
            else
                mapData.setSetDay(true);
            mapData.setDay();
        }

        private void showWeaponsButton_Click(object sender, EventArgs e)
        {
            // vehicleCheckBox.Checked = true;
            showLMGBox.Checked = true;
            showRiflesBox.Checked = true;
            showSniperBox.Checked = true;
            showSidearmsBox.Checked = true;
            showShotgunsBox.Checked = true;
            checkBox3.Checked = true; // SMG checkbox
        }

        private void thermalButton_Click(object sender, EventArgs e)
        {
            mapData.startThermalThread();
        }

        private void forceDayBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void forceThermalBox_CheckedChanged_1(object sender, EventArgs e)
        {
            mapData.startThermalThread();
            forceDayBox.Checked = false;

        }

        private void showFOVBox_CheckedChanged(object sender, EventArgs e)
        {
            if (showFOVBox.Checked)
                mapData.setShowFOVLines(true);
            else
                mapData.setShowFOVLines(false);
        }

        

        private void playerBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //playerBoxIndex = playerBox.SelectedIndex;
        }

        private void autoZeroBox_CheckedChanged(object sender, EventArgs e)
        {
            if (autoZeroBox.Checked)
                autoZero = true;
            else
                autoZero = false;
        }

        private void noRecoilButton_Click(object sender, EventArgs e)
        {
            mapData.setRecoil(0);
        }
        
        private void noFatigueBox_CheckedChanged(object sender, EventArgs e)
        {
            if (noFatigueBox.Checked)
                setNoFatigue = true;
            else
                setNoFatigue = false;
        }

        private void infiniteAmmoBox_CheckedChanged(object sender, EventArgs e)
        {
            infiniteGrenadeBox.Enabled = infiniteAmmoBox.Checked;
            fastBulletBox.Enabled = infiniteAmmoBox.Checked;
            if (infiniteAmmoBox.Checked)
            {
                infiniteAmmo = true;
            }
            else
            {
                infiniteAmmo = false;
                infiniteGrenadeBox.Checked = false;
                fastBulletBox.Checked = false;
            }
            
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void objImageViewer1_Click(object sender, EventArgs e)
        {

        }

        private void disableRecoil_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void infiniteGrenadeBox_CheckedChanged(object sender, EventArgs e)
        {
            if (infiniteAmmoBox.Checked)
                mapData.setRefillGrenades(true);
            else
                mapData.setRefillGrenades(false);
        }

        private void fastBulletBox_CheckedChanged(object sender, EventArgs e)
        {
            if (fastBulletBox.Checked)
            {
                if (fastBulletBox.Checked && setBulletSpeedBox.Text != null && float.Parse(setBulletSpeedBox.Text) > 0)
                {
                    mapData.setCurrentMuzzleVelocity(float.Parse(setBulletSpeedBox.Text));
                }
            }else
                mapData.setFastBullets(false);
        }

        private void grassCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (grassCheckBox.Checked)
                mapData.disableGrass();
            else
                mapData.enableGrass();
        }

        private void setBulletSpeedBox_TextChanged(object sender, EventArgs e)
        {
            if (fastBulletBox.Checked && float.Parse(setBulletSpeedBox.Text) > 0)
            {
                mapData.setCurrentMuzzleVelocity(float.Parse(setBulletSpeedBox.Text));
            }
        }

        private void fireRateBox_CheckedChanged(object sender, EventArgs e)
        {
            if (fireRateBox.Checked)
                mapData.setFastFire(true);
            else
                mapData.setFastFire(false);
        }

        private void rainCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (rainCheckBox.Checked)
                mapData.enableRain();
            else
                mapData.disableRain();
        }

        private void bigBulletBox_CheckedChanged(object sender, EventArgs e)
        {
            if (bigBulletBox.Checked)
                mapData.setDestructionBullet(float.Parse(bulletDamageTextBox.Text));
            else
                mapData.resetDestructionBullet();
        }

        private void morphineButton_Click(object sender, EventArgs e)
        {
            mapData.fixBrokenLegs();
        }

        private void indirectDamageButton_Click(object sender, EventArgs e)
        {
            if (float.Parse(indirectDamageBox.Text) >= 0) mapData.setIndirectDamage(float.Parse(indirectDamageBox.Text));
        }

        private void indirectDamageRangeButton_Click(object sender, EventArgs e)
        {
            if (float.Parse(indirectDamageRangeBox.Text) >= 0) mapData.setIndirectDamageRange(float.Parse(indirectDamageRangeBox.Text));
        }

        private void button_reload_Click(object sender, EventArgs e)
        {
            this.mapData = new Map();
        }

        private void checkBox_autoRepair_CheckedChanged(object sender, EventArgs e)
        {
            this.mapData.setAutoRepair(((CheckBox)sender).Checked);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            HelpForm help = new HelpForm();
            help.Show();
        }

        

        /*private void showSomeItemsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (showSomeItemsCheckBox.Checked)
                mapData.setShowSomeItems(true);
            else
                mapData.setShowSomeItems(false);
        }*/


    }
}
