﻿using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xiaoye97;
using CommonAPI;
using CommonAPI.Systems;
using UnityEngine;

namespace MoreMegaStructure
{
    //[CommonAPISubmoduleDependency(nameof(ProtoRegistry))]
    class MMSProtos
    {

        public static void ItemsDesc()
        {
            //简单地用临界光子轰击奇异物质即可激发引力波，但这也意味着只有在恒星附近才能使引力发生装置高效运行。
            //借助黑洞本身的引力，引力钻头能够将物质从黑洞中取出，这还包括吸积盘中大量的单极磁石。借助谐振盘，黑洞原质将能够被解压并在星系内输送。
            //将临界光子沿变频设备向中子星或白矮星发射，从而向地表引导规模庞大的微晶流。微晶流中的可控中子直接在合成器中部分地进行β衰变，即可直接形成稳定且完美的卡西米尔晶体。
            //位面约束环能够协同引力透镜引导并操纵引力，也是构建科学枢纽所需的恒星级粒子加速器的必要组件。
            //隧穿激发装置可以完美地掌控量子隧穿效应，常被用来强化量子芯片的处理能力和纠错能力。通过量子隧穿效应还能够轻易突破弯曲空间的能量势垒，使得在任意远的空间打开裂口成为可能。
            //谐振盘仅通过恒星级别的能量就可以产生跨越恒星系的空间波动能量束。如果将谐振盘组成阵列，理论上可以形成覆盖全宇宙的折跃能量场。
            //只要供给足够的能量，量子计算机的单线程运算时钟能够无限逼近普朗克时间，通过量子比特协同，其潜在的单线程运算速率还能突破物理极限，并可以无限提升。现在，限制其计算效率的将只有能量输入水平。
        }


