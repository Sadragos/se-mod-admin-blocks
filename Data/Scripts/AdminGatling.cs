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
using Sandbox.ModAPI;
using Sandbox.ModAPI.Ingame;
using Sandbox.ModAPI.Interfaces;

using VRage;
using VRage.Game;
using VRage.Game.Components;
using VRage.Game.ModAPI;
using VRage.Game.ObjectBuilders.Definitions;
using VRage.ModAPI;
using VRage.ObjectBuilders;
using VRage.Utils;
using VRageMath;
using VRage.Game.Entity;
using VRage.Voxels;

namespace UnstableBlocks
{
    [MyEntityComponentDescriptor(typeof(MyObjectBuilder_LargeGatlingTurret), true, "AdminGatlingTurret")]
    public class AdminGatlingTurret : MyGameLogicComponent
    {

        Sandbox.ModAPI.IMyTerminalBlock TerminalalBlock;

        public override void Init(MyObjectBuilder_EntityBase objectBuilder)
        {
            Entity.NeedsUpdate |= MyEntityUpdateEnum.EACH_100TH_FRAME;

            TerminalalBlock = Entity as Sandbox.ModAPI.IMyTerminalBlock;
        }

        public override void UpdateBeforeSimulation100()
        {
            base.UpdateBeforeSimulation100();


            IMyInventory inventory = ((Sandbox.ModAPI.IMyTerminalBlock)Entity).GetInventory(0) as IMyInventory;
            if(inventory.ItemCount < 1)
            {
                MyObjectBuilder_AmmoMagazine builder = new MyObjectBuilder_AmmoMagazine() { SubtypeName = "NATO_25x184mm" };
                inventory.AddItems((MyFixedPoint)1, builder);
            }


            TerminalalBlock.RefreshCustomInfo();
            
        }

    }
}