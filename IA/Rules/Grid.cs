﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IA.Rules
{
    class Grid
    {
        public Grid(List<Pawn> pawns)
        {
            Pawns = pawns;
        }

        public Grid()
        {
            Pawns = new List<Pawn>();
        }

        public Grid(int ourIndex, int theirIndex, int[,] mapCoords)
        {
            Pawns = new List<Pawn>();

            for (int i = 0; i < mapCoords.GetLength(0); i++)
            {
                char type;
                int quantity;
                Coord currentCoords = new Coord(mapCoords[i, 0], mapCoords[i, 1]);

                if (mapCoords[i, 2] != 0)
                {
                    type = Config.HUM;
                    quantity = mapCoords[i, 2];
                } else if (mapCoords[i, ourIndex] != 0)
                {
                    type = Config.US;
                    quantity = mapCoords[i, ourIndex];
                } else
                {
                    type = Config.THEM;
                    quantity = mapCoords[i, theirIndex];
                }

                Pawns.Add(new Pawn(type, quantity, currentCoords));
            }
        }

        public void Add(Pawn p)
        {
            Pawns.Add(p);
        }

        public Pawn _getInCoord(Coord c)
        {
            ///<summary>
            ///Renvoie ce qu'il y a dans une case, envoie pawn(h , 0 ,coord) par défaut
            ///</summary>
            foreach (var p in Pawns)
            {
                if (c.Equals(p._coordinates))
                {
                    return p;
                }
            }
            return new Pawn('h', 0, c);
        }

        public void _setQuantityInCoord(Coord c,int quantity)
        {
            ///<summary>
            ///Renvoie ce qu'il y a dans une case, envoie pawn(h , 0 ,coord) par défaut
            ///</summary>
            foreach (var p in Pawns)
            {
                if (c.Equals(p._coordinates))
                {
                    Pawns.Remove(p);
                    Pawns.Add(new Pawn(p._type, quantity, p._coordinates));
                    return;
                }
            }
            //TODO: Throw exception, not supposed to be here
        }
        public void Move(Pawn p, Coord c)
        {
            // TODO
        }

        public List<Pawn> Pawns { get; private set; }
    }
}