﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreEntity
{
  public   class MyAddressee
    {
        public Guid ID { get; set; }

        //收件人
        [Display(Name = "收件人")]
        [Required(ErrorMessage = "收件人不能为空")]
        public string AddressPerson { get; set; }

        //地址
        [Display(Name = "收货地址")]
        [Required(ErrorMessage = "地址不能为空")]
        public string Address { get; set; }

        //手机号码
        [Display(Name = "手机号")]
        [Required(ErrorMessage = "手机号不能为空")]
        public string MobilNumber { get; set; }

        //邮政编码
        [Display(Name = "邮政编码")]
        [Required(ErrorMessage = "邮政编码不能为空")]
        public  string Email { get; set; }

        public MyAddressee()
        {
            ID = Guid.NewGuid();
        }

    }
}