        public static void AddNewItems()
        {
            int pagePlus = MoreMegaStructure.pagenum * 1000;

            var oriRecipe = LDB.recipes.Select(51);
            var oriItem = LDB.items.Select(1303);

            //引力发生装置
            var itemGravityGenRecipe = oriRecipe.Copy();
            var itemGravityGen = oriItem.Copy();
            itemGravityGenRecipe.ID = 530;
            itemGravityGenRecipe.Name = "引力发生装置";
            itemGravityGenRecipe.name = "引力发生装置".Translate();
            itemGravityGenRecipe.Description = "引力发生装置描述";
            itemGravityGenRecipe.description = "引力发生装置描述".Translate();
            itemGravityGenRecipe.Items = new int[] { 1107, 1127 };
            itemGravityGenRecipe.ItemCounts = new int[] { 1, 1 };
            itemGravityGenRecipe.Results = new int[] { 9480 };
            itemGravityGenRecipe.ResultCounts = new int[] { 1 };
            itemGravityGenRecipe.TimeSpend = 180;
            itemGravityGenRecipe.GridIndex = 101 + pagePlus;
            itemGravityGenRecipe.preTech = LDB.techs.Select(1704);
            Traverse.Create(itemGravityGenRecipe).Field("_iconSprite").SetValue(MoreMegaStructure.iconGravityGen);
            //Traverse.Create(itemGravityGenRecipe).Field("_iconSprite").SetValue(Resources.Load<Sprite>("Assets/MegaStructureTab/gravitygenerator"));
            //ProtoRegistry.RegisterItem(9480, "引力发生装置".Translate(), "引力发生装置描述".Translate(), "Assets/MegaStructureTab/gravitygenerator",101+pagePlus,50,EItemType.Component);
            
            itemGravityGen.ID = 9480;
            itemGravityGen.Name = "引力发生装置";
            itemGravityGen.name = "引力发生装置".Translate();
            itemGravityGen.Description = "引力发生装置描述";
            itemGravityGen.description = "引力发生装置描述".Translate();
            itemGravityGen.GridIndex = 101 + pagePlus;
            itemGravityGen.prefabDesc = oriItem.prefabDesc.Copy(); //
            itemGravityGen.handcraft = itemGravityGenRecipe; //
            itemGravityGen.maincraft = itemGravityGenRecipe; //
            itemGravityGen.handcrafts = new List<RecipeProto> { itemGravityGenRecipe }; //
            itemGravityGen.recipes = new List<RecipeProto> { itemGravityGenRecipe }; //
            Traverse.Create(itemGravityGen).Field("_iconSprite").SetValue(MoreMegaStructure.iconGravityGen);
            
            //位面约束环
            var itemConstrainRingRecipe = oriRecipe.Copy();
            var itemConstrainRing = oriItem.Copy();
            itemConstrainRingRecipe.ID = 531;
            itemConstrainRingRecipe.Name = "位面约束环";
            itemConstrainRingRecipe.name = "位面约束环".Translate();
            itemConstrainRingRecipe.Description = "位面约束环描述";
            itemConstrainRingRecipe.description = "位面约束环描述".Translate();
            itemConstrainRingRecipe.Items = new int[] { 1205, 1304 };
            itemConstrainRingRecipe.ItemCounts = new int[] { 2, 1 };
            itemConstrainRingRecipe.Results = new int[] { 9481 };
            itemConstrainRingRecipe.ResultCounts = new int[] { 2 };
            itemConstrainRingRecipe.TimeSpend = 180;
            itemConstrainRingRecipe.GridIndex = 102 + pagePlus;
            itemConstrainRingRecipe.preTech = LDB.techs.Select(1141);
            Traverse.Create(itemConstrainRingRecipe).Field("_iconSprite").SetValue(MoreMegaStructure.iconConstrainRing);
            itemConstrainRing.ID = 9481;
            itemConstrainRing.Name = "位面约束环";
            itemConstrainRing.name = "位面约束环".Translate();
            itemConstrainRing.Description = "位面约束环描述";
            itemConstrainRing.description = "位面约束环描述".Translate();
            itemConstrainRing.GridIndex = 102 + pagePlus;
            itemConstrainRing.prefabDesc = oriItem.prefabDesc.Copy(); //
            itemConstrainRing.handcraft = itemConstrainRingRecipe; //
            itemConstrainRing.maincraft = itemConstrainRingRecipe; //
            itemConstrainRing.handcrafts = new List<RecipeProto> { itemConstrainRingRecipe }; //
            itemConstrainRing.recipes = new List<RecipeProto> { itemConstrainRingRecipe }; //
            Traverse.Create(itemConstrainRing).Field("_iconSprite").SetValue(MoreMegaStructure.iconConstrainRing);
            //引力钻头
            var itemGravityDrillRecipe = oriRecipe.Copy();
            var itemGravityDrill = oriItem.Copy();
            itemGravityDrillRecipe.ID = 532;
            itemGravityDrillRecipe.Name = "引力钻头";
            itemGravityDrillRecipe.name = "引力钻头".Translate();
            itemGravityDrillRecipe.Description = "引力钻头描述";
            itemGravityDrillRecipe.description = "引力钻头描述".Translate();
            itemGravityDrillRecipe.Items = new int[] { 9480, 9481, 1209 };
            itemGravityDrillRecipe.ItemCounts = new int[] { 1, 1, 1 };
            itemGravityDrillRecipe.Results = new int[] { 9482 };
            itemGravityDrillRecipe.ResultCounts = new int[] { 1 };
            itemGravityDrillRecipe.TimeSpend = 180;
            itemGravityDrillRecipe.GridIndex = 103 + pagePlus;
            itemGravityDrillRecipe.preTech = LDB.techs.Select(1704);
            Traverse.Create(itemGravityDrillRecipe).Field("_iconSprite").SetValue(MoreMegaStructure.iconGravityDrill);
            itemGravityDrill.ID = 9482;
            itemGravityDrill.Name = "引力钻头";
            itemGravityDrill.name = "引力钻头".Translate();
            itemGravityDrill.Description = "引力钻头描述";
            itemGravityDrill.description = "引力钻头描述".Translate();
            itemGravityDrill.GridIndex = 103 + pagePlus;
            itemGravityDrill.StackSize = 20;
            itemGravityDrill.prefabDesc = oriItem.prefabDesc.Copy(); //
            itemGravityDrill.handcraft = itemGravityDrillRecipe; //
            itemGravityDrill.maincraft = itemGravityDrillRecipe; //
            itemGravityDrill.handcrafts = new List<RecipeProto> { itemGravityDrillRecipe }; //
            itemGravityDrill.recipes = new List<RecipeProto> { itemGravityDrillRecipe }; //
            Traverse.Create(itemGravityDrill).Field("_iconSprite").SetValue(MoreMegaStructure.iconGravityDrill);
            //隧穿激发装置
            var itemExciterRecipe = oriRecipe.Copy();
            var itemExciter = oriItem.Copy();
            itemExciterRecipe.ID = 533;
            itemExciterRecipe.Name = "隧穿激发装置";
            itemExciterRecipe.name = "隧穿激发装置".Translate();
            itemExciterRecipe.Description = "隧穿激发装置描述";
            itemExciterRecipe.description = "隧穿激发装置描述".Translate();
            itemExciterRecipe.Items = new int[] { 1206, 1404 };
            itemExciterRecipe.ItemCounts = new int[] { 1, 1 };
            itemExciterRecipe.Results = new int[] { 9483 };
            itemExciterRecipe.ResultCounts = new int[] { 6 };
            itemExciterRecipe.TimeSpend = 360;
            itemExciterRecipe.GridIndex = 104 + pagePlus;
            itemExciterRecipe.preTech = LDB.techs.Select(1703);
            Traverse.Create(itemExciterRecipe).Field("_iconSprite").SetValue(MoreMegaStructure.iconTunnExciter);
            itemExciter.ID = 9483;
            itemExciter.Name = "隧穿激发装置";
            itemExciter.name = "隧穿激发装置".Translate();
            itemExciter.Description = "隧穿激发装置描述";
            itemExciter.description = "隧穿激发装置描述".Translate();
            itemExciter.GridIndex = 104 + pagePlus;
            itemExciter.prefabDesc = oriItem.prefabDesc.Copy(); //
            itemExciter.handcraft = itemExciterRecipe; //
            itemExciter.maincraft = itemExciterRecipe; //
            itemExciter.handcrafts = new List<RecipeProto> { itemExciterRecipe }; //
            itemExciter.recipes = new List<RecipeProto> { itemExciterRecipe }; //
            Traverse.Create(itemExciter).Field("_iconSprite").SetValue(MoreMegaStructure.iconTunnExciter);
            //谐振盘
            var itemDiscRecipe = oriRecipe.Copy();
            var itemDisc = oriItem.Copy();
            itemDiscRecipe.ID = 534;
            itemDiscRecipe.Name = "谐振盘";
            itemDiscRecipe.name = "谐振盘".Translate();
            itemDiscRecipe.Description = "谐振盘描述";
            itemDiscRecipe.description = "谐振盘描述".Translate();
            itemDiscRecipe.Items = new int[] { 9483, 1113, 1305 };
            itemDiscRecipe.ItemCounts = new int[] { 3, 2, 1 };
            itemDiscRecipe.Results = new int[] { 9484 };
            itemDiscRecipe.ResultCounts = new int[] { 1 };
            itemDiscRecipe.TimeSpend = 240;
            itemDiscRecipe.GridIndex = 105 + pagePlus;
            itemDiscRecipe.preTech = LDB.techs.Select(1303);
            Traverse.Create(itemDiscRecipe).Field("_iconSprite").SetValue(MoreMegaStructure.iconResDisc);
            itemDisc.ID = 9484;
            itemDisc.Name = "谐振盘";
            itemDisc.name = "谐振盘".Translate();
            itemDisc.Description = "谐振盘描述";
            itemDisc.description = "谐振盘描述".Translate();
            itemDisc.GridIndex = 105 + pagePlus;
            itemDisc.prefabDesc = oriItem.prefabDesc.Copy(); //
            itemDisc.handcraft = itemDiscRecipe; //
            itemDisc.maincraft = itemDiscRecipe; //
            itemDisc.handcrafts = new List<RecipeProto> { itemDiscRecipe }; //
            itemDisc.recipes = new List<RecipeProto> { itemDiscRecipe }; //
            Traverse.Create(itemDisc).Field("_iconSprite").SetValue(MoreMegaStructure.iconResDisc);
            //光子探针
            var itemProbeRecipe = oriRecipe.Copy();
            var itemProbe = oriItem.Copy();
            itemProbeRecipe.ID = 535;
            itemProbeRecipe.Name = "光子探针";
            itemProbeRecipe.name = "光子探针".Translate();
            itemProbeRecipe.Description = "光子探针描述";
            itemProbeRecipe.description = "光子探针描述".Translate();
            itemProbeRecipe.Items = new int[] { 1404, 1208 };
            itemProbeRecipe.ItemCounts = new int[] { 2, 1 };
            itemProbeRecipe.Results = new int[] { 9485 };
            itemProbeRecipe.ResultCounts = new int[] { 1 };
            itemProbeRecipe.TimeSpend = 240;
            itemProbeRecipe.GridIndex = 106 + pagePlus;
            itemProbeRecipe.preTech = LDB.techs.Select(1504); //射线接收站的科技
            Traverse.Create(itemProbeRecipe).Field("_iconSprite").SetValue(MoreMegaStructure.iconPhotonProbe);
            itemProbe.ID = 9485;
            itemProbe.Name = "光子探针";
            itemProbe.name = "光子探针".Translate();
            itemProbe.Description = "光子探针描述";
            itemProbe.description = "光子探针描述".Translate();
            itemProbe.GridIndex = 106 + pagePlus;
            itemProbe.prefabDesc = oriItem.prefabDesc.Copy(); //
            itemProbe.handcraft = itemProbeRecipe; //
            itemProbe.maincraft = itemProbeRecipe; //
            itemProbe.handcrafts = new List<RecipeProto> { itemProbeRecipe }; //
            itemProbe.recipes = new List<RecipeProto> { itemProbeRecipe }; //
            Traverse.Create(itemProbe).Field("_iconSprite").SetValue(MoreMegaStructure.iconPhotonProbe);

            //量子计算机
            var itemQuanCompRecipe = oriRecipe.Copy();
            var itemQuanComp = oriItem.Copy();
            itemQuanCompRecipe.ID = 536;
            itemQuanCompRecipe.Name = "量子计算机";
            itemQuanCompRecipe.name = "量子计算机".Translate();
            itemQuanCompRecipe.Description = "量子计算机描述";
            itemQuanCompRecipe.description = "量子计算机描述".Translate();
            itemQuanCompRecipe.Items = new int[] { 1305, 1402, 9483 };
            itemQuanCompRecipe.ItemCounts = new int[] { 3, 2, 1 };
            itemQuanCompRecipe.Results = new int[] { 9486 };
            itemQuanCompRecipe.ResultCounts = new int[] { 1 };
            itemQuanCompRecipe.TimeSpend = 720;
            itemQuanCompRecipe.GridIndex = 107 + pagePlus;
            itemQuanCompRecipe.preTech = LDB.techs.Select(1303);
            Traverse.Create(itemQuanCompRecipe).Field("_iconSprite").SetValue(MoreMegaStructure.iconQuanComp);
            itemQuanComp.ID = 9486;
            itemQuanComp.Name = "量子计算机";
            itemQuanComp.name = "量子计算机".Translate();
            itemQuanComp.Description = "量子计算机描述";
            itemQuanComp.description = "量子计算机描述".Translate();
            itemQuanComp.GridIndex = 107 + pagePlus;
            itemQuanComp.StackSize = 50;
            itemQuanComp.prefabDesc = oriItem.prefabDesc.Copy(); //
            itemQuanComp.handcraft = itemQuanCompRecipe; //
            itemQuanComp.maincraft = itemQuanCompRecipe; //
            itemQuanComp.handcrafts = new List<RecipeProto> { itemQuanCompRecipe }; //
            itemQuanComp.recipes = new List<RecipeProto> { itemQuanCompRecipe }; //
            Traverse.Create(itemQuanComp).Field("_iconSprite").SetValue(MoreMegaStructure.iconQuanComp);
            //星际组装厂组件
            var itemIACompoRecipe = oriRecipe.Copy();
            var itemIACompo = oriItem.Copy();
            itemIACompoRecipe.ID = 537;
            itemIACompoRecipe.Name = "星际组装厂组件";
            itemIACompoRecipe.name = "星际组装厂组件".Translate();
            itemIACompoRecipe.Description = "星际组装厂组件描述";
            itemIACompoRecipe.description = "星际组装厂组件描述".Translate();
            itemIACompoRecipe.Items = new int[] { 1125, 2305, 1143 };
            itemIACompoRecipe.ItemCounts = new int[] { 3, 3, 1 };
            itemIACompoRecipe.Results = new int[] { 9487 };
            itemIACompoRecipe.ResultCounts = new int[] { 1 };
            itemIACompoRecipe.TimeSpend = 480;
            itemIACompoRecipe.GridIndex = 108 + pagePlus;
            itemIACompoRecipe.preTech = LDB.techs.Select(1303);
            Traverse.Create(itemIACompoRecipe).Field("_iconSprite").SetValue(MoreMegaStructure.iconIACompo);
            itemIACompo.ID = 9487;
            itemIACompo.Name = "星际组装厂组件";
            itemIACompo.name = "星际组装厂组件".Translate();
            itemIACompo.Description = "星际组装厂组件描述";
            itemIACompo.description = "星际组装厂组件描述".Translate();
            itemIACompo.GridIndex = 108 + pagePlus;
            itemIACompo.StackSize = 100;
            itemIACompo.prefabDesc = oriItem.prefabDesc.Copy(); //
            itemIACompo.handcraft = itemIACompoRecipe; //
            itemIACompo.maincraft = itemIACompoRecipe; //
            itemIACompo.handcrafts = new List<RecipeProto> { itemIACompoRecipe }; //
            itemIACompo.recipes = new List<RecipeProto> { itemIACompoRecipe }; //
            Traverse.Create(itemIACompo).Field("_iconSprite").SetValue(MoreMegaStructure.iconIACompo);

            //下面是火箭
            var oriRecipe2 = LDB.recipes.Select(83);
            var oriItem2 = LDB.items.Select(1503);
            //物质解压器运载火箭
            var rocketMDRecipe = oriRecipe2.Copy();
            var rocketMD = oriItem2.Copy();
            rocketMDRecipe.ID = 538;
            rocketMDRecipe.Name = "物质解压器运载火箭";
            rocketMDRecipe.name = "物质解压器运载火箭".Translate();
            rocketMDRecipe.Description = "物质解压器运载火箭描述";
            rocketMDRecipe.description = "物质解压器运载火箭描述".Translate();
            rocketMDRecipe.Items = new int[] { 9482, 9484, 1802 };
            rocketMDRecipe.ItemCounts = new int[] { 2, 1, 2 };
            rocketMDRecipe.Results = new int[] { 9488 };
            rocketMDRecipe.ResultCounts = new int[] { 1 };
            rocketMDRecipe.TimeSpend = 480;
            rocketMDRecipe.GridIndex = 201 + pagePlus;
            rocketMDRecipe.preTech = LDB.techs.Select(1522); //垂直发射井科技
            Traverse.Create(rocketMDRecipe).Field("_iconSprite").SetValue(MoreMegaStructure.iconRocketMattD);
            rocketMD.ID = 9488;
            rocketMD.Name = "物质解压器运载火箭";
            rocketMD.name = "物质解压器运载火箭".Translate();
            rocketMD.Description = "物质解压器运载火箭描述";
            rocketMD.description = "物质解压器运载火箭描述".Translate();
            rocketMD.GridIndex = 201 + pagePlus;
            rocketMD.prefabDesc = oriItem2.prefabDesc.Copy(); //
            rocketMD.handcraft = rocketMDRecipe; //
            rocketMD.maincraft = rocketMDRecipe; //
            rocketMD.handcrafts = new List<RecipeProto> { rocketMDRecipe }; //
            rocketMD.recipes = new List<RecipeProto> { rocketMDRecipe }; //
            Traverse.Create(rocketMD).Field("_iconSprite").SetValue(MoreMegaStructure.iconRocketMattD);
            //科学枢纽运载火箭
            var rocketSNRecipe = oriRecipe2.Copy();
            var rocketSN = oriItem2.Copy();
            rocketSNRecipe.ID = 539;
            rocketSNRecipe.Name = "科学枢纽运载火箭";
            rocketSNRecipe.name = "科学枢纽运载火箭".Translate();
            rocketSNRecipe.Description = "科学枢纽运载火箭描述";
            rocketSNRecipe.description = "科学枢纽运载火箭描述".Translate();
            rocketSNRecipe.Items = new int[] { 9481, 9486, 1802 };
            rocketSNRecipe.ItemCounts = new int[] { 3, 1, 2 };
            rocketSNRecipe.Results = new int[] { 9489 };
            rocketSNRecipe.ResultCounts = new int[] { 1 };
            rocketSNRecipe.TimeSpend = 480;
            rocketSNRecipe.GridIndex = 202 + pagePlus;
            rocketSNRecipe.preTech = LDB.techs.Select(1522); //垂直发射井科技
            Traverse.Create(rocketSNRecipe).Field("_iconSprite").SetValue(MoreMegaStructure.iconRocketScieN);
            rocketSN.ID = 9489;
            rocketSN.Name = "科学枢纽运载火箭";
            rocketSN.name = "科学枢纽运载火箭".Translate();
            rocketSN.Description = "科学枢纽运载火箭描述";
            rocketSN.description = "科学枢纽运载火箭描述".Translate();
            rocketSN.GridIndex = 202 + pagePlus;
            rocketSN.prefabDesc = oriItem2.prefabDesc.Copy(); //
            rocketSN.handcraft = rocketSNRecipe; //
            rocketSN.maincraft = rocketSNRecipe; //
            rocketSN.handcrafts = new List<RecipeProto> { rocketSNRecipe }; //
            rocketSN.recipes = new List<RecipeProto> { rocketSNRecipe }; //
            Traverse.Create(rocketSN).Field("_iconSprite").SetValue(MoreMegaStructure.iconRocketScieN);
            //谐振发射器运载火箭
            var rocketWBARecipe = oriRecipe2.Copy();
            var rocketWBA = oriItem2.Copy();
            rocketWBARecipe.ID = 540;
            rocketWBARecipe.Name = "谐振发射器运载火箭";
            rocketWBARecipe.name = "谐振发射器运载火箭".Translate();
            rocketWBARecipe.Description = "谐振发射器运载火箭描述";
            rocketWBARecipe.description = "谐振发射器运载火箭描述".Translate();
            rocketWBARecipe.Items = new int[] { 9480, 9484, 1802 };
            rocketWBARecipe.ItemCounts = new int[] { 1, 4, 2 };
            rocketWBARecipe.Results = new int[] { 9490 };
            rocketWBARecipe.ResultCounts = new int[] { 1 };
            rocketWBARecipe.TimeSpend = 480;
            rocketWBARecipe.GridIndex = 203 + pagePlus;
            rocketWBARecipe.preTech = LDB.techs.Select(1522); //垂直发射井科技
            Traverse.Create(rocketWBARecipe).Field("_iconSprite").SetValue(MoreMegaStructure.iconRocketWarpG);
            rocketWBA.ID = 9490;
            rocketWBA.Name = "谐振发射器运载火箭";
            rocketWBA.name = "谐振发射器运载火箭".Translate();
            rocketWBA.Description = "谐振发射器运载火箭描述";
            rocketWBA.description = "谐振发射器运载火箭描述".Translate();
            rocketWBA.GridIndex = 203 + pagePlus;
            rocketWBA.prefabDesc = oriItem2.prefabDesc.Copy(); //
            rocketWBA.handcraft = rocketWBARecipe; //
            rocketWBA.maincraft = rocketWBARecipe; //
            rocketWBA.handcrafts = new List<RecipeProto> { rocketWBARecipe }; //
            rocketWBA.recipes = new List<RecipeProto> { rocketWBARecipe }; //
            Traverse.Create(rocketWBA).Field("_iconSprite").SetValue(MoreMegaStructure.iconRocketWarpG);
            //星际组装厂运载火箭
            var rocketIARecipe = oriRecipe2.Copy();
            var rocketIA = oriItem2.Copy();
            rocketIARecipe.ID = 541;
            rocketIARecipe.Name = "星际组装厂运载火箭";
            rocketIARecipe.name = "星际组装厂运载火箭".Translate();
            rocketIARecipe.Description = "星际组装厂运载火箭描述";
            rocketIARecipe.description = "星际组装厂运载火箭描述".Translate();
            rocketIARecipe.Items = new int[] { 9487, 1802 };
            rocketIARecipe.ItemCounts = new int[] { 2, 2 };
            rocketIARecipe.Results = new int[] { 9491 };
            rocketIARecipe.ResultCounts = new int[] { 1 };
            rocketIARecipe.TimeSpend = 480;
            rocketIARecipe.GridIndex = 204 + pagePlus;
            rocketIARecipe.preTech = LDB.techs.Select(1522); //垂直发射井科技
            Traverse.Create(rocketIARecipe).Field("_iconSprite").SetValue(MoreMegaStructure.iconRocketMegaA);
            rocketIA.ID = 9491;
            rocketIA.Name = "星际组装厂运载火箭";
            rocketIA.name = "星际组装厂运载火箭".Translate();
            rocketIA.Description = "星际组装厂运载火箭描述";
            rocketIA.description = "星际组装厂运载火箭描述".Translate();
            rocketIA.GridIndex = 204 + pagePlus;
            rocketIA.prefabDesc = oriItem2.prefabDesc.Copy(); //
            rocketIA.handcraft = rocketIARecipe; //
            rocketIA.maincraft = rocketIARecipe; //
            rocketIA.handcrafts = new List<RecipeProto> { rocketIARecipe }; //
            rocketIA.recipes = new List<RecipeProto> { rocketIARecipe }; //
            Traverse.Create(rocketIA).Field("_iconSprite").SetValue(MoreMegaStructure.iconRocketMegaA);
            //晶体重构器运载火箭
            var rocketCRRecipe = oriRecipe2.Copy();
            var rocketCR = oriItem2.Copy();
            rocketCRRecipe.ID = 542;
            rocketCRRecipe.Name = "晶体重构器运载火箭";
            rocketCRRecipe.name = "晶体重构器运载火箭".Translate();
            rocketCRRecipe.Description = "晶体重构器运载火箭描述";
            rocketCRRecipe.description = "晶体重构器运载火箭描述".Translate();
            rocketCRRecipe.Items = new int[] { 9485, 1802, 1305 };
            rocketCRRecipe.ItemCounts = new int[] { 1, 2, 2 };
            rocketCRRecipe.Results = new int[] { 9492 };
            rocketCRRecipe.ResultCounts = new int[] { 1 };
            rocketCRRecipe.TimeSpend = 480;
            rocketCRRecipe.GridIndex = 205 + pagePlus;
            rocketCRRecipe.preTech = LDB.techs.Select(1522); //垂直发射井科技
            Traverse.Create(rocketCRRecipe).Field("_iconSprite").SetValue(MoreMegaStructure.iconRocketCrysM);
            rocketCR.ID = 9492;
            rocketCR.Name = "晶体重构器运载火箭";
            rocketCR.name = "晶体重构器运载火箭".Translate();
            rocketCR.Description = "晶体重构器运载火箭描述";
            rocketCR.description = "晶体重构器运载火箭描述".Translate();
            rocketCR.GridIndex = 205 + pagePlus;
            rocketCR.prefabDesc = oriItem2.prefabDesc.Copy(); //
            rocketCR.handcraft = rocketCRRecipe; //
            rocketCR.maincraft = rocketCRRecipe; //
            rocketCR.handcrafts = new List<RecipeProto> { rocketCRRecipe }; //
            rocketCR.recipes = new List<RecipeProto> { rocketCRRecipe }; //
            Traverse.Create(rocketCR).Field("_iconSprite").SetValue(MoreMegaStructure.iconRocketCrysM);

            //下面是接收器
            var oriRecipe3 = LDB.recipes.Select(41);
            var oriItem3 = LDB.items.Select(2208);
            //Iron
            var ReceiverIronRecipe = oriRecipe3.Copy();
            var ReceiverIron = oriItem3.Copy();
            ReceiverIronRecipe.ID = 543;
            ReceiverIronRecipe.Name = "铁金属重构装置";
            ReceiverIronRecipe.name = "铁金属重构装置".Translate();
            ReceiverIronRecipe.Description = "接收重构装置描述";
            ReceiverIronRecipe.description = "接收重构装置描述".Translate();
            ReceiverIronRecipe.Items = new int[] { 1103, 1404, 1303, 9481 };
            ReceiverIronRecipe.ItemCounts = new int[] { 20, 10, 5, 2 };
            ReceiverIronRecipe.Results = new int[] { 9493 };
            ReceiverIronRecipe.ResultCounts = new int[] { 1 };
            ReceiverIronRecipe.GridIndex = 301 + pagePlus;
            ReceiverIronRecipe.TimeSpend = 480;
            Traverse.Create(ReceiverIronRecipe).Field("_iconSprite").SetValue(MoreMegaStructure.iconReceiverIron);
            ReceiverIronRecipe.preTech = LDB.techs.Select(1504); //射线接收站科技
            ReceiverIron.ID = 9493;
            ReceiverIron.Name = "铁金属重构装置";
            ReceiverIron.name = "铁金属重构装置".Translate();
            ReceiverIron.Description = "接收重构装置描述";
            ReceiverIron.description = "接收重构装置描述".Translate();
            ReceiverIron.GridIndex = 301 + pagePlus;
            ReceiverIron.HeatValue = 0L;
            ReceiverIron.prefabDesc = oriItem3.prefabDesc.Copy();
            ReceiverIron.prefabDesc.powerProductHeat = 6000000;
            ReceiverIron.prefabDesc.powerProductId = 1101;
            ReceiverIron.handcraft = ReceiverIronRecipe;
            ReceiverIron.handcrafts = new List<RecipeProto> { ReceiverIronRecipe };
            ReceiverIron.maincraft = ReceiverIronRecipe;
            ReceiverIron.recipes = new List<RecipeProto> { ReceiverIronRecipe };
            //ReceiverIron.makes = new List<RecipeProto> { ReceiverIronRecipe };
            Traverse.Create(ReceiverIron).Field("_iconSprite").SetValue(MoreMegaStructure.iconReceiverIron);
            //Copper
            var ReceiverCopperRecipe = oriRecipe3.Copy();
            var ReceiverCopper = oriItem3.Copy();
            ReceiverCopperRecipe.ID = 544;
            ReceiverCopperRecipe.Name = "铜金属重构装置";
            ReceiverCopperRecipe.name = "铜金属重构装置".Translate();
            ReceiverCopperRecipe.Description = "接收重构装置描述";
            ReceiverCopperRecipe.description = "接收重构装置描述".Translate();
            ReceiverCopperRecipe.Items = new int[] { 1103, 1404, 1303, 9481 };
            ReceiverCopperRecipe.ItemCounts = new int[] { 20, 10, 5, 2 };
            ReceiverCopperRecipe.Results = new int[] { 9494 };
            ReceiverCopperRecipe.ResultCounts = new int[] { 1 };
            ReceiverCopperRecipe.GridIndex = 302 + pagePlus;
            ReceiverCopperRecipe.TimeSpend = 480;
            Traverse.Create(ReceiverCopperRecipe).Field("_iconSprite").SetValue(MoreMegaStructure.iconReceiverCopper);
            ReceiverCopperRecipe.preTech = LDB.techs.Select(1504); //射线接收站科技
            ReceiverCopper.ID = 9494;
            ReceiverCopper.Name = "铜金属重构装置";
            ReceiverCopper.name = "铜金属重构装置".Translate();
            ReceiverCopper.Description = "接收重构装置描述";
            ReceiverCopper.description = "接收重构装置描述".Translate();
            ReceiverCopper.GridIndex = 302 + pagePlus;
            ReceiverCopper.HeatValue = 0L;
            ReceiverCopper.prefabDesc = oriItem3.prefabDesc.Copy();
            ReceiverCopper.prefabDesc.powerProductHeat = 6000000;
            ReceiverCopper.prefabDesc.powerProductId = 1104;
            ReceiverCopper.handcraft = ReceiverCopperRecipe;
            ReceiverCopper.handcrafts = new List<RecipeProto> { ReceiverCopperRecipe };
            ReceiverCopper.maincraft = ReceiverCopperRecipe;
            ReceiverCopper.recipes = new List<RecipeProto> { ReceiverCopperRecipe };
            //ReceiverCopper.makes = new List<RecipeProto> { ReceiverCopperRecipe };
            Traverse.Create(ReceiverCopper).Field("_iconSprite").SetValue(MoreMegaStructure.iconReceiverCopper);
            //Silicon
            var ReceiverSiliconRecipe = oriRecipe3.Copy();
            var ReceiverSilicon = oriItem3.Copy();
            ReceiverSiliconRecipe.ID = 545;
            ReceiverSiliconRecipe.Name = "高纯硅重构装置";
            ReceiverSiliconRecipe.name = "高纯硅重构装置".Translate();
            ReceiverSiliconRecipe.Description = "接收重构装置描述";
            ReceiverSiliconRecipe.description = "接收重构装置描述".Translate();
            ReceiverSiliconRecipe.Items = new int[] { 1103, 1404, 1303, 9481 };
            ReceiverSiliconRecipe.ItemCounts = new int[] { 20, 10, 5, 2 };
            ReceiverSiliconRecipe.Results = new int[] { 9495 };
            ReceiverSiliconRecipe.ResultCounts = new int[] { 1 };
            ReceiverSiliconRecipe.GridIndex = 303 + pagePlus;
            ReceiverSiliconRecipe.TimeSpend = 480;
            Traverse.Create(ReceiverSiliconRecipe).Field("_iconSprite").SetValue(MoreMegaStructure.iconReceiverSilicon);
            ReceiverSiliconRecipe.preTech = LDB.techs.Select(1504); //射线接收站科技
            ReceiverSilicon.ID = 9495;
            ReceiverSilicon.Name = "高纯硅重构装置";
            ReceiverSilicon.name = "高纯硅重构装置".Translate();
            ReceiverSilicon.Description = "接收重构装置描述";
            ReceiverSilicon.description = "接收重构装置描述".Translate();
            ReceiverSilicon.GridIndex = 303 + pagePlus;
            ReceiverSilicon.HeatValue = 0L;
            ReceiverSilicon.prefabDesc = oriItem3.prefabDesc.Copy();
            ReceiverSilicon.prefabDesc.powerProductHeat = 6000000;
            ReceiverSilicon.prefabDesc.powerProductId = 1105;
            ReceiverSilicon.handcraft = ReceiverSiliconRecipe;
            ReceiverSilicon.handcrafts = new List<RecipeProto> { ReceiverSiliconRecipe };
            ReceiverSilicon.maincraft = ReceiverSiliconRecipe;
            ReceiverSilicon.recipes = new List<RecipeProto> { ReceiverSiliconRecipe };
            //ReceiverSilicon.makes = new List<RecipeProto> { ReceiverSiliconRecipe };
            Traverse.Create(ReceiverSilicon).Field("_iconSprite").SetValue(MoreMegaStructure.iconReceiverSilicon);
            //Titanium
            var ReceiverTitaniumRecipe = oriRecipe3.Copy();
            var ReceiverTitanium = oriItem3.Copy();
            ReceiverTitaniumRecipe.ID = 546;
            ReceiverTitaniumRecipe.Name = "钛金属重构装置";
            ReceiverTitaniumRecipe.name = "钛金属重构装置".Translate();
            ReceiverTitaniumRecipe.Description = "接收重构装置描述";
            ReceiverTitaniumRecipe.description = "接收重构装置描述".Translate();
            ReceiverTitaniumRecipe.Items = new int[] { 1103, 1404, 1303, 9481 };
            ReceiverTitaniumRecipe.ItemCounts = new int[] { 20, 10, 5, 2 };
            ReceiverTitaniumRecipe.Results = new int[] { 9496 };
            ReceiverTitaniumRecipe.ResultCounts = new int[] { 1 };
            ReceiverTitaniumRecipe.GridIndex = 304 + pagePlus;
            ReceiverTitaniumRecipe.TimeSpend = 480;
            Traverse.Create(ReceiverTitaniumRecipe).Field("_iconSprite").SetValue(MoreMegaStructure.iconReceiverTitanium);
            ReceiverTitaniumRecipe.preTech = LDB.techs.Select(1504); //射线接收站科技
            ReceiverTitanium.ID = 9496;
            ReceiverTitanium.Name = "钛金属重构装置";
            ReceiverTitanium.name = "钛金属重构装置".Translate();
            ReceiverTitanium.Description = "接收重构装置描述";
            ReceiverTitanium.description = "接收重构装置描述".Translate();
            ReceiverTitanium.GridIndex = 304 + pagePlus;
            ReceiverTitanium.HeatValue = 0L;
            ReceiverTitanium.prefabDesc = oriItem3.prefabDesc.Copy();
            ReceiverTitanium.prefabDesc.powerProductHeat = 6000000;
            ReceiverTitanium.prefabDesc.powerProductId = 1106;
            ReceiverTitanium.handcraft = ReceiverTitaniumRecipe;
            ReceiverTitanium.handcrafts = new List<RecipeProto> { ReceiverTitaniumRecipe };
            ReceiverTitanium.maincraft = ReceiverTitaniumRecipe;
            ReceiverTitanium.recipes = new List<RecipeProto> { ReceiverTitaniumRecipe };
            //ReceiverTitanium.makes = new List<RecipeProto> { ReceiverTitaniumRecipe };
            Traverse.Create(ReceiverTitanium).Field("_iconSprite").SetValue(MoreMegaStructure.iconReceiverTitanium);
            //Magore
            var ReceiverMagoreRecipe = oriRecipe3.Copy();
            var ReceiverMagore = oriItem3.Copy();
            ReceiverMagoreRecipe.ID = 547;
            ReceiverMagoreRecipe.Name = "单极磁石重构装置";
            ReceiverMagoreRecipe.name = "单极磁石重构装置".Translate();
            ReceiverMagoreRecipe.Description = "接收重构装置描述";
            ReceiverMagoreRecipe.description = "接收重构装置描述".Translate();
            ReceiverMagoreRecipe.Items = new int[] { 1103, 1404, 1303, 9481 };
            ReceiverMagoreRecipe.ItemCounts = new int[] { 20, 10, 5, 2 };
            ReceiverMagoreRecipe.Results = new int[] { 9497 };
            ReceiverMagoreRecipe.ResultCounts = new int[] { 1 };
            ReceiverMagoreRecipe.GridIndex = 305 + pagePlus;
            ReceiverMagoreRecipe.TimeSpend = 480;
            Traverse.Create(ReceiverMagoreRecipe).Field("_iconSprite").SetValue(MoreMegaStructure.iconReceiverMagore);
            ReceiverMagoreRecipe.preTech = LDB.techs.Select(1504); //射线接收站科技
            ReceiverMagore.ID = 9497;
            ReceiverMagore.Name = "单极磁石重构装置";
            ReceiverMagore.name = "单极磁石重构装置".Translate();
            ReceiverMagore.Description = "接收重构装置描述";
            ReceiverMagore.description = "接收重构装置描述".Translate();
            ReceiverMagore.GridIndex = 305 + pagePlus;
            ReceiverMagore.HeatValue = 0L;
            ReceiverMagore.prefabDesc = oriItem3.prefabDesc.Copy();
            ReceiverMagore.prefabDesc.powerProductHeat = 6000000;
            ReceiverMagore.prefabDesc.powerProductId = 1016;
            ReceiverMagore.handcraft = ReceiverMagoreRecipe;
            ReceiverMagore.handcrafts = new List<RecipeProto> { ReceiverMagoreRecipe };
            ReceiverMagore.maincraft = ReceiverMagoreRecipe;
            ReceiverMagore.recipes = new List<RecipeProto> { ReceiverMagoreRecipe };
            //ReceiverMagore.makes = new List<RecipeProto> { ReceiverMagoreRecipe };
            Traverse.Create(ReceiverMagore).Field("_iconSprite").SetValue(MoreMegaStructure.iconReceiverMagore);
            //Casimir
            var ReceiverCasimirRecipe = oriRecipe3.Copy();
            var ReceiverCasimir = oriItem3.Copy();
            ReceiverCasimirRecipe.ID = 548;
            ReceiverCasimirRecipe.Name = "晶体接收器";
            ReceiverCasimirRecipe.name = "晶体接收器".Translate();
            ReceiverCasimirRecipe.Description = "晶体接收器描述";
            ReceiverCasimirRecipe.description = "晶体接收器描述".Translate();
            ReceiverCasimirRecipe.Items = new int[] { 1107, 1404, 1303, 1206 };
            ReceiverCasimirRecipe.ItemCounts = new int[] { 10, 10, 5, 5 };
            ReceiverCasimirRecipe.Results = new int[] { 9498 };
            ReceiverCasimirRecipe.ResultCounts = new int[] { 1 };
            ReceiverCasimirRecipe.GridIndex = 306 + pagePlus;
            ReceiverCasimirRecipe.TimeSpend = 480;
            Traverse.Create(ReceiverCasimirRecipe).Field("_iconSprite").SetValue(MoreMegaStructure.iconReceiverCasimir);
            ReceiverCasimirRecipe.preTech = LDB.techs.Select(1504); //射线接收站科技
            ReceiverCasimir.ID = 9498;
            ReceiverCasimir.Name = "晶体接收器";
            ReceiverCasimir.name = "晶体接收器".Translate();
            ReceiverCasimir.Description = "晶体接收器描述";
            ReceiverCasimir.description = "晶体接收器描述".Translate();
            ReceiverCasimir.GridIndex = 306 + pagePlus;
            ReceiverCasimir.HeatValue = 0L;
            ReceiverCasimir.prefabDesc = oriItem3.prefabDesc.Copy();
            ReceiverCasimir.prefabDesc.powerProductHeat = 120000000;
            ReceiverCasimir.prefabDesc.powerProductId = 1126;
            ReceiverCasimir.handcraft = ReceiverCasimirRecipe;
            ReceiverCasimir.handcrafts = new List<RecipeProto> { ReceiverCasimirRecipe };
            ReceiverCasimir.maincraft = ReceiverCasimirRecipe;
            ReceiverCasimir.recipes = new List<RecipeProto> { ReceiverCasimirRecipe };
            //ReceiverCasimir.makes = new List<RecipeProto> { ReceiverCasimirRecipe };
            Traverse.Create(ReceiverCasimir).Field("_iconSprite").SetValue(MoreMegaStructure.iconReceiverCasimir);
            //IC
            var ReceiverICRecipe = oriRecipe3.Copy();
            var ReceiverIC = oriItem3.Copy();
            ReceiverICRecipe.ID = 549;
            ReceiverICRecipe.Name = "组件集成装置";
            ReceiverICRecipe.name = "组件集成装置".Translate();
            ReceiverICRecipe.Description = "组件集成装置描述";
            ReceiverICRecipe.description = "组件集成装置描述".Translate();
            ReceiverICRecipe.Items = new int[] { 1125, 1404, 1303, 1206 };
            ReceiverICRecipe.ItemCounts = new int[] { 10, 10, 5, 5 };
            ReceiverICRecipe.Results = new int[] { 9499 };
            ReceiverICRecipe.ResultCounts = new int[] { 1 };
            ReceiverICRecipe.GridIndex = 307 + pagePlus;
            ReceiverICRecipe.TimeSpend = 480;
            Traverse.Create(ReceiverICRecipe).Field("_iconSprite").SetValue(MoreMegaStructure.iconReceiverIC);
            ReceiverICRecipe.preTech = LDB.techs.Select(1141); //射线接收站科技
            ReceiverIC.ID = 9499;
            ReceiverIC.Name = "组件集成装置";
            ReceiverIC.name = "组件集成装置".Translate();
            ReceiverIC.Description = "组件集成装置描述";
            ReceiverIC.description = "组件集成装置描述".Translate();
            ReceiverIC.GridIndex = 307 + pagePlus;
            ReceiverIC.HeatValue = 0L;
            ReceiverIC.prefabDesc = oriItem3.prefabDesc.Copy();
            ReceiverIC.prefabDesc.powerProductHeat = 4500000000;
            ReceiverIC.prefabDesc.powerProductId = 9500;
            ReceiverIC.handcraft = ReceiverICRecipe;
            ReceiverIC.handcrafts = new List<RecipeProto> { ReceiverICRecipe };
            ReceiverIC.maincraft = ReceiverICRecipe;
            ReceiverIC.recipes = new List<RecipeProto> { ReceiverICRecipe };
            //ReceiverIC.makes = new List<RecipeProto> { ReceiverICRecipe };
            Traverse.Create(ReceiverIC).Field("_iconSprite").SetValue(MoreMegaStructure.iconReceiverIC);
            
            //多功能集成组件
            var oriItem4 = LDB.items.Select(1131); //地基
            var itemICRecipe = oriRecipe.Copy();
            var itemIC = oriItem4.Copy();
            itemICRecipe.ID = 550;
            itemICRecipe.Name = "多功能集成组件";
            itemICRecipe.name = "多功能集成组件".Translate();
            itemICRecipe.Description = "多功能集成组件描述";
            itemICRecipe.description = "多功能集成组件描述".Translate();
            itemICRecipe.Items = new int[] { 9500 };
            itemICRecipe.ItemCounts = new int[] { 1 };
            itemICRecipe.Results = new int[] { 9500 };
            itemICRecipe.ResultCounts = new int[] { 1 };
            itemICRecipe.GridIndex = 199 + pagePlus;
            itemICRecipe.TimeSpend = 60;
            itemICRecipe.preTech = LDB.techs.Select(1203); //量子打印科技
            Traverse.Create(itemICRecipe).Field("_iconSprite").SetValue(MoreMegaStructure.iconInterCompo);
            itemIC.ID = 9500;
            itemIC.Name = "多功能集成组件";
            itemIC.name = "多功能集成组件".Translate();
            itemIC.Description = "多功能集成组件描述";
            itemIC.description = "多功能集成组件描述".Translate();
            itemIC.GridIndex = 109 + pagePlus;
            itemIC.StackSize = 1000;
            itemIC.HeatValue = 0L;
            itemIC.prefabDesc = oriItem4.prefabDesc.Copy();
            itemIC.handcraft = itemICRecipe;
            itemIC.handcrafts = new List<RecipeProto> { itemICRecipe };
            itemIC.maincraft = itemICRecipe;
            itemIC.recipes = new List<RecipeProto> { itemICRecipe };
            Traverse.Create(itemIC).Field("_iconSprite").SetValue(MoreMegaStructure.iconInterCompo);

            //快速组装配方
            var oriRecipe5 = LDB.recipes.Select(47);
            //传送带 快速组装
            var quickBeltRecipe = oriRecipe5.Copy();
            quickBeltRecipe.ID = 551;
            quickBeltRecipe.Name = "传送带 快速组装";
            quickBeltRecipe.name = "传送带 快速组装".Translate();
            quickBeltRecipe.Description = "快速组装描述";
            quickBeltRecipe.description = "快速组装描述".Translate();
            quickBeltRecipe.Items = new int[] { 9500 };
            quickBeltRecipe.ItemCounts = new int[] { 1 };
            quickBeltRecipe.Results = new int[] { 2003 };
            quickBeltRecipe.ResultCounts = new int[] { 60 };
            quickBeltRecipe.GridIndex = 401 + pagePlus;
            quickBeltRecipe.TimeSpend = 6;
            Traverse.Create(quickBeltRecipe).Field("_iconSprite").SetValue(MoreMegaStructure.iconQuickBelt);
            //分拣器 快速组装
            var quickSorterRecipe = oriRecipe5.Copy();
            quickSorterRecipe.ID = 552;
            quickSorterRecipe.Name = "分拣器 快速组装";
            quickSorterRecipe.name = "分拣器 快速组装".Translate();
            quickSorterRecipe.Description = "快速组装描述";
            quickSorterRecipe.description = "快速组装描述".Translate();
            quickSorterRecipe.Items = new int[] { 9500 };
            quickSorterRecipe.ItemCounts = new int[] { 1 };
            quickSorterRecipe.Results = new int[] { 2013 };
            quickSorterRecipe.ResultCounts = new int[] { 10 };
            quickSorterRecipe.GridIndex = 402 + pagePlus;
            quickSorterRecipe.TimeSpend = 6;
            Traverse.Create(quickSorterRecipe).Field("_iconSprite").SetValue(MoreMegaStructure.iconQuickSorter);
            //配电站 快速组装
            var quickPowerRecipe = oriRecipe5.Copy();
            quickPowerRecipe.ID = 553;
            quickPowerRecipe.Name = "配电站 快速组装";
            quickPowerRecipe.name = "配电站 快速组装".Translate();
            quickPowerRecipe.Description = "快速组装描述";
            quickPowerRecipe.description = "快速组装描述".Translate();
            quickPowerRecipe.Items = new int[] { 9500 };
            quickPowerRecipe.ItemCounts = new int[] { 1 };
            quickPowerRecipe.Results = new int[] { 2212 };
            quickPowerRecipe.ResultCounts = new int[] { 5 };
            quickPowerRecipe.GridIndex = 403 + pagePlus;
            quickPowerRecipe.TimeSpend = 6;
            Traverse.Create(quickPowerRecipe).Field("_iconSprite").SetValue(MoreMegaStructure.iconQuickPower);
            //制造台 快速组装
            var quickAssemblyRecipe = oriRecipe5.Copy();
            quickAssemblyRecipe.ID = 554;
            quickAssemblyRecipe.Name = "制造台 快速组装";
            quickAssemblyRecipe.name = "制造台 快速组装".Translate();
            quickAssemblyRecipe.Description = "快速组装描述";
            quickAssemblyRecipe.description = "快速组装描述".Translate();
            quickAssemblyRecipe.Items = new int[] { 9500 };
            quickAssemblyRecipe.ItemCounts = new int[] { 1 };
            quickAssemblyRecipe.Results = new int[] { 2305 };
            quickAssemblyRecipe.ResultCounts = new int[] { 1 };
            quickAssemblyRecipe.GridIndex = 404 + pagePlus;
            quickAssemblyRecipe.TimeSpend = 6;
            Traverse.Create(quickAssemblyRecipe).Field("_iconSprite").SetValue(MoreMegaStructure.iconQuickAssembly);
            //位面熔炉 快速组装
            var quickSmelterRecipe = oriRecipe5.Copy();
            quickSmelterRecipe.ID = 555;
            quickSmelterRecipe.Name = "位面熔炉 快速组装";
            quickSmelterRecipe.name = "位面熔炉 快速组装".Translate();
            quickSmelterRecipe.Description = "快速组装描述";
            quickSmelterRecipe.description = "快速组装描述".Translate();
            quickSmelterRecipe.Items = new int[] { 9500 };
            quickSmelterRecipe.ItemCounts = new int[] { 1 };
            quickSmelterRecipe.Results = new int[] { 2315 };
            quickSmelterRecipe.ResultCounts = new int[] { 1 };
            quickSmelterRecipe.GridIndex = 405 + pagePlus;
            quickSmelterRecipe.TimeSpend = 6;
            Traverse.Create(quickSmelterRecipe).Field("_iconSprite").SetValue(MoreMegaStructure.iconQuickSmelter);
            //化工厂 快速组装
            var quickChemicalRecipe = oriRecipe5.Copy();
            quickChemicalRecipe.ID = 556;
            quickChemicalRecipe.Name = "化工厂 快速组装";
            quickChemicalRecipe.name = "化工厂 快速组装".Translate();
            quickChemicalRecipe.Description = "快速组装描述";
            quickChemicalRecipe.description = "快速组装描述".Translate();
            quickChemicalRecipe.Items = new int[] { 9500 };
            quickChemicalRecipe.ItemCounts = new int[] { 1 };
            quickChemicalRecipe.Results = new int[] { 2309 };
            quickChemicalRecipe.ResultCounts = new int[] { 2 };
            quickChemicalRecipe.GridIndex = 406 + pagePlus;
            quickChemicalRecipe.TimeSpend = 6;
            Traverse.Create(quickChemicalRecipe).Field("_iconSprite").SetValue(MoreMegaStructure.iconQuickChemical);
            //精炼厂 快速组装
            var quickRefineryRecipe = oriRecipe5.Copy();
            quickRefineryRecipe.ID = 557;
            quickRefineryRecipe.Name = "精炼厂 快速组装";
            quickRefineryRecipe.name = "精炼厂 快速组装".Translate();
            quickRefineryRecipe.Description = "快速组装描述";
            quickRefineryRecipe.description = "快速组装描述".Translate();
            quickRefineryRecipe.Items = new int[] { 9500 };
            quickRefineryRecipe.ItemCounts = new int[] { 1 };
            quickRefineryRecipe.Results = new int[] { 2308 };
            quickRefineryRecipe.ResultCounts = new int[] { 2 };
            quickRefineryRecipe.GridIndex = 407 + pagePlus;
            quickRefineryRecipe.TimeSpend = 6;
            Traverse.Create(quickRefineryRecipe).Field("_iconSprite").SetValue(MoreMegaStructure.iconQuickRefinery);
            //对撞机 快速组装
            var quickColliderRecipe = oriRecipe5.Copy();
            quickColliderRecipe.ID = 558;
            quickColliderRecipe.Name = "对撞机 快速组装";
            quickColliderRecipe.name = "对撞机 快速组装".Translate();
            quickColliderRecipe.Description = "快速组装描述";
            quickColliderRecipe.description = "快速组装描述".Translate();
            quickColliderRecipe.Items = new int[] { 9500 };
            quickColliderRecipe.ItemCounts = new int[] { 2 };
            quickColliderRecipe.Results = new int[] { 2310 };
            quickColliderRecipe.ResultCounts = new int[] { 1 };
            quickColliderRecipe.GridIndex = 408 + pagePlus;
            quickColliderRecipe.TimeSpend = 6;
            Traverse.Create(quickColliderRecipe).Field("_iconSprite").SetValue(MoreMegaStructure.iconQuickCollider);
            //研究站 快速组装
            var quickLabRecipe = oriRecipe5.Copy();
            quickLabRecipe.ID = 559;
            quickLabRecipe.Name = "研究站 快速组装";
            quickLabRecipe.name = "研究站 快速组装".Translate();
            quickLabRecipe.Description = "快速组装描述";
            quickLabRecipe.description = "快速组装描述".Translate();
            quickLabRecipe.Items = new int[] { 9500 };
            quickLabRecipe.ItemCounts = new int[] { 1 };
            quickLabRecipe.Results = new int[] { 2901 };
            quickLabRecipe.ResultCounts = new int[] { 2 };
            quickLabRecipe.GridIndex = 409 + pagePlus;
            quickLabRecipe.TimeSpend = 6;
            Traverse.Create(quickLabRecipe).Field("_iconSprite").SetValue(MoreMegaStructure.iconQuickLab);
            //人造恒星 快速组装
            var quickReactorRecipe = oriRecipe5.Copy();
            quickReactorRecipe.ID = 560;
            quickReactorRecipe.Name = "人造恒星 快速组装";
            quickReactorRecipe.name = "人造恒星 快速组装".Translate();
            quickReactorRecipe.Description = "快速组装描述";
            quickReactorRecipe.description = "快速组装描述".Translate();
            quickReactorRecipe.Items = new int[] { 9500 };
            quickReactorRecipe.ItemCounts = new int[] { 5 };
            quickReactorRecipe.Results = new int[] { 2210 };
            quickReactorRecipe.ResultCounts = new int[] { 1 };
            quickReactorRecipe.GridIndex = 410 + pagePlus;
            quickReactorRecipe.TimeSpend = 6;
            quickReactorRecipe.preTech = LDB.techs.Select(1144);
            Traverse.Create(quickReactorRecipe).Field("_iconSprite").SetValue(MoreMegaStructure.iconQuickReactor);
            //行星内物流 快速组装
            var quickPLogRecipe = oriRecipe5.Copy();
            quickPLogRecipe.ID = 561;
            quickPLogRecipe.Name = "行星内物流 快速组装";
            quickPLogRecipe.name = "行星内物流 快速组装".Translate();
            quickPLogRecipe.Description = "快速组装描述";
            quickPLogRecipe.description = "快速组装描述".Translate();
            quickPLogRecipe.Items = new int[] { 9500 };
            quickPLogRecipe.ItemCounts = new int[] { 3 };
            quickPLogRecipe.Results = new int[] { 2103, 5001 };
            quickPLogRecipe.ResultCounts = new int[] { 1, 30 };
            quickPLogRecipe.GridIndex = 411 + pagePlus;
            quickPLogRecipe.TimeSpend = 6;
            quickPLogRecipe.preTech = LDB.techs.Select(1604);
            Traverse.Create(quickPLogRecipe).Field("_iconSprite").SetValue(MoreMegaStructure.iconQuickPLog);
            //星际物流 快速组装
            var quickILogRecipe = oriRecipe5.Copy();
            quickILogRecipe.ID = 562;
            quickILogRecipe.Name = "星际物流 快速组装";
            quickILogRecipe.name = "星际物流 快速组装".Translate();
            quickILogRecipe.Description = "快速组装描述";
            quickILogRecipe.description = "快速组装描述".Translate();
            quickILogRecipe.Items = new int[] { 9500 };
            quickILogRecipe.ItemCounts = new int[] { 5 };
            quickILogRecipe.Results = new int[] { 2104, 5002 };
            quickILogRecipe.ResultCounts = new int[] { 1, 10 };
            quickILogRecipe.GridIndex = 412 + pagePlus;
            quickILogRecipe.TimeSpend = 6;
            quickILogRecipe.preTech = LDB.techs.Select(1605);
            Traverse.Create(quickILogRecipe).Field("_iconSprite").SetValue(MoreMegaStructure.iconQuickILog);

            //itemGravityGen.makes = new List<RecipeProto> { itemGravityDrillRecipe, rocketWBARecipe };
            itemConstrainRing.makes = new List<RecipeProto> { itemGravityDrillRecipe, rocketSNRecipe};
            itemGravityDrill.makes = new List<RecipeProto> {rocketMDRecipe };
            itemExciter.makes = new List<RecipeProto> {itemDiscRecipe, itemQuanCompRecipe };
            itemDisc.makes = new List<RecipeProto> {rocketMDRecipe, rocketWBARecipe };
            itemProbe.makes = new List<RecipeProto> { rocketCRRecipe };
            itemQuanComp.makes = new List<RecipeProto> { rocketSNRecipe };
            itemIACompo.makes = new List<RecipeProto> { rocketIARecipe };
            itemIC.makes = new List<RecipeProto> { quickAssemblyRecipe, quickBeltRecipe, quickChemicalRecipe, quickColliderRecipe, quickILogRecipe, quickLabRecipe, quickPLogRecipe, quickPowerRecipe, quickReactorRecipe, quickRefineryRecipe, quickSmelterRecipe, quickSorterRecipe };

            LDB.items.Select(2003).recipes.Add(quickBeltRecipe);
            LDB.items.Select(2013).recipes.Add(quickSorterRecipe);
            LDB.items.Select(2305).recipes.Add(quickAssemblyRecipe);
            LDB.items.Select(2315).recipes.Add(quickSmelterRecipe);
            LDB.items.Select(2309).recipes.Add(quickChemicalRecipe);
            LDB.items.Select(2212).recipes.Add(quickPowerRecipe);
            LDB.items.Select(2308).recipes.Add(quickRefineryRecipe);
            LDB.items.Select(2310).recipes.Add(quickColliderRecipe);
            LDB.items.Select(2901).recipes.Add(quickLabRecipe);
            LDB.items.Select(2210).recipes.Add(quickReactorRecipe);
            LDB.items.Select(2103).recipes.Add(quickPLogRecipe);
            LDB.items.Select(5001).recipes.Add(quickPLogRecipe);
            LDB.items.Select(2104).recipes.Add(quickILogRecipe);
            LDB.items.Select(5002).recipes.Add(quickILogRecipe);

            LDBTool.PostAddProto(itemGravityGen);
            LDBTool.PostAddProto(itemGravityGenRecipe);
            LDBTool.PostAddProto(itemConstrainRing);
            LDBTool.PostAddProto(itemConstrainRingRecipe);
            LDBTool.PostAddProto(itemGravityDrill);
            LDBTool.PostAddProto(itemGravityDrillRecipe);
            LDBTool.PostAddProto(itemExciter);
            LDBTool.PostAddProto(itemExciterRecipe);
            LDBTool.PostAddProto(itemDisc);
            LDBTool.PostAddProto(itemDiscRecipe);
            LDBTool.PostAddProto(itemProbe);
            LDBTool.PostAddProto(itemProbeRecipe);
            LDBTool.PostAddProto(itemQuanComp);
            LDBTool.PostAddProto(itemQuanCompRecipe);
            LDBTool.PostAddProto(itemIACompo);
            LDBTool.PostAddProto(itemIACompoRecipe);
            LDBTool.PostAddProto(itemICRecipe);
            LDBTool.PostAddProto(itemIC);

            LDBTool.PostAddProto(rocketMD);
            LDBTool.PostAddProto(rocketMDRecipe);
            LDBTool.PostAddProto(rocketSN);
            LDBTool.PostAddProto(rocketSNRecipe);
            LDBTool.PostAddProto(rocketWBA);
            LDBTool.PostAddProto(rocketWBARecipe);
            LDBTool.PostAddProto(rocketIA);
            LDBTool.PostAddProto(rocketIARecipe);
            LDBTool.PostAddProto(rocketCR);
            LDBTool.PostAddProto(rocketCRRecipe);

            LDBTool.PostAddProto(ReceiverIron);
            LDBTool.PostAddProto(ReceiverIronRecipe);
            LDBTool.PostAddProto(ReceiverCopper);
            LDBTool.PostAddProto(ReceiverCopperRecipe);
            LDBTool.PostAddProto(ReceiverSilicon);
            LDBTool.PostAddProto(ReceiverSiliconRecipe);
            LDBTool.PostAddProto(ReceiverTitanium);
            LDBTool.PostAddProto(ReceiverTitaniumRecipe);
            LDBTool.PostAddProto(ReceiverMagore);
            LDBTool.PostAddProto(ReceiverMagoreRecipe);
            LDBTool.PostAddProto(ReceiverCasimir);
            LDBTool.PostAddProto(ReceiverCasimirRecipe);
            LDBTool.PostAddProto(ReceiverIC);
            LDBTool.PostAddProto(ReceiverICRecipe);

            LDBTool.PostAddProto(quickAssemblyRecipe);
            LDBTool.PostAddProto(quickBeltRecipe);
            LDBTool.PostAddProto(quickChemicalRecipe);
            LDBTool.PostAddProto(quickColliderRecipe);
            LDBTool.PostAddProto(quickILogRecipe);
            LDBTool.PostAddProto(quickLabRecipe);
            LDBTool.PostAddProto(quickPLogRecipe);
            LDBTool.PostAddProto(quickPowerRecipe);
            LDBTool.PostAddProto(quickReactorRecipe);
            LDBTool.PostAddProto(quickRefineryRecipe);
            LDBTool.PostAddProto(quickSmelterRecipe);
            LDBTool.PostAddProto(quickSorterRecipe);

            if (true)
            {
                LDBTool.SetBuildBar(8, 5, 9493);
                LDBTool.SetBuildBar(8, 6, 9494);
                LDBTool.SetBuildBar(8, 7, 9495);
                LDBTool.SetBuildBar(8, 8, 9496);
                LDBTool.SetBuildBar(8, 9, 9497);
                LDBTool.SetBuildBar(8, 10, 9498);
                LDBTool.SetBuildBar(4, 4, 9499);
            }
        }

