namespace Pokedex.Data
{
    public class UpdatePokemonRequest
    {
        public string Name { get; set; }
        public Type Type1 { get; set; }
        public Type? Type2 { get; set; }
        public uint Total => HP + Attack + Defense + SpAtk + SpDef + Speed;
        public uint HP { get; set; }
        public uint Attack { get; set; }
        public uint Defense { get; set; }
        public uint SpAtk { get; set; }
        public uint SpDef { get; set; }
        public uint Speed { get; set; }
        public uint Generation { get; set; }
        public bool Legendary { get; set; }
    }
}