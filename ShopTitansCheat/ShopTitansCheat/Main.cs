﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Riposte;
using ShopTitansCheat.Components;
using ShopTitansCheat.Utils;
using UnityEngine;

namespace ShopTitansCheat
{
    class Main : MonoBehaviour
    {
        private int _frame;

        private Menu _menu;
        private CraftingComponent _craftingComponent;
        private AutoSellComponent _autoSellComponent;
        private MiscComponent _miscComponent;

        private void Start()
        {
            _menu = Game.Instance.gameObject.AddComponent<Menu>();
           // Game.Scheduler.Register(Scheduler.Priority.BeginFrame, Update);

            _craftingComponent = new CraftingComponent();
            _autoSellComponent = new AutoSellComponent();
            _miscComponent = new MiscComponent();
        }

        private void FixedUpdate()
        {
            if (!Game.IsActivePlayState)
                return;

            _frame++;

            if (Settings.Crafting.DoCrafting)
            {
                Crafting();
                StoreCrafted();
            }

            if (_frame % 66 == 0)
            {
                //Something else
            }

            if (_frame % 111 == 0)
            {
                //another thing
            }

            if (_frame % 77 == 0)
            {
                //another another thing.
            }
        }

        private void StoreCrafted()
        {
            
        }

        private void Crafting()
        {
            if (_frame % 9 == 0)
            {
                if (Settings.Crafting.RegularCrafting)
                {
                    _craftingComponent.Craft();
                    Settings.Crafting.DoCrafting = false;
                    StartCoroutine(WaitThenStart(20));
                }
                else
                {
                    if (_craftingComponent.GlitchCraft())
                    {
                        Settings.Crafting.DoCrafting = false;
                        Resources.UnloadUnusedAssets();
                        GC.Collect();
                        Log.PrintConsoleMessage("We are waiting 20 seconds.", ConsoleColor.Blue);
                        StartCoroutine(WaitThenStart(20));
                    }
                    else
                    {
                        Settings.Crafting.DoCrafting = false;
                        StartCoroutine(WaitThenStart(0.1f));
                    }
                }
            }
        }

        private IEnumerator WaitThenStart(float seconds)
        {

            yield return new WaitForSeconds(seconds);
            Settings.Crafting.DoCrafting = true;
        }
    }
}
