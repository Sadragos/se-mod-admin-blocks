using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Sandbox.Common;
using Sandbox.Common.ObjectBuilders;
using Sandbox.Game;
using Sandbox.Game.GameSystems.Conveyors;
using Sandbox.Game.Entities;
using Sandbox.Game.EntityComponents;
using Sandbox.Definitions;
using Sandbox.ModAPI.Ingame;
using Sandbox.ModAPI.Interfaces;

using VRage;
using VRage.Game;
using VRage.Game.Components;
using VRage.Game.ModAPI;
using VRage.Game.ObjectBuilders.Definitions;
using VRage.ObjectBuilders;
using VRage.Utils;
using VRageMath;
using VRage.Game.Entity;
using VRage.Voxels;
using VRage.ModAPI;

namespace DefenseTurrets
{
    [MyEntityComponentDescriptor(typeof(MyObjectBuilder_BatteryBlock), true, "AdminBattery")]
    public class AdminBattery : MyGameLogicComponent
    {

        MyBatteryBlock TerminalalBlock;

        public override void Init(MyObjectBuilder_EntityBase objectBuilder)
        {
            Entity.NeedsUpdate |= MyEntityUpdateEnum.EACH_100TH_FRAME;

            TerminalalBlock = Entity as MyBatteryBlock;
        }

        public override void UpdateBeforeSimulation100()
        {
            base.UpdateBeforeSimulation100();
            TerminalalBlock.CurrentStoredPower = TerminalalBlock.MaxStoredPower;
        }
    }
}