﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HotelRest.Models
{
    public class Adresse
    {
        [ForeignKey("Hotel, Agence")]
        public int AdresseId { get; set; }
        public int Numero { get; set; }
        public string Rue { get; set; }
        public string Pays { get; set; }
        public string PositionGPS { get; set; }
        public string LieuDit { get; set; }
        public virtual Hotel Hotel { get; set; }
        public virtual Agence Agence { get; set; }
        public Adresse()
        {
            
        }

        public Adresse(int adresseId, int numero, string rue, string pays, string positionGPS, string lieuDit, Hotel hotel, Agence agence)
        {
            AdresseId = adresseId;
            Numero = numero;
            Rue = rue;
            Pays = pays;
            PositionGPS = positionGPS;
            LieuDit = lieuDit;
            Hotel = hotel;
            Agence = agence;
        }
    }
}