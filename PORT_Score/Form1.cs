using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
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
        public String language = "English";
        public int ValidateTimes = 0;
        public String PSIclass = "";
        public double Mortality = 0.0;
        private void btn_submit_Click(object sender, EventArgs e)
        {
            // 初始化属性
            // 1 is Yes
            // 0 is No

            if (ValidateInput())
            {
                CalculateScore();
            }
        }

        private Boolean ValidateInput()
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(tb_age.Text, @"^[1-9]\d*$"))
            {
                MessageBox.Show("请输入一个有效的正整数作为年龄。", "输入错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false; // 退出方法
            }

            //判断各个选项是否填上
            if (rb_female.Checked == true || rb_male.Checked == true)
            {
                ValidateTimes++;
            }
            if (rb_nhr_yes.Checked == true || rb_nhr_no.Checked == true)
            {
                ValidateTimes++;
            }
            if (rb_crd_no.Checked == true || rb_crd_yes.Checked == true)
            {
                ValidateTimes++;
            }
            if (rb_cd_no.Checked == true || rb_cd_yes.Checked == true)
            {
                ValidateTimes++;
            }
            if (rb_chf_no.Checked == true || rb_chf_yes.Checked == true)
            {
                ValidateTimes++;
            }
            if (rb_cld_no.Checked == true || rb_cld_yes.Checked == true)
            {
                ValidateTimes++;
            }
            if (rb_nd_no.Checked == true || rb_nd_yes.Checked == true)
            {
                ValidateTimes++;
            }
            if (rb_ams_no.Checked == true || rb_ams_yes.Checked == true)
            {
                ValidateTimes++;
            }
            if (rb_rr_small30.Checked == true || rb_rr_big30.Checked == true)
            {
                ValidateTimes++;
            }
            if (rb_sbp_small90.Checked == true || rb_sbp_big90.Checked == true)
            {
                ValidateTimes++;
            }
            if (rb_t_big40.Checked == true || rb_t_mid.Checked == true || rb_t_small35.Checked == true)
            {
                ValidateTimes++;
            }
            if (rb_hr_big125.Checked == true || rb_hr_small125.Checked == true)
            {
                ValidateTimes++;
            }
            if (rb_ph_small735.Checked == true || rb_ph_big735.Checked == true)
            {
                ValidateTimes++;
            }
            if (rb_bun_big11.Checked == true || rb_bun_small11.Checked == true)
            {
                ValidateTimes++;
            }
            if (rb_h_big30.Checked == true || rb_h_small30.Checked == true)
            {
                ValidateTimes++;
            }
            if (rb_gl_big14.Checked == true || rb_gl_small14.Checked == true)
            {
                ValidateTimes++;
            }
            if (rb_sl_big130.Checked == true || rb_sl_small130.Checked == true)
            {
                ValidateTimes++;
            }
            if (rb_p_big8.Checked == true || rb_p_small8.Checked == true)
            {
                ValidateTimes++;
            }
            if (rb_pe_no.Checked == true || rb_pe_yes.Checked == true)
            {
                ValidateTimes++;
            }

            if (ValidateTimes < 19) 
            {
                
                MessageBox.Show("有未填的选项，请继续填写。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ValidateTimes = 0;
                return false; // 退出方法
            }
            ValidateTimes = 0;
            return true;
        }

        private void CalculateScore()
        {
            int age = Convert.ToInt32(tb_age.Text);
            score += age;

            bool specialKind = true;

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
                specialKind = false;
                score += 10;
            }
            else
            {
                score += 0;
            }

            //  Neoplastic disease
            if (rb_nd_yes.Checked == true)
            {
                specialKind = false;
                score += 30;
            }
            else
            {
                score += 0;
            }

            //  Chronic liver disease
            if (rb_cld_yes.Checked == true)
            {
                specialKind = false;
                score += 20;
            }
            else
            {
                score += 0;
            }

            //  Congestive heart failure
            if (rb_chf_yes.Checked == true)
            {
                specialKind = false;
                score += 10;
            }
            else
            {
                score += 0;
            }

            //  Cerebrovascular disease
            if (rb_cd_yes.Checked == true)
            {
                specialKind = false;
                score += 10;
            }
            else
            {
                score += 0;
            }

            //  Chronic renal disease
            if (rb_crd_yes.Checked == true)
            {
                specialKind = false;
                score += 10;
            }
            else
            {
                score += 0;
            }

            //  Altered mental status
            if (rb_ams_yes.Checked == true)
            {
                specialKind = false;
                score += 20;
            }
            else
            {
                score += 0;
            }

            //  Respiratory Rate
            if (rb_rr_big30.Checked == true)
            {
                specialKind = false;
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
                specialKind = false;
                score += 20;
            }

            //  Temperature
            if (rb_t_big40.Checked == true)
            {
                specialKind = false;
                score += 15;
            }


            if (rb_t_mid.Checked == true)
            {
                score += 0;
            }


            if (rb_t_small35.Checked == true)
            {
                specialKind = false;
                score += 15;
            }

            //  Heart Rate
            if (rb_hr_big125.Checked == true)
            {
                specialKind = false;
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
                specialKind = false;
                score += 30;
            }

            //  Blood Urea Nitrogen
            if (rb_bun_big11.Checked == true)
            {
                specialKind = false;
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
                specialKind = false;
                score += 20;
            }

            //  Glucose Level
            if (rb_gl_big14.Checked == true)
            {
                specialKind = false;
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
                specialKind = false;
                score += 10;
            }

            //  PaO₂
            if (rb_p_big8.Checked == true)
            {
                score += 0;
            }
            else
            {
                specialKind = false;
                score += 10;
            }

            //   Pleural Effusion
            if (rb_pe_yes.Checked == true)
            {
                specialKind = false;
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
            if (score_pre <= 50)
            {
                if (specialKind)
                {
                    PSIclass = "Ⅰ";
                    Mortality = 0.1;
                }
                else
                {
                    PSIclass = "Ⅱ";
                    Mortality = 0.6;
                }
            }
            else if (score_pre > 51 && score_pre <= 70)
            {
                PSIclass = "Ⅱ";
                Mortality = 0.6;
            } 
            else if (score_pre > 70 && score_pre <= 90) {
                PSIclass = "Ⅲ";
                Mortality = 0.9;
            }
            else if (score_pre > 91 && score_pre <= 130)
            {
                PSIclass = "Ⅳ";
                Mortality = 9.3;
            }
            else
            {
                PSIclass = "Ⅴ";
                Mortality = 27.0;
            }
            MessageBox.Show(string.Format("Score: {0}\rRisk: {1}\rDisposition: {2}\rPSIclass: {3}\rMortality(percent): {4}", score_pre.ToString(), risk, disposition, PSIclass, Mortality));
        }

        private void toggleLanguage_Click(object sender, EventArgs e)
        {
            if (language == "Chinese")
            {
                toggleLanguage_toEN();
                language = "English";
                
            }
            else
            {
                toggleLanguage_toCN();
                language = "Chinese";
            }
        }

        private void toggleLanguage_toEN()
        {
            gender_label.Text = "gender";
            rb_female.Text = "female";
            rb_male.Text = "male";
            nhr_label.Text = "Nursing home resident";
            age_label.Text = "Age";
            nd_label.Text = "Neoplastic disease";
            cld_label.Text = "Chronic liver disease";
            chf_label.Text = "Congestive heart failure";
            cd_label.Text = "Cerebrovascular disease";
            crd_label.Text = "Chronic renal disease";
            ams_label.Text = "Altered mental status";
            rr_label.Text = "Respiratory Rate";
            sbp_label.Text = "Systollic Blood Pressure";
            t_label.Text = "Temperature";
            hr_label.Text = "Heart Rate";
            ph_label.Text = "      pH";
            bun_label.Text = "Blood Urea Nitrogen";
            sl_label.Text = "Sodium Level";
            gl_label.Text = "Glucose Level";
            h_label.Text = "Hematrocrit";
            p_label.Text = "         PaO₂";
            pe_label.Text = " Pleural Effusion";
            rb_nhr_no.Text = "no";
            rb_nhr_yes.Text = "yes";
            rb_crd_no.Text = "no";
            rb_crd_yes.Text = "yes";
            rb_cd_no.Text = "no";
            rb_cd_yes.Text = "yes";
            rb_chf_no.Text = "no";
            rb_chf_yes.Text = "yes";
            rb_cld_no.Text = "no";
            rb_cld_yes.Text = "yes";
            rb_nd_no.Text = "no";
            rb_nd_yes.Text = "yes";
            rb_ams_no.Text = "no";
            rb_ams_yes.Text = "yes";
            rb_pe_no.Text = "no";
            rb_pe_yes.Text = "yes";
            btn_submit.Text = "Calculate";
            btn_clear.Text = "Clear";
            HelpToolStripMenuItem.Text = "Help";
        }

        private void toggleLanguage_toCN()
        {
            gender_label.Text = "性别";
            rb_female.Text = "女性";
            rb_male.Text = "男性";
            nhr_label.Text = "养老院居民";
            age_label.Text = "年龄";
            nd_label.Text = "肿瘤疾病";
            cld_label.Text = "慢性肝病";
            chf_label.Text = "充血性心力衰竭";
            cd_label.Text = "脑血管疾病";
            crd_label.Text = "慢性肾病";
            ams_label.Text = "意识障碍";
            rr_label.Text = "呼吸频率";
            sbp_label.Text = "收缩压";
            t_label.Text = "体温";
            hr_label.Text = "心率";
            ph_label.Text = "   酸碱度";
            bun_label.Text = "血尿素氮";
            sl_label.Text = "血钠水平";
            gl_label.Text = "血糖水平";
            h_label.Text = " 血细胞比容";
            p_label.Text = "动脉血氧分压";
            pe_label.Text = "胸腔积液";
            rb_nhr_no.Text = "否";
            rb_nhr_yes.Text = "是";
            rb_crd_no.Text = "否";
            rb_crd_yes.Text = "是";
            rb_cd_no.Text = "否";
            rb_cd_yes.Text = "是";
            rb_chf_no.Text = "否";
            rb_chf_yes.Text = "是";
            rb_cld_no.Text = "否";
            rb_cld_yes.Text = "是";
            rb_nd_no.Text = "否";
            rb_nd_yes.Text = "是";
            rb_ams_no.Text = "否";
            rb_ams_yes.Text = "是";
            rb_pe_no.Text = "否";
            rb_pe_yes.Text = "是";
            btn_submit.Text = "确认";
            btn_clear.Text = "重置";
            HelpToolStripMenuItem.Text = "帮助";

            gender_label.TextAlign = ContentAlignment.MiddleRight;
            nhr_label.TextAlign = ContentAlignment.MiddleRight;
            age_label.TextAlign = ContentAlignment.MiddleRight;
            nd_label.TextAlign = ContentAlignment.MiddleRight;
            cld_label.TextAlign = ContentAlignment.MiddleRight;
            chf_label.TextAlign = ContentAlignment.MiddleRight;
            cd_label.TextAlign = ContentAlignment.MiddleRight;
            crd_label.TextAlign = ContentAlignment.MiddleRight;
            ams_label.TextAlign = ContentAlignment.MiddleRight;
            rr_label.TextAlign = ContentAlignment.MiddleRight;
            sbp_label.TextAlign = ContentAlignment.MiddleRight;
            t_label.TextAlign = ContentAlignment.MiddleRight;
            hr_label.TextAlign = ContentAlignment.MiddleRight;
            ph_label.TextAlign = ContentAlignment.MiddleRight;
            bun_label.TextAlign = ContentAlignment.MiddleRight;
            sl_label.TextAlign = ContentAlignment.MiddleRight;
            gl_label.TextAlign = ContentAlignment.MiddleRight;
            h_label.TextAlign = ContentAlignment.MiddleRight;
            p_label.TextAlign = ContentAlignment.MiddleRight;
            pe_label.TextAlign = ContentAlignment.MiddleRight;
        }

        private void HelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("更新记录\r1.增加对PSI级别和Mortality(percent)的计算\r2.对输入内容进行校验\r3.增加重置按键\r4.增加中英翻译\r--------------\r作者：xingjiawei", "帮助", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void ToggleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (language == "Chinese")
            {
                toggleLanguage_toEN();
                language = "English";

            }
            else
            {
                toggleLanguage_toCN();
                language = "Chinese";
            }
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            tb_age.Text="";
            rb_female.Checked = false;
            rb_male.Checked = false;
            rb_nhr_no.Checked = false;
            rb_nhr_yes.Checked = false;
            rb_crd_no.Checked = false;
            rb_crd_yes.Checked = false;
            rb_cd_no.Checked = false;
            rb_cd_yes.Checked = false;
            rb_chf_no.Checked = false;
            rb_chf_yes.Checked = false;
            rb_cld_no.Checked = false;
            rb_cld_yes.Checked = false;
            rb_nd_no.Checked = false;
            rb_nd_yes.Checked = false;
            rb_ams_no.Checked = false;
            rb_ams_yes.Checked = false;
            rb_rr_small30.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            rb_rr_big30.Checked = false;
            rb_sbp_small90.Checked = false;
            rb_sbp_big90.Checked = false;
            rb_t_big40.Checked = false;
            rb_t_mid.Checked = false;
            rb_t_small35.Checked = false;
            rb_hr_big125.Checked = false;
            rb_hr_small125.Checked = false;
            rb_ph_small735.Checked = false;
            rb_ph_big735.Checked = false;
            rb_bun_big11.Checked = false;
            rb_bun_small11.Checked = false;
            rb_h_big30.Checked = false;
            rb_h_small30.Checked = false;
            rb_gl_big14.Checked = false;
            rb_gl_small14.Checked = false;
            rb_sl_big130.Checked = false;
            rb_sl_small130.Checked = false;
            rb_p_big8.Checked = false;
            rb_p_small8.Checked = false;
            rb_pe_no.Checked = false;
            rb_pe_yes.Checked = false;

        }
    }
}
