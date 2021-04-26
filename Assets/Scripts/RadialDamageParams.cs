// Information used to compute radial damage
public struct RadialDamageInfo
{
    float baseDamage; // Maximum possible damage
    float damageFalloff; // Describes amount of exponential damage falloff
    float innerRadius; // Within innerRadius, do max damage
    float minimumDamage; // Damage will not fall below this if in range
    float outerRadius; // Outside outerRadius, do no damage
}
