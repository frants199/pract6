using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pr6_WinForm
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void count_TextChanged(object sender, EventArgs e)
		{
			Random rand = new Random();
			string str = "", arr="";
			int n = Convert.ToInt32(count.Text);
			try
			{
				if (n <= 0) throw new Exception("Недопустимый размер массива");
				else
				{
					int[] array = new int[n];

					for (int i = 0; i < n; i++)
					{
						array[i] = rand.Next(-100, 100);
						arr += $"array[{i}] = {array[i]}\n";
					}
					mas.Text = arr;
					for (int i = 0; i < n; i++)
					{
						if (array[i] % 7 != 0) str += i.ToString() + " ";
					}
					index.Text = str;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void calculate_button_Click(object sender, EventArgs e)
		{
			int n = Convert.ToInt32(n_box.Text);
			int m = Convert.ToInt32(m_box.Text);
			Random rand = new Random();
			string str="", arr = "";
			try
			{
				if (n <= 0 || m <= 0) throw new Exception("Недопустимый размер массива");
				else
				{
					int[,] mas = new int[n, m];
					for (int i = 0; i < n; i++, arr+="\n")
					{
						for (int j = 0; j < m; j++)
						{
							mas[i, j] = rand.Next(-100, 100);
							arr += $" {mas[i, j]} ";
						}
					}
					array_box.Text = arr;
					for (int i = 0; i < n; i++)
					{
						for (int j = 0; j < m; j++)
						{
							if (mas[i, j] % 7 != 0) str += "[" + i.ToString() + ", " + j.ToString() + "] ";
						}
					}
					index_matr.Text = str;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void count_KeyPress(object sender, KeyPressEventArgs e)
		{
			char symbol = e.KeyChar;
			if (!Char.IsDigit(symbol))
			{
				e.Handled = true;
			}
		}

		private void size_box_TextChanged(object sender, EventArgs e)
		{
			int n = Convert.ToInt32(size_box.Text);
			string str = "";
			try
			{
				if (n <= 0) throw new Exception("Некорректный размер массива");
				else
				{
					int[] array = new int[n];
					Random rand = new Random();
					for (int i = 0; i < n; i++)
					{
						array[i] = rand.Next(-5, 5);
						str += $"array[{i}] = {array[i]}\n";
					}
					arr_box.Text = str;
					if (array.Max() >= 0)
					{
						max_el_box.Text = array.Max().ToString();
					}
					else max_el_box.Text = "error";
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		private bool Symetric(int[,] a)
		{
			bool symm = true;
			for (int i = 0; i < a.GetLength(0); ++i)
			{
				for (int j = 0; j < a.GetLength(1); ++j)
					if (a[i, j] != a[j, i])
					{
						symm = false;
						break;
					}
				if (!symm) break;
			}
			return symm;
		}
		private void size3_box_TextChanged(object sender, EventArgs e)
		{
			int n = Convert.ToInt32(size3_box.Text);
			Random rand = new Random();
			string str = "";
			try
			{
				if (n <= 0) throw new Exception("Некорректный размер массива");
				else
				{
					int[,] array = new int[n, n];
					for (int i = 0; i < n; i++, str += "\n")
					{
						for (int j = 0; j < n; j++)
						{
							array[i, j] = rand.Next(-10, 10);
							str += $"{array[i, j]} ";
						}
					}
					array3_box.Text = str;
					symetric_box.Text = Symetric(array).ToString();
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		private int[][] Filling()
		{
			int n = Convert.ToInt32(size4_box.Text);
			try
			{
				if (n <= 0) throw new Exception("Некорректный размер массива");
			}
			catch
			{
				throw;
			}
			int[][] array = new int[n][];
			Random rand = new Random();
			for (int i = 0; i < n; ++i)
			{
				array[i] = new int[n];
				for (int j = 0; j < n; ++j)
				{
					array[i][j] = rand.Next(-20, 20);
				}
			}
			return array;
		}
		private void Print_array(int[][] array)
		{
			string str = "";
			for (int i = 0; i < array.Length; ++i, str += "\n")
				for (int j = 0; j < array[i].Length; ++j)
					str += $"{array[i][j]} ";
			array4_box.Text = str;
		}
		private int[] product(int[][] array, int index1, int index2)
		{
			int[] pr = new int[array.Length];
			for (int i = 0; i < pr.Length; i++)
			{
				pr[i] = 1;
			}
			for (int i = 0; i < array.Length; ++i)
			{
				for (int j = index1; j <= index2; ++j)
				{
					pr[i] *= array[j][i];
				}
			}
			return pr;
		}
		private void Print_result(int[] array)
		{
			string str = "";
			for (int i = 0; i < array.Length; i++)
			{
				str += $"{array[i]} ";
			}
			product_box.Text = str;
		}
		private void calculate4_box_Click(object sender, EventArgs e)
		{
			try
			{
				int[][] array = Filling();
				int ind1 = Convert.ToInt32(index1_box.Text);
				int ind2 = Convert.ToInt32(ind2_box.Text);
				if (ind1 < 0 || ind2 < 0 || ind1 > array.Length || ind2 > array.Length) throw new Exception("Выход за пределы массива");
				Print_array(array);
				Print_result(product(array, ind1, ind2));
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
	}
	
}
