using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Unbind
{
    public class UIManager : MonoBehaviour
    {
        public static bool menuOpened => Instance.activeMenu;

        private static UIManager Instance;

        private Dictionary<MenuType, Menu> menus;
        private Menu activeMenu;

        private void Start()
        {
            Instance = this;

            menus = new();
            foreach (Transform child in transform)
            {
                if (child.TryGetComponent(out Menu menu))
                    menus.Add(menu.type, menu);
            }
        }

        public static Menu OpenMenu(MenuType type, params object[] parameters)
        {
            if (Instance.activeMenu?.type == type) return null;

            Instance.activeMenu = Instance.menus[type];
            Instance.activeMenu.Open(parameters);
            return Instance.activeMenu;
        }

        public static void CloseMenu()
        {
            if (!Instance.activeMenu) return;
         
            Instance.activeMenu.Close();
            Instance.activeMenu = null;
        }
    }

    public enum MenuType
    {
        TraitSelectionMenu,
        PauseMenu,
    }
}
