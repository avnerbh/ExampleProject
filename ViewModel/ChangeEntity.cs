using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    /* return number of changed rows */
    public delegate int ExecuteChange(BaseEntity entity);

    public class ChangeEntity
    {
        private BaseEntity entity;
        private ExecuteChange executeChange;

        public ChangeEntity(BaseEntity entity, ExecuteChange executeChange)
        {
            this.entity = entity;
            this.executeChange = executeChange;
        }

        public BaseEntity Entity { get => entity; set => entity = value; }
        public ExecuteChange ExecuteChange { get => executeChange; set => executeChange = value; }

    }
}
