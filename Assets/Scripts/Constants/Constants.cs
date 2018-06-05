//Put magic numbers and strings here.

namespace Isopods.Constants
{
    public static class PLAYER_CONST
    {
        public const string PLAYER_TAG = "Player";
        public const float JUMP_FORCE = 5000f;
        public const float TOP_SPEED = 5.0f;
        public const float SNAIL_JUMP_BONUS = 1.6f;
        public const float MAX_HEALTH = 100.0f;
    }

    public static class ENEMY_CONST
    {
        public const float DEFAULT_ENEMY_HEALTH = 25.0f;
        public const string ENEMY_TAG = "Enemy";
        public const string SNAIL_TAG = "Snail";
        public const float DEFAULT_COLLISION_DAMAGE = 10.0f;
    }

    public static class WEAPON_CONST
    {
        public static class BAZOOKA_CONSTANTS
        {
            public const float ROTATION_SPEED = 15.0f;
            public const float PROJECTILE_SPEED = 175.0f;
            public const float RELOAD_TIME = 2.0f;
            public const int MAX_AMMO = 5;
        }

        public static class ROCKET_CONSTANTS
        {
            public const float DEFAULT_ROCKET_DAMAGE = 25.0f;
            public const string ROCKET_TAG = "Rocket";
            public const float ROCKET_TIME_TO_LIVE = 3.0f;
        }
    }

    public static class LEVEL_CONST
    {
        public const string GROUND_TAG = "Ground";
        public const string END_LEVEL_FLAG_TAG = "Flag";
        public const string WATER_TAG = "Water";
    }

    public static class NPC_CONST
    {
        public const string JUMP_NPC_MESSAGE = "Press the spacebar to jump!";
    }
}