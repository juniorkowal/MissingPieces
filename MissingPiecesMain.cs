using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.Reflection;
using System.Text.RegularExpressions;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using Jotunn.Managers;
using UnityEngine;


namespace MissingPieces
{
	[BepInPlugin(PLUGIN_GUID, PLUGIN_NAME, PLUGIN_VERSION)]
	[BepInDependency("com.jotunn.jotunn", "2.10.0")]
	public class MissingPiecesMain : BaseUnityPlugin
	{
		internal const string PLUGIN_NAME = "MissingPieces";
		internal const string PLUGIN_GUID = "juniorkowal." + PLUGIN_NAME;
		internal const string PLUGIN_VERSION = "1.0.0";

		private static ManualLogSource _logger;
		private static Regex PrefabNameRegex = new Regex("([a-z])([A-Z])");
		private static Piece.PieceCategory _prefabPieceCategory;
		private static Sprite _standardPrefabIconSprite;
		private static Quaternion _prefabIconRenderRotation = Quaternion.Euler(0f, -45f, 0f);
		public static bool _debug;
		public static bool IsDropTableDisabled { get; set; } = false;

		private Harmony _harmony;

		public void Awake()
		{
			_logger = Logger;
			PluginConfig.BindConfig(Config);
			_harmony = Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly(), PLUGIN_GUID);
			_prefabPieceCategory = PieceManager.Instance.AddPieceCategory("_HammerPieceTable", "Other");
		}

		public void OnDestroy()
		{
			_harmony?.UnpatchSelf();
		}

		public static IEnumerator AddPieces()
		{
			yield return AddHammerPieces(GetPieceTable("_HammerPieceTable"));
		}

		private static IEnumerator AddHammerPieces(PieceTable pieceTable)
		{
			if (!pieceTable)
			{
				_logger.LogError($"Could not find HammerPieceTable!");
				yield break;
			}
			_standardPrefabIconSprite = _standardPrefabIconSprite ??= CreateColorSprite(new Color32(34, 132, 73, 64));
			_prefabIconRenderRotation = Quaternion.Euler(0f, -45f, 0f);
			foreach (KeyValuePair<string, Dictionary<string, int>> item in Requirements.hammerCreatorShopItems.OrderBy((KeyValuePair<string, Dictionary<string, int>> o) => o.Key).ToList())
			{
				GetOrAddPieceComponent(item.Key, pieceTable).SetResources(CreateRequirements(item.Value)).SetCategory(_prefabPieceCategory).SetCraftingStation(GetCraftingStation(item.Key))
					.SetCanBeRemoved(canBeRemoved: true)
					.SetTargetNonPlayerBuilt(canTarget: false);
			}
		}

		private static Piece.Requirement[] CreateRequirements(Dictionary<string, int> data)
		{
			Piece.Requirement[] array = new Piece.Requirement[data.Count];
			for (int i = 0; i < data.Count; i++)
			{
				KeyValuePair<string, int> keyValuePair = data.ElementAt(i);
				Piece.Requirement requirement = new Piece.Requirement();
				requirement.m_resItem = PrefabManager.Cache.GetPrefab<GameObject>(keyValuePair.Key).GetComponent<ItemDrop>();
				requirement.m_amount = keyValuePair.Value;
				array[i] = requirement;
			}
			return array;
		}

		static PieceTable GetPieceTable(string pieceTableName) 
		{
		return ObjectDB.m_instance.Ref()?.m_items
          .Select(item => item.GetComponent<ItemDrop>().Ref()?.m_itemData?.m_shared?.m_buildPieces)
          .Where(table => table.Ref()?.name == pieceTableName)
          .FirstOrDefault();
		}

		static Piece GetExistingPiece(string prefabName)
		{
			return ZNetScene.m_instance.Ref()?.GetPrefab(prefabName).Ref()?.GetComponent<Piece>();
		}

		private static Piece GetOrAddPieceComponent(string prefabName, PieceTable pieceTable)
		{
			GameObject prefab = ZNetScene.instance.GetPrefab(prefabName);
			if (!prefab.TryGetComponent(out Piece piece))
			{
				piece = prefab.AddComponent<Piece>();
				piece.m_name = FormatPrefabName(prefab.name);

				SetPlacementRestrictions(piece);
			}
			Piece piece2 = piece;
			if (piece2.m_icon == null)
			{
				piece2.m_icon = LoadOrRenderIcon(prefab, _prefabIconRenderRotation, _standardPrefabIconSprite);
			}
			if (!pieceTable.m_pieces.Contains(prefab))
			{
				pieceTable.m_pieces.Add(prefab);
				ZLog.Log($"Added Piece {piece.m_name} to PieceTable {pieceTable.name}");
			}

			piece.m_description = prefab.name;

			return piece;
		}

		private static string FormatPrefabName(string prefabName)
		{
			return PrefabNameRegex.Replace(prefabName, "$1 $2").TrimStart(' ').Replace('_', ' ')
				.Replace("  ", " ");
		}

		static Sprite LoadOrRenderIcon(GameObject prefab, Quaternion renderRotation, Sprite defaultSprite)
		{
			RenderManager.RenderRequest request = new(prefab)
			{
				Rotation = renderRotation,
			};

			return RenderManager.Instance.Render(request).Ref() ?? defaultSprite;
		}

		private static Piece SetPlacementRestrictions(Piece piece)
		{
			piece.m_repairPiece = false;
			piece.m_groundOnly = false;
			piece.m_groundPiece = false;
			piece.m_cultivatedGroundOnly = false;
			piece.m_waterPiece = false;
			piece.m_noInWater = false;
			piece.m_notOnWood = false;
			piece.m_notOnTiltingSurface = false;
			piece.m_inCeilingOnly = false;
			piece.m_notOnFloor = false;
			piece.m_onlyInTeleportArea = false;
			piece.m_allowedInDungeons = false;
			piece.m_clipEverything = true;
			return piece;
		}

		static Sprite CreateColorSprite(Color color)
		{
			Texture2D texture = new(1, 1);
			texture.SetPixel(0, 0, color);
			texture.Apply();

			return Sprite.Create(texture, new(0, 0, 1, 1), Vector2.zero);
		}

		public static void LogMessage(string message)
		{
			if (_debug)
			{
				_logger.LogMessage(message);
			}
		}

		public static bool IsCreatorShopPiece(Piece piece)
		{
			if (Requirements.hammerCreatorShopItems.Keys.Contains(piece.m_description))
			{
				return true;
			}
			return false;
		}

		public static bool IsDestructibleCreatorShopPiece(string prefabName)
		{
			if (Requirements.hammerCreatorShopItems.Keys.Contains(prefabName))
			{
				return true;
			}
			return false;
		}

		public static bool IsDestructibleCreatorShopPiece(Piece piece)
		{
			if (Requirements.hammerCreatorShopItems.Keys.Contains(piece.m_description))
			{
				return true;
			}
			return false;
		}

		public static bool IsBuildHammerItem(string prefabName)
		{
			if (Requirements.hammerCreatorShopItems.Keys.Contains(prefabName))
			{
				return true;
			}
			return false;
		}

		public static bool HasCraftingStationRequirement(string prefabName)
		{
			if (Requirements.craftingStationRequirements.Keys.Contains(prefabName))
			{
				return true;
			}
			return false;
		}

		public static CraftingStation GetCraftingStation(string prefabName)
		{
			if (Requirements.craftingStationRequirements.ContainsKey(prefabName))
			{
				return PrefabManager.Instance
					.GetPrefab(Requirements.craftingStationRequirements[prefabName])
					.GetComponent<CraftingStation>();
			}
			return null;
		}
	}
}
