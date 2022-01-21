using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BinarySearchDemo
{
    public partial class BinarySearchForm : Form
    {
        private const int size = 20;
        private int[] dataSet = new int[size];

        private int binarySearch(int wanted)
        {
            int mid = 0;
            int start = 0;
            int end = dataSet.Length - 1;
            bool found = false;
            bool allListSearched = false;

            while (!found && ! allListSearched)
            {
                mid = (start + end) / 2;

                if (dataSet[mid] == wanted )
                {
                    found = true;
                }
                else if (start > end)
                {
                    allListSearched = true;
                }
                else if(wanted < dataSet[mid])
                {
                    end = mid - 1;
                }
                else
                {
                    start = mid + 1;
                }
            }
            if (found)
            {
                return (mid);
            }
            else
            {
                return -1;
            }
        }

        private void generateData()
        {
            int i;
            Random generator = new Random();
            for (i=0; i < size; i++)
            {
                dataSet[i] = generator.Next(1, 999);
            }
            Array.Sort(dataSet);
        }

        private void displayDataSet()
        {
            int i;
            lstData.Items.Clear();
            for(i = 0; i < size; i++)
            {
                lstData.Items.Add("[" + Convert.ToInt32(i) + "] = " + Convert.ToInt32(dataSet[i]));
            }
        }


        public BinarySearchForm()
        {
            InitializeComponent();
        }

        private void BinarySearchForm_Load(object sender, EventArgs e)
        {

        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            generateData();
            displayDataSet();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            txtPositionOfValue.Text = Convert.ToString(binarySearch(Convert.ToInt32(txtNumberToFind.Text)));
        }
    }
}