        public static void AddReceivers()
        {
            //LDBTool.PostAddProto(ProtoType.Item, ReceiverIron);
            //LDBTool.PostAddProto(ProtoType.Recipe, ReceiverIronRecipe);

        }



        
        public static void AddTranslateUILabel()
        {
            StringProto tr1 = new StringProto();
            StringProto tr2 = new StringProto();
            StringProto tr3 = new StringProto();
            StringProto tr4 = new StringProto();
            StringProto tr5 = new StringProto();
            StringProto tr6 = new StringProto();
            StringProto tr7 = new StringProto();
            StringProto tr8 = new StringProto();
            StringProto tr9 = new StringProto();
            StringProto tr10 = new StringProto();
            StringProto tr11 = new StringProto();
            StringProto tr12 = new StringProto();
            StringProto tr13 = new StringProto();
            StringProto tr14 = new StringProto();
            StringProto tr15 = new StringProto();
            StringProto tr16 = new StringProto();
            StringProto tr17 = new StringProto();
            StringProto tr18 = new StringProto();
            StringProto tr19 = new StringProto();
            //StringProto tr20 = new StringProto();

            tr1.ID = 10610;
            tr1.Name = "巨构建筑";
            tr1.name = "巨构建筑";
            tr1.ZHCN = "巨构建筑";
            tr1.ENUS = "Megastructure";
            tr1.FRFR = "Megastructure";

            tr2.ID = 10611;
            tr2.Name = "规划巨构建筑类型";
            tr2.name = "规划巨构建筑类型";
            tr2.ZHCN = "规划巨构建筑类型";
            tr2.ENUS = "Plan Megastructure";
            tr2.FRFR = "Plan Megastructure";


            tr3.ID = 10612;
            tr3.Name = "自由组件";
            tr3.name = "自由组件";
            tr3.ZHCN = "自由组件";
            tr3.ENUS = "Floating components ";
            tr3.FRFR = "Floating components ";


            tr4.ID = 10613;
            tr4.Name = "工作效率";
            tr4.name = "工作效率";
            tr4.ZHCN = "工作效率";
            tr4.ENUS = "Capacity";
            tr4.FRFR = "Capacity";


            tr5.ID = 10614;
            tr5.Name = "自由组件数量";
            tr5.name = "自由组件数量";
            tr5.ZHCN = "自由组件数量";
            tr5.ENUS = "Floating components in total";
            tr5.FRFR = "Floating components in total";


            tr6.ID = 10615;
            tr6.Name = "自由组件云";
            tr6.name = "自由组件云";
            tr6.ZHCN = "自由组件云";
            tr6.ENUS = "Components Swarm";
            tr6.FRFR = "Components Swarm";

            tr7.ID = 10616;
            tr7.Name = "组件云蓝图";
            tr7.name = "组件云蓝图";
            tr7.ZHCN = "组件云蓝图";
            tr7.ENUS = "Swarm Blueprint";
            tr7.FRFR = "Swarm Blueprint";

            tr8.ID = 10617;
            tr8.Name = "锚定结构";
            tr8.name = "锚定结构";
            tr8.ZHCN = "锚定结构";
            tr8.ENUS = "Anchored Structure";
            tr8.FRFR = "Anchored Structure";

            tr9.ID = 10618;
            tr9.Name = "结构层级";
            tr9.name = "结构层级";
            tr9.ZHCN = "结构层级";
            tr9.ENUS = "Structure Layers";
            tr9.FRFR = "Structure Layers";

            tr10.ID = 10619;
            tr10.Name = "锚定结构蓝图";
            tr10.name = "锚定结构蓝图";
            tr10.ZHCN = "锚定结构蓝图";
            tr10.ENUS = "Anchored Structure Blueprint";
            tr10.FRFR = "Anchored Structure Blueprint";

            tr11.ID = 10620;
            tr11.Name = "恒星功效系数";
            tr11.name = "恒星功效系数";
            tr11.ZHCN = "恒星功效系数";
            tr11.ENUS = "Star Efficiency";
            tr11.FRFR = "Star Efficiency";

            tr12.ID = 10621;
            tr12.Name = "最大工作效率";
            tr12.name = "最大工作效率";
            tr12.ZHCN = "最大工作效率";
            tr12.ENUS = "Capacity";
            tr12.FRFR = "Capacity";

            tr13.ID = 10622;
            tr13.Name = "巨构建筑蓝图";
            tr13.name = "巨构建筑蓝图";
            tr13.ZHCN = "巨构建筑蓝图";
            tr13.ENUS = "Structure Blueprint";
            tr13.FRFR = "Structure Blueprint";

            tr14.ID = 10623;
            tr14.Name = "自由组件寿命分布";
            tr14.name = "自由组件寿命分布";
            tr14.ZHCN = "自由组件寿命分布";
            tr14.ENUS = "Life Distribution of Floating Components";
            tr14.FRFR = "Life Distribution of Floating Components";

            tr15.ID = 10624;
            tr15.Name = "自由组件状态统计";
            tr15.name = "自由组件状态统计";
            tr15.ZHCN = "自由组件状态统计";
            tr15.ENUS = "Floating Components Status Statistics";
            tr15.FRFR = "Floating Components Status Statistics";

            tr16.ID = 10625;
            tr16.Name = "自由组件工作效率";
            tr16.name = "自由组件工作效率";
            tr16.ZHCN = "自由组件工作效率";
            tr16.ENUS = "Generation of Floating Components";
            tr16.FRFR = "Generation of Floating Components";

            tr17.ID = 10626;
            tr17.Name = "锚定结构工作效率";
            tr17.name = "锚定结构工作效率";
            tr17.ZHCN = "锚定结构工作效率";
            tr17.ENUS = "Generation of Anchored Structure";
            tr17.FRFR = "Generation of Anchored Structure";

            tr18.ID = 10627;
            tr18.Name = "研究效率";
            tr18.name = "研究效率";
            tr18.ZHCN = "研究效率";
            tr18.ENUS = "Research Capacity";
            tr18.FRFR = "Research Capacity";

            tr19.ID = 10628;
            tr19.Name = "折跃场加速";
            tr19.name = "折跃场加速";
            tr19.ZHCN = "折跃场加速";
            tr19.ENUS = "Warp Acceleration";
            tr19.FRFR = "Warp Acceleration";

            //tr20.ID = 10629;
            //tr20.Name = "锚定结构工作效率";
            //tr20.name = "锚定结构工作效率";
            //tr20.ZHCN = "锚定结构工作效率";
            //tr20.ENUS = "Generation of Anchored Structure";
            //tr20.FRFR = "Generation of Anchored Structure";

            LDBTool.PreAddProto(tr1);
            LDBTool.PreAddProto(tr2);
            LDBTool.PreAddProto(tr3);
            LDBTool.PreAddProto(tr4);
            LDBTool.PreAddProto(tr5);
            LDBTool.PreAddProto(tr6);
            LDBTool.PreAddProto(tr7);
            LDBTool.PreAddProto(tr8);
            LDBTool.PreAddProto(tr9);
            LDBTool.PreAddProto(tr10);
            LDBTool.PreAddProto(tr11);
            LDBTool.PreAddProto(tr12);
            LDBTool.PreAddProto(tr13);
            LDBTool.PreAddProto(tr14);
            LDBTool.PreAddProto(tr15);
            LDBTool.PreAddProto(tr16);
            LDBTool.PreAddProto(tr17);
            LDBTool.PreAddProto(tr18);
            LDBTool.PreAddProto(tr19);
            //LDBTool.PreAddProto(tr20);
        }

