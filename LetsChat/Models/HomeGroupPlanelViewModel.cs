﻿using LetsChat.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LetsChat.Models
{
    public class HomeGroupPlanelViewModel : BaseViewModel
    {
       
        
        public virtual List<Channel> Channels { get; set; }
      
    }
}
