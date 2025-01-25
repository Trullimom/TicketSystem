﻿using TicketSystem.Models.Data;

namespace TicketSystem.Models
{
    public class MitarbeiterListe : ILoginDatenRepository
    {
        private readonly AnwendungsDbContext _context;

        public MitarbeiterListe(AnwendungsDbContext context)
        {
            _context = context;
        }

        public string CheckRolle(MitarbeiterDaten m)
        {
            if (m.UserName == "admin")
            {
                m.Rolle = "Admin";
                m.ViewName = "Admin";
            }
            else
            {
                m.ViewName = "AnfragenTabelle";
            }
            return m.ViewName;
        }
        public bool IstLoginKorrekt(MitarbeiterDaten m)
        {
            foreach (var daten in _context.LoginDaten)
            {
                if (daten.UserName == m.UserName && daten.Passwort == m.Passwort)
                {
                    return true;
                }
            }
            return false;
        }


        public void Add(MitarbeiterDaten md)
        {
            _context.LoginDaten.Add(md);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            MitarbeiterDaten mitarbeiter = _context.LoginDaten.Find(id);
            if (mitarbeiter != null)
            {
                _context.LoginDaten.Remove(mitarbeiter);
                _context.SaveChanges();
            }
        }

        public bool Exists(int id)
        {
            return _context.LoginDaten.Any(m => m.Id == id);
        }

        public List<MitarbeiterDaten> GetAll()
        {
            return _context.LoginDaten.ToList();
        }

        public MitarbeiterDaten GetById(int id)
        {
            return _context.LoginDaten.Find(id);
        }

       

    }
    }
