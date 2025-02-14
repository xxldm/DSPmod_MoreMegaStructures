﻿using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using BepInEx;
using HarmonyLib;
using xiaoye97;
using UnityEngine;
using System.Reflection;
using BepInEx.Configuration;
using System.Reflection.Emit;
using CommonAPI;
using CommonAPI.Systems;
using System.IO;
using UnityEngine.UI;
using crecheng.DSPModSave;

namespace MoreMegaStructure
{
    [BepInDependency("me.xiaoye97.plugin.Dyson.LDBTool", BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency("dsp.common-api.CommonAPI", BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency(DSPModSavePlugin.MODGUID, BepInDependency.DependencyFlags.HardDependency)]
    [BepInPlugin("Gnimaerd.DSP.plugin.MoreMegaStructure", "MoreMegaStructure", "1.0")]
    [CommonAPISubmoduleDependency(nameof(ProtoRegistry), nameof(TabSystem))]
    public class MoreMegaStructure : BaseUnityPlugin, IModCanSave
    {
        /// <summary>
        /// mod版本会进行存档
        /// </summary>
        public static int modVersion = 100;
        public static bool CompatibilityPatchUnlocked = true;
        public static bool GenesisCompatibility = false;


        //private static Sprite iconAntiInject;
        public static List<int> RelatedGammas;
        public static string GUID = "Gnimaerd.DSP.plugin.MoreMegaStructure";
        public static string MODID_tab = "MegaStructures";
        public static int pagenum = 3;
        public static long HashGenDivisor = 4000000L; //巨构能量转换为哈希点数的除数，每帧hash = 巨构每帧能量 / 此值
        public static long WarpAccDivisor = 10000000L; //计算曲速倍率加成时，每帧巨构能量先除以这个数。如果是10^6，代表每60MW提供100%曲速。此值越大，每MW提供的加速效果越少。
        public static int WarpAccMax = 5000; //巨构提供的最大曲速倍数
        //public static Color defaultType = new Color(0.566f, 0.915f, 1f, 0.07f); //原本是按钮的颜色，后来因为UIButton的鼠标移入移出事件我不会改，那个会扰乱按钮颜色的设定，所以不再用按钮颜色，改用文字颜色
        //public static Color currentType = new Color(0.95f, 0.68f, 0.5f, 0.15f);
        //public static Color disableType = new Color(0.4f, 0.4f, 0.4f, 0.85f); 
        public static Color normalTextColor = new Color(1f, 1f, 1f, 1f);
        public static Color currentTextColor = new Color(1f, 0.75f, 0.1f, 1f);
        public static Color disableTextColor = new Color(0.75f, 0.75f, 0.75f, 1f);

        public static ConfigEntry<bool> LowResolutionMode;

        public static ResourceData resources;
        public static ResourceData iconResources;
        public static Sprite iconRocketMattD;
        public static Sprite iconRocketScieN;
        public static Sprite iconRocketWarpG;
        public static Sprite iconRocketMegaA;
        public static Sprite iconRocketCrysM;
        public static Sprite iconGravityGen;
        public static Sprite iconConstrainRing;
        public static Sprite iconGravityDrill;
        public static Sprite iconIACompo;
        public static Sprite iconInterCompo;
        public static Sprite iconPhotonProbe;
        public static Sprite iconQuanComp;
        public static Sprite iconResDisc;
        public static Sprite iconTunnExciter;
        public static Sprite iconQuickAssembly;
        public static Sprite iconQuickBelt;
        public static Sprite iconQuickChemical;
        public static Sprite iconQuickCollider;
        public static Sprite iconQuickLab;
        public static Sprite iconQuickPLog;
        public static Sprite iconQuickILog;
        public static Sprite iconQuickPower;
        public static Sprite iconQuickReactor;
        public static Sprite iconQuickRefinery;
        public static Sprite iconQuickSmelter;
        public static Sprite iconQuickSorter;
        public static Sprite iconHashes;
        public static Sprite iconWarpBroadcast;
        public static Sprite iconReceiverIron;
        public static Sprite iconReceiverCopper;
        public static Sprite iconReceiverTitanium;
        public static Sprite iconReceiverSilicon;
        public static Sprite iconReceiverMagore;
        public static Sprite iconReceiverCasimir;
        public static Sprite iconReceiverIC;
        public static Sprite iconReceiverScience;
        public static Sprite iconReceiverWarp;
        public static Sprite iconReceiverCoal;
        public static Sprite iconReceiverGrating;

        public static Text LeftDysonCloudTitle;
        public static Text LeftDysonCloudBluePrintText;
        public static Text LeftDysonShellTitle;
        public static Text LeftDysonShellBluePrintText;
        public static Text LeftDysonShellOrbitTitleText;
        public static Text RightDysonTitle;
        public static Text RightStarPowRatioText;
        public static Text RightMaxPowGenText;
        public static Text RightMaxPowGenValueText;
        public static Text RightDysonBluePrintText;
        public static Text SpSailAmoutText;
        public static Text SpSailLifeTimeText;
        public static Text SpSailLifeTimeBarText;
        public static Text SpSwarmPowGenText;
        public static Text SpShellPowGenText;
        public static Text SoSailAmoutText;
        public static Text SoSailPowGenText;
        public static Text SoSailLifeTimeText;
        public static Text SoSailLifeTimeBarText;
        public static Text LyPowGenText;
        public static Text NdPowGenText;
        public static Text FrPowGenText;
        public static Text ShPowGenText;
        public static Text ReceiverUIButton2Text;//接收器UI的模式2按钮的文本

        public static GameObject set2DysonButtonObj;
        public static GameObject set2MatDecomButtonObj;
        public static GameObject set2SciNexusButtonObj;
        public static GameObject set2WarpFieldGenButtonObj;
        public static GameObject set2MegaAssemButtonObj;
        public static GameObject set2CrystalMinerButtonObj; 
        public static Button set2DysonButton;
        public static Button set2MatDecomButton;
        public static Button set2SciNexusButton;
        public static Button set2WarpFieldGenButton;
        public static Button set2MegaAssemButton;
        public static Button set2CrystalMinerButton;
        public static Transform set2DysonButtonTextTrans;
        public static Transform set2MatDecomButtonTextTrans;
        public static Transform set2SciNexusButtonTextTrans;
        public static Transform set2WarpFieldGenButtonTextTrans;
        public static Transform set2MegaAssemButtonTextTrans;
        public static Transform set2CrystalMinerButtonTextTrans;

        public static Text SetMegaStructureLabelText;
        public static Text SetMegaStructureWarningText;

        //public static bool UIDysonEditorIsOn = false; //戴森球编辑界面是否处于打开状态

        public static StarData curStar; //编辑巨构建筑页面当前显示的恒星的数据
        public static DysonSphere curDysonSphere; //戴森球编辑界面正在浏览的戴森球
        public static int WarpBuiltStarIndex; //折跃场已经在该地址的恒星上建造过了

        /// <summary>
        /// 下面的数据为游戏运行时的关键数据，且会进行存档
        /// </summary>
        public static int[] StarMegaStructureType = new int[1000]; //用于存储每个恒星所构建的巨构建筑类型，默认为0则为戴森球

        public void Awake()
        {
            try
            {
                using (ProtoRegistry.StartModLoad(GUID))
                {
                    //Initilize new instance of ResourceData class.
                    string pluginfolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                    resources = new ResourceData(GUID, "MegaStructureTab", pluginfolder); // Make sure that the keyword you are using is not used by other mod authors.
                    resources.LoadAssetBundle("mmstabicon"); // Load asset bundle located near your assembly
                                                              //resources.ResolveVertaFolder(); // Call this to resolver verta folder. You don't need to call this if you are not using .verta files 
                    ProtoRegistry.AddResource(resources); // Add your ResourceData to global list of resources
                    pagenum = TabSystem.RegisterTab($"{MODID_tab}:{MODID_tab}Tab", new TabData("MegaStructures", "Assets/MegaStructureTab/megaStructureTabIcon"));

                }
            }
            catch (Exception)
            {

                pagenum = TabSystem.RegisterTab($"{MODID_tab}:{MODID_tab}Tab", new TabData("MegaStructures", "Assets/MegaStructureTab/megaStructureTabIcon"));
            }
            LowResolutionMode = Config.Bind<bool>("config", "LowResolutionMode", false, "Trun this to true if your game resolution is lower than 1920*1080. 如果你的游戏分辨率低于1920*1080，请设置此项为true。");
            //var ab = AssetBundle.LoadFromStream(Assembly.GetExecutingAssembly().GetManifestResourceStream("MoreMegaStructure.megastructureicons"));
            iconRocketMattD = Resources.Load<Sprite>("Assets/MegaStructureTab/rocketMatter");
            iconRocketScieN = Resources.Load<Sprite>("Assets/MegaStructureTab/rocketScience");
            iconRocketWarpG = Resources.Load<Sprite>("Assets/MegaStructureTab/rocketWarp");
            iconRocketMegaA = Resources.Load<Sprite>("Assets/MegaStructureTab/rocketAssembly");
            iconRocketCrysM = Resources.Load<Sprite>("Assets/MegaStructureTab/rocketCrystal");
            iconGravityGen = Resources.Load<Sprite>("Assets/MegaStructureTab/gravitygenerator");
            iconConstrainRing = Resources.Load<Sprite>("Assets/MegaStructureTab/constrainring");
            iconGravityDrill = Resources.Load<Sprite>("Assets/MegaStructureTab/gravitydrill2");
            iconIACompo = Resources.Load<Sprite>("Assets/MegaStructureTab/iacomponent");
            iconInterCompo = Resources.Load<Sprite>("Assets/MegaStructureTab/integratedcomponents");
            iconPhotonProbe = Resources.Load<Sprite>("Assets/MegaStructureTab/photonprobeflipsmall");
            iconQuanComp = Resources.Load<Sprite>("Assets/MegaStructureTab/quantumcomputer2");
            iconResDisc = Resources.Load<Sprite>("Assets/MegaStructureTab/resonancedisc");
            iconTunnExciter = Resources.Load<Sprite>("Assets/MegaStructureTab/tunnelingexciter");
            iconQuickAssembly = Resources.Load<Sprite>("Assets/MegaStructureTab/Rassembly");
            iconQuickBelt = Resources.Load<Sprite>("Assets/MegaStructureTab/Rbelt");
            iconQuickChemical = Resources.Load<Sprite>("Assets/MegaStructureTab/Rchemical");
            iconQuickCollider = Resources.Load<Sprite>("Assets/MegaStructureTab/Rcollider");
            iconQuickLab = Resources.Load<Sprite>("Assets/MegaStructureTab/Rlab");
            iconQuickPLog = Resources.Load<Sprite>("Assets/MegaStructureTab/Rlogistic");
            iconQuickILog = Resources.Load<Sprite>("Assets/MegaStructureTab/Rislogistic");
            iconQuickPower = Resources.Load<Sprite>("Assets/MegaStructureTab/Rpower");
            iconQuickReactor = Resources.Load<Sprite>("Assets/MegaStructureTab/Rreactor");
            iconQuickRefinery = Resources.Load<Sprite>("Assets/MegaStructureTab/Rrefinery");
            iconQuickSmelter = Resources.Load<Sprite>("Assets/MegaStructureTab/Rsmelter");
            iconQuickSorter = Resources.Load<Sprite>("Assets/MegaStructureTab/Rsorter");
            iconHashes = Resources.Load<Sprite>("Assets/MegaStructureTab/HashPoints");
            iconWarpBroadcast = Resources.Load<Sprite>("Assets/MegaStructureTab/WarpFieldBroadcast");
            iconReceiverIron = Resources.Load<Sprite>("Assets/MegaStructureTab/Ciron");
            iconReceiverCopper = Resources.Load<Sprite>("Assets/MegaStructureTab/Ccopper");
            iconReceiverTitanium = Resources.Load<Sprite>("Assets/MegaStructureTab/Ctitanium");
            iconReceiverSilicon = Resources.Load<Sprite>("Assets/MegaStructureTab/Csilicon");
            iconReceiverMagore = Resources.Load<Sprite>("Assets/MegaStructureTab/Cmagore");
            iconReceiverCasimir = Resources.Load<Sprite>("Assets/MegaStructureTab/Ccrystal");
            iconReceiverIC = Resources.Load<Sprite>("Assets/MegaStructureTab/Cic");
            iconReceiverScience = Resources.Load<Sprite>("Assets/MegaStructureTab/Cscience");
            iconReceiverWarp = Resources.Load<Sprite>("Assets/MegaStructureTab/Cwarp");
            iconReceiverCoal = Resources.Load<Sprite>("Assets/MegaStructureTab/Ccoal");
            iconReceiverGrating = Resources.Load<Sprite>("Assets/MegaStructureTab/Cgrating");

            Harmony.CreateAndPatchAll(typeof(MoreMegaStructure));

            LDBTool.EditDataAction += MMSProtos.ChangeReceiverRelatedStringProto;

            LDBTool.PreAddDataAction += MMSProtos.AddTranslateUILabel;
            LDBTool.PreAddDataAction += MMSProtos.AddTranslateStructureName;
            LDBTool.PreAddDataAction += MMSProtos.AddTranslateProtoNames1;
            LDBTool.PreAddDataAction += MMSProtos.AddTranslateProtoNames2;
            LDBTool.PreAddDataAction += MMSProtos.AddTranslateProtoNames3;
            LDBTool.PreAddDataAction += MMSProtos.AddNewItems;
            LDBTool.PostAddDataAction += MMSProtos.AddReceivers;
            LDBTool.PostAddDataAction += MMSProtos.RefreshInitAll;

            if(CompatibilityPatchUnlocked)
            {
                AccessTools.StaticFieldRefAccess<ConfigFile>(typeof(LDBTool), "CustomID").Clear();
                AccessTools.StaticFieldRefAccess<ConfigFile>(typeof(LDBTool), "CustomGridIndex").Clear();
                AccessTools.StaticFieldRefAccess<ConfigFile>(typeof(LDBTool), "CustomStringZHCN").Clear();
                AccessTools.StaticFieldRefAccess<ConfigFile>(typeof(LDBTool), "CustomStringENUS").Clear();
                AccessTools.StaticFieldRefAccess<ConfigFile>(typeof(LDBTool), "CustomStringFRFR").Clear();
            }

        }

        public void Start()
        {
            GetVanillaUITexts();
            InitMegaSetUI();
        }
        public void Update()
        {
        }

        public static void GetVanillaUITexts()
        {
            try
            {
                GameObject LeftCloud = GameObject.Find("UI Root/Overlay Canvas/In Game/Windows/Dyson Sphere Editor/Dyson Editor Control Panel/hierarchy/swarm/title-text");
                GameObject LeftCloudBluePrint = GameObject.Find("UI Root/Overlay Canvas/In Game/Windows/Dyson Sphere Editor/Dyson Editor Control Panel/hierarchy/swarm/blueprint/text");
                LeftDysonCloudTitle = LeftCloud.GetComponent<Text>();
                LeftDysonCloudBluePrintText = LeftCloudBluePrint.GetComponent<Text>();
                //戴森云 戴森云蓝图
            }
            catch (Exception)
            {
                //Console.WriteLine("GO Find Group 1 ERROR");
            }

            try
            {
                GameObject LeftShell = GameObject.Find("UI Root/Overlay Canvas/In Game/Windows/Dyson Sphere Editor/Dyson Editor Control Panel/hierarchy/layers/title-text");
                GameObject LeftShellBluePrint = GameObject.Find("UI Root/Overlay Canvas/In Game/Windows/Dyson Sphere Editor/Dyson Editor Control Panel/hierarchy/layers/blueprint-group/blueprint-text");
                GameObject LeftShellOrbitTitle = GameObject.Find("UI Root/Overlay Canvas/In Game/Windows/Dyson Sphere Editor/Dyson Editor Control Panel/hierarchy/layers/buttons-group/orbit-title-text");
                LeftDysonShellTitle = LeftShell.GetComponent<Text>();
                LeftDysonShellBluePrintText = LeftShellBluePrint.GetComponent<Text>();
                LeftDysonShellOrbitTitleText = LeftShellOrbitTitle.GetComponent<Text>();
                //戴森壳 戴森壳蓝图
            }
            catch (Exception)
            {
                //Console.WriteLine("GO Find Group 2 ERROR");
            }

            try
            {
                RightDysonTitle = GameObject.Find("UI Root/Overlay Canvas/In Game/Windows/Dyson Sphere Editor/Dyson Editor Control Panel/inspector/overview-group/name-text").GetComponent<Text>();
                RightStarPowRatioText = GameObject.Find("UI Root/Overlay Canvas/In Game/Windows/Dyson Sphere Editor/Dyson Editor Control Panel/inspector/overview-group/star-label").GetComponent<Text>();
                RightMaxPowGenText = GameObject.Find("UI Root/Overlay Canvas/In Game/Windows/Dyson Sphere Editor/Dyson Editor Control Panel/inspector/overview-group/gen-label").GetComponent<Text>();
                RightMaxPowGenValueText = GameObject.Find("UI Root/Overlay Canvas/In Game/Windows/Dyson Sphere Editor/Dyson Editor Control Panel/inspector/overview-group/gen-value").GetComponent<Text>();
                RightDysonBluePrintText = GameObject.Find("UI Root/Overlay Canvas/In Game/Windows/Dyson Sphere Editor/Dyson Editor Control Panel/inspector/overview-group/blueprint").GetComponent<Text>();
                //戴森球+星系名称  恒星光度系数  最大发电性能 最大发电性能的值 戴森球蓝图  
            }
            catch (Exception)
            {
                //Console.WriteLine("GO Find Group 3 ERROR");
            }

            try
            {
                SpSailAmoutText = GameObject.Find("UI Root/Overlay Canvas/In Game/Windows/Dyson Sphere Editor/Dyson Editor Control Panel/inspector/sphere-group/prop-label-0").GetComponent<Text>();
                SpSailLifeTimeText = GameObject.Find("UI Root/Overlay Canvas/In Game/Windows/Dyson Sphere Editor/Dyson Editor Control Panel/inspector/sphere-group/sail-stat/sail-histogram/title").GetComponent<Text>();
                SpSailLifeTimeBarText = GameObject.Find("UI Root/Overlay Canvas/In Game/Windows/Dyson Sphere Editor/Dyson Editor Control Panel/inspector/sphere-group/sail-stat/bar-group/title").GetComponent<Text>();
                //太阳帆总数 太阳帆寿命分布 太阳帆状态统计
                SpSwarmPowGenText = GameObject.Find("UI Root/Overlay Canvas/In Game/Windows/Dyson Sphere Editor/Dyson Editor Control Panel/inspector/sphere-group/power-desc/label-3").GetComponent<Text>();
                SpShellPowGenText = GameObject.Find("UI Root/Overlay Canvas/In Game/Windows/Dyson Sphere Editor/Dyson Editor Control Panel/inspector/sphere-group/power-desc/label-4").GetComponent<Text>();
                //戴森云发电性能 戴森壳发电性能 
            }
            catch (Exception)
            {
                //Console.WriteLine("GO Find Group 4 ERROR");
            }

            try
            {
                SoSailAmoutText = GameObject.Find("UI Root/Overlay Canvas/In Game/Windows/Dyson Sphere Editor/Dyson Editor Control Panel/inspector/swarm-orbit-group/self-info/prop-label-0").GetComponent<Text>();
                SoSailPowGenText = GameObject.Find("UI Root/Overlay Canvas/In Game/Windows/Dyson Sphere Editor/Dyson Editor Control Panel/inspector/swarm-orbit-group/self-info/prop-label-1").GetComponent<Text>();
                SoSailLifeTimeText = GameObject.Find("UI Root/Overlay Canvas/In Game/Windows/Dyson Sphere Editor/Dyson Editor Control Panel/inspector/swarm-orbit-group/sail-stat/sail-histogram/title").GetComponent<Text>();
                SoSailLifeTimeBarText = GameObject.Find("UI Root/Overlay Canvas/In Game/Windows/Dyson Sphere Editor/Dyson Editor Control Panel/inspector/swarm-orbit-group/sail-stat/bar-group/title").GetComponent<Text>();
                //轨道的 太阳帆数量 发电性能 太阳帆寿命分布 太阳帆状态统计    
                LyPowGenText = GameObject.Find("UI Root/Overlay Canvas/In Game/Windows/Dyson Sphere Editor/Dyson Editor Control Panel/inspector/layer-group/self-info/prop-label-4").GetComponent<Text>();
                //层的 发电性能
                NdPowGenText = GameObject.Find("UI Root/Overlay Canvas/In Game/Windows/Dyson Sphere Editor/Dyson Editor Control Panel/inspector/node-group/self-info/prop-label-5").GetComponent<Text>();
                //节点的 发电性能
            }
            catch (Exception)
            {
                //Console.WriteLine("GO Find Group 5 ERROR");
            }

            try
            {

                FrPowGenText = GameObject.Find("UI Root/Overlay Canvas/In Game/Windows/Dyson Sphere Editor/Dyson Editor Control Panel/inspector/frame-group/self-info/prop-label-0").GetComponent<Text>();
                //框架的 发电性能
                ShPowGenText = GameObject.Find("UI Root/Overlay Canvas/In Game/Windows/Dyson Sphere Editor/Dyson Editor Control Panel/inspector/shell-group/self-info/prop-label-0").GetComponent<Text>();
                //壳的 发电性能
            }
            catch (Exception)
            {
                //Console.WriteLine("GO Find Group 6 ERROR");
            }

            try
            {
                ReceiverUIButton2Text = GameObject.Find("UI Root/Overlay Canvas/In Game/Windows/Power Generator Window/ray-receiver/switch-button-2/button-text").GetComponent<Text>();
                ReceiverUIButton2Text.text = "物质合成".Translate();
            }
            catch (Exception)
            {
                //Console.WriteLine("GO Find Group 7 ERROR");
            }
        }

        public static void InitMegaSetUI()
        {
            try
            {
                //低分辨率
                int biasX = 0;
                int biasY = 0;
                if (LowResolutionMode.Value)
                {
                    biasX = 300;
                    biasY = 800;
                }

                //主要标签提示文字等
                GameObject DysonUILeft = GameObject.Find("UI Root/Overlay Canvas/In Game/Windows/Dyson Sphere Editor/Dyson Editor Control Panel/hierarchy"); //戴森球编辑器UI的左边 作为Parent

                GameObject LeftShellLabel2 = GameObject.Find("UI Root/Overlay Canvas/In Game/Windows/Dyson Sphere Editor/Dyson Editor Control Panel/hierarchy/layers/title-text");
                GameObject LeftMegaStructrueTypeLabel = Instantiate(LeftShellLabel2);
                LeftMegaStructrueTypeLabel.name = "title3";
                LeftMegaStructrueTypeLabel.transform.SetParent(DysonUILeft.transform, false);
                LeftMegaStructrueTypeLabel.transform.localPosition = new Vector3(22 + biasX, -800 + biasY, 0);
                SetMegaStructureLabelText = LeftMegaStructrueTypeLabel.GetComponent<Text>();
                SetMegaStructureLabelText.text = "规划巨构建筑类型";

                GameObject LeftMegaBuildWarning = Instantiate(LeftShellLabel2);
                LeftMegaBuildWarning.name = "settype-warning";
                LeftMegaBuildWarning.transform.SetParent(DysonUILeft.transform, false);
                LeftMegaBuildWarning.transform.localPosition = new Vector3(20 + biasX, -1025 + biasY, 0);
                SetMegaStructureWarningText = LeftMegaBuildWarning.GetComponent<Text>();
                SetMegaStructureWarningText.GetComponent<RectTransform>().sizeDelta = new Vector2(250, 50); //按钮大小
                SetMegaStructureWarningText.text = "警告文本";
                SetMegaStructureWarningText.fontSize = 14;
                SetMegaStructureWarningText.color = new Color(0.9f, 0.1f, 0.1f, 0.8f);

                //按钮
                GameObject addNewLayerButton = GameObject.Find("UI Root/Overlay Canvas/In Game/Windows/Dyson Sphere Editor/Dyson Editor Control Panel/hierarchy/layers/buttons-group/buttons/add-button");

                set2DysonButtonObj = Instantiate(addNewLayerButton);
                set2DysonButtonObj.SetActive(true);
                set2DysonButtonObj.name = "set-mega-0"; //名字
                set2DysonButtonObj.transform.SetParent(DysonUILeft.transform, false);
                set2DysonButtonObj.transform.localPosition = new Vector3(30 + biasX, -835 + biasY, 0); //位置
                set2DysonButtonObj.GetComponent<RectTransform>().sizeDelta = new Vector2(220, 28); //按钮大小
                set2DysonButtonTextTrans = set2DysonButtonObj.transform.Find("Text");
                set2DysonButton = set2DysonButtonObj.GetComponent<Button>();
                set2DysonButton.interactable = true;

                set2MatDecomButtonObj = Instantiate(addNewLayerButton);
                set2MatDecomButtonObj.SetActive(true);
                set2MatDecomButtonObj.name = "set-mega-1"; //名字
                set2MatDecomButtonObj.transform.SetParent(DysonUILeft.transform, false);
                set2MatDecomButtonObj.transform.localPosition = new Vector3(30 + biasX, -865 + biasY, 0); //位置
                set2MatDecomButtonObj.GetComponent<RectTransform>().sizeDelta = new Vector2(220, 28); //按钮大小
                set2MatDecomButtonTextTrans = set2MatDecomButtonObj.transform.Find("Text");
                set2MatDecomButton = set2MatDecomButtonObj.GetComponent<Button>();
                set2MatDecomButton.interactable = true;

                set2SciNexusButtonObj = Instantiate(addNewLayerButton);
                set2SciNexusButtonObj.SetActive(true);
                set2SciNexusButtonObj.name = "set-mega-2"; //名字
                set2SciNexusButtonObj.transform.SetParent(DysonUILeft.transform, false);
                set2SciNexusButtonObj.transform.localPosition = new Vector3(30 + biasX, -895 + biasY, 0); //位置
                set2SciNexusButtonObj.GetComponent<RectTransform>().sizeDelta = new Vector2(220, 28); //按钮大小
                set2SciNexusButtonTextTrans = set2SciNexusButtonObj.transform.Find("Text");
                set2SciNexusButton = set2SciNexusButtonObj.GetComponent<Button>();
                set2SciNexusButton.interactable = true;

                set2WarpFieldGenButtonObj = Instantiate(addNewLayerButton);
                set2WarpFieldGenButtonObj.SetActive(true);
                set2WarpFieldGenButtonObj.name = "set-mega-3"; //名字
                set2WarpFieldGenButtonObj.transform.SetParent(DysonUILeft.transform, false);
                set2WarpFieldGenButtonObj.transform.localPosition = new Vector3(30 + biasX, -925 + biasY, 0); //位置
                set2WarpFieldGenButtonObj.GetComponent<RectTransform>().sizeDelta = new Vector2(220, 28); //按钮大小
                set2WarpFieldGenButtonTextTrans = set2WarpFieldGenButtonObj.transform.Find("Text");
                set2WarpFieldGenButton = set2WarpFieldGenButtonObj.GetComponent<Button>();
                set2WarpFieldGenButton.interactable = true;

                set2MegaAssemButtonObj = Instantiate(addNewLayerButton);
                set2MegaAssemButtonObj.SetActive(true);
                set2MegaAssemButtonObj.name = "set-mega-4"; //名字
                set2MegaAssemButtonObj.transform.SetParent(DysonUILeft.transform, false);
                set2MegaAssemButtonObj.transform.localPosition = new Vector3(30 + biasX, -955 + biasY, 0); //位置
                set2MegaAssemButtonObj.GetComponent<RectTransform>().sizeDelta = new Vector2(220, 28); //按钮大小
                set2MegaAssemButtonTextTrans = set2MegaAssemButtonObj.transform.Find("Text");
                set2MegaAssemButton = set2MegaAssemButtonObj.GetComponent<Button>();
                set2MegaAssemButton.interactable = true;

                set2CrystalMinerButtonObj = Instantiate(addNewLayerButton);
                set2CrystalMinerButtonObj.SetActive(true);
                set2CrystalMinerButtonObj.name = "set-mega-5"; //名字
                set2CrystalMinerButtonObj.transform.SetParent(DysonUILeft.transform, false);
                set2CrystalMinerButtonObj.transform.localPosition = new Vector3(30 + biasX, -985 + biasY, 0); //位置
                set2CrystalMinerButtonObj.GetComponent<RectTransform>().sizeDelta = new Vector2(220, 28); //按钮大小
                set2CrystalMinerButtonTextTrans = set2CrystalMinerButtonObj.transform.Find("Text");
                set2CrystalMinerButton = set2CrystalMinerButtonObj.GetComponent<Button>();
                set2CrystalMinerButton.interactable = true;

                set2DysonButton.onClick.RemoveAllListeners();
                set2DysonButton.onClick.AddListener(() => { SetMegaStructure(0); });//按下按钮，设置巨构类型
                set2MatDecomButton.onClick.RemoveAllListeners();
                set2MatDecomButton.onClick.AddListener(() => { SetMegaStructure(1); });
                set2SciNexusButton.onClick.RemoveAllListeners();
                set2SciNexusButton.onClick.AddListener(() => { SetMegaStructure(2); });
                set2WarpFieldGenButton.onClick.RemoveAllListeners();
                set2WarpFieldGenButton.onClick.AddListener(() => { SetMegaStructure(3); });
                set2MegaAssemButton.onClick.RemoveAllListeners();
                set2MegaAssemButton.onClick.AddListener(() => { SetMegaStructure(4); });
                set2CrystalMinerButton.onClick.RemoveAllListeners();
                set2CrystalMinerButton.onClick.AddListener(() => { SetMegaStructure(5); });

            }
            catch (Exception)
            {
                Debug.LogWarning("ButtonInit ERROR");
            }
        }


        /// <summary>
        /// 下面的patch用于：让其他巨构建筑只计算壳面的“发电量”，不计算漂浮的“戴森云/太阳帆”的“发电量”
        /// </summary>
        /// <param name="__instance"></param>
        [HarmonyPostfix]
        [HarmonyPatch(typeof(DysonSphere), "BeforeGameTick")]
        public static void BeforeGameTickPostPatch(ref DysonSphere __instance)
        {
            if(StarMegaStructureType[__instance.starData.id-1] == 0) //如果是戴森球，则不进行修改
            {
                return;
            }    

            //否则，只计算壳面的效果，忽略游戏本体所谓戴森云的效果（也就是发电量）
            __instance.energyGenCurrentTick -= __instance.swarm.energyGenCurrentTick;
        }



        /// <summary>
        /// 接收器每帧函数的patch，用于设定各种新接收器的行为。待完善。
        /// </summary>
        /// <param name="__instance"></param>
        /// <param name="useIon"></param>
        /// <param name="useCata"></param>
        /// <param name="factory"></param>
        /// <param name="productRegister"></param>
        /// <param name="consumeRegister"></param>
        /// <returns></returns>
        [HarmonyPrefix]
        [HarmonyPatch(typeof(PowerGeneratorComponent), "GameTick_Gamma")]
        public static bool GameTick_GammaPatch(ref PowerGeneratorComponent __instance, bool useIon, bool useCata, PlanetFactory factory, int[] productRegister, int[] consumeRegister)
        {
            int idx = factory.planet.star.id - 1;
            if(idx<0 || idx > 999)
            {
                Debug.LogWarning("GameTick_GammaPatch index out of range. Now return true.");
                return true;
            }
            int megaType = StarMegaStructureType[idx];
            int protoID = factory.entityPool[__instance.entityId].protoId;//接收器的建筑的原型ID
            if(megaType == 0 && protoID == 2208)
            {
                return true;
            }
            else if (megaType == 1 && ((protoID >= 9493 && protoID<=9497) || protoID == 9501))//物质解压器
            {
                return true;
            }
            else if(megaType == 4 && protoID==9499)//星际组装厂
            {
                return true;
            }
            else if(megaType == 5 && (protoID == 9498 || protoID == 9502))//晶体重构器
            {
                return true;
            }
            //其他情况不允许接收器输出物质
            return false;
        }





        /// <summary>
        /// 折跃场广播阵列巨构 以及 科学枢纽 的效果，将在戴森球本身的gametick里完成，而不需要接收器
        /// </summary>
        /// <param name="__instance"></param>
        [HarmonyPostfix]
        [HarmonyPatch(typeof(DysonSphere), "GameTick")]
        public static void DysonSphereGameTickPostPatch(ref DysonSphere __instance)
        {
            int idx = __instance.starData.id - 1;
            if(idx<0 || idx > 999)
            {
                return;
            }

            if (StarMegaStructureType[idx] == 2) //如果是科学枢纽
            {
                GameHistoryData history = GameMain.history;
                GameStatData statistics = GameMain.statistics;

                int num = history.currentTech;
                if (num <= 0)
                {
                    return;
                }
                TechProto techProto = LDB.techs.Select(num);
                TechState ts = default(TechState);


                FactoryProductionStat factoryProductionStat = null;
                if (__instance.starData.planets.Length > 0)
                {
                    try
                    {
                        //PlanetFactory factory = __instance.starData.planets[__instance.starData.planets.Length - 1].factory;//科学枢纽的科研点产出算在0号星球上，目前测试0号是最内轨行星，如果是气态怎么办呢？
                        //factoryProductionStat = statistics.production.factoryStatPool[factory.index];
                        factoryProductionStat = statistics.production.factoryStatPool[0]; //这是母星的统计面板
                    }
                    catch (Exception)
                    {
                        factoryProductionStat = null;
                        Debug.LogWarning("factoryProductionStat didn't find.");
                    }
                }
                int techHashedThisFrame = statistics.techHashedThisFrame;
                long universeMatrixPointUploaded = history.universeMatrixPointUploaded;

                if (num > 0 && techProto != null && techProto.IsLabTech && GameMain.history.techStates.ContainsKey(num))
                {
                    ts = history.techStates[num];
                }

                int researchTechId = num;
                long baseHashP = (__instance.energyGenCurrentTick - __instance.energyReqCurrentTick) / HashGenDivisor;
                long HashP = baseHashP * history.techSpeed;//默认情况下每tick增加这么多的研究哈希值
                HashP = (HashP < ts.hashNeeded - ts.hashUploaded) ? HashP : (ts.hashNeeded - ts.hashUploaded - 1);//但每次增加的值不会达到最终需求点数，总会差一点。

                //下面的if其实没必要。阻止锅盖直接完成科技的全部哈希值，而是剩下最后一点。如果完成全部的hash会出现各种错误。因此最后一点hash交由游戏本身的研究所或者机甲研究完成科技的解锁。
                if (ts.hashUploaded < ts.hashNeeded - HashP)
                {
                    ts.hashUploaded += HashP;
                    universeMatrixPointUploaded += (long)ts.uPointPerHash * HashP;
                    techHashedThisFrame += (int)HashP;
                }

                history.techStates[researchTechId] = ts;
                statistics.techHashedThisFrame = techHashedThisFrame;
                history.universeMatrixPointUploaded = universeMatrixPointUploaded;
                //如果找到了工厂，就记录数据面板研究点数
                if (factoryProductionStat != null)
                {
                    long hashRegister = factoryProductionStat.hashRegister;
                    hashRegister += HashP;
                    factoryProductionStat.hashRegister = hashRegister;
                }
            }
            else if (StarMegaStructureType[idx] == 3) //如果是折跃场广播阵列
            {
                GameHistoryData history = GameMain.history;

                int curTechLevel = 2;

                //TechProto techProto = LDB.techs.Select(3407);
                try
                {
                    TechState ts = history.techStates[3407];
                    curTechLevel = ts.curLevel > 2 ? ts.curLevel : 2;
                }
                catch (Exception)
                {
                    Debug.LogWarning("No history techStates of 3407.");
                }

                try
                {
                    if (__instance != null)
                    {
                        long DysonEnergy = (__instance.energyGenCurrentTick - __instance.energyReqCurrentTick) / WarpAccDivisor; //根据巨构的能量减去需求量，除以1000000后，如果再乘60，单位就是MW。现在除10^7也就是每60MW提供10%的额外曲速速度
                        DysonEnergy = DysonEnergy > WarpAccMax ? WarpAccMax : DysonEnergy; //3TW为上限加成，即+250ly/s
                        if (DysonEnergy <= 0) // 原来有|| __instance.energyGenCurrentTick_Layers <= 0，但是不需要了因为energyGenCurrentTick的计算方式已被我改了
                        {
                            history.logisticShipSpeedScale = 1f + (float)(curTechLevel - 2) * 0.5f;
                        }
                        else
                        {
                            history.logisticShipSpeedScale = 1f + (float)(curTechLevel - 2) * 0.5f + (float)DysonEnergy;
                        }
                    }
                    else
                    {
                        history.logisticShipSpeedScale = 1f + (float)(curTechLevel - 2) * 0.5f;
                    }

                }
                catch (Exception)
                {
                    Debug.LogWarning("Error on RefreshShipSpeedScale");
                }
            }
            

        }


        

        /// <summary>
        /// 火箭发射器所需火箭修正，注意如果更改了巨构类型，而发射器内还存有不相符的火箭，该火箭将直接消失（为了防止用廉价火箭白嫖高价火箭）
        /// </summary>
        /// <param name="__instance"></param>
        [HarmonyPostfix]
        [HarmonyPatch(typeof(SiloComponent), "InternalUpdate")]
        public static void SiloUpdatePatch(ref SiloComponent __instance)
        {
            int starIndex = __instance.planetId / 100 - 1;
            if (starIndex < 0 || starIndex > 999)
            {
                Debug.LogWarning("SiloInternalUpdate Patch Error because starIndex out of range.");
                return;
            }
            int bulletIdExpected = 1503;
            int megaType = StarMegaStructureType[starIndex];
            switch (megaType)
            {
                case 0:
                    bulletIdExpected = 1503;
                    break;
                case 1:
                    bulletIdExpected = 9488;
                    break;
                case 2:
                    bulletIdExpected = 9489;
                    break;
                case 3:
                    bulletIdExpected = 9490;
                    break;
                case 4:
                    bulletIdExpected = 9491;
                    break;
                case 5:
                    bulletIdExpected = 9492;
                    break;
                default:
                    break;
            }

            if(__instance.bulletId != bulletIdExpected)
            {
                __instance.bulletCount = 0;
                __instance.bulletInc = 0;
                __instance.bulletId = bulletIdExpected;
            }
            
        }


        /// <summary>
        /// 下面三个是在戴森球界面进行操作时需要重置UI文本、按钮等操作，貌似改游戏本身的stringproto也可以，但是没改
        /// </summary>
        /// <param name="__instance"></param>
        [HarmonyPostfix]
        [HarmonyPatch(typeof(UIDysonEditor), "_OnOpen")]
        public static void SetTextOnOpen(UIDysonEditor __instance)
        {
            if (__instance.selection.viewDysonSphere != null)
            {
                curDysonSphere = __instance.selection.viewDysonSphere;
            }
            if (__instance.selection.viewStar != null)
            {
                RefreshUILabels(__instance.selection.viewStar);
            }
            else
            {
                RefreshUILabels(__instance.gameData.localStar);
            }
            
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(UIDysonEditor), "OnViewStarChange")]
        public static void SetTextOnViewStarChange(UIDysonEditor __instance)
        {
            if (__instance.selection.viewDysonSphere != null)
            {
                curDysonSphere = __instance.selection.viewDysonSphere;
            }
            if (__instance.selection.viewStar != null)
            {
                RefreshUILabels(__instance.selection.viewStar);
            }
            else
            {
                RefreshUILabels(__instance.gameData.localStar);
            }
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(UIDysonEditor), "OnSelectionChange")]
        public static void SetTextOnSelectionChange(UIDysonEditor __instance)
        {
            if (__instance.selection.viewDysonSphere != null)
            {
                curDysonSphere = __instance.selection.viewDysonSphere;
            }
            if (__instance.selection.viewStar != null)
            {
                RefreshUILabels(__instance.selection.viewStar);
            }
            else
            {
                RefreshUILabels(__instance.gameData.localStar);
            }
            
        }


        public static void RefreshUILabels(StarData star)//改变UI中显示的文本，不能再叫戴森球了。另外改变新增的设置巨构建筑类型的按钮的状态
        {
            curStar = star;

            int idx = star.id - 1;
            idx = idx < 0 ? 0 : (idx > 999 ? 999 : idx);

            //Console.WriteLine($"Refreshing phase. ori_idx={star.id -1} and finding idx the name is {GameMain.galaxy.stars[idx].displayName}, while cur name is {star.displayName}");

            SetMegaStructureLabelText.text = "规划巨构建筑类型".Translate();

            LeftDysonCloudTitle.text = "自由组件云".Translate();
            LeftDysonCloudBluePrintText.text = "组件云蓝图".Translate();
            LeftDysonShellTitle.text = "锚定结构".Translate();
            LeftDysonShellOrbitTitleText.text = "结构层级".Translate();
            LeftDysonShellBluePrintText.text = "锚定结构蓝图".Translate();
            RightStarPowRatioText.text = "恒星功效系数".Translate();
            RightMaxPowGenText.text = "最大工作效率".Translate();
            RightDysonBluePrintText.text = "巨构建筑蓝图".Translate();
            SpSailAmoutText.text = "自由组件数量".Translate();
            SpSailLifeTimeText.text = "自由组件寿命分布".Translate();
            SpSailLifeTimeBarText.text = "自由组件状态统计".Translate();
            SpSwarmPowGenText.text = "自由组件工作效率".Translate();
            SpShellPowGenText.text = "锚定结构工作效率".Translate();
            SoSailAmoutText.text = "自由组件数量".Translate();
            SoSailPowGenText.text = "工作效率".Translate();
            SoSailLifeTimeText.text = "自由组件寿命分布".Translate();
            SoSailLifeTimeBarText.text = "自由组件状态统计".Translate();
            LyPowGenText.text = "工作效率".Translate();
            NdPowGenText.text = "工作效率".Translate();
            FrPowGenText.text = "工作效率".Translate();
            ShPowGenText.text = "工作效率".Translate();

            //初始化按钮等显示
            set2DysonButtonTextTrans.GetComponent<Text>().text = "规划".Translate() + "戴森球jinx".Translate();
            set2MatDecomButtonTextTrans.GetComponent<Text>().text = "规划".Translate() + "物质解压器".Translate();
            set2SciNexusButtonTextTrans.GetComponent<Text>().text = "规划".Translate() + "科学枢纽".Translate();
            set2WarpFieldGenButtonTextTrans.GetComponent<Text>().text = "规划".Translate() + "折跃场广播阵列".Translate();//WarpFieldBroadcastArray
            set2MegaAssemButtonTextTrans.GetComponent<Text>().text = "规划".Translate() + "星际组装厂".Translate();//生产多功能预制件
            set2CrystalMinerButtonTextTrans.GetComponent<Text>().text = "规划".Translate() + "晶体重构器".Translate();
            SetMegaStructureWarningText.text = "";

            set2DysonButtonTextTrans.GetComponent<Text>().color = normalTextColor;
            set2MatDecomButtonTextTrans.GetComponent<Text>().color = normalTextColor;
            set2SciNexusButtonTextTrans.GetComponent<Text>().color = normalTextColor;
            set2WarpFieldGenButtonTextTrans.GetComponent<Text>().color = normalTextColor;
            set2MegaAssemButtonTextTrans.GetComponent<Text>().color = normalTextColor;
            set2CrystalMinerButtonTextTrans.GetComponent<Text>().color = normalTextColor;

            //根据当前恒星和巨构的状态修正显示
            int curtype = StarMegaStructureType[idx];
            RightDysonTitle.text = "巨构建筑".Translate() + " " + star.displayName;

            if (star.type != EStarType.BlackHole)
            {
                set2MatDecomButtonTextTrans.GetComponent<Text>().color = disableTextColor;
            }
            if (star.type != EStarType.NeutronStar && star.type != EStarType.WhiteDwarf)
            {
                set2CrystalMinerButtonTextTrans.GetComponent<Text>().color = disableTextColor;
            }
            WarpBuiltStarIndex = CheckWarpArrayBuilt();
            if (WarpBuiltStarIndex >= 0)
            {
                set2WarpFieldGenButtonTextTrans.GetComponent<Text>().color = disableTextColor;
            }

            switch (curtype)
            {
                case 0:
                    RightDysonTitle.text = "戴森球jinx".Translate() + " " + star.displayName;
                    set2DysonButtonTextTrans.GetComponent<Text>().color = currentTextColor;
                    set2DysonButtonTextTrans.GetComponent<Text>().text = "当前".Translate() + " " + "戴森球jinx".Translate();
                    break;
                case 1:
                    RightDysonTitle.text = "物质解压器".Translate() + " " + star.displayName;
                    set2MatDecomButtonTextTrans.GetComponent<Text>().color = currentTextColor;
                    set2MatDecomButtonTextTrans.GetComponent<Text>().text = "当前".Translate() + " " + "物质解压器".Translate();
                    break;
                case 2:
                    RightDysonTitle.text = "科学枢纽".Translate() + " " + star.displayName;
                    set2SciNexusButtonTextTrans.GetComponent<Text>().color = currentTextColor;
                    set2SciNexusButtonTextTrans.GetComponent<Text>().text = "当前".Translate() + " " + "科学枢纽".Translate();
                    RightMaxPowGenText.text = "研究效率".Translate();
                    
                    break;
                case 3:
                    RightDysonTitle.text = "折跃场广播阵列".Translate() + " " + star.displayName;
                    set2WarpFieldGenButtonTextTrans.GetComponent<Text>().color = currentTextColor;
                    set2WarpFieldGenButtonTextTrans.GetComponent<Text>().text = "当前".Translate() + " " + "折跃场广播阵列".Translate();
                    RightMaxPowGenText.text = "折跃场加速".Translate();
                    break;
                case 4:
                    RightDysonTitle.text = "星际组装厂".Translate() + " " + star.displayName;
                    set2MegaAssemButtonTextTrans.GetComponent<Text>().color = currentTextColor;
                    set2MegaAssemButtonTextTrans.GetComponent<Text>().text = "当前".Translate() + " " + "星际组装厂".Translate();
                    break;
                case 5:
                    RightDysonTitle.text = "晶体重构器".Translate() + " " + star.displayName;
                    set2CrystalMinerButtonTextTrans.GetComponent<Text>().color = currentTextColor;
                    set2CrystalMinerButtonTextTrans.GetComponent<Text>().text = "当前".Translate() + " " + "晶体重构器".Translate();
                    break;
                default:
                    break;
            }


        }

        /// <summary>
        /// 尝试设置或改变巨构建筑的类型
        /// </summary>
        /// <param name="type"></param>
        public static void SetMegaStructure(int type)
        {
            try
            {
                int idx = curStar.id - 1;

                //没改变类型，无效操作
                if (type == StarMegaStructureType[idx])
                {
                    return;
                }

                //根据是否有现存框架，是否允许改变巨构类型
                if (curDysonSphere != null)
                {
                    if (curDysonSphere.totalNodeCount > 0) //如果有框架，则不允许修改巨构类型，在后续的UI刷新时对应修改按钮状态和文本
                    {
                        SetMegaStructureWarningText.text = "警告先拆除".Translate();
                        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!开发者专用 记得还原return;!!!!!!!!!!!!!!!!!!!
                        return;
                        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

                    }
                }
                else
                {
                    Debug.LogWarning("Can change type because of null refrence.");
                }

                //各种不满足条件不能修改巨构类型的情况
                if (type == 1 && curStar.type != EStarType.BlackHole)
                {
                    SetMegaStructureWarningText.text = "警告仅黑洞".Translate();
                    return;
                }
                if (type == 3 && WarpBuiltStarIndex >= 0)
                {
                    string systemName = GameMain.galaxy.stars[WarpBuiltStarIndex].displayName;
                    SetMegaStructureWarningText.text = "警告最多一个".Translate() + " " + systemName;
                    return;
                }
                if (type == 5 && curStar.type != EStarType.NeutronStar && curStar.type != EStarType.WhiteDwarf)
                {
                    SetMegaStructureWarningText.text = "警告仅中子星白矮星".Translate();
                    return;
                }

                //条件满足
                StarMegaStructureType[idx] = type;
                RefreshUILabels(curStar);
            }
            catch (Exception)
            {
                SetMegaStructureWarningText.text = "警告未知错误".Translate();
                return;
            }
            
        }

        //每秒刷新巨构UI的总Capacity数值的显示，主要用于科学枢纽和广播阵列（这两个不需要接收器）显示其效率
        [HarmonyPostfix]
        [HarmonyPatch(typeof(UIDEOverview), "_OnUpdate")]
        public static void UIValueUpdate()
        {
            try
            {
                if (StarMegaStructureType[curDysonSphere.starData.id - 1] == 2)//如果是科学枢纽
                {
                    long baseSpeed = (curDysonSphere.energyGenCurrentTick - curDysonSphere.energyReqCurrentTick) / HashGenDivisor * 60L;
                    RightMaxPowGenValueText.text = Capacity2Str(baseSpeed * GameMain.history.techSpeed) + "H/s";
                }
                else if (StarMegaStructureType[curDysonSphere.starData.id - 1] == 3)//如果是折跃场广播阵列
                {
                    long DysonEnergy = (curDysonSphere.energyGenCurrentTick - curDysonSphere.energyReqCurrentTick) / WarpAccDivisor;
                    DysonEnergy = DysonEnergy > WarpAccMax ? WarpAccMax : DysonEnergy;
                    RightMaxPowGenValueText.text = Capacity2SpeedAcc((int)DysonEnergy) + "ly/s";
                }
            }
            catch (Exception)
            {
                Debug.LogWarning("Unable to edit the DysonUI's PowerGen Value.");
            }
        }

        //查看折跃场广播阵列是否达到建造上限
        public static int CheckWarpArrayBuilt()
        {
            for (int i = 0; i < 200; i++) //应该是1000，但是考虑到一般不会有人用恒星数超过200的mod吧？
            {
                if (StarMegaStructureType[i] == 3)
                    return i;
            }
            return -1;
        }



        //下面两个prefix+postfix联合作用。由于新版游戏实际执行的能量消耗、采集速率等属性都使用映射到的modelProto的prefabDesc中的数值，而不是itemProto的PrefabDesc，而修改/新增modelProto我还不会改，会报错（貌似是和模型读取不到有关）
        //因此，提前修改设定建筑信息时读取的PrefabDesc的信息，在存储建筑属性前先修改一下（改成itemProto的PrefabDesc中对应的某些值），建造建筑设定完成后再改回去
        //并且，原始item和model执向的貌似是同一个PrefabDesc，所以不能直接改model的，然后再还原成oriItem的prefabDesc，因为改了model的oriItem的也变了，还原不回去了。所以得Copy一个出来改。
        [HarmonyPrefix]
        [HarmonyPatch(typeof(PlanetFactory), "AddEntityDataWithComponents")]
        public static bool AddEntityDataPrePatch(EntityData entity, ref PrefabDesc __state)
        {
            int gmProtoId = entity.protoId;
            if ((gmProtoId < 9493 || gmProtoId > 9499) && gmProtoId != 2208 && gmProtoId != 9501 && gmProtoId != 9502)
            {
                __state = null;
                return true;//不相关建筑直接返回
            }
            ItemProto itemProto = LDB.items.Select((int)entity.protoId);
            if (itemProto == null || !itemProto.IsEntity)
            {
                __state = null;
                return true;
            }

            ModelProto modelProto = LDB.models.Select((int)entity.modelIndex);
            __state = modelProto.prefabDesc;
            modelProto.prefabDesc = __state.Copy();
            modelProto.prefabDesc.powerProductId = itemProto.prefabDesc.powerProductId;
            modelProto.prefabDesc.powerProductHeat = itemProto.prefabDesc.powerProductHeat;
            //modelProto.prefabDesc.ejectorBulletId = itemProto.prefabDesc.ejectorBulletId;
            //modelProto.prefabDesc.siloBulletId = itemProto.prefabDesc.siloBulletId;
            return true;
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(PlanetFactory), "AddEntityDataWithComponents")]
        public static void AddEntityDataPostPatch(EntityData entity, ref PrefabDesc __state)
        {
            if (__state == null)
            {
                return;
            }
            int gmProtoId = entity.protoId;
            if ((gmProtoId < 9493 || gmProtoId > 9499) && gmProtoId != 2208 && gmProtoId != 9501 && gmProtoId != 9502)
            {
                return;//不相关
            }

            ModelProto modelProto = LDB.models.Select((int)entity.modelIndex);
            modelProto.prefabDesc = __state;//还原
            return;
        }


