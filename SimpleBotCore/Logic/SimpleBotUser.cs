using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Driver;
using MongoDB.Bson;

namespace SimpleBotCore.Logic
{
      public class SimpleBotUser
    {
        
        public string Reply(SimpleMessage message)
        {
            SalvarMsg(message);

            return $"{message.User} disse '{message.Text}' (mensagens enviadas)";

        }

        public void SalvarMsg(SimpleMessage message)
        {
            var cliente = new MongoClient("mongodb://localhost:27017");

            var db = cliente.GetDatabase("DesafioSalvarHistorico");

            var col = db.GetCollection<BsonDocument>("colMensagem");

            var doc = new BsonDocument() {
                { "Usuario", message.User },
                { "Mensagem", message.Text }
            };

            col.InsertOne(doc);

        }


        public void Consultar(SimpleMessage message)
        {



        }

    }
}