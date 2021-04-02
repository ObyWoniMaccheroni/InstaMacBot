﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InstaMacBot.classi_MacBotClient
{
    abstract class SSSBot : StartStopBot
    {
        //OVERVIEW: this abstract class define a status bot -> a StartStopBot with status is_running

        protected bool status;
        protected TextBox tx_console;

        public bool is_running { get { return status; } }


        private async Task<bool> wait(int secondi)
        {
            int i = 0;
            while (i < secondi)
            {
                await Task.Delay(1000);
                i++;
            }
            return true;
        }

        public SSSBot(TextBox console = null)
        {
            status = false;
            if (console != null)
                tx_console = console;


        }

        protected void write_on_console(string output)
        {
            if (tx_console != null)
            {
                string s = tx_console.Text;
                tx_console.Text = output;
                tx_console.Text += Environment.NewLine;
                tx_console.Text += s;

            }
        }

        public abstract void start();
        public abstract void stop(bool save_infos);
        
    }
}