        /// <summary>
        /// Save and Load
        /// </summary>
        /// <param name="r"></param>
        public void Import(BinaryReader r)
        {
            try
            {
                curStar = null;
                curDysonSphere = null;
                int savedModVersion = r.ReadInt32();
                for (int i = 0; i < 1000; i++)
                {
                    StarMegaStructureType[i] = r.ReadInt32();
                }

            }
            catch (Exception)
            {
                IntoOtherSave();
            }
        }

        public void Export(BinaryWriter w)
        {
            w.Write(modVersion);
            for (int i = 0; i < 1000; i++)
            {
                w.Write(StarMegaStructureType[i]);
            }
        }
        public void IntoOtherSave()
        {
            for (int i = 0; i < 1000; i++)
            {
                StarMegaStructureType[i] = 0;
            }
            // Initialize here. This method will only be called if there is no saved data.
        }

        public static string Capacity2Str(long capacityPerSecond)
        {
            long midValue;
            string unitStr = "";
            if (capacityPerSecond >= 1000000000000000000)
            {
                midValue = capacityPerSecond / 1000000000000000;
                //return (midValue / 1000.0).ToString("G3") + " E";
                unitStr = " E";
            }
            else if (capacityPerSecond >= 1000000000000000)
            {
                midValue = capacityPerSecond / 1000000000000;
                //return (midValue / 1000.0).ToString("G3") + " P";
                unitStr = " P";
            }
            else if(capacityPerSecond >= 1000000000000)
            {
                midValue = capacityPerSecond / 1000000000;
                //return (midValue / 1000.0).ToString("G3") + " T";
                unitStr = " T";
            }
            else if(capacityPerSecond >= 1000000000)
            {
                midValue = capacityPerSecond / 1000000;
                //return (midValue / 1000.0).ToString("G3") + " G";
                unitStr = " G";
            }
            else if(capacityPerSecond >= 1000000)
            {
                midValue = capacityPerSecond / 1000;
                //return (midValue / 1000.0).ToString("G3") + " M";
                unitStr = " M";
            }
            else if (capacityPerSecond >= 1000)
            {
                midValue = capacityPerSecond;
                //return (midValue / 1000.0).ToString("G3") + " k";
                unitStr = " k";
            }
            else
            {
                return (capacityPerSecond.ToString() + " ");
            }

            if(midValue >= 100000)
            {
                return (midValue / 1000).ToString() + unitStr;
            }
            else if(midValue >= 10000)
            {
                return ((midValue / 100) / 10.0).ToString() + unitStr;
            }
            else
            {
                return ((midValue / 10) / 100.0).ToString() + unitStr;
            }
        }


        public static string Capacity2SpeedAcc(int ratio)
        {
            return (ratio * 0.05).ToString("G3") + " ";
        }



    }


    /// 以下为创世之书特别适配用
    [BepInDependency("org.LoShin.GenesisBook", BepInDependency.DependencyFlags.HardDependency)]
    [BepInPlugin("Gnimaerd.DSP.plugin.MMSGCPatch", "MMSGCPatch", "1.0")]
    [CommonAPISubmoduleDependency(nameof(ProtoRegistry), nameof(TabSystem))]
    public class GenesisCompatibilityPatch : BaseUnityPlugin
    {
        void Awake()
        {
            if (MoreMegaStructure.CompatibilityPatchUnlocked)
            {
                MoreMegaStructure.GenesisCompatibility = true;
            }
        }
    }

}