        public static void AddTranslateStructureName()
        {
            StringProto tr1 = new StringProto();
            StringProto tr2 = new StringProto();
            StringProto tr3 = new StringProto();
            StringProto tr4 = new StringProto();
            StringProto tr5 = new StringProto();
            StringProto tr6 = new StringProto();
            StringProto tr7 = new StringProto();
            StringProto tr8 = new StringProto();
            StringProto tr9 = new StringProto();
            StringProto tr10 = new StringProto();
            StringProto tr11 = new StringProto();
            StringProto tr12 = new StringProto();
            StringProto tr13 = new StringProto();
            StringProto tr14 = new StringProto();
            StringProto tr15 = new StringProto();
            StringProto tr16 = new StringProto();
            StringProto tr17 = new StringProto();

            tr1.ID = 10630;
            tr1.Name = "规划";
            tr1.name = "规划";
            tr1.ZHCN = "规划";
            tr1.ENUS = "Plan ";
            tr1.FRFR = "Plan ";

            tr2.ID = 10631;
            tr2.Name = "戴森球jinx";
            tr2.name = "戴森球jinx";
            tr2.ZHCN = "戴森球";
            tr2.ENUS = "Dyson Sphere";
            tr2.FRFR = "Dyson Sphere";


            tr3.ID = 10632;
            tr3.Name = "物质解压器";
            tr3.name = "物质解压器";
            tr3.ZHCN = "物质解压器";
            tr3.ENUS = "Matter Decompressor";
            tr3.FRFR = "Matter Decompressor";


            tr4.ID = 10633;
            tr4.Name = "科学枢纽";
            tr4.name = "科学枢纽";
            tr4.ZHCN = "科学枢纽";
            tr4.ENUS = "Science Nexus";
            tr4.FRFR = "Science Nexus";


            tr5.ID = 10634;
            tr5.Name = "折跃场广播阵列";
            tr5.name = "折跃场广播阵列";
            tr5.ZHCN = "折跃场广播阵列";
            tr5.ENUS = "Warp Field Broadcast Array";
            tr5.FRFR = "Warp Field Broadcast Array";


            tr6.ID = 10635;
            tr6.Name = "星际组装厂";
            tr6.name = "星际组装厂";
            tr6.ZHCN = "星际组装厂";
            tr6.ENUS = "Interstellar Assembly";
            tr6.FRFR = "Interstellar Assembly";

            tr7.ID = 10636;
            tr7.Name = "晶体重构器";
            tr7.name = "晶体重构器";
            tr7.ZHCN = "晶体重构器";
            tr7.ENUS = "Crystal Reconstructor";
            tr7.FRFR = "Crystal Reconstructor";

            tr8.ID = 10637;
            tr8.Name = "警告最多一个";
            tr8.name = "警告最多一个";
            tr8.ZHCN = "折跃场广播阵列最多建造一个，请检查星系:";
            tr8.ENUS = "You can only build one Wrapfield broadcast array, please check:";
            tr8.FRFR = "You can only build one Wrapfield broadcast array, please check:";

            tr9.ID = 10638;
            tr9.Name = "警告先拆除";
            tr9.name = "警告先拆除";
            tr9.ZHCN = "你必须先拆除所有锚定结构（节点）再规划不同的巨构建筑。";
            tr9.ENUS = "You have to remove all anchor structures (nodes) before planning different megastructures.";
            tr9.FRFR = "You have to remove all anchor structures (nodes) before planning different megastructures.";

            tr10.ID = 10639;
            tr10.Name = "警告仅黑洞";
            tr10.name = "警告仅黑洞";
            tr10.ZHCN = "物质解压器只能在黑洞上建造。";
            tr10.ENUS = "Matter decompressors can only be built on black holes.";
            tr10.FRFR = "Matter decompressors can only be built on black holes.";

            tr11.ID = 10640;
            tr11.Name = "警告仅中子星白矮星";
            tr11.name = "警告仅中子星白矮星";
            tr11.ZHCN = "晶体重构器只能在中子星或白矮星上建造。";
            tr11.ENUS = "Crystal reconstructors can only be built on neutron stars or white drawf.";
            tr11.FRFR = "Crystal reconstructors can only be built on neutron stars or white drawf.";

            
            tr12.ID = 10641;
            tr12.Name = "当前";
            tr12.name = "当前";
            tr12.ZHCN = "当前";
            tr12.ENUS = "Currently";
            tr12.FRFR = "Currently";
            
            tr13.ID = 10642;
            tr13.Name = "警告未知错误";
            tr13.name = "警告未知错误";
            tr13.ZHCN = "设置异常失败，请像mod作者反馈该问题。";
            tr13.ENUS = "The setting fails abnormally, please report this problem.";
            tr13.FRFR = "The setting fails abnormally, please report this problem.";
            
            tr14.ID = 10643;
            tr14.Name = "MegaStructures";
            tr14.name = "MegaStructures";
            tr14.ZHCN = "巨构";
            tr14.ENUS = "Megastructures";
            tr14.FRFR = "Megastructures";
            
            tr15.ID = 10644;
            tr15.Name = "物质合成";
            tr15.name = "物质合成";
            tr15.ZHCN = "物质合成";
            tr15.ENUS = "Substance generation";
            tr15.FRFR = "Substance generation";
            /*
            tr16.ID = 10645;
            tr16.Name = "自由组件工作效率";
            tr16.name = "自由组件工作效率";
            tr16.ZHCN = "自由组件工作效率";
            tr16.ENUS = "Generation of Floating Components";
            tr16.FRFR = "Generation of Floating Components";

            tr17.ID = 10646;
            tr17.Name = "锚定结构工作效率";
            tr17.name = "锚定结构工作效率";
            tr17.ZHCN = "锚定结构工作效率";
            tr17.ENUS = "Generation of Anchored Structure";
            tr17.FRFR = "Generation of Anchored Structure";
            */

            LDBTool.PreAddProto(tr1);
            LDBTool.PreAddProto(tr2);
            LDBTool.PreAddProto(tr3);
            LDBTool.PreAddProto(tr4);
            LDBTool.PreAddProto(tr5);
            LDBTool.PreAddProto(tr6);
            LDBTool.PreAddProto(tr7);
            LDBTool.PreAddProto(tr8);
            LDBTool.PreAddProto(tr9);
            LDBTool.PreAddProto(tr10);
            LDBTool.PreAddProto(tr11);
            LDBTool.PreAddProto(tr12);
            LDBTool.PreAddProto(tr13);
            LDBTool.PreAddProto(tr14);
            LDBTool.PreAddProto(tr15);
            //LDBTool.PreAddProto(tr16);
            //LDBTool.PreAddProto(tr17);
        }

