using App.Scripts.Gameplay.Windows;
using App.Scripts.Utils;
using Cysharp.Threading.Tasks;
using Scenes.App.Scripts.Gameplay.Battle;
using Scenes.App.Scripts.Gameplay.Factory;
using Scenes.App.Scripts.Gameplay.UnitRegistryImpl;
using Scenes.App.Scripts.Gameplay.Units;
using Scenes.App.Scripts.Gameplay.Units.Config;
using UnityEngine;
using Zenject;

namespace App.Scripts.Gameplay
{
  public class GameLoop : ITickable
  {
    private readonly IBattleConductor _battleConductor;
    private readonly IUnitRegistry _unitRegistry;
    private readonly IUnitFactory _unitFactory;
    private readonly IWindowRouter _windowRouter;
    private readonly UnitsConfig _unitsConfig;
    
    private readonly Vector2 _leftUnitPosition = new Vector2(-5, -2);
    private readonly Vector2 _rightUnitPosition = new Vector2(5, -2);
    private readonly Vector2 _centre = Vector2.zero;

    private int WinBattlesCount; 
    private Player _player;
    private Enemy _enemy;
    

    public GameLoop(IBattleConductor battleConductor, IUnitRegistry unitRegistry, 
      IUnitFactory unitFactory, IWindowRouter windowRouter, UnitsConfig unitsConfig)
    {
      _battleConductor = battleConductor;
      _unitRegistry = unitRegistry;
      _unitFactory = unitFactory;
      _windowRouter = windowRouter;
      _unitsConfig = unitsConfig;
    }

    public void Tick()
    {
      if (_battleConductor.IsBattleStarted && _battleConductor.IsBattleEnded)
      {
        _battleConductor.Reset();

        if (_battleConductor.IsBattleWin)
          WinBattle().Forget();
        else
          LooseBattle().Forget();
      }
    }
    
    public async UniTaskVoid StartGame()
    {
      ResetWinBattlesCount();
      UnitType playerType = await _windowRouter.ChooseUnitWindow.ShowAndSetup(UnitTypes.Player);

      SpawnPlayer(playerType);
      SpawnRandomEnemy();
      
      _battleConductor.Reset();
      _battleConductor.Start();
    }

    private async UniTaskVoid LooseBattle()
    {
      _unitRegistry.RemovePlayer();
      await LooseWindow();
        
      _unitRegistry.Cleanup();
      StartGame().Forget();
    }

    private async UniTaskVoid WinBattle()
    {
      WinBattlesCount++;
      _unitRegistry.RemoveEnemy();

      if (GameCompleted())
      {
        await GameEndWindow();
        Application.Quit();
      }

      await BattleWinWindow();
      
      if (await NeedChangeWeapon()) 
        _player.SetWeapon(_unitsConfig.Enemies[_enemy.UnitType].RewardWeapon);
      
      if(_player.Level < 3)
        _unitFactory.UpdatePlayerLevel(await NextPlayerType(), _player);
      
      _player.Health.SetCurrentHealth(_player.Health.MaxHealth);
      
      SpawnRandomEnemy();
      _battleConductor.Start();
    }

    private bool GameCompleted() => WinBattlesCount >= 5;
    private void ResetWinBattlesCount() => WinBattlesCount = 0;
    
    private void SpawnPlayer(UnitType playerType) => _player = _unitFactory.CreatePlayer(playerType, at: _leftUnitPosition, lookTo: _centre);
    private void SpawnRandomEnemy()
    {
      UnitType enemyType = UnitTypes.Enemy.PickRandom();
      _enemy = _unitFactory.CreateEnemy(enemyType, at: _rightUnitPosition, lookTo: _centre);
    }

    private UniTask<bool> GameEndWindow() => _windowRouter.GameWinWindow.SetupAndShow();
    private UniTask<bool> BattleWinWindow() => _windowRouter.BattleWinWindow.SetupAndShow();
    private UniTask<bool> LooseWindow() => _windowRouter.LooseWindow.SetupAndShow();
    private UniTask<UnitType> NextPlayerType() => _windowRouter.ChooseUnitWindow.ShowAndSetup(UnitTypes.Player);
    private UniTask<bool> NeedChangeWeapon() => _windowRouter.ChangeWeaponWindow.SetupAndShow(_unitsConfig.Enemies[_enemy.UnitType].RewardWeapon);
  }
}