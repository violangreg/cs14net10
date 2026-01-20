namespace Packt.Shared;

[Flags]
public enum WondersOfTheAncientWorld : byte
{
    None = 0b_0000_0000,
    GreatPyramidOfGiza = 0b_0000_0001,
    HangingGardensOfBabylon = 0b_0000_0010,
    StatueOfZeusAtOlympia = 0b_0000_0100,
    TempleOfArtemisAtEphesus = 0b_0000_1000,
    MausoleumAtHalicarnassus = 0b_0001_0000,
    ColossusOfRhodes = 0b_0010_0000,
    LighthouseOfAlexandria = 0b_0100_0000,
}

// Flags attribute allows bitwise operations on the enum values
// Each wonder is represented by a unique bit in a byte
// This allows combining multiple wonders using bitwise OR
// Example: HangingGardensOfBabylon | MausoleumAtHalicarnassus
// byte gives a maximum of 8 unique values (0-7)
// ushort would allow 16 unique values (0-15)
// uint would allow 32 unique values (0-31)
// ulong would allow 64 unique values (0-63)