        public static void AddTranslateProtoNames1()
        {
            int bias = 40;
            StringProto tr1 = new StringProto();
            StringProto tr2 = new StringProto();
            StringProto tr3 = new StringProto();
            StringProto tr4 = new StringProto();
            StringProto tr5 = new StringProto();
            StringProto tr6 = new StringProto();
            StringProto tr7 = new StringProto();
            StringProto tr8 = new StringProto();
            StringProto tr9 = new StringProto();
            StringProto tr10 = new StringProto();
            StringProto tr11 = new StringProto();
            StringProto tr12 = new StringProto();
            StringProto tr13 = new StringProto();
            StringProto tr14 = new StringProto();
            StringProto tr15 = new StringProto();
            StringProto tr16 = new StringProto();
            StringProto tr17 = new StringProto();
            StringProto tr18 = new StringProto();
            StringProto tr19 = new StringProto();
            StringProto tr20 = new StringProto();

            tr1.ID = 10610 + bias;
            tr1.Name = "引力发生装置";
            tr1.name = "引力发生装置";
            tr1.ZHCN = "引力发生装置";
            tr1.ENUS = "Gravity generator";
            tr1.FRFR = tr1.ENUS;

            tr2.ID = 10611 + bias;
            tr2.Name = "引力发生装置描述";
            tr2.name = "引力发生装置描述";
            tr2.ZHCN = "引导临界光子轰击奇异物质即可激发引力波。恒星附近能够获取大量的临界光子，从而能够使引力发生装置高效地运行。";
            tr2.ENUS = "Gravitational waves can be excited by directing critical photons to hit strange matter. A large number of critical photons can be obtained near the star, allowing the gravitational generator to operate efficiently.";
            tr2.FRFR = tr2.ENUS;


            tr3.ID = 10612 + bias;
            tr3.Name = "位面约束环";
            tr3.name = "位面约束环";
            tr3.ZHCN = "位面约束环";
            tr3.ENUS = "Plane constraint ring";
            tr3.FRFR = tr3.ENUS;


            tr4.ID = 10613 + bias;
            tr4.Name = "位面约束环描述";
            tr4.name = "位面约束环描述";
            tr4.ZHCN = "位面约束环能够协同引力透镜引导并操纵引力，也是构建科学枢纽所需的恒星级粒子加速器的必要组件。";
            tr4.ENUS = "Plane constraint ring can guide and manipulate gravity with graviton lens, and it is also an essential component of the stellar-scale particle accelerators which are needed to build science nexus.";
            tr4.FRFR = tr4.ENUS;


            tr5.ID = 10614 + bias;
            tr5.Name = "引力钻头";
            tr5.name = "引力钻头";
            tr5.ZHCN = "引力钻头";
            tr5.ENUS = "Graviton drill";
            tr5.FRFR = tr5.ENUS;


            tr6.ID = 10615 + bias;
            tr6.Name = "引力钻头描述";
            tr6.name = "引力钻头描述";
            tr6.ZHCN = "借助黑洞本身的引力，引力钻头能够将物质从黑洞中取出，这还包括吸积盘中大量的单极磁石。借助谐振盘，黑洞原质将能够被解压并在星系内输送。";
            tr6.ENUS = "The graviton drill can pull matter out of the black hole using the gravity of the black hole itself, which also includes the unipolar magnets in the accretion disk. With the help of the resonant disc, the matter from the black hole will be able to be decompressed and transported within the galaxy.";
            tr6.FRFR = tr6.ENUS;

            tr7.ID = 10616 + bias;
            tr7.Name = "隧穿激发装置";
            tr7.name = "隧穿激发装置";
            tr7.ZHCN = "隧穿激发装置";
            tr7.ENUS = "Tunneling exciter";
            tr7.FRFR = tr7.ENUS;

            tr8.ID = 10617 + bias;
            tr8.Name = "隧穿激发装置描述";
            tr8.name = "隧穿激发装置描述";
            tr8.ZHCN = "隧穿激发装置可以完美地掌控量子隧穿效应，常被用来强化量子芯片的处理能力和纠错能力。通过量子隧穿效应还能够轻易突破弯曲空间的能量势垒，使得在任意远的空间打开裂口成为可能。";
            tr8.ENUS = "Tunneling exciters can perfectly control the quantum tunneling effect, and are often used to enhance the processing and error correction capabilities of quantum chips. The quantum tunneling effect can also easily break through the energy barrier of the curved space, making it possible to open the warp crack in any space far away.";
            tr8.FRFR = tr8.ENUS;

            tr9.ID = 10618 + bias;
            tr9.Name = "谐振盘";
            tr9.name = "谐振盘";
            tr9.ZHCN = "谐振盘";
            tr9.ENUS = "Resonant disc";
            tr9.FRFR = tr9.ENUS;

            tr10.ID = 10619 + bias;
            tr10.Name = "谐振盘描述";
            tr10.name = "谐振盘描述";
            tr10.ZHCN = "谐振盘仅通过恒星级别的能量就可以产生跨越恒星系的空间波动能量束。如果将谐振盘组成阵列，理论上可以形成覆盖全宇宙的折跃能量场。";
            tr10.ENUS = "The resonant disc can generate interstellar-scale space-wave energy beams from only stellar-scale energy. If the resonant discs are formed into an array, a warp field covering the entire universe can theoretically be formed.";
            tr10.FRFR = tr10.ENUS;

            tr11.ID = 10620 + bias;
            tr11.Name = "光子探针";
            tr11.name = "光子探针";
            tr11.ZHCN = "光子探针";
            tr11.ENUS = "Photon probe";
            tr11.FRFR = tr11.ENUS;

            tr12.ID = 10621 + bias;
            tr12.Name = "光子探针描述";
            tr12.name = "光子探针描述";
            tr12.ZHCN = "将临界光子变频后发射并引导晶体重构，发射的光子还能被回收。";
            tr12.ENUS = "The critical photons are frequency-converted and emitted, thereby guiding the crystal reconstruction. The photons can also be recovered.";
            tr12.FRFR = tr12.ENUS;

            tr13.ID = 10622 + bias;
            tr13.Name = "量子计算机";
            tr13.name = "量子计算机";
            tr13.ZHCN = "量子计算机";
            tr13.ENUS = "Quantum computer";
            tr13.FRFR = tr13.ENUS;

            tr14.ID = 10623 + bias;
            tr14.Name = "量子计算机描述";
            tr14.name = "量子计算机描述";
            tr14.ZHCN = "只要供给足够的能量，量子计算机的运算时钟能够无限逼近普朗克时间。通过量子比特协同，其潜在的单线程运算速率还能突破物理极限，并可以无限提升。现在，限制其计算速度的将只有能量输入水平。";
            tr14.ENUS = "As long as enough energy is supplied, the computing clock of a quantum computer can approach Planck time indefinitely. Through the cooperation of qubits, its potential single-threaded operation rate can also break through the physical limit and can be infinitely improved. Now, it will only be the level of energy input that will limit its computational speed.";
            tr14.FRFR = tr14.ENUS;

            tr15.ID = 10624 + bias;
            tr15.Name = "星际组装厂组件";
            tr15.name = "星际组装厂组件";
            tr15.ZHCN = "星际组装厂组件";
            tr15.ENUS = "Interstellar assembly component";
            tr15.FRFR = tr15.ENUS;

            tr16.ID = 10625 + bias;
            tr16.Name = "星际组装厂组件描述";
            tr16.name = "星际组装厂组件描述";
            tr16.ZHCN = "使用微型火箭将组件运载到恒星附近并构建星际组装厂的节点和框架。";
            tr16.ENUS = "Use a small carrier rocket to the planned Interstellar assembly to form the nodes and frames of Interstellar assembly.";
            tr16.FRFR = tr16.ENUS;

            tr17.ID = 10626 + bias;
            tr17.Name = "物质解压器运载火箭";
            tr17.name = "物质解压器运载火箭";
            tr17.ZHCN = "物质解压器运载火箭";
            tr17.ENUS = "Matter decompressor carrier rocket";
            tr17.FRFR = tr17.ENUS;

            tr18.ID = 10627 + bias;
            tr18.Name = "物质解压器运载火箭描述";
            tr18.name = "物质解压器运载火箭描述";
            tr18.ZHCN = "物质解压器相关组件的运载工具。";
            tr18.ENUS = "The delivery vehicle for the components of the Matter decompressor.";
            tr18.FRFR = tr18.ENUS;

            tr19.ID = 10628 + bias;
            tr19.Name = "科学枢纽运载火箭";
            tr19.name = "科学枢纽运载火箭";
            tr19.ZHCN = "科学枢纽运载火箭";
            tr19.ENUS = "Science nexus carrier rocket";
            tr19.FRFR = tr19.ENUS;

            tr20.ID = 10629 + bias;
            tr20.Name = "科学枢纽运载火箭描述";
            tr20.name = "科学枢纽运载火箭描述";
            tr20.ZHCN = "科学枢纽相关组件的运载工具。";
            tr20.ENUS = "The delivery vehicle for the components of the Science nexus.";
            tr20.FRFR = tr20.ENUS;

            LDBTool.PreAddProto(tr1);
            LDBTool.PreAddProto(tr2);
            LDBTool.PreAddProto(tr3);
            LDBTool.PreAddProto(tr4);
            LDBTool.PreAddProto(tr5);
            LDBTool.PreAddProto(tr6);
            LDBTool.PreAddProto(tr7);
            LDBTool.PreAddProto(tr8);
            LDBTool.PreAddProto(tr9);
            LDBTool.PreAddProto(tr10);
            LDBTool.PreAddProto(tr11);
            LDBTool.PreAddProto(tr12);
            LDBTool.PreAddProto(tr13);
            LDBTool.PreAddProto(tr14);
            LDBTool.PreAddProto(tr15);
            LDBTool.PreAddProto(tr16);
            LDBTool.PreAddProto(tr17);
            LDBTool.PreAddProto(tr18);
            LDBTool.PreAddProto(tr19);
            LDBTool.PreAddProto(tr20);
        }

