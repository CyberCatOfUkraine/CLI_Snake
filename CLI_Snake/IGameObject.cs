namespace CLI_Snake
{
    interface IGameObject
    {
        Point Position { get; set; }

        void Spawn();
    }
}
