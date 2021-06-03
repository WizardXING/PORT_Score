using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PORT_Score
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public int score = 0;
        public String risk = "";
        public String disposition = "";
        public int score_pre = 0;
        private void btn_submit_Click(object sender, EventArgs e)
        {
            // 初始化属性
            // 1 is Yes
            // 0 is No

            // 获取病人数据
            int age = Convert.ToInt32(tb_age.Text);

            score += age;

            //  Gender
            if (rb_female.Checked == true)
            {
                score -= 10;
            }
            else
            {
                score += 0;
            }

            //  Nursing home resident
            if (rb_nhr_yes.Checked == true)
            {
                score += 10;
            }
            else
            {
                score += 0;
            }

            //  Neoplastic disease
            if (rb_nd_yes.Checked == true)
            {
                score += 30;
            }
            else
            {
                score += 0;
            }

            //  Chronic liver disease
            if (rb_cld_yes.Checked == true)
            {
                score += 20;
            }
            else
            {
                score += 0;
            }

            //  Congestive heart failure
            if (rb_chf_yes.Checked == true)
            {
                score += 10;
            }
            else
            {
                score += 0;
            }

            //  Cerebrovascular disease
            if (rb_cd_yes.Checked == true)
            {
                score += 10;
            }
            else
            {
                score += 0;
            }

            //  Chronic renal disease
            if (rb_crd_yes.Checked == true)
            {
                score += 10;
            }
            else
            {
                score += 0;
            }

            //  Altered mental status
            if (rb_ams_yes.Checked == true)
            {
                score += 20;
            }
            else
            {
                score += 0;
            }

            //  Respiratory Rate
            if (rb_rr_big30.Checked == true)
            {
                score += 20;
            }
            else
            {
                score += 0;
            }

            //  Systollic Blood Pressure
            if (rb_sbp_big90.Checked == true)
            {
                score += 0;
            }
            else
            {
                score += 20;
            }

            //  Temperature
            if (rb_t_big40.Checked == true)
            {
                score += 15;
            }


            if (rb_t_mid.Checked == true)
            {
                score += 0;
            }


            if (rb_t_small35.Checked == true)
            {
                score += 15;
            }

            //  Heart Rate
            if (rb_hr_big125.Checked == true)
            {
                score += 10;
            }
            else
            {
                score += 0;
            }

            //  pH
            if (rb_ph_big735.Checked == true)
            {
                score += 0;
            }
            else
            {
                score += 30;
            }

            //  Blood Urea Nitrogen
            if (rb_bun_big11.Checked == true)
            {
                score += 20;
            }
            else
            {
                score += 0;
            }

            //  Sodium Level
            if (rb_sl_big130.Checked == true)
            {
                score += 0;
            }
            else
            {
                score += 20;
            }

            //  Glucose Level
            if (rb_gl_big14.Checked == true)
            {
                score += 10;
            }
            else
            {
                score += 0;
            }

            //  Hematrocrit
            if (rb_h_big30.Checked == true)
            {
                score += 0;
            }
            else
            {
                score += 10;
            }

            //  PaO₂
            if (rb_p_big8.Checked == true)
            {
                score += 0;
            }
            else
            {
                score += 10;
            }

            //   Pleural Effusion
            if (rb_pe_yes.Checked == true)
            {
                score += 10;
            }
            else
            {
                score += 0;
            }


            if (score <= 70)
            {
                risk = "Low risk";
                disposition = "Outpatient care";
            }
            else if (score >= 71 && score <= 90)
            {
                risk = "Low risk";
                disposition = "Outpatient vs. Observation admission";
            }
            else if (score >= 91 && score <= 130)
            {
                risk = "Moderate risk";
                disposition = "Inpatient admission";
            }
            else if (score > 130)
            {
                risk = "High risk";
                disposition = "Inpatient admission";
            }

            score_pre = score;
            score = 0;
            MessageBox.Show(string.Format("Score:{0}\rRisk:{1}\rDisposition{2}", score_pre.ToString(), risk, disposition));
        }
    }
}
