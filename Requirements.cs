using System.Collections.Generic;


public class Requirements
{
	public static readonly Dictionary<string, Dictionary<string, int>> hammerCreatorShopItems = new Dictionary<string, Dictionary<string, int>>
	{
		{
			"piece_dvergr_pole",
			new Dictionary<string, int>
			{
				{ "YggdrasilWood", 2 },
				{ "Copper", 1 }
			}
		},
		{
			"piece_dvergr_wood_door",
			new Dictionary<string, int>
			{
				{ "YggdrasilWood", 8 },
				{ "Copper", 8 }
			}
		},
		{
			"piece_dvergr_wood_wall",
			new Dictionary<string, int>
			{
				{ "YggdrasilWood", 6 },
				{ "Copper", 2 }
			}
		},
		{
			"dvergrprops_wood_wall",
			new Dictionary<string, int>
			{
				{ "YggdrasilWood", 8 },
				{ "Copper", 4 }
			}
		},
		{
			"dvergrtown_stair_corner_wood_left",
			new Dictionary<string, int>
			{
				{ "YggdrasilWood", 5 },
				{ "Copper", 2 }
			}
		},
		{
			"dvergrtown_wood_crane",
			new Dictionary<string, int>
			{
				{ "YggdrasilWood", 8 },
				{ "Copper", 2 },
				{ "Iron", 6 }
			}
		},
		{
			"dvergrtown_wood_wall03",
			new Dictionary<string, int>
			{
				{ "YggdrasilWood", 4 },
				{ "Copper", 1 }
			}
		},
		{
			"dvergrprops_hooknchain",
			new Dictionary<string, int>
			{
				{ "Copper", 4 },
				{ "Iron", 10 }
			}
		},
		{
			"dvergrprops_shelf",
			new Dictionary<string, int>
			{
				{ "YggdrasilWood", 8 },
				{ "Copper", 2 }
			}
		},
		{
			"dvergrprops_stool",
			new Dictionary<string, int>
			{
				{ "FineWood", 4 },
				{ "Copper", 1 }
			}
		},
		{
			"dvergrprops_table",
			new Dictionary<string, int>
			{
				{ "FineWood", 6 },
				{ "Copper", 1 }
			}
		},
		{
			"dvergrprops_wood_beam",
			new Dictionary<string, int> { { "YggdrasilWood", 6 } }
		},
		{
			"dvergrprops_wood_pole",
			new Dictionary<string, int>
			{
				{ "YggdrasilWood", 4 },
				{ "Copper", 2 }
			}
		},
		{
			"blackmarble_head_big01",
			new Dictionary<string, int> { { "BlackMarble", 4 } }
		},
		{
			"blackmarble_head_big02",
			new Dictionary<string, int> { { "BlackMarble", 4 } }
		},
		{
			"blackmarble_head01",
			new Dictionary<string, int>
			{
				{ "BlackMarble", 2 },
				{ "Copper", 1 }
			}
		},
		{
			"blackmarble_head02",
			new Dictionary<string, int>
			{
				{ "BlackMarble", 2 },
				{ "Copper", 1 }
			}
		},
		{
			"metalbar_1x2",
			new Dictionary<string, int> 
			{
				{ "BlackMarble", 4 },
				{ "Copper", 1 }
			}
		},
		{
			"blackmarble_post01",
			new Dictionary<string, int> { { "BlackMarble", 6 } }
		},
		{
			"dverger_demister",
			new Dictionary<string, int>
			{
				{ "Copper", 4 },
				{ "Wisp", 2 }
			}
		},
		{
			"dverger_demister_large",
			new Dictionary<string, int>
			{
				{ "Copper", 4 },
				{ "Wisp", 4 }
			}
		},
		// DOESN'T WORK FOR SOME REASON
		{
			"blackmarble_stair_corner",
			new Dictionary<string, int> { { "BlackMarble", 8 } }
		},
		// DOESN'T WORK FOR SOME REASON
		{
			"blackmarble_stair_corner_left",
			new Dictionary<string, int> { { "BlackMarble", 8 } }
		},      
		{
			"blackmarble_tile_floor_2x2",
			new Dictionary<string, int> { { "BlackMarble", 2 } }
		},
		{
			"blackmarble_tile_floor_1x1",
			new Dictionary<string, int> { { "BlackMarble", 1 } }
		},      
		{
			"blackmarble_2x2x1",
			new Dictionary<string, int> { { "BlackMarble", 6 } }
		},
		{
			"blackmarble_tile_wall_1x1",
			new Dictionary<string, int> { { "BlackMarble", 1 } }
		},
		{
			"blackmarble_tile_wall_2x2",
			new Dictionary<string, int> { { "BlackMarble", 2 } }
		},
		{
			"blackmarble_tile_wall_2x4",
			new Dictionary<string, int> { { "BlackMarble", 4 } }
		},
		{
			"blackmarble_slope_1x2",
			new Dictionary<string, int> { { "BlackMarble", 2 } }
		},
		{
			"blackmarble_slope_inverted_1x2",
			new Dictionary<string, int> { { "BlackMarble", 2 } }
		},
		{
			"blackmarble_2x2_enforced",
			new Dictionary<string, int>
			{
				{ "BlackMarble", 8 },
				{ "Copper", 4 }
			}
		},
		{
			"blackmarble_out_2",
			new Dictionary<string, int> { { "BlackMarble", 10 } }
		},
		{
			"blackmarble_column_3",
			new Dictionary<string, int> { { "BlackMarble", 32 } }
		},
		{
			"blackmarble_floor_large",
			new Dictionary<string, int> { { "BlackMarble", 128 } }
		},
		{
			"dvergrprops_wood_floor",
			new Dictionary<string, int> { { "YggdrasilWood", 2 } }
		},
		{
			"dvergrprops_wood_stair",
			new Dictionary<string, int> { { "YggdrasilWood", 2 } }
		},
		{
			"dvergrprops_chair",
			new Dictionary<string, int>
			{
				{ "FineWood", 4 },
				{ "Copper", 1 }
			}
		},
		{
			"dvergrprops_bed",
			new Dictionary<string, int>
			{ 
				{ "FineWood", 6 },
				{ "ScaleHide", 2 },
				{ "DeerHide", 4 },
				{ "Copper", 1 }
			}
		},
		{
			"dvergrprops_barrel",
			new Dictionary<string, int>
			{
				{ "MeadTasty", 1 },
				{ "FineWood", 1 },
				{ "Copper", 1 }
			}
		},
		{
			"dvergrprops_banner",
			new Dictionary<string, int> 
			{ 
				{ "JuteBlue", 1 },
				{ "Wood", 1 }
			}
		},
		{
			"dvergrprops_curtain",
			new Dictionary<string, int>
			{
				{ "JuteBlue", 2 },
				{ "Wood", 1 }
			}
		},
		{
			"trader_wagon_destructable",
			new Dictionary<string, int>
			{ 
				{ "FineWood", 3 },
				{ "YggdrasilWood", 5 }
			}
		},
		{
			"dverger_demister_broken",
			new Dictionary<string, int> { { "Copper", 4 } }
		},
		// STONE FLOOR
		{
			"stone_floor",
			new Dictionary<string, int> { { "Stone", 24 } }
		},
		// GOBLIN CAMP
		{
			"goblin_woodwall_2m",
			new Dictionary<string, int> { { "Wood", 3 } }
		},       
		{
			"goblin_woodwall_1m",
			new Dictionary<string, int> { { "Wood", 2 } }
		},       
		{
			"goblin_stepladder",
			new Dictionary<string, int> { { "Wood", 2 } }
		},       
		{
			"goblin_woodwall_2m_ribs",
			new Dictionary<string, int> { { "BoneFragments", 5 } }
		},
		{
			"goblin_stairs",
			new Dictionary<string, int> { { "Wood", 2 } }
		},
		{
			"goblin_roof_cap",
			new Dictionary<string, int> 
			{ 
				{ "Wood", 4 },
				{ "DeerHide", 4 }
			}
		},
		{
			"goblin_roof_45d",
			new Dictionary<string, int> { { "DeerHide", 2 } }
		},
		{
			"goblin_roof_45d_corner",
			new Dictionary<string, int> { { "DeerHide", 2 } }
		},
		{
			"goblin_pole",
			new Dictionary<string, int> { { "Wood", 2 } }
		},
		{
			"goblin_pole_small",
			new Dictionary<string, int> { { "Wood", 1 } }
		},  
		{
			"goblin_fence",
			new Dictionary<string, int> { { "Wood", 2 } }
		},
		{
			"goblin_banner",
			new Dictionary<string, int> 
			{
				{ "Wood", 1 },
				{ "DeerHide", 1 }
			}
		}
	};

