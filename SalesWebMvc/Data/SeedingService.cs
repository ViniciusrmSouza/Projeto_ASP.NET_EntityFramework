﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMvc.Models;
using SalesWebMvc.Models.Enums;

namespace SalesWebMvc.Data
{
    public class SeedingService
    {
        private SalesWebMvcContext _context;

        public SeedingService(SalesWebMvcContext context)//injeção de dependencia
        {
            _context = context;
        }

        public void Seed()
        {
            //caso o banco de dados estiver populado
            if (_context.Departament.Any() || _context.Saller.Any() || _context.SalesRecord.Any())
            {
                return;
            }

            Departament d1 = new Departament(1, "Computer");
            Departament d2 = new Departament(2, "Electronics");
            Departament d3 = new Departament(3, "Tools");
            Departament d4 = new Departament(4, "Books");

            Saller s1 = new Saller(1, "Vinicius", "viniciusrmsouza577@gmail.com", new DateTime(2003, 1, 18), 1000, d1);
            Saller s2 = new Saller(2, "Roberto", "rmsouza577@gmail.com", new DateTime(2002, 2, 17), 800, d2);
            Saller s3 = new Saller(3, "Matias", "msouza577@gmail.com", new DateTime(2001, 3, 16), 900, d3);
            Saller s4 = new Saller(4, "Souza", "souza577@gmail.com", new DateTime(2000, 4, 15), 850, d4);
            Saller s5 = new Saller(5, "Rafael", "rafa577@gmail.com", new DateTime(2001, 4, 15), 920, d2);

            SalesRecord sr1 = new SalesRecord(1, new DateTime(2021, 09, 3), 11000, SaleStatus.Billed, s1);
            SalesRecord sr2 = new SalesRecord(2, new DateTime(2021, 09, 4), 7000.0, SaleStatus.Billed, s5);
            SalesRecord sr3 = new SalesRecord(3, new DateTime(2021, 09, 13), 4000.0, SaleStatus.Canceled, s4);
            SalesRecord sr4 = new SalesRecord(4, new DateTime(2021, 09, 1), 8000.0, SaleStatus.Billed, s1);
            SalesRecord sr5 = new SalesRecord(5, new DateTime(2021, 09, 21), 3000.0, SaleStatus.Billed, s3);
            SalesRecord sr6 = new SalesRecord(6, new DateTime(2021, 09, 15), 2000.0, SaleStatus.Billed, s1);
            SalesRecord sr7 = new SalesRecord(7, new DateTime(2021, 09, 28), 13000.0, SaleStatus.Billed, s2);
            SalesRecord sr8 = new SalesRecord(8, new DateTime(2021, 09, 11), 4000.0, SaleStatus.Billed, s4);
            SalesRecord sr9 = new SalesRecord(9, new DateTime(2021, 09, 14), 11000.0, SaleStatus.Pending, s1);
            SalesRecord sr10 = new SalesRecord(10, new DateTime(2021, 09, 7), 9000.0, SaleStatus.Billed, s3);
            SalesRecord sr11 = new SalesRecord(11, new DateTime(2021, 09, 13), 6000.0, SaleStatus.Billed, s2);
            SalesRecord sr12 = new SalesRecord(12, new DateTime(2021, 09, 25), 7000.0, SaleStatus.Pending, s3);
            SalesRecord sr13 = new SalesRecord(13, new DateTime(2021, 09, 29), 10000.0, SaleStatus.Billed, s4);
            SalesRecord sr14 = new SalesRecord(14, new DateTime(2021, 09, 4), 3000.0, SaleStatus.Billed, s5);
            SalesRecord sr15 = new SalesRecord(15, new DateTime(2021, 09, 12), 4000.0, SaleStatus.Billed, s1);
            SalesRecord sr16 = new SalesRecord(16, new DateTime(2021, 10, 5), 2000.0, SaleStatus.Billed, s4);
            SalesRecord sr17 = new SalesRecord(17, new DateTime(2021, 10, 1), 12000.0, SaleStatus.Billed, s1);
            SalesRecord sr18 = new SalesRecord(18, new DateTime(2021, 10, 24), 6000.0, SaleStatus.Billed, s3);
            SalesRecord sr19 = new SalesRecord(19, new DateTime(2021, 10, 22), 8000.0, SaleStatus.Billed, s5);
            SalesRecord sr20 = new SalesRecord(20, new DateTime(2021, 10, 15), 8000.0, SaleStatus.Billed, s4);
            SalesRecord sr21 = new SalesRecord(21, new DateTime(2021, 10, 17), 9000.0, SaleStatus.Billed, s2);
            SalesRecord sr22 = new SalesRecord(22, new DateTime(2021, 10, 24), 4000.0, SaleStatus.Billed, s4);
            SalesRecord sr23 = new SalesRecord(23, new DateTime(2021, 10, 19), 11000.0, SaleStatus.Canceled, s2);
            SalesRecord sr24 = new SalesRecord(24, new DateTime(2021, 10, 12), 8000.0, SaleStatus.Billed, s5);
            SalesRecord sr25 = new SalesRecord(25, new DateTime(2021, 10, 31), 7000.0, SaleStatus.Billed, s3);
            SalesRecord sr26 = new SalesRecord(26, new DateTime(2021, 10, 6), 5000.0, SaleStatus.Billed, s4);
            SalesRecord sr27 = new SalesRecord(27, new DateTime(2021, 10, 13), 9000.0, SaleStatus.Pending, s1);
            SalesRecord sr28 = new SalesRecord(28, new DateTime(2021, 10, 7), 4000.0, SaleStatus.Billed, s3);
            SalesRecord sr29 = new SalesRecord(29, new DateTime(2021, 10, 23), 12000.0, SaleStatus.Billed, s5);
            SalesRecord sr30 = new SalesRecord(30, new DateTime(2021, 10, 12), 5000.0, SaleStatus.Billed, s2);

            _context.Departament.AddRange(d1, d2, d3, d4);
            _context.Saller.AddRange(s1, s2, s3, s4, s5);
            _context.SalesRecord.AddRange(sr1, sr2, sr3, sr4, sr5, sr6, sr7, sr8, sr9, sr10, sr11, sr12, sr13, sr14, sr15, sr16, sr17, sr18, sr19, sr20,
                sr21, sr22, sr23, sr24, sr25, sr26, sr27, sr28, sr29, sr30);

            _context.SaveChanges();
        }
    }
}
