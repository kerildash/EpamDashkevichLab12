using System;
using System.Data.OleDb;
using EpamDashkevichLab12.Db;
using EpamDashkevichLab12.Ui;

namespace EpamDashkevichLab12
{
    class Program
    {
        static void Main(string[] args)
        {
            Cli cli = new Cli();

            cli.ShowDbAndMenu();

        }
    }
}
