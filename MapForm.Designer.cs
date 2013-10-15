using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace DayZMap
{
    partial class MapForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MapForm));
            this.checkBox_keepCentered = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.checkBox_vehicle = new System.Windows.Forms.CheckBox();
            this.checkBox_vehicleNames = new System.Windows.Forms.CheckBox();
            this.mapSelectionBox = new System.Windows.Forms.ComboBox();
            this.distanceCheckBox = new System.Windows.Forms.CheckBox();
            this.xCoordBox = new System.Windows.Forms.TextBox();
            this.yCoordBox = new System.Windows.Forms.TextBox();
            this.zCoordBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.nightVisionButton = new System.Windows.Forms.Button();
            this.playerCheckBox = new System.Windows.Forms.CheckBox();
            this.playerNamesCheckBox = new System.Windows.Forms.CheckBox();
            this.playerWeaponCheckBox = new System.Windows.Forms.CheckBox();
            this.showAnimalsCheckBox = new System.Windows.Forms.CheckBox();
            this.showWeaponsBox = new System.Windows.Forms.CheckBox();
            this.showAmmoBox = new System.Windows.Forms.CheckBox();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.showTentsBox = new System.Windows.Forms.CheckBox();
            this.showHeloCrashesBox = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.showSidearmsBox = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.showRiflesBox = new System.Windows.Forms.CheckBox();
            this.showLMGBox = new System.Windows.Forms.CheckBox();
            this.showSniperBox = new System.Windows.Forms.CheckBox();
            this.showShotgunsBox = new System.Windows.Forms.CheckBox();
            this.showCorpsesBox = new System.Windows.Forms.CheckBox();
            this.showBackpackBox = new System.Windows.Forms.CheckBox();
            this.zoomBar = new System.Windows.Forms.TrackBar();
            this.forceNVBox = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.viewDistanceBox = new System.Windows.Forms.TextBox();
            this.showWeaponsButton = new System.Windows.Forms.Button();
            this.forceDayBox = new System.Windows.Forms.CheckBox();
            this.forceThermalBox = new System.Windows.Forms.CheckBox();
            this.showFOVBox = new System.Windows.Forms.CheckBox();
            this.autoZeroBox = new System.Windows.Forms.CheckBox();
            this.noFatigueBox = new System.Windows.Forms.CheckBox();
            this.infiniteAmmoBox = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.disableRecoil = new System.Windows.Forms.CheckBox();
            this.infiniteGrenadeBox = new System.Windows.Forms.CheckBox();
            this.fastBulletBox = new System.Windows.Forms.CheckBox();
            this.grassCheckBox = new System.Windows.Forms.CheckBox();
            this.setBulletSpeedBox = new System.Windows.Forms.TextBox();
            this.fireRateBox = new System.Windows.Forms.CheckBox();
            this.rainCheckBox = new System.Windows.Forms.CheckBox();
            this.bigBulletBox = new System.Windows.Forms.CheckBox();
            this.bulletDamageTextBox = new System.Windows.Forms.TextBox();
            this.morphineButton = new System.Windows.Forms.Button();
            this.indirectDamageButton = new System.Windows.Forms.Button();
            this.indirectDamageBox = new System.Windows.Forms.TextBox();
            this.indirectDamageRangeButton = new System.Windows.Forms.Button();
            this.indirectDamageRangeBox = new System.Windows.Forms.TextBox();
            this.button_reload = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBox_autoRepair = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.objImageViewer1 = new Balance.objImageViewer();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.zoomBar)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkBox_keepCentered
            // 
            this.checkBox_keepCentered.AutoSize = true;
            this.checkBox_keepCentered.Location = new System.Drawing.Point(6, 102);
            this.checkBox_keepCentered.Name = "checkBox_keepCentered";
            this.checkBox_keepCentered.Size = new System.Drawing.Size(97, 17);
            this.checkBox_keepCentered.TabIndex = 7;
            this.checkBox_keepCentered.Text = "Keep Centered";
            this.checkBox_keepCentered.UseVisualStyleBackColor = true;
            this.checkBox_keepCentered.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Range to Reticle:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(8, 147);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(153, 20);
            this.textBox2.TabIndex = 9;
            this.textBox2.Text = "UNSYNCHRONIZED";
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // checkBox_vehicle
            // 
            this.checkBox_vehicle.AutoSize = true;
            this.checkBox_vehicle.Location = new System.Drawing.Point(111, 19);
            this.checkBox_vehicle.Name = "checkBox_vehicle";
            this.checkBox_vehicle.Size = new System.Drawing.Size(66, 17);
            this.checkBox_vehicle.TabIndex = 12;
            this.checkBox_vehicle.Text = "Vehicles";
            this.checkBox_vehicle.UseVisualStyleBackColor = true;
            this.checkBox_vehicle.CheckedChanged += new System.EventHandler(this.vehicleCheckBox_CheckedChanged);
            // 
            // checkBox_vehicleNames
            // 
            this.checkBox_vehicleNames.AutoSize = true;
            this.checkBox_vehicleNames.Location = new System.Drawing.Point(111, 42);
            this.checkBox_vehicleNames.Name = "checkBox_vehicleNames";
            this.checkBox_vehicleNames.Size = new System.Drawing.Size(97, 17);
            this.checkBox_vehicleNames.TabIndex = 13;
            this.checkBox_vehicleNames.Text = "Vehicle Names";
            this.checkBox_vehicleNames.UseVisualStyleBackColor = true;
            this.checkBox_vehicleNames.CheckedChanged += new System.EventHandler(this.vehicleNamesCheckBox_CheckedChanged);
            // 
            // mapSelectionBox
            // 
            this.mapSelectionBox.FormattingEnabled = true;
            this.mapSelectionBox.Location = new System.Drawing.Point(130, 21);
            this.mapSelectionBox.Name = "mapSelectionBox";
            this.mapSelectionBox.Size = new System.Drawing.Size(82, 21);
            this.mapSelectionBox.TabIndex = 16;
            this.mapSelectionBox.Text = "Chernarus";
            this.mapSelectionBox.SelectedIndexChanged += new System.EventHandler(this.mapSelectionBox_SelectedIndexChanged);
            // 
            // distanceCheckBox
            // 
            this.distanceCheckBox.AutoSize = true;
            this.distanceCheckBox.Location = new System.Drawing.Point(6, 232);
            this.distanceCheckBox.Name = "distanceCheckBox";
            this.distanceCheckBox.Size = new System.Drawing.Size(98, 17);
            this.distanceCheckBox.TabIndex = 17;
            this.distanceCheckBox.Text = "Show Distance";
            this.distanceCheckBox.UseVisualStyleBackColor = true;
            this.distanceCheckBox.CheckedChanged += new System.EventHandler(this.distanceCheckBox_CheckedChanged);
            // 
            // xCoordBox
            // 
            this.xCoordBox.Location = new System.Drawing.Point(26, 39);
            this.xCoordBox.Name = "xCoordBox";
            this.xCoordBox.Size = new System.Drawing.Size(86, 20);
            this.xCoordBox.TabIndex = 20;
            // 
            // yCoordBox
            // 
            this.yCoordBox.Location = new System.Drawing.Point(26, 67);
            this.yCoordBox.Name = "yCoordBox";
            this.yCoordBox.Size = new System.Drawing.Size(86, 20);
            this.yCoordBox.TabIndex = 21;
            // 
            // zCoordBox
            // 
            this.zCoordBox.Location = new System.Drawing.Point(26, 95);
            this.zCoordBox.Name = "zCoordBox";
            this.zCoordBox.Size = new System.Drawing.Size(86, 20);
            this.zCoordBox.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "X:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "Y:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "Z:";
            // 
            // nightVisionButton
            // 
            this.nightVisionButton.Location = new System.Drawing.Point(112, 110);
            this.nightVisionButton.Name = "nightVisionButton";
            this.nightVisionButton.Size = new System.Drawing.Size(111, 26);
            this.nightVisionButton.TabIndex = 26;
            this.nightVisionButton.Text = "Enable Night Vision";
            this.nightVisionButton.UseVisualStyleBackColor = true;
            this.nightVisionButton.Click += new System.EventHandler(this.nightVisionButton_Click);
            // 
            // playerCheckBox
            // 
            this.playerCheckBox.AutoSize = true;
            this.playerCheckBox.Location = new System.Drawing.Point(6, 19);
            this.playerCheckBox.Name = "playerCheckBox";
            this.playerCheckBox.Size = new System.Drawing.Size(60, 17);
            this.playerCheckBox.TabIndex = 10;
            this.playerCheckBox.Text = "Players";
            this.playerCheckBox.UseVisualStyleBackColor = true;
            this.playerCheckBox.CheckedChanged += new System.EventHandler(this.playerCheckBox_CheckedChanged);
            // 
            // playerNamesCheckBox
            // 
            this.playerNamesCheckBox.AutoSize = true;
            this.playerNamesCheckBox.Location = new System.Drawing.Point(6, 42);
            this.playerNamesCheckBox.Name = "playerNamesCheckBox";
            this.playerNamesCheckBox.Size = new System.Drawing.Size(91, 17);
            this.playerNamesCheckBox.TabIndex = 11;
            this.playerNamesCheckBox.Text = "Player Names";
            this.playerNamesCheckBox.UseVisualStyleBackColor = true;
            this.playerNamesCheckBox.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // playerWeaponCheckBox
            // 
            this.playerWeaponCheckBox.AutoSize = true;
            this.playerWeaponCheckBox.Location = new System.Drawing.Point(6, 65);
            this.playerWeaponCheckBox.Name = "playerWeaponCheckBox";
            this.playerWeaponCheckBox.Size = new System.Drawing.Size(104, 17);
            this.playerWeaponCheckBox.TabIndex = 29;
            this.playerWeaponCheckBox.Text = "Player Weapons";
            this.playerWeaponCheckBox.UseVisualStyleBackColor = true;
            this.playerWeaponCheckBox.CheckedChanged += new System.EventHandler(this.playerWeaponCheckBox_CheckedChanged);
            // 
            // showAnimalsCheckBox
            // 
            this.showAnimalsCheckBox.AutoSize = true;
            this.showAnimalsCheckBox.Location = new System.Drawing.Point(111, 65);
            this.showAnimalsCheckBox.Name = "showAnimalsCheckBox";
            this.showAnimalsCheckBox.Size = new System.Drawing.Size(92, 17);
            this.showAnimalsCheckBox.TabIndex = 31;
            this.showAnimalsCheckBox.Text = "Show Animals";
            this.showAnimalsCheckBox.UseVisualStyleBackColor = true;
            this.showAnimalsCheckBox.CheckedChanged += new System.EventHandler(this.showAnimalsCheckBox_CheckedChanged);
            // 
            // showWeaponsBox
            // 
            this.showWeaponsBox.AutoSize = true;
            this.showWeaponsBox.Location = new System.Drawing.Point(111, 255);
            this.showWeaponsBox.Name = "showWeaponsBox";
            this.showWeaponsBox.Size = new System.Drawing.Size(81, 17);
            this.showWeaponsBox.TabIndex = 32;
            this.showWeaponsBox.Text = "Show Items";
            this.showWeaponsBox.UseVisualStyleBackColor = true;
            this.showWeaponsBox.CheckedChanged += new System.EventHandler(this.showWeaponsBox_CheckedChanged);
            // 
            // showAmmoBox
            // 
            this.showAmmoBox.AutoSize = true;
            this.showAmmoBox.Location = new System.Drawing.Point(6, 255);
            this.showAmmoBox.Name = "showAmmoBox";
            this.showAmmoBox.Size = new System.Drawing.Size(85, 17);
            this.showAmmoBox.TabIndex = 33;
            this.showAmmoBox.Text = "Show Ammo";
            this.showAmmoBox.UseVisualStyleBackColor = true;
            this.showAmmoBox.CheckedChanged += new System.EventHandler(this.showAmmoBox_CheckedChanged);
            // 
            // searchBox
            // 
            this.searchBox.Location = new System.Drawing.Point(6, 302);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(153, 20);
            this.searchBox.TabIndex = 34;
            this.searchBox.TextChanged += new System.EventHandler(this.searchBox_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 286);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 13);
            this.label5.TabIndex = 35;
            this.label5.Text = "Search for Weapon";
            // 
            // showTentsBox
            // 
            this.showTentsBox.AutoSize = true;
            this.showTentsBox.Location = new System.Drawing.Point(6, 88);
            this.showTentsBox.Name = "showTentsBox";
            this.showTentsBox.Size = new System.Drawing.Size(83, 17);
            this.showTentsBox.TabIndex = 36;
            this.showTentsBox.Text = "Show Tents";
            this.showTentsBox.UseVisualStyleBackColor = true;
            this.showTentsBox.CheckedChanged += new System.EventHandler(this.showTentsBox_CheckedChanged);
            // 
            // showHeloCrashesBox
            // 
            this.showHeloCrashesBox.AutoSize = true;
            this.showHeloCrashesBox.Location = new System.Drawing.Point(111, 88);
            this.showHeloCrashesBox.Name = "showHeloCrashesBox";
            this.showHeloCrashesBox.Size = new System.Drawing.Size(119, 17);
            this.showHeloCrashesBox.TabIndex = 37;
            this.showHeloCrashesBox.Text = "Show Helo Crashes";
            this.showHeloCrashesBox.UseVisualStyleBackColor = true;
            this.showHeloCrashesBox.CheckedChanged += new System.EventHandler(this.showHeloCrashesBox_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(36, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 38;
            this.label6.Text = "Coordinates";
            // 
            // showSidearmsBox
            // 
            this.showSidearmsBox.AutoSize = true;
            this.showSidearmsBox.Location = new System.Drawing.Point(6, 140);
            this.showSidearmsBox.Name = "showSidearmsBox";
            this.showSidearmsBox.Size = new System.Drawing.Size(99, 17);
            this.showSidearmsBox.TabIndex = 39;
            this.showSidearmsBox.Text = "Show Sidearms";
            this.showSidearmsBox.UseVisualStyleBackColor = true;
            this.showSidearmsBox.CheckedChanged += new System.EventHandler(this.showSidearmsBox_CheckedChanged);
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(6, 163);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(85, 17);
            this.checkBox3.TabIndex = 40;
            this.checkBox3.Text = "Show SMGs";
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged_1);
            // 
            // showRiflesBox
            // 
            this.showRiflesBox.AutoSize = true;
            this.showRiflesBox.Location = new System.Drawing.Point(6, 186);
            this.showRiflesBox.Name = "showRiflesBox";
            this.showRiflesBox.Size = new System.Drawing.Size(82, 17);
            this.showRiflesBox.TabIndex = 41;
            this.showRiflesBox.Text = "Show Rifles";
            this.showRiflesBox.UseVisualStyleBackColor = true;
            this.showRiflesBox.CheckedChanged += new System.EventHandler(this.showRiflesBox_CheckedChanged);
            // 
            // showLMGBox
            // 
            this.showLMGBox.AutoSize = true;
            this.showLMGBox.Location = new System.Drawing.Point(111, 140);
            this.showLMGBox.Name = "showLMGBox";
            this.showLMGBox.Size = new System.Drawing.Size(84, 17);
            this.showLMGBox.TabIndex = 42;
            this.showLMGBox.Text = "Show LMGs";
            this.showLMGBox.UseVisualStyleBackColor = true;
            this.showLMGBox.CheckedChanged += new System.EventHandler(this.showLMGBox_CheckedChanged);
            // 
            // showSniperBox
            // 
            this.showSniperBox.AutoSize = true;
            this.showSniperBox.Location = new System.Drawing.Point(111, 163);
            this.showSniperBox.Name = "showSniperBox";
            this.showSniperBox.Size = new System.Drawing.Size(115, 17);
            this.showSniperBox.TabIndex = 43;
            this.showSniperBox.Text = "Show Sniper Rifles";
            this.showSniperBox.UseVisualStyleBackColor = true;
            this.showSniperBox.CheckedChanged += new System.EventHandler(this.showSniperBox_CheckedChanged);
            // 
            // showShotgunsBox
            // 
            this.showShotgunsBox.AutoSize = true;
            this.showShotgunsBox.Location = new System.Drawing.Point(111, 186);
            this.showShotgunsBox.Name = "showShotgunsBox";
            this.showShotgunsBox.Size = new System.Drawing.Size(101, 17);
            this.showShotgunsBox.TabIndex = 44;
            this.showShotgunsBox.Text = "Show Shotguns";
            this.showShotgunsBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.showShotgunsBox.UseVisualStyleBackColor = true;
            this.showShotgunsBox.CheckedChanged += new System.EventHandler(this.showShotgunsBox_CheckedChanged);
            // 
            // showCorpsesBox
            // 
            this.showCorpsesBox.AutoSize = true;
            this.showCorpsesBox.Location = new System.Drawing.Point(6, 209);
            this.showCorpsesBox.Name = "showCorpsesBox";
            this.showCorpsesBox.Size = new System.Drawing.Size(94, 17);
            this.showCorpsesBox.TabIndex = 45;
            this.showCorpsesBox.Text = "Show Corpses";
            this.showCorpsesBox.UseVisualStyleBackColor = true;
            this.showCorpsesBox.CheckedChanged += new System.EventHandler(this.showCorpsesBox_CheckedChanged);
            // 
            // showBackpackBox
            // 
            this.showBackpackBox.AutoSize = true;
            this.showBackpackBox.Location = new System.Drawing.Point(111, 209);
            this.showBackpackBox.Name = "showBackpackBox";
            this.showBackpackBox.Size = new System.Drawing.Size(110, 17);
            this.showBackpackBox.TabIndex = 46;
            this.showBackpackBox.Text = "Show Backpacks";
            this.showBackpackBox.UseVisualStyleBackColor = true;
            this.showBackpackBox.CheckedChanged += new System.EventHandler(this.showBackpackBox_CheckedChanged);
            // 
            // zoomBar
            // 
            this.zoomBar.Location = new System.Drawing.Point(6, 34);
            this.zoomBar.Maximum = 50;
            this.zoomBar.Name = "zoomBar";
            this.zoomBar.Size = new System.Drawing.Size(543, 45);
            this.zoomBar.TabIndex = 47;
            this.zoomBar.TickFrequency = 2;
            this.zoomBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.zoomBar.Scroll += new System.EventHandler(this.zoomBar_Scroll);
            // 
            // forceNVBox
            // 
            this.forceNVBox.AutoSize = true;
            this.forceNVBox.Location = new System.Drawing.Point(6, 19);
            this.forceNVBox.Name = "forceNVBox";
            this.forceNVBox.Size = new System.Drawing.Size(113, 17);
            this.forceNVBox.TabIndex = 48;
            this.forceNVBox.Text = "Set View Distance";
            this.forceNVBox.UseVisualStyleBackColor = true;
            this.forceNVBox.CheckedChanged += new System.EventHandler(this.forceNVBox_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1121, 853);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(0, 13);
            this.label7.TabIndex = 49;
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // viewDistanceBox
            // 
            this.viewDistanceBox.Location = new System.Drawing.Point(141, 17);
            this.viewDistanceBox.Name = "viewDistanceBox";
            this.viewDistanceBox.Size = new System.Drawing.Size(78, 20);
            this.viewDistanceBox.TabIndex = 50;
            this.viewDistanceBox.Text = "4000";
            this.viewDistanceBox.TextChanged += new System.EventHandler(this.viewDistanceBox_TextChanged);
            // 
            // showWeaponsButton
            // 
            this.showWeaponsButton.Location = new System.Drawing.Point(6, 111);
            this.showWeaponsButton.Name = "showWeaponsButton";
            this.showWeaponsButton.Size = new System.Drawing.Size(110, 23);
            this.showWeaponsButton.TabIndex = 53;
            this.showWeaponsButton.Text = "Show All Weapons";
            this.showWeaponsButton.UseVisualStyleBackColor = true;
            this.showWeaponsButton.Click += new System.EventHandler(this.showWeaponsButton_Click);
            // 
            // forceDayBox
            // 
            this.forceDayBox.AutoSize = true;
            this.forceDayBox.Location = new System.Drawing.Point(6, 179);
            this.forceDayBox.Name = "forceDayBox";
            this.forceDayBox.Size = new System.Drawing.Size(100, 17);
            this.forceDayBox.TabIndex = 57;
            this.forceDayBox.Text = "Always Daytime";
            this.forceDayBox.UseVisualStyleBackColor = true;
            this.forceDayBox.CheckedChanged += new System.EventHandler(this.forceDayBox_CheckedChanged);
            // 
            // forceThermalBox
            // 
            this.forceThermalBox.AutoSize = true;
            this.forceThermalBox.Location = new System.Drawing.Point(6, 110);
            this.forceThermalBox.Name = "forceThermalBox";
            this.forceThermalBox.Size = new System.Drawing.Size(100, 17);
            this.forceThermalBox.TabIndex = 58;
            this.forceThermalBox.Text = "Enable Thermal";
            this.forceThermalBox.UseVisualStyleBackColor = true;
            this.forceThermalBox.CheckedChanged += new System.EventHandler(this.forceThermalBox_CheckedChanged_1);
            // 
            // showFOVBox
            // 
            this.showFOVBox.AutoSize = true;
            this.showFOVBox.Location = new System.Drawing.Point(111, 232);
            this.showFOVBox.Name = "showFOVBox";
            this.showFOVBox.Size = new System.Drawing.Size(131, 17);
            this.showFOVBox.TabIndex = 59;
            this.showFOVBox.Text = "Show NMe FOV Lines";
            this.showFOVBox.UseVisualStyleBackColor = true;
            this.showFOVBox.CheckedChanged += new System.EventHandler(this.showFOVBox_CheckedChanged);
            // 
            // autoZeroBox
            // 
            this.autoZeroBox.AutoSize = true;
            this.autoZeroBox.Location = new System.Drawing.Point(6, 133);
            this.autoZeroBox.Name = "autoZeroBox";
            this.autoZeroBox.Size = new System.Drawing.Size(73, 17);
            this.autoZeroBox.TabIndex = 63;
            this.autoZeroBox.Text = "Auto Zero";
            this.autoZeroBox.UseVisualStyleBackColor = true;
            this.autoZeroBox.CheckedChanged += new System.EventHandler(this.autoZeroBox_CheckedChanged);
            // 
            // noFatigueBox
            // 
            this.noFatigueBox.AutoSize = true;
            this.noFatigueBox.Location = new System.Drawing.Point(6, 156);
            this.noFatigueBox.Name = "noFatigueBox";
            this.noFatigueBox.Size = new System.Drawing.Size(78, 17);
            this.noFatigueBox.TabIndex = 65;
            this.noFatigueBox.Text = "No Fatigue";
            this.noFatigueBox.UseVisualStyleBackColor = true;
            this.noFatigueBox.CheckedChanged += new System.EventHandler(this.noFatigueBox_CheckedChanged);
            // 
            // infiniteAmmoBox
            // 
            this.infiniteAmmoBox.AutoSize = true;
            this.infiniteAmmoBox.Location = new System.Drawing.Point(6, 42);
            this.infiniteAmmoBox.Name = "infiniteAmmoBox";
            this.infiniteAmmoBox.Size = new System.Drawing.Size(101, 17);
            this.infiniteAmmoBox.TabIndex = 69;
            this.infiniteAmmoBox.Tag = "Fred Fuchs";
            this.infiniteAmmoBox.Text = "Unlimited Ammo";
            this.infiniteAmmoBox.UseVisualStyleBackColor = true;
            this.infiniteAmmoBox.CheckedChanged += new System.EventHandler(this.infiniteAmmoBox_CheckedChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(253, 18);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(76, 13);
            this.label11.TabIndex = 70;
            this.label11.Text = "-  Map Zoom +";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 24);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(61, 13);
            this.label12.TabIndex = 71;
            this.label12.Text = "Select Map";
            // 
            // disableRecoil
            // 
            this.disableRecoil.AutoSize = true;
            this.disableRecoil.Location = new System.Drawing.Point(6, 202);
            this.disableRecoil.Name = "disableRecoil";
            this.disableRecoil.Size = new System.Drawing.Size(94, 17);
            this.disableRecoil.TabIndex = 72;
            this.disableRecoil.Text = "Disable Recoil";
            this.disableRecoil.UseVisualStyleBackColor = true;
            // 
            // infiniteGrenadeBox
            // 
            this.infiniteGrenadeBox.AutoSize = true;
            this.infiniteGrenadeBox.Enabled = false;
            this.infiniteGrenadeBox.Location = new System.Drawing.Point(26, 88);
            this.infiniteGrenadeBox.Name = "infiniteGrenadeBox";
            this.infiniteGrenadeBox.Size = new System.Drawing.Size(118, 17);
            this.infiniteGrenadeBox.TabIndex = 76;
            this.infiniteGrenadeBox.Text = "Unlimited Grenades";
            this.infiniteGrenadeBox.UseVisualStyleBackColor = true;
            this.infiniteGrenadeBox.CheckedChanged += new System.EventHandler(this.infiniteGrenadeBox_CheckedChanged);
            // 
            // fastBulletBox
            // 
            this.fastBulletBox.AutoSize = true;
            this.fastBulletBox.Enabled = false;
            this.fastBulletBox.Location = new System.Drawing.Point(26, 65);
            this.fastBulletBox.Name = "fastBulletBox";
            this.fastBulletBox.Size = new System.Drawing.Size(105, 17);
            this.fastBulletBox.TabIndex = 77;
            this.fastBulletBox.Text = "Set Bullet Speed";
            this.fastBulletBox.UseVisualStyleBackColor = true;
            this.fastBulletBox.CheckedChanged += new System.EventHandler(this.fastBulletBox_CheckedChanged);
            // 
            // grassCheckBox
            // 
            this.grassCheckBox.AutoSize = true;
            this.grassCheckBox.Location = new System.Drawing.Point(6, 224);
            this.grassCheckBox.Name = "grassCheckBox";
            this.grassCheckBox.Size = new System.Drawing.Size(90, 17);
            this.grassCheckBox.TabIndex = 78;
            this.grassCheckBox.Text = "Cut the Grass";
            this.grassCheckBox.UseVisualStyleBackColor = true;
            this.grassCheckBox.CheckedChanged += new System.EventHandler(this.grassCheckBox_CheckedChanged);
            // 
            // setBulletSpeedBox
            // 
            this.setBulletSpeedBox.Location = new System.Drawing.Point(141, 62);
            this.setBulletSpeedBox.Name = "setBulletSpeedBox";
            this.setBulletSpeedBox.Size = new System.Drawing.Size(78, 20);
            this.setBulletSpeedBox.TabIndex = 79;
            this.setBulletSpeedBox.TextChanged += new System.EventHandler(this.setBulletSpeedBox_TextChanged);
            // 
            // fireRateBox
            // 
            this.fireRateBox.AutoSize = true;
            this.fireRateBox.Location = new System.Drawing.Point(112, 156);
            this.fireRateBox.Name = "fireRateBox";
            this.fireRateBox.Size = new System.Drawing.Size(115, 17);
            this.fireRateBox.TabIndex = 80;
            this.fireRateBox.Text = "Unlimited Fire Rate";
            this.fireRateBox.UseVisualStyleBackColor = true;
            this.fireRateBox.CheckedChanged += new System.EventHandler(this.fireRateBox_CheckedChanged);
            // 
            // rainCheckBox
            // 
            this.rainCheckBox.AutoSize = true;
            this.rainCheckBox.Location = new System.Drawing.Point(112, 179);
            this.rainCheckBox.Name = "rainCheckBox";
            this.rainCheckBox.Size = new System.Drawing.Size(84, 17);
            this.rainCheckBox.TabIndex = 81;
            this.rainCheckBox.Text = "Enable Rain";
            this.rainCheckBox.UseVisualStyleBackColor = true;
            this.rainCheckBox.CheckedChanged += new System.EventHandler(this.rainCheckBox_CheckedChanged);
            // 
            // bigBulletBox
            // 
            this.bigBulletBox.AutoSize = true;
            this.bigBulletBox.Enabled = false;
            this.bigBulletBox.Location = new System.Drawing.Point(112, 202);
            this.bigBulletBox.Name = "bigBulletBox";
            this.bigBulletBox.Size = new System.Drawing.Size(70, 17);
            this.bigBulletBox.TabIndex = 82;
            this.bigBulletBox.Text = "Big Bullet";
            this.bigBulletBox.UseVisualStyleBackColor = true;
            this.bigBulletBox.CheckedChanged += new System.EventHandler(this.bigBulletBox_CheckedChanged);
            // 
            // bulletDamageTextBox
            // 
            this.bulletDamageTextBox.Location = new System.Drawing.Point(109, 221);
            this.bulletDamageTextBox.Name = "bulletDamageTextBox";
            this.bulletDamageTextBox.Size = new System.Drawing.Size(100, 20);
            this.bulletDamageTextBox.TabIndex = 83;
            // 
            // morphineButton
            // 
            this.morphineButton.Location = new System.Drawing.Point(9, 315);
            this.morphineButton.Name = "morphineButton";
            this.morphineButton.Size = new System.Drawing.Size(63, 23);
            this.morphineButton.TabIndex = 84;
            this.morphineButton.Text = "Morphine Cures Bones";
            this.morphineButton.UseVisualStyleBackColor = true;
            this.morphineButton.Click += new System.EventHandler(this.morphineButton_Click);
            // 
            // indirectDamageButton
            // 
            this.indirectDamageButton.Enabled = false;
            this.indirectDamageButton.Location = new System.Drawing.Point(114, 317);
            this.indirectDamageButton.Name = "indirectDamageButton";
            this.indirectDamageButton.Size = new System.Drawing.Size(63, 23);
            this.indirectDamageButton.TabIndex = 85;
            this.indirectDamageButton.Text = "Indirect";
            this.indirectDamageButton.UseVisualStyleBackColor = true;
            this.indirectDamageButton.Click += new System.EventHandler(this.indirectDamageButton_Click);
            // 
            // indirectDamageBox
            // 
            this.indirectDamageBox.Location = new System.Drawing.Point(185, 317);
            this.indirectDamageBox.Name = "indirectDamageBox";
            this.indirectDamageBox.Size = new System.Drawing.Size(69, 20);
            this.indirectDamageBox.TabIndex = 86;
            // 
            // indirectDamageRangeButton
            // 
            this.indirectDamageRangeButton.Enabled = false;
            this.indirectDamageRangeButton.Location = new System.Drawing.Point(115, 346);
            this.indirectDamageRangeButton.Name = "indirectDamageRangeButton";
            this.indirectDamageRangeButton.Size = new System.Drawing.Size(63, 23);
            this.indirectDamageRangeButton.TabIndex = 87;
            this.indirectDamageRangeButton.Text = "Range";
            this.indirectDamageRangeButton.UseVisualStyleBackColor = true;
            this.indirectDamageRangeButton.Click += new System.EventHandler(this.indirectDamageRangeButton_Click);
            // 
            // indirectDamageRangeBox
            // 
            this.indirectDamageRangeBox.Location = new System.Drawing.Point(185, 348);
            this.indirectDamageRangeBox.Name = "indirectDamageRangeBox";
            this.indirectDamageRangeBox.Size = new System.Drawing.Size(69, 20);
            this.indirectDamageRangeBox.TabIndex = 88;
            // 
            // button_reload
            // 
            this.button_reload.Location = new System.Drawing.Point(9, 164);
            this.button_reload.Name = "button_reload";
            this.button_reload.Size = new System.Drawing.Size(110, 27);
            this.button_reload.TabIndex = 89;
            this.button_reload.Text = "Reload Process";
            this.button_reload.UseVisualStyleBackColor = true;
            this.button_reload.Click += new System.EventHandler(this.button_reload_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.playerCheckBox);
            this.groupBox1.Controls.Add(this.checkBox_vehicle);
            this.groupBox1.Controls.Add(this.playerNamesCheckBox);
            this.groupBox1.Controls.Add(this.checkBox_vehicleNames);
            this.groupBox1.Controls.Add(this.playerWeaponCheckBox);
            this.groupBox1.Controls.Add(this.showAnimalsCheckBox);
            this.groupBox1.Controls.Add(this.showHeloCrashesBox);
            this.groupBox1.Controls.Add(this.showTentsBox);
            this.groupBox1.Controls.Add(this.showWeaponsButton);
            this.groupBox1.Controls.Add(this.showSidearmsBox);
            this.groupBox1.Controls.Add(this.checkBox3);
            this.groupBox1.Controls.Add(this.showLMGBox);
            this.groupBox1.Controls.Add(this.showSniperBox);
            this.groupBox1.Controls.Add(this.showRiflesBox);
            this.groupBox1.Controls.Add(this.showShotgunsBox);
            this.groupBox1.Controls.Add(this.showCorpsesBox);
            this.groupBox1.Controls.Add(this.showBackpackBox);
            this.groupBox1.Controls.Add(this.distanceCheckBox);
            this.groupBox1.Controls.Add(this.showFOVBox);
            this.groupBox1.Controls.Add(this.showAmmoBox);
            this.groupBox1.Controls.Add(this.showWeaponsBox);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.searchBox);
            this.groupBox1.Location = new System.Drawing.Point(999, 143);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(272, 643);
            this.groupBox1.TabIndex = 90;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Display Options";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.checkBox_autoRepair);
            this.groupBox2.Controls.Add(this.forceNVBox);
            this.groupBox2.Controls.Add(this.nightVisionButton);
            this.groupBox2.Controls.Add(this.viewDistanceBox);
            this.groupBox2.Controls.Add(this.indirectDamageRangeBox);
            this.groupBox2.Controls.Add(this.forceDayBox);
            this.groupBox2.Controls.Add(this.indirectDamageRangeButton);
            this.groupBox2.Controls.Add(this.forceThermalBox);
            this.groupBox2.Controls.Add(this.indirectDamageBox);
            this.groupBox2.Controls.Add(this.autoZeroBox);
            this.groupBox2.Controls.Add(this.indirectDamageButton);
            this.groupBox2.Controls.Add(this.noFatigueBox);
            this.groupBox2.Controls.Add(this.morphineButton);
            this.groupBox2.Controls.Add(this.infiniteAmmoBox);
            this.groupBox2.Controls.Add(this.bulletDamageTextBox);
            this.groupBox2.Controls.Add(this.disableRecoil);
            this.groupBox2.Controls.Add(this.bigBulletBox);
            this.groupBox2.Controls.Add(this.infiniteGrenadeBox);
            this.groupBox2.Controls.Add(this.rainCheckBox);
            this.groupBox2.Controls.Add(this.fastBulletBox);
            this.groupBox2.Controls.Add(this.fireRateBox);
            this.groupBox2.Controls.Add(this.grassCheckBox);
            this.groupBox2.Controls.Add(this.setBulletSpeedBox);
            this.groupBox2.Location = new System.Drawing.Point(1277, 143);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(279, 643);
            this.groupBox2.TabIndex = 91;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Game Modifiers";
            // 
            // checkBox_autoRepair
            // 
            this.checkBox_autoRepair.AutoSize = true;
            this.checkBox_autoRepair.Location = new System.Drawing.Point(6, 247);
            this.checkBox_autoRepair.Name = "checkBox_autoRepair";
            this.checkBox_autoRepair.Size = new System.Drawing.Size(82, 17);
            this.checkBox_autoRepair.TabIndex = 89;
            this.checkBox_autoRepair.Text = "Auto Repair";
            this.checkBox_autoRepair.UseVisualStyleBackColor = true;
            this.checkBox_autoRepair.CheckedChanged += new System.EventHandler(this.checkBox_autoRepair_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.xCoordBox);
            this.groupBox3.Controls.Add(this.yCoordBox);
            this.groupBox3.Controls.Add(this.zCoordBox);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.textBox2);
            this.groupBox3.Location = new System.Drawing.Point(999, 792);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(272, 197);
            this.groupBox3.TabIndex = 92;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Location Information";
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.button1);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.mapSelectionBox);
            this.groupBox4.Controls.Add(this.button_reload);
            this.groupBox4.Location = new System.Drawing.Point(1277, 792);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(279, 197);
            this.groupBox4.TabIndex = 93;
            this.groupBox4.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(184, 164);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 27);
            this.button1.TabIndex = 90;
            this.button1.Text = "Help";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // objImageViewer1
            // 
            this.objImageViewer1.AutoScroll = true;
            this.objImageViewer1.AutoScrollMargin = new System.Drawing.Size(980, 980);
            this.objImageViewer1.AutoScrollMinSize = new System.Drawing.Size(980, 980);
            this.objImageViewer1.Image = global::DayZMap.Properties.Resources.bigmap;
            this.objImageViewer1.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
            this.objImageViewer1.Location = new System.Drawing.Point(12, 11);
            this.objImageViewer1.Name = "objImageViewer1";
            this.objImageViewer1.Size = new System.Drawing.Size(980, 982);
            this.objImageViewer1.TabIndex = 4;
            this.objImageViewer1.Text = "objImageViewer1";
            this.objImageViewer1.Zoom = 1F;
            this.objImageViewer1.Click += new System.EventHandler(this.objImageViewer1_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Controls.Add(this.zoomBar);
            this.groupBox5.Controls.Add(this.checkBox_keepCentered);
            this.groupBox5.Location = new System.Drawing.Point(998, 12);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(557, 125);
            this.groupBox5.TabIndex = 94;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "groupBox5";
            // 
            // MapForm
            // 
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1577, 881);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.objImageViewer1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MapForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "DayZ Drone";
            this.Load += new System.EventHandler(this.MapForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.zoomBar)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Balance.objImageViewer objImageViewer1;
        private CheckBox checkBox_keepCentered;
        private Label label1;
        private TextBox textBox2;
        public CheckBox checkBox_vehicle;
        public CheckBox checkBox_vehicleNames;
        private ComboBox mapSelectionBox;
        private CheckBox distanceCheckBox;
        private TextBox xCoordBox;
        private TextBox yCoordBox;
        private TextBox zCoordBox;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button nightVisionButton;
        public CheckBox playerCheckBox;
        public CheckBox playerNamesCheckBox;
        private CheckBox playerWeaponCheckBox;
        private CheckBox showAnimalsCheckBox;
        private CheckBox showWeaponsBox;
        private CheckBox showAmmoBox;
        private TextBox searchBox;
        private Label label5;
        private CheckBox showTentsBox;
        private CheckBox showHeloCrashesBox;
        private Label label6;
        private CheckBox showSidearmsBox;
        private CheckBox checkBox3;
        private CheckBox showRiflesBox;
        private CheckBox showLMGBox;
        private CheckBox showSniperBox;
        private CheckBox showShotgunsBox;
        private CheckBox showCorpsesBox;
        private CheckBox showBackpackBox;
        private TrackBar zoomBar;
        private CheckBox forceNVBox;
        private Label label7;
        private TextBox viewDistanceBox;
        private Button showWeaponsButton;
        private CheckBox forceDayBox;
        private CheckBox forceThermalBox;
        private CheckBox showFOVBox;
        private CheckBox autoZeroBox;
        private CheckBox noFatigueBox;
        private CheckBox infiniteAmmoBox;
        private Label label11;
        private Label label12;
        private CheckBox disableRecoil;
        private CheckBox infiniteGrenadeBox;
        private CheckBox fastBulletBox;
        private CheckBox grassCheckBox;
        private TextBox setBulletSpeedBox;
        private CheckBox fireRateBox;
        private CheckBox rainCheckBox;
        private CheckBox bigBulletBox;
        private TextBox bulletDamageTextBox;
        private Button morphineButton;
        private Button indirectDamageButton;
        private TextBox indirectDamageBox;
        private Button indirectDamageRangeButton;
        private TextBox indirectDamageRangeBox;
        private Button button_reload;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private GroupBox groupBox4;
        private CheckBox checkBox_autoRepair;
        private Button button1;
        private GroupBox groupBox5;
    }
}

