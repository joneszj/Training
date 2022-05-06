using System;
using System.Collections.Generic;

namespace Class
{
    class Program
    {
        static void Main(string[] args)
        {
            // Class is likely to be the most common type construct you will use
            // Out of the other non-data reference and value type constructs, this is the most common
            // A class can be, anything that can be modeled as a thing with state and behavior
            // Besides possibly the philosophical concept of absolute noting, everything else in theory could be modeled in a class
            // Read the classes below that are a simplified modeling of a music player
        }

        class MusicPlayer
        {
            public IEnumerable<Song> Library { get; set; }
            public Song SelectedSong { get; set; }
            public void Play() { }
            public void Pause() { }
            public void Resume() { }
            public void Next() { }
            public void Back() { }
            public void Shuffle() { }
            public void Exit() { }
        }

        class Song
        {
            public string Name { get; set; }
            public int LengthInSeconds { get; set; }
            public IEnumerable<Artist> Group { get; set; }
            public string Album { get; set; }
            public string VideoUrl { get; set; }
        }

        class Artist
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public DateTime DateOfBirth { get; set; }
            public DateTime? DateOfDeath { get; set; }
            public IEnumerable<Instrument> Instruments { get; set; }
            public bool IsSinger { get; set; }
            public string Biography { get; set; }
        }

        class Instrument
        {
            public string Name { get; set; }
        }
    }
}
