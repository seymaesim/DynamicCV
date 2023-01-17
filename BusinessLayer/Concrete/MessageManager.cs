using BusinessLayer.Abstract;
using DataAccesLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class MessageManager : IMessageService
    {
        IMessageDAL _messageDAL;

        public MessageManager(IMessageDAL messageDAL)
        {
            _messageDAL = messageDAL;
        }

        public void T_Add(Message t)
        {
            _messageDAL.Insert(t);
        }

        public void T_Delete(Message t)
        {
            _messageDAL.Delete(t);
        }

        public Message T_GetByID(int id)
        {
            return _messageDAL.GetByID(id);
        }

        public List<Message> T_GetList()
        {
           return _messageDAL.GetList();
        }

        public void T_Update(Message t)
        {
            _messageDAL.Update(t);
        }
    }
}
