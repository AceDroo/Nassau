// using Sakura.Actions;
// using Sakura.Units;
// using Sakura.Weapons;
//
// namespace Sakura.Enemies;
//
// public class EnemyFactory(GunFactory gunFactory, IRandomService randomService)
// {
//     public IUnit CreateSectoid()
//     {
//         var stats = new EnemyStats("Sectoid", 3, 10, 65, 0);
//         var plasmaPistol = gunFactory.CreatePlasmaPistol();
//
//         var sectoid = new Enemy(stats, plasmaPistol);
//         sectoid.AddCombatAction(new Shoot(sectoid, randomService));
//         sectoid.AddCombatAction(new MindMerge());
//         return sectoid;
//     }
//
//     public IUnit CreateThinMan()
//     {
//         var stats = new EnemyStats("Thin Man", 3, 15, 65, 0);
//         var lightPlasmaRifle = gunFactory.CreateLightPlasmaRifle();
//
//         var thinMan = new Enemy(stats, lightPlasmaRifle);
//         thinMan.AddCombatAction(new Shoot(thinMan, randomService));
//         thinMan.AddCombatAction(new SpitPoison(thinMan));
//         return thinMan;
//     }
//
//     public IUnit CreateSectoidCommander()
//     {
//         var stats = new EnemyStats("Sectoid Commander", 10, 90, 85, 20);
//         var plasmaPistol = gunFactory.CreatePlasmaPistol();
//         var sectoidCommander = new Enemy(stats, plasmaPistol);
//         sectoidCommander.AddCombatAction(new PsiAttack());
//         sectoidCommander.AddCombatAction(new Shoot(sectoidCommander, randomService));
//         sectoidCommander.AddCombatAction(new MindControl(sectoidCommander));
//         return sectoidCommander;
//     }
//
//     public IUnit CreateMuton()
//     {
//         var stats = new EnemyStats("Muton", 8, 10, 70, 10);
//         var plasmaRifle = gunFactory.CreatePlasmaRifle();
//
//         var muton = new Enemy(stats, plasmaRifle);
//         muton.AddCombatAction(new Shoot(muton, randomService));
//         muton.AddCombatAction(new Intimidate(muton, randomService));
//         return muton;
//     }
//
//     public IUnit CreateChrysallid()
//     {
//         var stats = new EnemyStats("Chrysallid", 8, 120, 0, 10);
//         var claws = new Claws(10);
//         var chrysallid = new Enemy(stats, claws);
//         return chrysallid;
//     }
// }