        public static void AddTranslateProtoNames2()
        {
            int bias = 60;
            StringProto tr1 = new StringProto();
            StringProto tr2 = new StringProto();
            StringProto tr3 = new StringProto();
            StringProto tr4 = new StringProto();
            StringProto tr5 = new StringProto();
            StringProto tr6 = new StringProto();
            StringProto tr7 = new StringProto();
            StringProto tr8 = new StringProto();
            StringProto tr9 = new StringProto();
            StringProto tr10 = new StringProto();
            StringProto tr11 = new StringProto();
            StringProto tr12 = new StringProto();
            StringProto tr13 = new StringProto();
            StringProto tr14 = new StringProto();
            StringProto tr15 = new StringProto();
            StringProto tr16 = new StringProto();
            StringProto tr17 = new StringProto();
            StringProto tr18 = new StringProto();
            //StringProto tr19 = new StringProto();
            //StringProto tr20 = new StringProto();

            tr1.ID = 10610 + bias;
            tr1.Name = "谐振发射器运载火箭";
            tr1.name = "谐振发射器运载火箭";
            tr1.ZHCN = "谐振发射器运载火箭";
            tr1.ENUS = "Resonant generator carrier rocket";
            tr1.FRFR = tr1.ENUS;

            tr2.ID = 10611 + bias;
            tr2.Name = "谐振发射器运载火箭描述";
            tr2.name = "谐振发射器运载火箭描述";
            tr2.ZHCN = "大量谐振发射器将组成阵列并向全星系广播折跃能量场。";
            tr2.ENUS = "A large number of resonant generators will form an array and broadcast the warp energy field to the entire galaxy.";
            tr2.FRFR = tr2.ENUS;


            tr3.ID = 10612 + bias;
            tr3.Name = "星际组装厂运载火箭";
            tr3.name = "星际组装厂运载火箭";
            tr3.ZHCN = "星际组装厂运载火箭";
            tr3.ENUS = "Interstellar assembly carrier rocket";
            tr3.FRFR = tr3.ENUS;


            tr4.ID = 10613 + bias;
            tr4.Name = "星际组装厂运载火箭描述";
            tr4.name = "星际组装厂运载火箭描述";
            tr4.ZHCN = "星际组装厂组件的运载工具。";
            tr4.ENUS = "The delivery vehicle of Interstellar assembly components.";
            tr4.FRFR = tr4.ENUS;


            tr5.ID = 10614 + bias;
            tr5.Name = "晶体重构器运载火箭";
            tr5.name = "晶体重构器运载火箭";
            tr5.ZHCN = "晶体重构器运载火箭";
            tr5.ENUS = "Crystal reconstructor carrier rocket";
            tr5.FRFR = tr5.ENUS;


            tr6.ID = 10615 + bias;
            tr6.Name = "晶体重构器运载火箭描述";
            tr6.name = "晶体重构器运载火箭描述";
            tr6.ZHCN = "晶体重构器相关组件的运载工具。";
            tr6.ENUS = "The delivery vehicle for the components of the Crystal reconstructor.";
            tr6.FRFR = tr6.ENUS;

            tr7.ID = 10616 + bias;
            tr7.Name = "铁金属重构装置";
            tr7.name = "铁金属重构装置";
            tr7.ZHCN = "铁金属重构装置";
            tr7.ENUS = "Iron reconstruct receiver";
            tr7.FRFR = tr7.ENUS;

            tr8.ID = 10617 + bias;
            tr8.Name = "铜金属重构装置";
            tr8.name = "铜金属重构装置";
            tr8.ZHCN = "铜金属重构装置";
            tr8.ENUS = "Copper reconstruct receiver";
            tr8.FRFR = tr8.ENUS;

            tr9.ID = 10618 + bias;
            tr9.Name = "高纯硅重构装置";
            tr9.name = "高纯硅重构装置";
            tr9.ZHCN = "高纯硅重构装置";
            tr9.ENUS = "Silicon reconstruct receiver";
            tr9.FRFR = tr9.ENUS;

            tr10.ID = 10619 + bias;
            tr10.Name = "钛金属重构装置";
            tr10.name = "钛金属重构装置";
            tr10.ZHCN = "钛金属重构装置";
            tr10.ENUS = "Titanium reconstruct receiver";
            tr10.FRFR = tr10.ENUS;

            tr11.ID = 10620 + bias;
            tr11.Name = "单极磁石重构装置";
            tr11.name = "单极磁石重构装置";
            tr11.ZHCN = "单极磁石重构装置";
            tr11.ENUS = "Unipolar magnet receiver";
            tr11.FRFR = tr11.ENUS;

            tr12.ID = 10621 + bias;
            tr12.Name = "接收重构装置描述";
            tr12.name = "接收重构装置描述";
            tr12.ZHCN = "从黑洞中解压出的亚稳态物质被接收后经过处理，重构为可直接使用的稳定材料。";
            tr12.ENUS = "The metastable matter decompressed from the black hole is received, processed, and reconstructed into stable material that can be used directly.";
            tr12.FRFR = tr12.ENUS;

            tr13.ID = 10622 + bias;
            tr13.Name = "晶体接收器";
            tr13.name = "晶体接收器";
            tr13.ZHCN = "晶体接收器";
            tr13.ENUS = "Crystal receiver";
            tr13.FRFR = tr13.ENUS;

            tr14.ID = 10623 + bias;
            tr14.Name = "晶体接收器描述";
            tr14.name = "晶体接收器描述";
            tr14.ZHCN = "从晶体重构器中合成的卡西米尔晶体前导微晶流将在此经过自发β衰变并形成完美的卡西米尔晶体。";
            tr14.ENUS = "The Casimir crystal precursor crystallite flow synthesized from the Crystal reconstructor will undergo spontaneous β decay here and form perfect casimir crystals.";
            tr14.FRFR = tr14.ENUS;

            tr15.ID = 10624 + bias;
            tr15.Name = "组件集成装置";
            tr15.name = "组件集成装置";
            tr15.ZHCN = "组件集成装置";
            tr15.ENUS = "Component integration station";
            tr15.FRFR = tr15.ENUS;

            tr16.ID = 10625 + bias;
            tr16.Name = "组件集成装置描述";
            tr16.name = "组件集成装置描述";
            tr16.ZHCN = "将星际组装厂的高集成配件进行预解压，形成可被快速组装的多功能集成组件。";
            tr16.ENUS = "Pre-decompress the high-integration parts from the Interstellar assembly, to form multi-functional integrated components that can be quickly assembled.";
            tr16.FRFR = tr16.ENUS;

            tr17.ID = 10626 + bias;
            tr17.Name = "多功能集成组件";
            tr17.name = "多功能集成组件";
            tr17.ZHCN = "多功能集成组件";
            tr17.ENUS = "Multi-functional integrated components";
            tr17.FRFR = tr17.ENUS;

            tr18.ID = 10627 + bias;
            tr18.Name = "多功能集成组件描述";
            tr18.name = "多功能集成组件描述";
            tr18.ZHCN = "超高集成度使其可以迅速地组装成多种生产建筑和物流组件，却仅占用极小的空间。";
            tr18.ENUS = "The high level of integration makes it possible to quickly assemble a variety of production building and logistics components, while occupying very little space.";
            tr18.FRFR = tr18.ENUS;

            //tr19.ID = 10628 + bias;
            //tr19.Name = "科学枢纽运载火箭";
            //tr19.name = "科学枢纽运载火箭";
            //tr19.ZHCN = "科学枢纽运载火箭";
            //tr19.ENUS = "Science nexus carrier rocket";
            //tr19.FRFR = tr19.ENUS;

            //tr20.ID = 10629 + bias;
            //tr20.Name = "科学枢纽运载火箭描述";
            //tr20.name = "科学枢纽运载火箭描述";
            //tr20.ZHCN = "科学枢纽相关组件的运载工具。";
            //tr20.ENUS = "The delivery vehicle for the components of the Science nexus.";
            //tr20.FRFR = tr20.ENUS;

            LDBTool.PreAddProto(tr1);
            LDBTool.PreAddProto(tr2);
            LDBTool.PreAddProto(tr3);
            LDBTool.PreAddProto(tr4);
            LDBTool.PreAddProto(tr5);
            LDBTool.PreAddProto(tr6);
            LDBTool.PreAddProto(tr7);
            LDBTool.PreAddProto(tr8);
            LDBTool.PreAddProto(tr9);
            LDBTool.PreAddProto(tr10);
            LDBTool.PreAddProto(tr11);
            LDBTool.PreAddProto(tr12);
            LDBTool.PreAddProto(tr13);
            LDBTool.PreAddProto(tr14);
            LDBTool.PreAddProto(tr15);
            LDBTool.PreAddProto(tr16);
            LDBTool.PreAddProto(tr17);
            LDBTool.PreAddProto(tr18);
            //LDBTool.PreAddProto(tr19);
            //LDBTool.PreAddProto(tr20);
        }