	public static readonly Dictionary<string, string> craftingStationRequirements = new Dictionary<string, string>
	{
		{ "piece_dvergr_pole", "blackforge" },
		{ "piece_dvergr_wood_door", "blackforge" },
		{ "piece_dvergr_wood_wall", "blackforge" },
		{ "dvergrprops_wood_wall", "blackforge" },
		{ "dvergrtown_stair_corner_wood_left", "blackforge" },
		{ "dvergrtown_wood_crane", "blackforge" },
		{ "dvergrtown_wood_wall03", "blackforge" },
		{ "dvergrprops_hooknchain", "blackforge" },
		{ "dvergrprops_shelf", "blackforge" },
		{ "dvergrprops_stool", "blackforge" },
		{ "dvergrprops_table", "blackforge" },
		{ "dvergrprops_wood_beam", "blackforge" },
		{ "dvergrprops_wood_pole", "blackforge" },
		{ "blackmarble_head_big01", "piece_stonecutter" },
		{ "blackmarble_head_big02", "piece_stonecutter" },
		{ "blackmarble_head01", "blackforge" },
		{ "blackmarble_head02", "blackforge" },
		{ "metalbar_1x2", "blackforge" },
		{ "blackmarble_post01", "piece_stonecutter" },
		{ "dverger_demister", "blackforge" },
		{ "dverger_demister_large", "blackforge" },
		{ "blackmarble_stair_corner", "piece_stonecutter" },
		{ "blackmarble_stair_corner_left", "piece_stonecutter" },
		{ "blackmarble_tile_floor_2x2", "piece_stonecutter" },
		{ "blackmarble_tile_floor_1x1", "piece_stonecutter" },
		{ "blackmarble_2x2x1", "piece_stonecutter" },
		{ "blackmarble_tile_wall_1x1", "piece_stonecutter" },
		{ "blackmarble_tile_wall_2x2", "piece_stonecutter" },
		{ "blackmarble_tile_wall_2x4", "piece_stonecutter" },
		{ "blackmarble_slope_1x2", "piece_stonecutter" },
		{ "blackmarble_slope_inverted_1x2", "piece_stonecutter" },
		{ "blackmarble_2x2_enforced", "blackforge" },
		{ "blackmarble_out_2", "piece_stonecutter" },
		{ "blackmarble_column_3", "piece_stonecutter" },
		{ "blackmarble_floor_large", "piece_stonecutter" },
		{ "dvergrprops_wood_floor", "piece_workbench" },
		{ "dvergrprops_wood_stair", "piece_workbench" },
		{ "dvergrprops_chair", "blackforge" },
		{ "dvergrprops_bed", "blackforge" },
		{ "dvergrprops_barrel", "blackforge" },
		{ "dvergrprops_banner", "piece_workbench" },
		{ "dvergrprops_curtain", "piece_workbench" },
		{ "trader_wagon_destructable", "piece_workbench" },
		{ "dverger_demister_broken", "blackforge" },
		//stone floor
		{ "stone_floor", "blackforge" },
		//goblin camp
		{ "goblin_woodwall_2m", "piece_workbench" },
		{ "goblin_woodwall_1m", "piece_workbench" },
		{ "goblin_stepladder", "piece_workbench" },
		{ "goblin_woodwall_2m_ribs", "piece_workbench" },
		{ "goblin_stairs", "piece_workbench" },
		{ "goblin_roof_cap", "piece_workbench" },
		{ "goblin_roof_45d", "piece_workbench" },
		{ "goblin_roof_45d_corner", "piece_workbench" },
		{ "goblin_pole", "piece_workbench" },
		{ "goblin_pole_small", "piece_workbench" },
		{ "goblin_fence", "piece_workbench" },
		{ "goblin_banner", "piece_workbench" },
	};
}