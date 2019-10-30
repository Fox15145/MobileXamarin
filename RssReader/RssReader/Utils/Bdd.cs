using System;
using SQLite;
using System.Collections.Generic;
using RssReader.Models;

namespace RssReader.Utils
{
    public class Bdd
    {
        public string Path { get; private set; }

        public Bdd(string path)
        {
            this.Path = path;
        }

        public void Save(RssSource rssSource)
        {
            using (var cnx = new SQLite.SQLiteConnection(Path))
            {
                // création de la table si elle n'existe pas
                cnx.CreateTable<RssReader.Models.RssSource>();

                //insertion de la données contenu dans l'objet au format de celui-ci
                cnx.Insert(rssSource);
            }
        }

        public IEnumerable<RssSource> GetAll()
        {
            using (var cnx = new SQLiteConnection(Path))
            {
                cnx.CreateTable<RssSource>();
                return cnx.Table<RssSource>().ToList();
            }

        }

        public RssSource GetById(long id)
        {
            using (var cnx = new SQLiteConnection(Path))
            {
                cnx.CreateTable<RssSource>();
                return cnx.Table<RssSource>().FirstOrDefault(i => i.Id == id);
            }

        }

        public void Delete(long id)
        {
            using (var cnx = new SQLiteConnection(Path))
            {
                cnx.CreateTable<RssSource>();
                cnx.Delete<RssSource>(id);
            }

        }
    }
}