        public static void AddTranslateProtoNames3()
        {
            int bias = 80;
            StringProto tr1 = new StringProto();
            StringProto tr2 = new StringProto();
            StringProto tr3 = new StringProto();
            StringProto tr4 = new StringProto();
            StringProto tr5 = new StringProto();
            StringProto tr6 = new StringProto();
            StringProto tr7 = new StringProto();
            StringProto tr8 = new StringProto();
            StringProto tr9 = new StringProto();
            StringProto tr10 = new StringProto();
            StringProto tr11 = new StringProto();
            StringProto tr12 = new StringProto();
            StringProto tr13 = new StringProto();
            //StringProto tr14 = new StringProto();
            //StringProto tr15 = new StringProto();
            //StringProto tr16 = new StringProto();
            //StringProto tr17 = new StringProto();
            //StringProto tr18 = new StringProto();
            //StringProto tr19 = new StringProto();
            //StringProto tr20 = new StringProto();

            tr1.ID = 10610 + bias;
            tr1.Name = "传送带 快速组装";
            tr1.name = "传送带 快速组装";
            tr1.ZHCN = "传送带 快速组装";
            tr1.ENUS = "Conveyor belt - quick assembly";
            tr1.FRFR = tr1.ENUS;

            tr2.ID = 10611 + bias;
            tr2.Name = "分拣器 快速组装";
            tr2.name = "分拣器 快速组装";
            tr2.ZHCN = "分拣器 快速组装";
            tr2.ENUS = "Sorter - quick assembly";
            tr2.FRFR = tr2.ENUS;


            tr3.ID = 10612 + bias;
            tr3.Name = "配电站 快速组装";
            tr3.name = "配电站 快速组装";
            tr3.ZHCN = "配电站 快速组装";
            tr3.ENUS = "Substation - quick assembly";
            tr3.FRFR = tr3.ENUS;


            tr4.ID = 10613 + bias;
            tr4.Name = "制造台 快速组装";
            tr4.name = "制造台 快速组装";
            tr4.ZHCN = "制造台 快速组装";
            tr4.ENUS = "Assembling machine - quick assembly";
            tr4.FRFR = tr4.ENUS;


            tr5.ID = 10614 + bias;
            tr5.Name = "位面熔炉 快速组装";
            tr5.name = "位面熔炉 快速组装";
            tr5.ZHCN = "位面熔炉 快速组装";
            tr5.ENUS = "Plane smelter - quick assembly";
            tr5.FRFR = tr5.ENUS;


            tr6.ID = 10615 + bias;
            tr6.Name = "化工厂 快速组装";
            tr6.name = "化工厂 快速组装";
            tr6.ZHCN = "化工厂 快速组装";
            tr6.ENUS = "Chemical plant - quick assembly";
            tr6.FRFR = tr6.ENUS;

            tr7.ID = 10616 + bias;
            tr7.Name = "精炼厂 快速组装";
            tr7.name = "精炼厂 快速组装";
            tr7.ZHCN = "精炼厂 快速组装";
            tr7.ENUS = "Refinery - quick assembly";
            tr7.FRFR = tr7.ENUS;

            tr8.ID = 10617 + bias;
            tr8.Name = "对撞机 快速组装";
            tr8.name = "对撞机 快速组装";
            tr8.ZHCN = "对撞机 快速组装";
            tr8.ENUS = "Collider - quick assembly";
            tr8.FRFR = tr8.ENUS;

            tr9.ID = 10618 + bias;
            tr9.Name = "研究站 快速组装";
            tr9.name = "研究站 快速组装";
            tr9.ZHCN = "研究站 快速组装";
            tr9.ENUS = "Lab - quick assembly";
            tr9.FRFR = tr9.ENUS;

            tr10.ID = 10619 + bias;
            tr10.Name = "人造恒星 快速组装";
            tr10.name = "人造恒星 快速组装";
            tr10.ZHCN = "人造恒星 快速组装";
            tr10.ENUS = "Artificial star - quick assembly";
            tr10.FRFR = tr10.ENUS;

            tr11.ID = 10620 + bias;
            tr11.Name = "行星内物流 快速组装";
            tr11.name = "行星内物流 快速组装";
            tr11.ZHCN = "行星内物流 快速组装";
            tr11.ENUS = "Planetary logistics - quick assembly";
            tr11.FRFR = tr11.ENUS;

            tr12.ID = 10621 + bias;
            tr12.Name = "星际物流 快速组装";
            tr12.name = "星际物流 快速组装";
            tr12.ZHCN = "星际物流 快速组装";
            tr12.ENUS = "Interstellar logistics - quick assembly";
            tr12.FRFR = tr12.ENUS;

            tr13.ID = 10622 + bias;
            tr13.Name = "快速组装描述";
            tr13.name = "快速组装描述";
            tr13.ZHCN = "使用多功能集成组件快速递组装成目标物品。";
            tr13.ENUS = "Quickly assemble target items using multi-functional integrated components.";
            tr13.FRFR = tr13.ENUS;

            //tr14.ID = 10623 + bias;
            //tr14.Name = "快速组装描述";
            //tr14.name = "快速组装描述";
            //tr14.ZHCN = "使用多功能集成组件快速递组装成目标物品。";
            //tr14.ENUS = "Quickly assemble target items using multi-functional integrated components.";
            //tr14.FRFR = tr14.ENUS;

            //tr15.ID = 10624 + bias;
            //tr15.Name = "组件集成装置";
            //tr15.name = "组件集成装置";
            //tr15.ZHCN = "组件集成装置";
            //tr15.ENUS = "Component integration station";
            //tr15.FRFR = tr15.ENUS;

            //tr16.ID = 10625 + bias;
            //tr16.Name = "组件集成装置描述";
            //tr16.name = "组件集成装置描述";
            //tr16.ZHCN = "将星际组装厂的高集成配件进行预解压，形成可被快速组装的多功能集成组件。";
            //tr16.ENUS = "Pre-decompress the high-integration parts from the Interstellar assembly, to form multi-functional integrated components that can be quickly assembled.";
            //tr16.FRFR = tr16.ENUS;

            //tr17.ID = 10626 + bias;
            //tr17.Name = "多功能集成组件";
            //tr17.name = "多功能集成组件";
            //tr17.ZHCN = "多功能集成组件";
            //tr17.ENUS = "Multi-functional integrated components";
            //tr17.FRFR = tr17.ENUS;

            //tr18.ID = 10627 + bias;
            //tr18.Name = "多功能集成组件描述";
            //tr18.name = "多功能集成组件描述";
            //tr18.ZHCN = "超高集成度使其可以迅速地组装成多种生产建筑和物流组件，却仅占用极小的空间。";
            //tr18.ENUS = "The high level of integration makes it possible to quickly assemble a variety of production building and logistics components, while occupying very little space.";
            //tr18.FRFR = tr18.ENUS;

            //tr19.ID = 10628 + bias;
            //tr19.Name = "科学枢纽运载火箭";
            //tr19.name = "科学枢纽运载火箭";
            //tr19.ZHCN = "科学枢纽运载火箭";
            //tr19.ENUS = "Science nexus carrier rocket";
            //tr19.FRFR = tr19.ENUS;

            //tr20.ID = 10629 + bias;
            //tr20.Name = "科学枢纽运载火箭描述";
            //tr20.name = "科学枢纽运载火箭描述";
            //tr20.ZHCN = "科学枢纽相关组件的运载工具。";
            //tr20.ENUS = "The delivery vehicle for the components of the Science nexus.";
            //tr20.FRFR = tr20.ENUS;

            LDBTool.PreAddProto(tr1);
            LDBTool.PreAddProto(tr2);
            LDBTool.PreAddProto(tr3);
            LDBTool.PreAddProto(tr4);
            LDBTool.PreAddProto(tr5);
            LDBTool.PreAddProto(tr6);
            LDBTool.PreAddProto(tr7);
            LDBTool.PreAddProto(tr8);
            LDBTool.PreAddProto(tr9);
            LDBTool.PreAddProto(tr10);
            LDBTool.PreAddProto(tr11);
            LDBTool.PreAddProto(tr12);
            LDBTool.PreAddProto(tr13);
            //LDBTool.PreAddProto(tr14);
            //LDBTool.PreAddProto(tr15);
            //LDBTool.PreAddProto(tr16);
            //LDBTool.PreAddProto(tr17);
            //LDBTool.PreAddProto(tr18);
            //LDBTool.PreAddProto(tr19);
            //LDBTool.PreAddProto(tr20);
        }


