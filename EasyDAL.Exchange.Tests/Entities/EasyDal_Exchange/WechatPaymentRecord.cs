﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EasyDAL.Exchange.Tests.Entities.EasyDal_Exchange
{
    /*
     *CREATE TABLE `wechatpaymentrecord` (
     * `Id` char(36) NOT NULL,
     * `CreatedOn` datetime(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6),
     * `PaymentBillId` char(36) NOT NULL,
     * `Amount` double NOT NULL,
     * `PaymentTime` datetime(6) NOT NULL,
     * `WechatpayTradeNo` longtext
     * ) ENGINE=InnoDB DEFAULT CHARSET=utf8
     */
    [Table("WechatPaymentRecord")]
    public class WechatPaymentRecord 
    {

        public DateTime CreatedOn { get; set; }
        public Guid Id { get; set; }
        
        public Guid PaymentBillId { get; set; }
        

        public double Amount { get; set; }
        
        public DateTime PaymentTime { get; set; }
        
        public string WechatpayTradeNo { get; set; }
    }
}
