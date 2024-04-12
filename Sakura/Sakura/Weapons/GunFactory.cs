namespace Sakura.Weapons;

public class GunFactory
{
    private IRandomService _randomService;

    public GunFactory(IRandomService randomService)
    {
        _randomService = randomService;
    }

    public Gun CreatePlasmaPistol()
    {
        return new Gun(new GunStats("Plasma Pistol", 2, 4, 10), _randomService);
    }

    public Gun CreateLightPlasmaRifle()
    {
        return new Gun(new GunStats("Light Plasma Rifle", 4, 6, 10), _randomService);
    }

    public Gun CreatePlasmaRifle()
    {
        return new Gun(new GunStats("Plasma Rifle", 6, 8, 10), _randomService);
    }
}