        /// <summary>
        /// 用于在接收器面板显示的文本修正，因为并非总是生成光子
        /// </summary>
        /// <param name="proto"></param>
        public static void ChangeReceiverRelatedStringProto(Proto proto)
        {
            if (proto is StringProto) //光子生成
            {
                if (proto.ID == 1264)
                {
                    var item = proto as StringProto;
                    item.ZHCN = "物质合成";
                    item.ENUS = "Substance generation";
                    item.FRFR = "Substance generation";
                }

                else if (proto.ID == 1265 || proto.ID == 1369)
                {
                    var item = proto as StringProto;
                    item.ZHCN = "在物质合成模式下，接收站将允许接收巨构建筑的输出，并将其转换为对应物质。";
                    item.ENUS = "In Substance generation mode, the receiver will receive product delivered by the megastructure and convert it into the corresponding item.";
                    item.FRFR = "In Substance generation mode, the receiver will receive product delivered by the megastructure and convert it into the corresponding item.";
                }

                else if (proto.ID == 1187)
                {
                    var item = proto as StringProto;
                    item.ZHCN = "打开巨构建筑面板，制定巨构建筑的建造规划。";
                    item.ENUS = "Turn on the Megastructure editor, and make a build plan.";
                    item.FRFR = "Turn on the Megastructure editor, and make a build plan.";
                }

                else if (proto.ID == 1186) //左下角戴森球编辑器按钮
                {
                    var item = proto as StringProto;
                    item.ZHCN = "巨构建筑 (Y)";
                    item.ENUS = "Megastructure (Y)";
                    item.FRFR = "Megastructure (Y)";
                }

                else if (proto.ID == 1167) //戴森球计划 (8)   这是建造栏的标签
                {
                    var item = proto as StringProto;
                    item.ZHCN = "巨构建筑 (8)";
                    item.ENUS = "Megastructure (8)";
                    item.FRFR = "Megastructure (8)";
                }

                else if (proto.ID == 1416) //统计面板
                {
                    var item = proto as StringProto;
                    item.ZHCN = "巨构建筑";
                    item.ENUS = "Megastructure";
                    item.FRFR = "Megastructure";
                }

                else if (proto.ID == 7346) //修建时的tooltip
                {
                    var item = proto as StringProto;
                    item.ZHCN = "巨构节点";
                    item.ENUS = "Megastructure Node";
                    item.FRFR = "Megastructure Node";
                }

                else if (proto.ID == 7347) //修建时的tooltip
                {
                    var item = proto as StringProto;
                    item.ZHCN = "规划修建巨构建筑节点，点击该按钮可以选择节点的样式。";
                    item.ENUS = "Plan and build the Megastructure Node, click this button to choose the node style.";
                    item.FRFR = "Plan and build the Megastructure Node, click this button to choose the node style.";
                }

                else if (proto.ID == 7348) //修建时的tooltip
                {
                    var item = proto as StringProto;
                    item.ZHCN = "巨构壳面";
                    item.ENUS = "Megastructure Shell";
                    item.FRFR = "Megastructure Shell";
                }

                else if (proto.ID == 7349) //修建时的tooltip
                {
                    var item = proto as StringProto;
                    item.ZHCN = "若要规划一个巨构壳面，需要将相应的壳面用节点和框架规划成一个闭合的多边形。\n点击该按钮可以选择巨构壳面的样式进行修建规划。";
                    item.ENUS = "In order to Plan a Megastructure Shell, it is necessary to plan the corresponding shell as a closed polygon with nodes and frames.\nClick this button to choose the Megastructure Shell style.";
                    item.FRFR = item.ENUS;
                }

                else if (proto.ID == 394) //规划完在球上点击时的显示，由于太长把英文的Megastructure改成了Structure
                {
                    var item = proto as StringProto;
                    item.ZHCN = "巨构节点 # {0}-{1}";
                    item.ENUS = "Structure Node # {0}-{1}"; //Megastructure Node # {0}-{1}
                    item.FRFR = item.ENUS;
                }

                else if (proto.ID == 772) //
                {
                    var item = proto as StringProto;
                    item.ZHCN = "巨构框架 # {0}-{1}";
                    item.ENUS = "Structure Frame # {0}-{1}"; //Megastructure Frame # {0}-{1}
                    item.FRFR = item.ENUS;
                }

                else if (proto.ID == 773) //
                {
                    var item = proto as StringProto;
                    item.ZHCN = "巨构壳面 # {0}-{1}";
                    item.ENUS = "Structure Shell # {0}-{1}"; //Megastructure Shell # {0}-{1}
                    item.FRFR = item.ENUS;
                }


                /*
                if (((StringProto)proto).ZHCN.Length >= 5 && ((StringProto)proto).ZHCN.Substring(0,5) == "戴森球节点")
                {
                    Console.WriteLine($"戴森球节点id={proto.ID},name={proto.name}, eng = {((StringProto)proto).ENUS}");
                }
                */
                
                
            }

        }

    }
}
