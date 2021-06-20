using FootballPlayers.daos;
using FootballPlayers.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FootballPlayers
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            updateTables();
        }

        // заполнение таблиц
        private void updateTables()
        {
            updateForwardTable();
            updateMidfielderTable();
            updateDefenderTable();
        }

        // заполнение таблицы нападающих
        private void updateForwardTable()
        {
            // удаление текущих записей
            dataGridViewForward.Rows.Clear();

            // добавляем найденные в БД
            List<Forward> forwards = ForwardDAO.getAllForwards();
            for (int i = 0; i < forwards.Count; i++)
            {
                dataGridViewForward.Rows.Add(forwards[i].name, forwards[i].lastname, forwards[i].club, forwards[i].attacking, forwards[i].shooting, forwards[i].technical,
                    forwards[i].physical, forwards[i].speed, forwards[i].cost);
                dataGridViewForward.Rows[i].Selected = false;
            }
        }

        // заполнение таблицы полузащитников
        private void updateMidfielderTable()
        {
            // удаление текущих записей
            dataGridViewMidField.Rows.Clear();

            // добавляем найденные в БД
            List<Midfielder> midfielders = MidfielderDAO.getAllMidfielders();
            for (int i = 0; i < midfielders.Count; i++)
            {
                dataGridViewMidField.Rows.Add(midfielders[i].name, midfielders[i].lastname, midfielders[i].club, midfielders[i].dribbling, midfielders[i].pass, midfielders[i].technical,
                    midfielders[i].agility, midfielders[i].speed, midfielders[i].cost);
                dataGridViewMidField.Rows[i].Selected = false;
            }
        }

        // заполнение таблицы защитников
        private void updateDefenderTable()
        {
            // удаление текущих записей
            dataGridViewDefender.Rows.Clear();

            // добавляем найденные в БД
            List<Defender> defenders = DefenderDAO.getAllDefenders();
            for (int i = 0; i < defenders.Count; i++)
            {
                dataGridViewDefender.Rows.Add(defenders[i].name, defenders[i].lastname, defenders[i].club, defenders[i].heading, defenders[i].opeka, defenders[i].otbor,
                    defenders[i].strenght, defenders[i].speed, defenders[i].cost);
                dataGridViewDefender.Rows[i].Selected = false;
            }
        }


        // обновить таблицу нападающих по фильтрам
        private void updateForwardTableByTemplate()
        {
            dataGridViewForward.Rows.Clear();

            // получаем значения фильтров
            string name = textBoxFName.Text.Trim();
            string lastname = textBoxFLastname.Text.Trim();
            string club = textBoxFClub.Text.Trim();
            string attacking = textBoxFAttacking.Text.Trim();
            string shooting = textBoxFShooting.Text.Trim();
            string technical = textBoxFTechnical.Text.Trim();
            string physical = textBoxFPhysical.Text.Trim();
            string speed = textBoxFSpeed.Text.Trim();
            string cost = textBoxFCost.Text.Trim();

            try
            {
                // попытка поиска игроков
                List<Forward> forwards = ForwardDAO.getForwardsByTemplate(name.Length > 0 ? name : null, lastname.Length > 0 ? lastname : null, club.Length > 0 ? club : null,
                    attacking.Length > 0 ? int.Parse(attacking) : 0, shooting.Length > 0 ? int.Parse(shooting) : 0, technical.Length > 0 ? int.Parse(technical) : 0,
                    physical.Length > 0 ? int.Parse(physical) : 0, speed.Length > 0 ? int.Parse(speed) : 0, cost.Length > 0 ? int.Parse(cost) : -1);
                for (int i = 0; i < forwards.Count; i++)
                {
                    dataGridViewForward.Rows.Add(forwards[i].name, forwards[i].lastname, forwards[i].club, forwards[i].attacking, forwards[i].shooting, forwards[i].technical,
                        forwards[i].physical, forwards[i].speed, forwards[i].cost);
                    dataGridViewForward.Rows[i].Selected = false;
                }
            }
            catch (Exception e) { MessageBox.Show("Некорректно заданы числовые значения."); }
        }

        // обновить таблицу полузащитников по фильтрам
        private void updateMidfielderTableByTemplate()
        {
            dataGridViewMidField.Rows.Clear();

            // получаем значения фильтров
            string name = textBoxMName.Text.Trim();
            string lastname = textBoxMLastname.Text.Trim();
            string club = textBoxMClub.Text.Trim();
            string dribbling = textBoxMDribbling.Text.Trim();
            string pass = textBoxMPass.Text.Trim();
            string technical = textBoxMTechnical.Text.Trim();
            string agility = textBoxMAgility.Text.Trim();
            string speed = textBoxMSpeed.Text.Trim();
            string cost = textBoxMCost.Text.Trim();

            try
            {
                // попытка поиска игроков
                List<Midfielder> midfielders = MidfielderDAO.getMidfieldersByTemplate(name.Length > 0 ? name : null, lastname.Length > 0 ? lastname : null, club.Length > 0 ? club : null,
                    dribbling.Length > 0 ? int.Parse(dribbling) : 0, pass.Length > 0 ? int.Parse(pass) : 0, technical.Length > 0 ? int.Parse(technical) : 0,
                    agility.Length > 0 ? int.Parse(agility) : 0, speed.Length > 0 ? int.Parse(speed) : 0, cost.Length > 0 ? int.Parse(cost) : -1);
                for (int i = 0; i < midfielders.Count; i++)
                {
                    dataGridViewMidField.Rows.Add(midfielders[i].name, midfielders[i].lastname, midfielders[i].club, midfielders[i].dribbling, midfielders[i].pass, midfielders[i].technical,
                        midfielders[i].agility, midfielders[i].speed, midfielders[i].cost);
                    dataGridViewMidField.Rows[i].Selected = false;
                }
            }
            catch (Exception e) { MessageBox.Show("Некорректно заданы числовые значения."); }
        }

        // обновить таблицу защитников по фильтрам
        private void updateDefenderTableByTemplate()
        {
            dataGridViewDefender.Rows.Clear();

            // получаем значения фильтров
            string name = textBoxDName.Text.Trim();
            string lastname = textBoxDLastname.Text.Trim();
            string club = textBoxDClub.Text.Trim();
            string heading = textBoxDHeading.Text.Trim();
            string opeka = textBoxDOpeka.Text.Trim();
            string otbor = textBoxDOtbor.Text.Trim();
            string strenght = textBoxDStrenght.Text.Trim();
            string speed = textBoxDSpeed.Text.Trim();
            string cost = textBoxDCost.Text.Trim();

            try
            {
                // попытка поиска игроков
                List<Defender> defenders = DefenderDAO.getDefendersByTemplate(name.Length > 0 ? name : null, lastname.Length > 0 ? lastname : null, club.Length > 0 ? club : null,
                    heading.Length > 0 ? int.Parse(heading) : 0, opeka.Length > 0 ? int.Parse(opeka) : 0, otbor.Length > 0 ? int.Parse(otbor) : 0,
                    strenght.Length > 0 ? int.Parse(strenght) : 0, speed.Length > 0 ? int.Parse(speed) : 0, cost.Length > 0 ? int.Parse(cost) : -1);
                for (int i = 0; i < defenders.Count; i++)
                {
                    dataGridViewDefender.Rows.Add(defenders[i].name, defenders[i].lastname, defenders[i].club, defenders[i].heading, defenders[i].opeka, defenders[i].otbor,
                        defenders[i].strenght, defenders[i].speed, defenders[i].cost);
                    dataGridViewDefender.Rows[i].Selected = false;
                }
            }
            catch (Exception e) { MessageBox.Show("Некорректно заданы числовые значения."); }
        }

        private void textBoxFName_TextChanged(object sender, EventArgs e)
        {
            updateForwardTableByTemplate();
        }

        private void textBoxFLastname_TextChanged(object sender, EventArgs e)
        {
            updateForwardTableByTemplate();
        }

        private void textBoxFClub_TextChanged(object sender, EventArgs e)
        {
            updateForwardTableByTemplate();
        }

        private void textBoxFAttacking_TextChanged(object sender, EventArgs e)
        {
            updateForwardTableByTemplate();
        }

        private void textBoxFShooting_TextChanged(object sender, EventArgs e)
        {
            updateForwardTableByTemplate();
        }

        private void textBoxFTechnical_TextChanged(object sender, EventArgs e)
        {
            updateForwardTableByTemplate();
        }

        private void textBoxFPhysical_TextChanged(object sender, EventArgs e)
        {
            updateForwardTableByTemplate();
        }

        private void textBoxFSpeed_TextChanged(object sender, EventArgs e)
        {
            updateForwardTableByTemplate();
        }

        private void textBoxFCost_TextChanged(object sender, EventArgs e)
        {
            updateForwardTableByTemplate();
        }

        private void textBoxFAttacking_KeyPress(object sender, KeyPressEventArgs e)
        {
            isNumber(e);
        }

        private void textBoxFShooting_KeyPress(object sender, KeyPressEventArgs e)
        {
            isNumber(e);
        }

        private void textBoxFTechnical_KeyPress(object sender, KeyPressEventArgs e)
        {
            isNumber(e);
        }

        private void textBoxFPhysical_KeyPress(object sender, KeyPressEventArgs e)
        {
            isNumber(e);
        }

        private void textBoxFSpeed_KeyPress(object sender, KeyPressEventArgs e)
        {
            isNumber(e);
        }

        private void textBoxFCost_KeyPress(object sender, KeyPressEventArgs e)
        {
            isNumber(e);
        }

        // Проверка на ввод цифры + backspace в поля с цифровыми значениями
        private static void isNumber(KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
            }
        }

        private void textBoxMName_TextChanged(object sender, EventArgs e)
        {
            updateMidfielderTableByTemplate();
        }

        private void textBoxMLastname_TextChanged(object sender, EventArgs e)
        {
            updateMidfielderTableByTemplate();
        }

        private void textBoxMClub_TextChanged(object sender, EventArgs e)
        {
            updateMidfielderTableByTemplate();
        }

        private void textBoxMDribbling_TextChanged(object sender, EventArgs e)
        {
            updateMidfielderTableByTemplate();
        }

        private void textBoxMPass_TextChanged(object sender, EventArgs e)
        {
            updateMidfielderTableByTemplate();
        }

        private void textBoxMTechnical_TextChanged(object sender, EventArgs e)
        {
            updateMidfielderTableByTemplate();
        }

        private void textBoxMAgility_TextChanged(object sender, EventArgs e)
        {
            updateMidfielderTableByTemplate();
        }

        private void textBoxMSpeed_TextChanged(object sender, EventArgs e)
        {
            updateMidfielderTableByTemplate();
        }

        private void textBoxMCost_TextChanged(object sender, EventArgs e)
        {
            updateMidfielderTableByTemplate();
        }

        private void textBoxMDribbling_KeyPress(object sender, KeyPressEventArgs e)
        {
            isNumber(e);
        }

        private void textBoxMPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            isNumber(e);
        }

        private void textBoxMTechnical_KeyPress(object sender, KeyPressEventArgs e)
        {
            isNumber(e);
        }

        private void textBoxMAgility_KeyPress(object sender, KeyPressEventArgs e)
        {
            isNumber(e);
        }

        private void textBoxMSpeed_KeyPress(object sender, KeyPressEventArgs e)
        {
            isNumber(e);
        }

        private void textBoxMCost_KeyPress(object sender, KeyPressEventArgs e)
        {
            isNumber(e);
        }

        private void textBoxDName_TextChanged(object sender, EventArgs e)
        {
            updateDefenderTableByTemplate();
        }

        private void textBoxDLastname_TextChanged(object sender, EventArgs e)
        {
            updateDefenderTableByTemplate();
        }

        private void textBoxDClub_TextChanged(object sender, EventArgs e)
        {
            updateDefenderTableByTemplate();
        }

        private void textBoxDHeading_TextChanged(object sender, EventArgs e)
        {
            updateDefenderTableByTemplate();
        }

        private void textBoxDOpeka_TextChanged(object sender, EventArgs e)
        {
            updateDefenderTableByTemplate();
        }

        private void textBoxDOtbor_TextChanged(object sender, EventArgs e)
        {
            updateDefenderTableByTemplate();
        }

        private void textBoxDStrenght_TextChanged(object sender, EventArgs e)
        {
            updateDefenderTableByTemplate();
        }

        private void textBoxDSpeed_TextChanged(object sender, EventArgs e)
        {
            updateDefenderTableByTemplate();
        }

        private void textBoxDCost_TextChanged(object sender, EventArgs e)
        {
            updateDefenderTableByTemplate();
        }

        private void textBoxDHeading_KeyPress(object sender, KeyPressEventArgs e)
        {
            isNumber(e);
        }

        private void textBoxDOpeka_KeyPress(object sender, KeyPressEventArgs e)
        {
            isNumber(e);
        }

        private void textBoxDOtbor_KeyPress(object sender, KeyPressEventArgs e)
        {
            isNumber(e);
        }

        private void textBoxDStrenght_KeyPress(object sender, KeyPressEventArgs e)
        {
            isNumber(e);
        }

        private void textBoxDSpeed_KeyPress(object sender, KeyPressEventArgs e)
        {
            isNumber(e);
        }

        private void textBoxDCost_KeyPress(object sender, KeyPressEventArgs e)
        {
            isNumber(e);
        }

        private void buttonFFindBest_Click(object sender, EventArgs e)
        {
            // получаем значения фильтров
            string name = textBoxFName.Text.Trim();
            string lastname = textBoxFLastname.Text.Trim();
            string club = textBoxFClub.Text.Trim();
            string attacking = textBoxFAttacking.Text.Trim();
            string shooting = textBoxFShooting.Text.Trim();
            string technical = textBoxFTechnical.Text.Trim();
            string physical = textBoxFPhysical.Text.Trim();
            string speed = textBoxFSpeed.Text.Trim();
            string cost = textBoxFCost.Text.Trim();

            try
            {
                // попытка поиска игроков
                Forward bestForward = ForwardDAO.getBestForwardByTemplate(name.Length > 0 ? name : null, lastname.Length > 0 ? lastname : null, club.Length > 0 ? club : null,
                    attacking.Length > 0 ? int.Parse(attacking) : 0, shooting.Length > 0 ? int.Parse(shooting) : 0, technical.Length > 0 ? int.Parse(technical) : 0,
                    physical.Length > 0 ? int.Parse(physical) : 0, speed.Length > 0 ? int.Parse(speed) : 0, cost.Length > 0 ? int.Parse(cost) : -1);

                if (bestForward == null)
                {
                    MessageBox.Show("По найденным фильтрам лучший игрок не найден");
                }
                else
                {
                    MessageBox.Show("Лучший игрок - " + bestForward.name + " " + bestForward.lastname);
                }

            }
            catch (Exception ex) { MessageBox.Show("Некорректно заданы числовые значения."); }
        }

        private void buttonMFindBest_Click(object sender, EventArgs e)
        {
            // получаем значения фильтров
            string name = textBoxMName.Text.Trim();
            string lastname = textBoxMLastname.Text.Trim();
            string club = textBoxMClub.Text.Trim();
            string dribbling = textBoxMDribbling.Text.Trim();
            string pass = textBoxMPass.Text.Trim();
            string technical = textBoxMTechnical.Text.Trim();
            string agility = textBoxMAgility.Text.Trim();
            string speed = textBoxMSpeed.Text.Trim();
            string cost = textBoxMCost.Text.Trim();

            try
            {
                // попытка поиска игроков
                Midfielder bestMidfielder= MidfielderDAO.getBestMidfielderdByTemplate(name.Length > 0 ? name : null, lastname.Length > 0 ? lastname : null, club.Length > 0 ? club : null,
                    dribbling.Length > 0 ? int.Parse(dribbling) : 0, pass.Length > 0 ? int.Parse(pass) : 0, technical.Length > 0 ? int.Parse(technical) : 0,
                    agility.Length > 0 ? int.Parse(agility) : 0, speed.Length > 0 ? int.Parse(speed) : 0, cost.Length > 0 ? int.Parse(cost) : -1);

                if (bestMidfielder == null)
                {
                    MessageBox.Show("По найденным фильтрам лучший игрок не найден");
                }
                else
                {
                    MessageBox.Show("Лучший игрок - " + bestMidfielder.name + " " + bestMidfielder.lastname);
                }
            }
            catch (Exception ex) { MessageBox.Show("Некорректно заданы числовые значения."); }
        }

        private void buttonDFindBest_Click(object sender, EventArgs e)
        {
            // получаем значения фильтров
            string name = textBoxDName.Text.Trim();
            string lastname = textBoxDLastname.Text.Trim();
            string club = textBoxDClub.Text.Trim();
            string heading = textBoxDHeading.Text.Trim();
            string opeka = textBoxDOpeka.Text.Trim();
            string otbor = textBoxDOtbor.Text.Trim();
            string strenght = textBoxDStrenght.Text.Trim();
            string speed = textBoxDSpeed.Text.Trim();
            string cost = textBoxDCost.Text.Trim();

            try
            {
                // попытка поиска игроков
                Defender bestDefender= DefenderDAO.getBestDefenderByTemplate(name.Length > 0 ? name : null, lastname.Length > 0 ? lastname : null, club.Length > 0 ? club : null,
                    heading.Length > 0 ? int.Parse(heading) : 0, opeka.Length > 0 ? int.Parse(opeka) : 0, otbor.Length > 0 ? int.Parse(otbor) : 0,
                    strenght.Length > 0 ? int.Parse(strenght) : 0, speed.Length > 0 ? int.Parse(speed) : 0, cost.Length > 0 ? int.Parse(cost) : -1);

                if (bestDefender == null)
                {
                    MessageBox.Show("По найденным фильтрам лучший игрок не найден");
                }
                else
                {
                    MessageBox.Show("Лучший игрок - " + bestDefender.name + " " + bestDefender.lastname);
                }
            }
            catch (Exception ex) { MessageBox.Show("Некорректно заданы числовые значения."); }
        }
    }
}
